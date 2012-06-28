namespace AndroidApplication1
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;

    using AndroidApplication1.Handlers;

    [Activity(Label = "My boards",  Theme="@android:style/Theme.NoTitleBar")]
    public class BoardActivity : TabActivity
    {

		private string _idBoard = string.Empty;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			_idBoard = Intent.GetStringExtra("idBoard");

            var lists = MainActivity.TrelloUserInfoProxy.LoadListsFrom(_idBoard);

			TabHost.TabSpec spec;
		    Intent intent;

            foreach (var list in lists)
            {
				intent = new Intent (this, typeof (CardActivity));
		    	intent.AddFlags (ActivityFlags.NewTask);
				intent.PutExtra("idList",list.Id);
				
                spec = TabHost.NewTabSpec(list.Id);
                //TODO: spec.SetIndicator (list.name, Resources.GetDrawable (Resource.Drawable.ic_tab_artists));
                spec.SetIndicator(list.Name);
                spec.SetContent(intent);
                TabHost.AddTab(spec);
            }
        }
    }

}