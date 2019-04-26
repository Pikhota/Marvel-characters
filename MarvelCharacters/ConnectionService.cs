using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System.Linq;

namespace MarvelCharacters
{
	public class ConnectionService
	{
		public ConnectionService()
		{
			CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
		}
		private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			CheckConnection();
		}

		public static bool IsConnection()
		{
			return CrossConnectivity.Current.IsConnected;
		}

		public string CheckConnection()
		{
			string failedConnection = "Connection failed";

			if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
			{
				var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
				return connectionType.ToString();
			}
			else
			{
				return failedConnection;
			}
		}
	}
}
