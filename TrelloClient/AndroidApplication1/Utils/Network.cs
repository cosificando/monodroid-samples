// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Network.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Network type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace AndroidApplication1.Utils
{
    using Android.Content;
    using Android.Net;

    /// <summary>
    /// 
    /// </summary>
    public static class NetworkStatus
    {
        /// <summary>
        /// Determines whether the specified context has connectivity.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <c>true</c> if the specified context has connectivity; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasConnectivity(Context context)
        {
            var connMgr = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);

            return connMgr.GetAllNetworkInfo().ToList().Select(n => n.IsConnected).Count() > 0;
        } 
    }
}