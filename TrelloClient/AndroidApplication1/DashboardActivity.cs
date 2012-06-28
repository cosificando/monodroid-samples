namespace AndroidApplication1
{
    using System.Collections.Generic;
    using System.Linq;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Views;
    using Android.Widget;

    using AndroidApplication1.Views;

    [Activity(Label = "My dashboard")]
    public class DashboardActivity : ListActivity
    {
        private BoardAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var source = new Dictionary<string, List<BoardView>>();

            MainActivity.TrelloUserInfoProxy.LoadOrganizations();
            MainActivity.TrelloUserInfoProxy.LoadBoardsUserIsMemberOf();

            //TODO: Colocar texto de info de usuario y algo de estadísticas

            foreach (var organization in MainActivity.TrelloUserInfoProxy.OrganizationsUserBelongsTo)
            {
                foreach (var idBoard in organization.IdBoards)
                {
                    var boards = (from board in MainActivity.TrelloUserInfoProxy.BoardsUserIsMemberOf
                                 where board.Id == idBoard
                                  select new BoardView(board.Name, board.Id, typeof(BoardActivity))).ToList();

                    source.Add(organization.DisplayName, boards);
                }
            }

            var mainBoards = (from board in MainActivity.TrelloUserInfoProxy.BoardsUserIsMemberOf
                              where string.IsNullOrEmpty(board.IdOrganization)
                              select new BoardView(board.Name, board.Id, typeof(BoardActivity))).ToList();

            source.Add("Boards", mainBoards);

            this.adapter = new BoardAdapter(this, source);

            this.ListAdapter = this.adapter;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var s = adapter[position];
            var intent = new Intent(this, s.Screen);
			intent.PutExtra("idBoard", s.Id);

            this.StartActivity(intent);
        }
    }
}