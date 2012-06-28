namespace AndroidApplication1.Handlers
{
    using System.Linq;

    using AndroidApplication1.Model;
    using AndroidApplication1.Utils;

    using RestSharp;
    using RestSharp.Deserializers;

    public class GravatarHandler : HandData<GravEntry>.GivenA<TrelloOAuth>
    {
        public GravEntry GetData(TrelloOAuth proxy, string hash)
        {
            var apiClient = proxy.GetCustomRestClient("http://en.gravatar.com");

            //http://en.gravatar.com/ad9d845d326eba333689b6c1d5682752.json
            var request = new RestRequest(string.Format("/{0}.json", hash));
            var response = apiClient.Execute(request);

            var jsonDeserializer = new JsonDeserializer();

            var res = jsonDeserializer.Deserialize<Gravatar>(response);

            return res.entry.FirstOrDefault();
        }
    }
}