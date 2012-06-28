namespace AndroidApplication1.Model
{
    using System.Collections.Generic;

    #region JSON
    /*
     * {
    "id": "4fe2030ddf5c3cc66b1092ac",
    "avatarHash": "53128e211cbee9704af4bd1498a1e514",
    "avatarSource": "gravatar",
    "bio": "",
    "fullName": "José Miguel Torres",
    "gravatarHash": "ad9d845d326eba333689b6c1d5682752",
    "idBoards": [
        "4fe20366df5c3cc66b1122cd",
        "4fe203bd52d860025f0dffd4",
        "4fe258d327441f7e13023137"
    ],
    "idBoardsInvited": [ ],
    "idBoardsPinned": [
        "4fe20366df5c3cc66b1122cd",
        "4fe203bd52d860025f0dffd4",
        "4fe258d327441f7e13023137"
    ],
    "idOrganizations": [
        "4fe258c527441f7e13023070"
    ],
    "idOrganizationsInvited": [ ],
    "initials": "JT",
    "prefs": {
        "sendSummaries": true,
        "minutesBetweenSummaries": 60,
        "colorBlind": false
    },
    "status": "disconnected",
    "url": "https://trello.com/josemigueltorres",
    "username": "josemigueltorres"
}
     */
    #endregion

    /// <summary>
    /// Represents a Trello's User
    /// </summary>
    public class InfoUser
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the avatar hash.
        /// </summary>
        /// <value>
        /// The avatar hash.
        /// </value>
        public string AvatarHash { get; set; }

        /// <summary>
        /// Gets or sets the avatar source.
        /// </summary>
        /// <value>
        /// The avatar source.
        /// </value>
        public string AvatarSource { get; set; }

        /// <summary>
        /// Gets or sets the bio.
        /// </summary>
        /// <value>
        /// The bio.
        /// </value>
        public string Bio { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the gravatar hash.
        /// </summary>
        /// <value>
        /// The gravatar hash.
        /// </value>
        public string GravatarHash { get; set; }

        /// <summary>
        /// Gets or sets the id boards.
        /// </summary>
        /// <value>
        /// The id boards.
        /// </value>
        public List<string> IdBoards { get; set; }

        /// <summary>
        /// Gets or sets the id boards invited.
        /// </summary>
        /// <value>
        /// The id boards invited.
        /// </value>
        public List<string> IdBoardsInvited { get; set; }

        /// <summary>
        /// Gets or sets the id boards pinned.
        /// </summary>
        /// <value>
        /// The id boards pinned.
        /// </value>
        public List<string> IdBoardsPinned { get; set; }

        /// <summary>
        /// Gets or sets the id organizations.
        /// </summary>
        /// <value>
        /// The id organizations.
        /// </value>
        public List<string> IdOrganizations { get; set; }

        /// <summary>
        /// Gets or sets the id organizations invited.
        /// </summary>
        /// <value>
        /// The id organizations invited.
        /// </value>
        public List<string> IdOrganizationsInvited { get; set; }

        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        /// <value>
        /// The initials.
        /// </value>
        public string Initials { get; set; }

        /// <summary>
        /// Gets or sets the prefs.
        /// </summary>
        /// <value>
        /// The prefs.
        /// </value>
        //public Prefs prefs { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }
    }
}