namespace AndroidApplication1.Handlers
{
    using AndroidApplication1.Model;
    using AndroidApplication1.Utils;

    using RestSharp;
    using RestSharp.Deserializers;

    internal class CardHandler : HandData<Card>.GivenA<TrelloOAuth>
    {
        public Card GetData(TrelloOAuth proxy, string idCard)
        {
            var apiClient = proxy.GetApiRestClient();

            //https://api.trello.com/1/cards/4fe20366df5c3cc66b1122d6?key=b0241095b86be629a129979be29fa6db&token=637b50a2b29fb3ff8497014c1d773de293a32968dd59e189026eeac6316f1fa0
            var request = new RestRequest(string.Format("/1/cards/{0}", idCard));
            request.AddParameter("key", TrelloOAuth.consumerKey);
            request.AddParameter("token", TrelloOAuth.client_token);
            var response = apiClient.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            return jsonDeserializer.Deserialize<Card>(response);
        }
    }
}