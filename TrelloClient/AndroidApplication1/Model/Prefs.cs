namespace AndroidApplication1.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Prefs
    {
        /// <summary>
        /// Gets or sets the permission level.
        /// </summary>
        /// <value>
        /// The permission level.
        /// </value>
        public string PermissionLevel { get; set; }

        /// <summary>
        /// Gets or sets the voting.
        /// </summary>
        /// <value>
        /// The voting.
        /// </value>
        public string Voting { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the invitations.
        /// </summary>
        /// <value>
        /// The invitations.
        /// </value>
        public string Invitations { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [self join].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [self join]; otherwise, <c>false</c>.
        /// </value>
        public bool SelfJoin { get; set; }
    }
}