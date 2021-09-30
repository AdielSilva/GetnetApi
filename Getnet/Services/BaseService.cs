using Getnet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace Getnet.Services
{
    public class BaseService
    {

        protected string _baseUrl;
        protected AuthorizationToken Token;
        protected HttpClient _client;

        protected HttpRequestMessage PostMethod(string json, string method, string serviceName)
        {
            try
            {
                var httpBody = new StringContent(json, null, "application/json");
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri(_baseUrl + method),
                    Content = httpBody,
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken),
                    }
                };

                return requestMessage;
            }

            catch
            {
                throw new Exception($"O Serviço da {serviceName} está offline");
            }

        }

        protected HttpRequestMessage GetMethod(string method, string serviceName)
        {
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("GET"),
                    RequestUri = new Uri(_baseUrl + method),
                };

                return requestMessage;
            }

            catch
            {
                throw new Exception($"O Serviço da {serviceName} está offline");
            }

        }

        protected async Task<(string, HttpStatusCode)> Execute(HttpRequestMessage request)
        {
            try
            {
                var result = await _client.SendAsync(request);
                //Response with header gzip must to read as stream and descompact
                if (result.Content.Headers.ContentEncoding.Any(x => x == "gzip"))
                {
                    var content = Descompress(await result.Content.ReadAsStreamAsync());
                    return (content, result.StatusCode);
                }
                else
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return (content, result.StatusCode);
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationException("HTTP REQUEST ERROR", ex);
            }
        }
        protected T DeserializeHttpContent<T>(string content)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(content);
                return obj;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"JSON DESERIALIZE ERROR", ex);
            }
        }

        protected string Descompress(Stream stream)
        {
            try
            {
                var decompress = new GZipStream(stream, CompressionMode.Decompress);

                using (var sr = new StreamReader(decompress))
                {
                   var obj = sr.ReadToEnd();

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"DESCOMPRESS ERROR", ex);
            }
        }

    }
}
