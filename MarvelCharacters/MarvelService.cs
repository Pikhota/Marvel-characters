using MarvelCharacters.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCharacters
{
	public static class MarvelService
	{
		private const string _url = "https://gateway.marvel.com";

		public static async Task<MarvelData> GetDataAsync(string urlRequest, string ts, string publicApiKey, string privateApiKey)
		{
			using (HttpClient client = InitialClient(_url))
			{
				string generatedHashKey = GenerateHash(ts, privateApiKey, publicApiKey);
				string hash = $"hash={generatedHashKey}";
				string requestUri = $"{urlRequest}ts={ts}&apikey={publicApiKey}&{hash}";

				using (HttpResponseMessage response = client.GetAsync(requestUri).Result)
				{
					if (response.IsSuccessStatusCode)
					{
						string resultResponse = await response.Content.ReadAsStringAsync();
						MarvelData root = JsonConvert.DeserializeObject<MarvelData>(resultResponse);
						return root;
					}
					else
					{
						return null;
					}
				}
			}
		}

		private static string GenerateHash(string ts, string privateKey, string publicKey)
		{
		    string key = ts + privateKey + publicKey; 
			MD5 md5 = MD5.Create();
			byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(key));
			StringBuilder sb = new StringBuilder();

			foreach(var hashByte in hashBytes)
			{
				sb.Append(hashByte.ToString("x2"));
			}

			return sb.ToString(); ;
		}

		private static HttpClient InitialClient(string url)
		{
			HttpClient client = new HttpClient()
			{
				BaseAddress = new Uri(url),
			};

			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}
	}
}
