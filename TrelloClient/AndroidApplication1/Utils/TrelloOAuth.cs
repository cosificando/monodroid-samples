// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Autenticacion.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Autenticacion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AndroidApplication1.Utils
{
    using System;
    using System.Collections.Generic;

    using Android.App;
    using Android.Content;
    using Android.Preferences;

    using AndroidApplication1.Delegates;
    using AndroidApplication1.Model;

    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Contrib;
    using RestSharp.Deserializers;

    /// <summary>
    /// Trello API Core Class
    /// </summary>
    public class TrelloOAuth
    {
        private RestClient _client;

        private ISharedPreferences _settings = PreferenceManager.GetDefaultSharedPreferences(Application.Context);

        internal const string consumerKey = "<<CHANGE>>";

        internal const string consumerSecret = "<<CHANGE>>";

        private string _verifier = string.Empty;

        private const string _baseUrl = "https://trello.com";

        protected internal const string _apiBaseUrl = "https://api.trello.com";

        private string _oauth_token = string.Empty;

        private string _oauth_token_secret = string.Empty;

        internal static string client_token = string.Empty;

        public event Authenticated LoggedIn;

		public event AuthenticationFailed OAuthFailed;

		public event UrlObtained UrlReady;

        public TrelloOAuth()
        {
        }

        public List<Organization> OrganizationsUserBelongsTo { get; set; }

        public List<Board> BoardsUserIsMemberOf { get; set; }

        public InfoUser InfoUser { get; set; }

        public Uri Url { get; set; }
        
        public void GetOAuthToken()
        {
            this._client = new RestClient(_baseUrl)
            {
                Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret)
            };

			var request = new RestRequest("/1/OAuthGetRequestToken", Method.POST);

            var response = this._client.Execute(request);

            var qs = HttpUtility.ParseQueryString(response.Content);

            this._oauth_token = qs["oauth_token"];
            this._oauth_token_secret = qs["oauth_token_secret"];
        }

		public void Authenticate(bool loadVerifier)
		{
			if (loadVerifier)
			{
				LoadVerifier();

				if (string.IsNullOrEmpty (_verifier))
				{
				    this.GetAccessTokenUrl();
				}
			    else
				{
				    this.GetOAuthToken();
					this.Check ();
				}
			}
			else
			{
			    GetAccessTokenUrl();
			}
		}

        private void GetAccessTokenUrl()
        {
            this.GetOAuthToken();

            var sslClient = new RestClient(_baseUrl);
            var request = new RestRequest("/1/OAuthAuthorizeToken");
            request.AddParameter("oauth_token", this._oauth_token);
            request.AddParameter("oauth_consumer_key", consumerKey);
            request.AddParameter("application_name", "trello for android");
            request.AddParameter("oauth_callback", "http://desarrollomobile.net");
            this.Url = sslClient.BuildUri(request);

			if (UrlReady != null)
			{
				UrlReady();
			}

        }

        public void Check(string verifier)
        {
            var request = new RestRequest("/1/OAuthGetAccessToken"); 
            this._client.Authenticator = OAuth1Authenticator
                .ForAccessToken(consumerKey, consumerSecret, this._oauth_token, this._oauth_token_secret, verifier);
            var response = this._client.Execute(request);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
            	//https://trello.com/1/members/me?key=xx&token=substitutethispartwiththeauthorizationtokenthatyougotfromtheuser
            	var qs = HttpUtility.ParseQueryString(response.Content);

            	client_token = qs["oauth_token"];

                SaveVerifier(verifier);

            	this.GetUserInfo();
			}
			else
			{
				if (this.OAuthFailed != null)
            	{
					this.OAuthFailed();
            	}
			}
        }

        public void Check()
        {
            this.Check(this._verifier);
        }

        private void SaveVerifier(string verifier)
        {
            var editor = this._settings.Edit();
            editor.PutString("verifier", verifier);
            editor.Commit();
        }

        public void LoadVerifier()
        {
            _verifier = this._settings.GetString("verifier", null); 
        }

        public void GetUserInfo()
        {
            var request = new RestRequest("/1/members/me");
            request.AddParameter("key", consumerKey);
            request.AddParameter("token", client_token);
            IRestResponse response = this._client.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            this.InfoUser = jsonDeserializer.Deserialize<InfoUser>(response);

            if (this.LoggedIn != null)
            {
                this.LoggedIn(this.InfoUser);
            }
        }

        public void LoadOrganizations()
        {
            //https://trello.com/1/members/my/organizations?key=b0241095b86be629a129979be29fa6db&token=637b50a2b29fb3ff8497014c1d773de293a32968dd59e189026eeac6316f1fa0
            var request = new RestRequest("/1/members/my/organizations");
            request.AddParameter("key", consumerKey);
            request.AddParameter("token", client_token);
            var response = this._client.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            this.OrganizationsUserBelongsTo = jsonDeserializer.Deserialize<List<Organization>>(response);
        }

        public void LoadBoardsUserIsMemberOf()
        {
            //https://trello.com/1/members/my/boards?key=b0241095b86be629a129979be29fa6db&token=637b50a2b29fb3ff8497014c1d773de293a32968dd59e189026eeac6316f1fa0
            var request = new RestRequest("/1/members/my/boards");
            request.AddParameter("key", consumerKey);
            request.AddParameter("token", client_token);
            var response = this._client.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            this.BoardsUserIsMemberOf = jsonDeserializer.Deserialize<List<Board>>(response);
        }

        public void ForceLogout()
        {
            this.SaveVerifier(string.Empty);
        }

        public RestClient GetApiRestClient()
        {
            return new RestClient(_apiBaseUrl)
            {
                Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret)
            };
        }

        public RestClient GetCustomRestClient(string url)
        {
            return new RestClient(url);
        }

        public RestClient GetTrelloRestClient()
        {
            return new RestClient(_baseUrl)
            {
                Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret)
            };

        }
    }
}