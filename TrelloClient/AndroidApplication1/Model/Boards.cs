namespace AndroidApplication1.Model
{
    using System.Collections.Generic;

    /*
     * {
        "id": "4fe203bd52d860025f0dffd4",
        "name": "Ejemplo",
        "desc": "",
        "closed": false,
        "invited": false,
        "pinned": true,
        "url": "https://trello.com/board/ejemplo/4fe203bd52d860025f0dffd4",
        "prefs": {
            "permissionLevel": "private",
            "voting": "members",
            "comments": "members",
            "invitations": "members",
            "selfJoin": false
        },
        "invitations": [ ],
        "memberships": [
            {
                "id": "4fe203bd52d860025f0dffd8",
                "idMember": "4fe2030ddf5c3cc66b1092ac",
                "memberType": "admin"
            }
        ],
        "labelNames": {
            "red": "",
            "orange": "",
            "yellow": "",
            "green": "",
            "blue": "",
            "purple": ""
        }
    },
    {
        "id": "4fe20366df5c3cc66b1122cd",
        "name": "Welcome Board",
        "desc": "welcome description",
        "closed": false,
        "invited": false,
        "pinned": true,
        "url": "https://trello.com/board/welcome-board/4fe20366df5c3cc66b1122cd",
        "prefs": {
            "permissionLevel": "private",
            "voting": "members",
            "comments": "members",
            "invitations": "members",
            "selfJoin": false
        },
        "invitations": [ ],
        "memberships": [
            {
                "id": "4fe20366df5c3cc66b1122ce",
                "idMember": "4e6a7fad05d98b02ba00845c",
                "memberType": "normal"
            },
            {
                "id": "4fe20366df5c3cc66b1122e2",
                "idMember": "4fe2030ddf5c3cc66b1092ac",
                "memberType": "admin"
            }
        ],
        "labelNames": {
            "red": "",
            "orange": "",
            "yellow": "",
            "green": "",
            "blue": "",
            "purple": ""
        }
    },
    {
        "id": "4fe258d327441f7e13023137",
        "name": "board de x",
        "desc": "",
        "closed": false,
        "idOrganization": "4fe258c527441f7e13023070",
        "invited": false,
        "pinned": true,
        "url": "https://trello.com/board/board-de-x/4fe258d327441f7e13023137",
        "prefs": {
            "permissionLevel": "org",
            "voting": "members",
            "comments": "members",
            "invitations": "members",
            "selfJoin": false
        },
        "invitations": [ ],
        "memberships": [
            {
                "id": "4fe258d327441f7e1302313b",
                "idMember": "4fe2030ddf5c3cc66b1092ac",
                "memberType": "admin"
            }
        ],
        "labelNames": {
            "red": "",
            "orange": "",
            "yellow": "",
            "green": "",
            "blue": "",
            "purple": ""
        }
    }

     */
    /// <summary>
    /// Represents a Trello Board
    /// </summary>
    public class Board
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
        /// Gets or sets the desc.
        /// </summary>
        /// <value>
        /// The desc.
        /// </value>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Board"/> is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if closed; otherwise, <c>false</c>.
        /// </value>
        public bool Closed { get; set; }

        /// <summary>
        /// Gets or sets the id organization.
        /// </summary>
        /// <value>
        /// The id organization.
        /// </value>
        public string IdOrganization { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Board"/> is invited.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invited; otherwise, <c>false</c>.
        /// </value>
        public bool Invited { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Board"/> is pinned.
        /// </summary>
        /// <value>
        ///   <c>true</c> if pinned; otherwise, <c>false</c>.
        /// </value>
        public bool Pinned { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the prefs.
        /// </summary>
        /// <value>
        /// The prefs.
        /// </value>
        public Prefs Prefs { get; set; }

        /// <summary>
        /// Gets or sets the invitations.
        /// </summary>
        /// <value>
        /// The invitations.
        /// </value>
        public List<Invitation> Invitations { get; set; }

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>
        /// The memberships.
        /// </value>
        public List<Membership> Memberships { get; set; }

        /// <summary>
        /// Gets or sets the label names.
        /// </summary>
        /// <value>
        /// The label names.
        /// </value>
        public LabelNames LabelNames { get; set; }

    }
}