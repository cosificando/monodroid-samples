namespace AndroidApplication1
{
    using System.Threading;

    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.OS;
    using Android.Views;
    using Android.Webkit;
    using Android.Widget;

    using AndroidApplication1.Model;
    using AndroidApplication1.Utils;

    using RestSharp.Contrib;

    [Activity(Label = "trello client for Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static TrelloOAuth TrelloUserInfoProxy;

        private ProgressDialog _progress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var explorer = FindViewById<WebView>(Resource.Id.webView1);
            explorer.Settings.JavaScriptEnabled = true;

            var button = FindViewById<Button>(Resource.Id.MyButton);
            var txtWelcome = this.FindViewById<TextView>(Resource.Id.txtWelcome);

            if (NetworkStatus.HasConnectivity(this))
            {
                TrelloUserInfoProxy = new TrelloOAuth();

                TrelloUserInfoProxy.OAuthFailed += delegate
                    {
                        _progress.Hide();
                        Toast.MakeText(this, "Unable to login. OAuthentication failed...", ToastLength.Short).Show();
                        TrelloUserInfoProxy.Authenticate(false);
                    };

                TrelloUserInfoProxy.LoggedIn += delegate(InfoUser infoUser)
                    {
                        var dashboard = new Intent(this, typeof(DashboardActivity));
                        button.Text = "Logout";
                        button.Enabled = true;
                        _progress.Hide();
                        txtWelcome.Text = string.Format("Welcome, {0}", infoUser.FullName);
                        Thread.Sleep(1000);
                        StartActivity(dashboard);
                    };

                TrelloUserInfoProxy.UrlReady += delegate {
                        _progress.Hide();
                        button.Enabled = true;
                    };

                this._progress = new ProgressDialog(this) { Indeterminate = true };
                this._progress.SetTitle("Login In Progress");
                this._progress.SetMessage("Please wait...");
                this._progress.Show(); 

                TrelloUserInfoProxy.Authenticate(true);

            }
            else
            {
                Toast.MakeText(this, "Unable to reach internet...", ToastLength.Long).Show();
                button.Enabled = false;
            }

            button.Click += delegate
                {
                    if (button.Text == "Logout")
                    {
                        button.Text = "Login";
                        TrelloUserInfoProxy.ForceLogout();
                        TrelloUserInfoProxy.Authenticate(false);
                    }
                    else
                    {
                        explorer.LoadUrl(TrelloUserInfoProxy.Url.ToString());
                        button.Enabled = false;
						RunOnUiThread (() => { explorer.Visibility = ViewStates.Visible; });
                    }
                };

            explorer.SetWebViewClient(new TrelloAuthViewClient());
        }

        private class TrelloAuthViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)  
            {
                view.LoadUrl(url);
                return true;
            }

            public override void OnPageStarted(WebView view, string url, Bitmap favicon)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(url);
#endif

                if (url.StartsWith("http://desarrollomobile.net/?oauth_token"))
                {
                    view.Visibility = ViewStates.Invisible;

                    var qs = HttpUtility.ParseQueryString(url);

                    var verifier = qs["oauth_verifier"];

                    TrelloUserInfoProxy.Check(verifier);                    
                }
            }
        }
    }
}

