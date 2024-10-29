namespace lyqbing.DGLAB
{
	using System;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;

	public static class FTPManager
	{
		/// <summary>
		/// Get请求
		/// </summary>
		public static async Task<string> Get(string Url)
		{
			HttpRequestMessage request = new(HttpMethod.Get, Url);
			return await IsSuccessStatusCode(request);
		}

		/// <summary>
		/// POST请求
		/// </summary>
		public static async Task<string> Post(string Url, string jsonParas)
		{
			HttpRequestMessage request = new(HttpMethod.Post, Url)
			{
				Content = new StringContent(jsonParas, Encoding.UTF8, "application/x-www-form-urlencoded")
			};

			return await IsSuccessStatusCode(request);
		}

		/// <summary>
		/// 服务器请求回执
		/// </summary>
		public static async Task<string> IsSuccessStatusCode(HttpRequestMessage request)
		{
			HttpClient httpClient = new();
			HttpResponseMessage response = await httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				string responseBody = await response.Content.ReadAsStringAsync();
				return responseBody;
			}
			else
			{
				Console.WriteLine("【FTPManager】请求失败，状态码: " + response.StatusCode);
				return null;
			}
		}
	}
}