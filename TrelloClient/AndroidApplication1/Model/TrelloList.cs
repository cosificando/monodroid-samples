namespace AndroidApplication1.Model
{
    /*
     * data sample
    {
        "id": "4fe20366df5c3cc66b1122d6",
        "name": "Basics",
        "closed": false,
        "idBoard": "4fe20366df5c3cc66b1122cd",
        "pos": 16384
    },

     */

    //https://api.trello.com/1/boards/4fe20366df5c3cc66b1122cd/cards?key=b0241095b86be629a129979be29fa6db&token=637b50a2b29fb3ff8497014c1d773de293a32968dd59e189026eeac6316f1fa0
    /// <summary>
    /// Represents a list
    /// </summary>
    public class TrelloList
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TrelloList"/> is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if closed; otherwise, <c>false</c>.
        /// </value>
        public bool Closed { get; set; }

        /// <summary>
        /// Gets or sets the id board.
        /// </summary>
        /// <value>
        /// The id board.
        /// </value>
        public string IdBoard { get; set; }

        /// <summary>
        /// Gets or sets the pos.
        /// </summary>
        /// <value>
        /// The pos.
        /// </value>
        public int Pos { get; set; }
    }
}