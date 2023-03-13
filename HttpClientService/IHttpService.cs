using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientService
{
    public interface IHttpService
    {
        MediaType MediaType { get; set; }
        HttpClient Client { get; set; }

        Task<HttpResponseWrapper<T>> Delete<T>(string url, double timeout = 100);
        Task<HttpResponseWrapper<T>> Delete<T>(string url, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<T>> Delete<T>(string url, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<T>> Delete<T>(string url, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T>> Delete<T>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T>> Delete<T>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Delete<T, TError>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T>> Get<T>(string url, double timeout = 100);
        Task<HttpResponseWrapper<T>> Get<T>(string url, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<T>> Get<T>(string url, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<T>> Get<T>(string url, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T>> Get<T>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T>> Get<T>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<T, TError>> Get<T, TError>(string url, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, double timeout = 100);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, double timeout = 100);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Post<T, TResponse, TError>(string url, T data, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, double timeout = 100);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, double timeout = 100);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, AuthorizeHeader auth, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, List<HttpHeaderWrapper> headers, CancellationToken cancellationToken, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, double timeout = 100);
        Task<HttpResponseWrapper<TResponse, TError>> Put<T, TResponse, TError>(string url, T data, CancellationToken cancellationToken, double timeout = 100);
    }
}
