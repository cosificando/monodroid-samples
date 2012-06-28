namespace AndroidApplication1.Model
{
    /// <summary>
    /// Respresents a card's badget
    /// </summary>
    public class Badges
    {
        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>
        /// The votes.
        /// </value>
        public int Votes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [viewing member voted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [viewing member voted]; otherwise, <c>false</c>.
        /// </value>
        public bool ViewingMemberVoted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Badges"/> is subscribed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if subscribed; otherwise, <c>false</c>.
        /// </value>
        public bool Subscribed { get; set; }

        /// <summary>
        /// Gets or sets the fogbugz.
        /// </summary>
        /// <value>
        /// The fogbugz.
        /// </value>
        public string Fogbugz { get; set; }

        /// <summary>
        /// Gets or sets the check items.
        /// </summary>
        /// <value>
        /// The check items.
        /// </value>
        public int CheckItems { get; set; }

        /// <summary>
        /// Gets or sets the check items checked.
        /// </summary>
        /// <value>
        /// The check items checked.
        /// </value>
        public int CheckItemsChecked { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public int Comments { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public int Attachments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Badges"/> is description.
        /// </summary>
        /// <value>
        ///   <c>true</c> if description; otherwise, <c>false</c>.
        /// </value>
        public bool Description { get; set; }

        /// <summary>
        /// Gets or sets the due.
        /// </summary>
        /// <value>
        /// The due.
        /// </value>
        public string Due { get; set; }

    }
}