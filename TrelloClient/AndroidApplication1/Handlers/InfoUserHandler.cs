namespace AndroidApplication1.Handlers
{
    using AndroidApplication1.Model;
    using AndroidApplication1.Utils;

    using RestSharp;
    using RestSharp.Deserializers;

    public class InfoUserHandler : HandData<InfoUser>.GivenA<TrelloOAuth>
    {
        public InfoUser GetData(TrelloOAuth proxy, string id)
        {
            var client = proxy.GetTrelloRestClient();
            var request = new RestRequest("/1/members/me");
            request.AddParameter("key", TrelloOAuth.consumerKey);
            request.AddParameter("token", TrelloOAuth.client_token);
            IRestResponse response = client.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            return jsonDeserializer.Deserialize<InfoUser>(response);
        }
    }
}