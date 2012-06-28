namespace AndroidApplication1
{
    using System;
    using System.Net;

    using Android.App;
    using Android.Graphics;
    using Android.OS;
    using Android.Widget;

    using AndroidApplication1.Handlers;
    using AndroidApplication1.Model;

    [Activity(Label = "Card details")]
    public class DetailsActivity : Activity
    {

		private string _idCard;

        private Card _cardDetails;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Details);

            _idCard = Intent.GetStringExtra("idCard");

            _cardDetails = MainActivity.TrelloUserInfoProxy.LoadCardById(this._idCard);

            var txtName = FindViewById<TextView>(Resource.Id.txtName);
            txtName.Text = _cardDetails.Name;

            var txtDesc = FindViewById<TextView>(Resource.Id.txtDesc);
            txtDesc.Text = string.IsNullOrEmpty(this._cardDetails.Desc) ? "..." : this._cardDetails.Desc;

            this.DrawLabels();

            //badges
            if (_cardDetails.HasComments())
            {
                this.FindViewById<TextView>(Resource.Id.txtComment).Text = this._cardDetails.Badges.Comments.ToString();
            }

            if (_cardDetails.HasAttachments())
            {
                this.FindViewById<TextView>(Resource.Id.txtAttach).Text = this._cardDetails.Badges.Attachments.ToString();
            }

            if (_cardDetails.HasCheckItems())
            {
                this.FindViewById<TextView>(Resource.Id.txtCheck).Text =  
                    string.Format("{0}/{1}",_cardDetails.Badges.CheckItemsChecked, _cardDetails.Badges.CheckItems);
            }

            if (_cardDetails.HasVotes())
            {
                this.FindViewById<TextView>(Resource.Id.txtVotes).Text = this._cardDetails.Badges.Votes.ToString();
            }

            //members
            if (_cardDetails.IdMembers.Count > 0)
            {
                //var layout = FindViewById<LinearLayout>(Resource.Id.layMembers);

                foreach (var member in _cardDetails.IdMembers)
                {
                    var gravatarHash = MainActivity.TrelloUserInfoProxy.GetMember(member).GravatarHash;
                    var strUrl = MainActivity.TrelloUserInfoProxy.LoadGravatarEntry(gravatarHash).ThumbnailUrl;
					var imageView = new ImageView(this);
                    LoadImage(strUrl);
                    //layout.AddView(imageView);
                }
            }
        }

        private void LoadImage(string strUrl)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += this.webClient_DownloadDataCompleted;
            webClient.DownloadDataAsync(new Uri(strUrl));
        }

        private void webClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            var layout = FindViewById<LinearLayout>(Resource.Id.layMembers);

            var bitmap = BitmapFactory.DecodeByteArray(e.Result, 0, e.Result.Length);

            RunOnUiThread(
                () =>
                    {
                        var imageView = new ImageView(this);
                        imageView.SetImageBitmap(bitmap);

                        layout.AddView(imageView);
                    });
        }

        private void DrawLabels()
        {
            int idColor = default(int);
            int idResource = default(int);
            int count = default(int);

            foreach (var label in _cardDetails.Labels)
            {
                count++;

                switch (label.Color)
                {
                    case "blue":
                        idColor = Resource.Drawable.Blue;
                        break;
                    case "green":
                        idColor = Resource.Drawable.Green;
                        break;
                    case "orange":
                        idColor = Resource.Drawable.Orange;
                        break;
                    case "purple":
                        idColor = Resource.Drawable.Purple;
                        break;
                    case "red":
                        idColor = Resource.Drawable.Red;
                        break;
                    case "yellow":
                        idColor = Resource.Drawable.Yellow;
                        break;
                }

                if (idColor != default(int))
                {
                    switch (count)
                    {
                        case 1:
                            idResource = Resource.Id.imgLabel1;
                            break;
                        case 2:
                            idResource = Resource.Id.imgLabel2;
                            break;
                        case 3:
                            idResource = Resource.Id.imgLabel3;
                            break;
                        case 4:
                            idResource = Resource.Id.imgLabel4;
                            break;
                        case 5:
                            idResource = Resource.Id.imgLabel5;
                            break;
                        case 6:
                            idResource = Resource.Id.imgLabel6;
                            break;
                    }

                    FindViewById<ImageView>(idResource).SetImageResource(idColor);
                }
            }
        }
    }
}