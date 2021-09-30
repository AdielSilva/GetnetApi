using Getnet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Getnet.Services
{
    public class GetNetService : BaseService
    {
        public GetNetService(string baseUrl)
        {
            //Initialize base properties
            _client = new System.Net.Http.HttpClient();
            _baseUrl = baseUrl;
        }
        //Calls to Getnet Domain

        #region Authentication call
        //Authentication
        public async Task Authentication(Credentials credentials)
        {
            try
            {
                //Convert Credentials to base 64 
                byte[] ClientIdClientSecret = Encoding.UTF8.GetBytes(string.Concat(HttpUtility.UrlEncode(credentials.ClientId), ":", HttpUtility.UrlEncode(credentials.ClientSecret)));
                string base64 = string.Concat("Basic ", Convert.ToBase64String(ClientIdClientSecret, Base64FormattingOptions.None));
                string authorization = base64;

                using (var httpClient = new HttpClient())
                {
                    var parametros = new List<KeyValuePair<string, string>>() {
                    new KeyValuePair<string, string>("scope", "oob"),
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                };

                    var requestMessage = new HttpRequestMessage()
                    {
                        Method = new HttpMethod("POST"),
                        RequestUri = new Uri(_baseUrl + "/auth/oauth/v2/token"),
                        Content = new FormUrlEncodedContent(parametros)
                    };

                    requestMessage.Content.Headers.ContentType =
                          new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    requestMessage.Headers.Add("Authorization", authorization);

                    var response = await httpClient.SendAsync(requestMessage);
                    var responseStatusCode = response.StatusCode;
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (responseStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Token = JsonConvert.DeserializeObject<AuthorizationToken>(responseBody);
                    }
                    else
                    {
                        throw new Exception("Error making credential call");
                    }
                    
                }
           
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Card
        //Transform card number in a token
        public async Task<object> CardTokenization(TokenCardRequest cardRequest)
        {
            try
            {
                if (Token == null)
                {
                    return "Invalid credentials";
                }

                var json = JsonConvert.SerializeObject(cardRequest);
                var requestMessage = PostMethod(json, "/v1/tokens/card", "GetNet");

                var (content, statusCode) = await Execute(requestMessage);

                if (statusCode == System.Net.HttpStatusCode.OK || statusCode == System.Net.HttpStatusCode.Created)
                {
                    var response = DeserializeHttpContent<TokenCardResponse>(content);
                    return response;
                }
                else
                {
                    var response = DeserializeHttpContent<TokenCardResponseError>(content);
                    return response;
                }
            }
            catch
            {
                throw;
            }

           

        }

        //Verify token
        public async Task<object> VerifyCard(TokenCardRequest cardRequest)
        {
            if (Token == null)
            {
                return "Invalid credentials";
            }

            var json = JsonConvert.SerializeObject(cardRequest);
            var requestMessage = PostMethod(json, "/v1/tokens/card", "GetNet");

            var (content, statusCode) = await Execute(requestMessage);

            if (statusCode == System.Net.HttpStatusCode.OK || statusCode == System.Net.HttpStatusCode.Created)
            {
                //Some calls getnet response with gzip compress mode, must read as stream a 
                var streamResponse = await content.ReadAsStreamAsync();
                var response = Descompress<TokenCardResponse>(streamResponse);
                return response;
            }
            else
            {
                var streamResponse = await content.ReadAsStreamAsync();
                var response = Descompress<TokenCardResponseError>(streamResponse);
                return response;
            }

        }
        #endregion

        #region Payment

        public async Task<object> CardPayment(CardPaymentRequest cardRequest)
        {
            try
            {
                if (Token == null)
                {
                    return "Invalid credentials";
                }

                var json = JsonConvert.SerializeObject(cardRequest);
                var requestMessage = PostMethod(json, "/v1/payments/credit", "GetNet");

                var (content, statusCode) = await Execute(requestMessage);

                if (statusCode == System.Net.HttpStatusCode.OK || statusCode == System.Net.HttpStatusCode.Created)
                {
                    var response = DeserializeHttpContent<TokenCardResponse>(content);
                    return response;
                }
                else
                {
                    var response = DeserializeHttpContent<TokenCardResponseError>(content);
                    return response;
                }
            }
            catch
            {
                throw;
            }



        }

        #endregion
    }
}
