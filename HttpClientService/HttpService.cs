using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;

namespace HttpClientService
{
    public class HttpService: IHttpService
    {
        //private readonly HttpClient httpClient;
        private readonly IHttpClientFactory httpClientFactory;
        public HttpClient Client { get; set; }
        public MediaType MediaType { get; set; }
        // Update -- Remove Dependency Injection for constructor
        public HttpService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            Client = httpClientFactory.CreateClient("codecamp");
        }
        #region Post request
        // Post: normal post with no response
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, double timeout = 100)
        {
            
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }


        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }


        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }


        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }


        }
        // Post: with authorization and no response
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        // Post: with normal headers and no response
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }

        // Post: with authorization and response object
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request 
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);
                
                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request 
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        // Post: with noral headers and response object
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);


            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        // Post: with response object
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                // make request
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PostAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                // make request
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        #endregion

        #region Put Request
        // Put: normal put with no response
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }

        }
        // Put: with authorization and no response
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        // Put: with normal headers and no response
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<object>(healthcz);
                return new HttpResponseWrapper<object>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
            }
        }
        // Put: with authorization and response object
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }


        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }


        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }


        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }


        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }


        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }


        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }


        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }


        }
        // Put: with noral headers and response object
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, string healthCheck, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                request.Content = content;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                request.Content = stringContent;
                request = AddHeder(headers, request);
                var response = await Client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }

        // Put: with response object
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse>(hcz, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                var resDeserialize = await Deserialize<TResponse>(response);
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, true, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(resDeserialize, false, response);
                }
            }

        }

        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        public async Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<TResponse>(healthcz);
                return new HttpResponseWrapper<TResponse, TError>(hcz, default, false, healthcz);
            }

            if (MediaType == MediaType.JSON)
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormUrlEncode)
            {
                var stringContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)data);
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else if (MediaType == MediaType.FormData)
            {
                var content = (MultipartFormDataContent)Convert.ChangeType(data, typeof(MultipartFormDataContent));
                var response = await Client.PutAsync(url, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }
            else
            {
                var dataJson = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(url, stringContent, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var resDeserialize = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse, TError>(resDeserialize, default, true, response);
                }
                else
                {
                    var resDeserialize = await Deserialize<TError>(response);
                    return new HttpResponseWrapper<TResponse, TError>(default, resDeserialize, false, response);
                }
            }

        }
        #endregion

        #region Delete Request
        // Delete: normal request
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            var resHttp = await Client.DeleteAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }

            var resHttp = await Client.DeleteAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }

            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        // Delete: with authorization
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, string healthCheck, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }

            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        // Delete: with normal header
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Delete<T>(string url, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }

        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            var resHttp = await Client.DeleteAsync(url);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            var resHttp = await Client.DeleteAsync(url);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }

            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        // Delete: with authorization
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.DeleteAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        // Delete: with normal header
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        #endregion

        #region Get Request
        // Get Request: normal request
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // make request
            var resHttp = await Client.GetAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            // make request
            var resHttp = await Client.GetAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        // Get Request: with authorization header
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        // Get Request: with normal header
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T>(hcz, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            var response = await Deserialize<T>(resHttp);

            if (resHttp.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<T>(response, true, resHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(response, false, resHttp);
            }
        }

        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // make request
            var resHttp = await Client.GetAsync(url);

            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
            
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            // make request
            var resHttp = await Client.GetAsync(url);

            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }

        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        // Get Request: with authorization header
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, AuthorizeHeader auth, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, AuthorizeHeader auth, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, AuthorizeHeader auth, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);
            // make request
            var resHttp = await Client.GetAsync(url, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        // Get Request: with normal header
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, List<HttpHeaderWrapper> headers, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, List<HttpHeaderWrapper> headers, string healthCheck, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        public async Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, List<HttpHeaderWrapper> headers, string healthCheck, CancellationToken cancellationToken, double timeout = 100)
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            // Check healthCheck
            var healthcz = await Client.GetAsync(healthCheck);
            if (!healthcz.IsSuccessStatusCode)
            {
                var hcz = await ResponseHealthCheck<T>(healthcz);
                return new HttpResponseWrapper<T, TError>(hcz, default, false, healthcz);
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            // make request
            var resHttp = await Client.SendAsync(request, cancellationToken);
            if (resHttp.IsSuccessStatusCode)
            {
                var resDeserialize = await Deserialize<T>(resHttp);
                return new HttpResponseWrapper<T, TError>(resDeserialize, default, true, resHttp);
            }
            else
            {
                var resDeserialize = await Deserialize<TError>(resHttp);
                return new HttpResponseWrapper<T, TError>(default, resDeserialize, false, resHttp);
            }
        }
        #endregion

        #region GraphQL Request
        public async Task<HttpResponseWrapper> QueryGraphQLAsync(string url, string data, AuthorizeHeader auth, double timeout = 100, string healthCheck = "")
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrWhiteSpace(healthCheck))
            {
                // Check healthCheck
                var healthcz = await Client.GetAsync(healthCheck);
                if (!healthcz.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper(false, healthcz);
                }
            }

            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            string dataJson = "{\"query\":\"query" + data + "\",\"variables\":{}}";
            // make request
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, stringContent);
            

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper(true, response);
            }
            else
            {
                return new HttpResponseWrapper(false, response);
            }

        }
        public async Task<HttpResponseWrapper> QueryGraphQLAsync(string url, string data, AuthorizeHeader auth, CancellationToken cancellationToken = default(CancellationToken), double timeout = 100, string healthCheck = "")
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrWhiteSpace(healthCheck))
            {
                // Check healthCheck
                var healthcz = await Client.GetAsync(healthCheck);
                if (!healthcz.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper(false, healthcz);
                }
            }

            // set header
            Client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue(auth.Type, auth.Value);

            string dataJson = "{\"query\":\"query" + data + "\",\"variables\":{}}";
            // make request
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, stringContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper(true, response);
            }
            else
            {
                return new HttpResponseWrapper(false, response);
            }

        }
        public async Task<HttpResponseWrapper> QueryGraphQLAsync(string url, string data, double timeout = 100, string healthCheck = "")
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrWhiteSpace(healthCheck))
            {
                // Check healthCheck
                var healthcz = await Client.GetAsync(healthCheck);
                if (!healthcz.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper(false, healthcz);
                }
            }
            string dataJson = "{\"query\":\"query" + data + "\",\"variables\":{}}";
            // make request
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper(true, response);
            }
            else
            {
                return new HttpResponseWrapper(false, response);
            }

        }
        public async Task<HttpResponseWrapper> QueryGraphQLAsync(string url, string data, CancellationToken cancellationToken = default(CancellationToken), double timeout = 100, string healthCheck = "")
        {
            //var httpClient = httpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrWhiteSpace(healthCheck))
            {
                // Check healthCheck
                var healthcz = await Client.GetAsync(healthCheck);
                if (!healthcz.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper(false, healthcz);
                }
            }
            string dataJson = "{\"query\":\"query" + data + "\",\"variables\":{}}";
            // make request
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, stringContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper(true, response);
            }
            else
            {
                return new HttpResponseWrapper(false, response);
            }

        }
        #endregion
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse)
        {
            try
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                if (typeof(T) == typeof(string) || typeof(T) == typeof(int) ||
                    typeof(T) == typeof(bool) || typeof(T) == typeof(decimal))
                {
                    return (T)Convert.ChangeType(responseString, typeof(T));
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    var responseByte = await httpResponse.Content.ReadAsByteArrayAsync();
                    return (T)Convert.ChangeType(responseByte, typeof(T));
                }
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception)
            {
                return default(T);
            }
           
        }

        private async Task<T> ResponseHealthCheck<T>(HttpResponseMessage httpResponse)
        {
            try
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseString = await httpResponse.Content.ReadAsStringAsync();
                    return (T)Convert.ChangeType(responseString, typeof(string));
                }
                return (T)Convert.ChangeType("You're offline", typeof(string));
            }
            catch (Exception)
            {
                return default(T);
            }

        }
        
        private HttpRequestMessage AddHeder(List<HttpHeaderWrapper> headers, HttpRequestMessage request)
        {
            // set header
            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Name, h.Value);
            }

            return request;
        }

    }
}
