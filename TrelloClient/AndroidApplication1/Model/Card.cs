namespace AndroidApplication1.Model
{
    using System.Collections.Generic;

    //https://api.trello.com/1/boards/4fe20366df5c3cc66b1122cd/cards?key=b0241095b86be629a129979be29fa6db&token=637b50a2b29fb3ff8497014c1d773de293a32968dd59e189026eeac6316f1fa0
    /// <summary>
    /// Represents a Trello's Card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the check item states.
        /// </summary>
        /// <value>
        /// The check item states.
        /// </value>
        public List<CheckItemStates> CheckItemStates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Card"/> is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if closed; otherwise, <c>false</c>.
        /// </value>
        public bool Closed { get; set; }

        /// <summary>
        /// Gets or sets the desc.
        /// </summary>
        /// <value>
        /// The desc.
        /// </value>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the id board.
        /// </summary>
        /// <value>
        /// The id board.
        /// </value>
        public string IdBoard { get; set; }

        /// <summary>
        /// Gets or sets the id members.
        /// </summary>
        /// <value>
        /// The id members.
        /// </value>
        public List<string> IdMembers { get; set; }

        /// <summary>
        /// Gets or sets the id short.
        /// </summary>
        /// <value>
        /// The id short.
        /// </value>
        public int IdShort { get; set; }

        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        /// <value>
        /// The labels.
        /// </value>
        public List<LabelColor> Labels { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pos.
        /// </summary>
        /// <value>
        /// The pos.
        /// </value>
        public int Pos { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the badges.
        /// </summary>
        /// <value>
        /// The badges.
        /// </value>
        public Badges Badges { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Card"/> is subscribed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if subscribed; otherwise, <c>false</c>.
        /// </value>
        public bool Subscribed { get; set; }

        /// <summary>
        /// Determines whether this instance has comments.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has comments; otherwise, <c>false</c>.
        /// </returns>
        public bool HasComments()
        {
            return this.Badges.Comments > 0;
        }

        /// <summary>
        /// Determines whether this instance has attachments.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has attachments; otherwise, <c>false</c>.
        /// </returns>
        public bool HasAttachments()
        {
            return this.Badges.Attachments > 0;
        }

        /// <summary>
        /// Determines whether [has check items].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has check items]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasCheckItems()
        {
            return this.Badges.CheckItems > 0;
        }

        /// <summary>
        /// Determines whether this instance has votes.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has votes; otherwise, <c>false</c>.
        /// </returns>
        public bool HasVotes()
        {
            return this.Badges.Votes > 0;
        }

        /// <summary>
        /// Determines whether this instance has due.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has due; otherwise, <c>false</c>.
        /// </returns>
        public bool HasDue()
        {
            return !string.IsNullOrEmpty(this.Badges.Due);
        }
    }
}