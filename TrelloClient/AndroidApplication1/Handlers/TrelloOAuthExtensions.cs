namespace AndroidApplication1.Handlers
{
    using System;
    using System.Collections.Generic;

    using AndroidApplication1.Model;
    using AndroidApplication1.Utils;

    public static class TrelloOAuthExtensions
    {
        public static Card LoadCardById(this TrelloOAuth proxy, string id)
        {
            return new CardHandler().GetData(proxy, id);
        }

        public static List<Card> LoadCardsFrom(this TrelloOAuth proxy, string idList)
        {
            return new ListCardHandler().GetDataList(proxy, idList);
        }

        public static List<TrelloList> LoadListsFrom(this TrelloOAuth proxy, string idboard)
        {
            return new TrelloListHandler().GetDataList(proxy, idboard);
        }

        public static GravEntry LoadGravatarEntry(this TrelloOAuth proxy, string hash)
        {
            return new GravatarHandler().GetData(proxy, hash);
        }

        public static InfoUser GetMember(this TrelloOAuth proxy, string id)
        {
            return new InfoUserHandler().GetData(proxy, id);
        }
    }
}