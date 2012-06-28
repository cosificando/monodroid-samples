namespace AndroidApplication1.Views
{
    using System.Collections.Generic;

    using Android.App;
    using Android.Views;
    using Android.Widget;

    public class CardAdapter : ArrayAdapter<CardView>
    {
        Activity context;
        public CardAdapter(Activity context, IList<CardView> objects)
            : base(context, Android.Resource.Id.Text1, objects)
        {
            this.context = context;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = this.context.LayoutInflater.Inflate(Resource.Layout.Cards, null);
            var item = GetItem(position);

            view.FindViewById<TextView>(Resource.Id.textCard).Text = item.Card.Name;

            //labels
            DrawLabels(view, item);

            //badges
            int badgetCount = default(int);

            if (item.Card.HasComments())
            {
                this.SetIcon(view, ++badgetCount, Resource.Drawable.Comments, item.Card.Badges.Comments.ToString());
            }

            if (item.Card.HasAttachments())
            {
                this.SetIcon(view, ++badgetCount, Resource.Drawable.attachment, item.Card.Badges.Attachments.ToString());
            }

            if (item.Card.HasCheckItems())
            {
				this.SetIcon(view, ++badgetCount, Resource.Drawable.details_list, 
				             string.Format("{0}/{1}",item.Card.Badges.CheckItemsChecked, item.Card.Badges.CheckItems));
            }

            if (item.Card.HasVotes())
            {
                this.SetIcon(view, ++badgetCount, Resource.Drawable.Likes, item.Card.Badges.Votes.ToString());
            }

            if (!string.IsNullOrEmpty(item.Card.Desc))
            {
                this.SetIcon(view, ++badgetCount, Resource.Drawable.Description);
            }

            //members
            if (item.Card.IdMembers.Count > 0)
            {
                view.FindViewById<ImageView>(Resource.Id.imgMembership).SetImageResource(Resource.Drawable.Icon);
            }

            return view;
        }

        private void SetIcon(View view, int position, int image, string count = "")
        {
            var idImgResource = default(int);
            var idTxtResource = default(int);

            switch (position)
            {
                case 1:
                    idImgResource = Resource.Id.imgBadge1;
                    idTxtResource = Resource.Id.txtBadge1;
                    break;
                case 2:
                    idImgResource = Resource.Id.imgBadge2;
                    idTxtResource = Resource.Id.txtBadge2;
                    break;
                case 3:
                    idImgResource = Resource.Id.imgBadge3;
                    idTxtResource = Resource.Id.txtBadge3;
                    break;
                case 4:
                    idImgResource = Resource.Id.imgBadge4;
                    idTxtResource = Resource.Id.txtBadge4;
                    break;
                case 5:
                    idImgResource = Resource.Id.imgBadge5;
					idTxtResource = Resource.Id.txtBadge5;
                    break;
            }

            //img
            view.FindViewById<ImageView>(idImgResource).SetImageResource(image);
            //txt
            if (string.IsNullOrEmpty(count))
            {
                view.FindViewById<TextView>(idTxtResource).Visibility = ViewStates.Invisible;
            }
            else
            {
                view.FindViewById<TextView>(idTxtResource).Visibility = ViewStates.Visible;
            }
			view.FindViewById<TextView>(idTxtResource).Text = count;
        }

        private void DrawLabels(View view, CardView item)
        {
            int idColor = default(int);
            int idResource = default(int);
            int count = default(int);

            foreach ( var label in item.Card.Labels)
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
                            idResource = Resource.Id.imgLagel1;
                            break;
                        case 2:
                            idResource = Resource.Id.imgLagel2;
                            break;
                        case 3:
                            idResource = Resource.Id.imgLagel3;
                            break;
                        case 4:
                            idResource = Resource.Id.imgLagel4;
                            break;
                        case 5:
                            idResource = Resource.Id.imgLagel5;
                            break;
                        case 6:
                            idResource = Resource.Id.imgLagel6;
                            break;
                    }
                    
                    view.FindViewById<ImageView>(idResource).SetImageResource(idColor);
                }
            }
        }
    }
}