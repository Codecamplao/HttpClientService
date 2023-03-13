using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientService
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Success = success;
            HttpResponseMessage = httpResponseMessage;
        }
        public bool Success { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }

    public class HttpResponseWrapper<T, TError>
    {
        public HttpResponseWrapper(T response, TError error, bool success, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Success = success;
            HttpResponseMessage = httpResponseMessage;
            Error = error;
        }
        public bool Success { get; set; }
        public T Response { get; set; }
        public TError Error { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }

    public class HttpResponseWrapper
    {
        public HttpResponseWrapper(bool success, HttpResponseMessage httpResponseMessage)
        {
            Success = success;
            HttpResponseMessage = httpResponseMessage;
        }
        public bool Success { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public async Task<T> GetData<T>(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return default;
            }

            JObject json = JObject.Parse(await GetBody());

            json.TryGetValue("data", out JToken jData);
            if (jData == null)
            {
                return default;

            }
            JObject jField = JObject.Parse(jData.ToString());
            if (jField == null)
            {
                return default;

            }
            jField.TryGetValue(propertyName, out JToken value);

            string jsonStr = value.ToString();
            if (string.IsNullOrWhiteSpace(jsonStr))
            {
                return default;

            }

            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
        
    }
}
