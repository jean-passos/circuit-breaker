using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace eLoja.UI.ServiceCaller
{
	public class SenderAgent<T> where T : class
	{

		private readonly Uri _baseAddress;

		public SenderAgent(string baseAddress)
		{
			_baseAddress = new Uri(baseAddress);
		}

		public string SendPost(T bodyParameter, string resource)
		{
			using (HttpClient httpClient = new HttpClient())
			{
				httpClient.BaseAddress = _baseAddress;
				string jsonFromObject = JsonConvert.SerializeObject(bodyParameter);
				StringContent contentPost = new StringContent(jsonFromObject, Encoding.UTF8, "application/json");
				var responseMessage = httpClient.PostAsync(resource, contentPost);
				responseMessage.Wait();

				var responseJson = responseMessage.Result.Content.ReadAsStringAsync();
				responseJson.Wait();

				return responseJson.Result;
			}
		}
	}
}
