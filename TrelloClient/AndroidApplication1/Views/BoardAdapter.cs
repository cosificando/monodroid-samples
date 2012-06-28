namespace AndroidApplication1.Views
{
    using System.Collections.Generic;
    using System.Linq;

    using Android.App;
    using Android.Views;
    using Android.Widget;

    public class BoardAdapter : BaseAdapter<BoardView>
    {
        private Dictionary<string, List<BoardView>> _source;

        public Dictionary<string, List<BoardView>> Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }

        const int TypeSectionHeader = 0;
        const int TypeSectionSample = 1;

        readonly Activity context;
        readonly IList<object> rows = new List<object>();

        readonly ArrayAdapter<string> headers;
        readonly Dictionary<string, IAdapter> sections = new Dictionary<string, IAdapter>();

        public BoardAdapter(Activity context,Dictionary<string, List<BoardView>> source)
        {
            this.context = context;
            headers = new ArrayAdapter<string>(context, Resource.Layout.OrganizationHeaderSection, Resource.Id.Text1);
            this._source = source;

            rows = new List<object>();
            foreach (var section in _source.Keys)
            {
                headers.Add(section);
                sections.Add(section, new ArrayAdapter<BoardView>(context, Android.Resource.Layout.SimpleListItem1, _source[section]));
                rows.Add(new Organization() { Name = section, SectionIndex = sections.Count - 1 });
                foreach (var session in _source[section])
                {
                    rows.Add(session);
                }
            }
        }
        public BoardView GetBoard(int position)
        {
            return (BoardView)rows[position];
        }
        public override BoardView this[int position]
        {
            get
            { // this'll break if called with a 'header' position
                return (BoardView)rows[position];
            }
        }

        public override int ViewTypeCount
        {
            get
            {
                return 1 + sections.Values.Sum(adapter => adapter.ViewTypeCount);
            }
        }

        public override int GetItemViewType(int position)
        {
            return rows[position] is Organization
                ? TypeSectionHeader
                : TypeSectionSample;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return rows.Count; }
        }
        public override bool AreAllItemsEnabled()
        {
            return true;
        }
        public override bool IsEnabled(int position)
        {
            return !(rows[position] is Organization);
        }

        /// <summary>
        /// Grouped list: view could be a 'section heading' or a 'data row'
        /// </summary>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get our object for this position
            var item = this.rows[position];

            View view;

            if (item is Organization)
            {
                view = headers.GetView(((Organization)item).SectionIndex, convertView, parent);
                view.Clickable = false;
                view.LongClickable = false;
                return view;
            }

            int i = position - 1;
            while (i > 0 && rows[i] is BoardView)
                i--;
            Organization h = (Organization)rows[i];
            view = sections[h.Name].GetView(position - i - 1, convertView, parent);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = ((BoardView)item).Name;
            return view;
        }
    }


}