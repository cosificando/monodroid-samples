namespace AndroidApplication1
{
    using System.Linq;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Views;
    using Android.Widget;

    using AndroidApplication1.Handlers;
    using AndroidApplication1.Views;

    [Activity(Label = "", Theme = "@android:style/Theme.NoTitleBar")]
    public class CardActivity : ListActivity
    {

        private CardAdapter adapter;

		private string idList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			idList = Intent.GetStringExtra("idList");

            var res = MainActivity.TrelloUserInfoProxy.LoadCardsFrom(idList);

            var source = res.Select(card => new CardView(card.Name, card, typeof(DetailsActivity))).ToList();

            this.adapter = new CardAdapter(this, source);

            this.ListAdapter = this.adapter;

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var s = adapter.GetItem(position);
            var intent = new Intent(this, s.Screen);
            intent.PutExtra("idCard", s.Card.Id);

            this.StartActivity(intent);
        }
    }
}