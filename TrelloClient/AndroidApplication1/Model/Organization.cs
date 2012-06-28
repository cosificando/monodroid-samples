namespace AndroidApplication1.Model
{
    using System.Collections.Generic;

    /*
     * 
     *  {
        "id": "4fe258c527441f7e13023070",
        "name": "organizationx1",
        "displayName": "organization X",
        "desc": "",
        "invited": false,
        "invitations": [ ],
        "memberships": [
            {
                "id": "4fe258c527441f7e13023074",
                "idMember": "4fe2030ddf5c3cc66b1092ac",
                "memberType": "admin"
            }
        ],
        "prefs": {
            "permissionLevel": "private"
        },
        "url": "https://trello.com/organizationx1",
        "website": "",
        "idBoards": [
            "4fe258d327441f7e13023137"
        ]
    }

     */
    /// <summary>
    /// Represents an organization
    /// </summary>
    public class Organization
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
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the desc.
        /// </summary>
        /// <value>
        /// The desc.
        /// </value>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Organization"/> is invited.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invited; otherwise, <c>false</c>.
        /// </value>
        public bool Invited { get; set; }

        //public List<Invitation> invitations { get; set; }

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>
        /// The memberships.
        /// </value>
        public List<Membership> Memberships { get; set; }

        /// <summary>
        /// Gets or sets the prefs.
        /// </summary>
        /// <value>
        /// The prefs.
        /// </value>
        public Prefs Prefs { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the id boards.
        /// </summary>
        /// <value>
        /// The id boards.
        /// </value>
        public List<string> IdBoards { get; set; }
        
    }
}