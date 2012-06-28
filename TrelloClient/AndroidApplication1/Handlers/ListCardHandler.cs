using System.Collections.Generic;

namespace AndroidApplication1.Handlers
{
    using AndroidApplication1.Model;
    using AndroidApplication1.Utils;

    using RestSharp;
    using RestSharp.Deserializers;

    internal class ListCardHandler : HandDataList<List<Card>>.GivenA<TrelloOAuth>

    {
        public List<Card> GetDataList(TrelloOAuth proxy, string idList)
        {
            var apiClient = proxy.GetApiRestClient();

            //https://api.trello.com/1/lists/4fe20366df5c3cc66b1122d6/cards?key=b0241095b86be629a129979be29fa6db&token=637b50a2b29fb3ff8497014c1d773de293a32968dd59e189026eeac6316f1fa0
            var request = new RestRequest(string.Format("/1/lists/{0}/cards", idList));
            request.AddParameter("key", TrelloOAuth.consumerKey);
            request.AddParameter("token", TrelloOAuth.client_token);
            var response = apiClient.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            return jsonDeserializer.Deserialize<List<Card>>(response);
        }
    }
}