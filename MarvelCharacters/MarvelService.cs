using MarvelCharacters.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCharacters
{
	public class MarvelService
	{
		private const string _url = "https://gateway.marvel.com";
		private const string _publicApiKey = "ca1ce146dbac71cc415a6e5804dadbae";
		private const string _privateApiKey = "f228bc563b74b592cabc2db4b827093d6f8369c3";
		private const string _charactersRequest = "/v1/public/characters?";
		private const string _ts = "23";

		public MarvelService()
		{
			CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
		}
		public async Task<RootObject> GetDataAsync()
		{
			using (HttpClient client = InitialClient())
			{
				string _hash = $"hash={GenerateHash(_ts, _privateApiKey, _publicApiKey)}";
				string requestUri = $"{_charactersRequest}ts={_ts}&apikey={_publicApiKey}&{_hash}";

				using (HttpResponseMessage response = client.GetAsync(requestUri).Result)
				{
					if (response.IsSuccessStatusCode)
					{
						string resultResponse = await response.Content.ReadAsStringAsync();
						RootObject root = JsonConvert.DeserializeObject<RootObject>(resultResponse);
						return root;
					}
					else
					{
						return null;
					}
				}
			}
		}

		public static string GenerateHash(string ts, string privateKey, string publicKey)
		{
		    string key = ts + privateKey + publicKey; 
			MD5 md5 = MD5.Create();
			byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(key));

			StringBuilder sb = new StringBuilder();
			foreach(var item in hash)
			{
				sb.Append(item.ToString("x2"));
			}

			return sb.ToString(); ;
		}

		private HttpClient InitialClient()
		{
			HttpClient client = new HttpClient()
			{
				BaseAddress = new Uri(_url),
			};
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}

		private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			CheckConnection();
		}

		public string CheckConnection()
		{
			string failedConnection = "Connection failed";
			if (CrossConnectivity.Current != null 
				&& CrossConnectivity.Current.ConnectionTypes != null 
				&& CrossConnectivity.Current.IsConnected == true)
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
