using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client
{
    class Crud
    {
        public Crud()
        {
            m_Client = new HttpClient();
            m_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            m_Client.DefaultRequestHeaders.Add("appId", "campus-task");
            m_Client.BaseAddress = new Uri("http://localhost:5000/somedata/");
        }
        public async Task<ListSomeData> GetList(bool isSorted = false)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "");
            request.Properties["sorted"] = isSorted ? "True" : "False";
            HttpResponseMessage response = await m_Client.SendAsync(request);
            ListSomeData listSomeData = new ListSomeData();
            if (response.IsSuccessStatusCode)
            {
                listSomeData.Data = JsonConvert.DeserializeObject<List<SomeData>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                listSomeData.ResponseStatus = (int)response.StatusCode;
                listSomeData.ResponseText = response.ReasonPhrase;
            }
            return listSomeData;
        }

        public async Task<SingleSomeData> GetSingle(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{id}");
            HttpResponseMessage response = await m_Client.SendAsync(request);
            SingleSomeData singleSomeData = new SingleSomeData();
            if (response.IsSuccessStatusCode)
            {
                singleSomeData.Data = JsonConvert.DeserializeObject<SomeData>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                singleSomeData.ResponseStatus = (int)response.StatusCode;
                singleSomeData.ResponseText = response.ReasonPhrase;
            }
            return singleSomeData;
        }

        public async Task<BaseResponse> Create(SomeData someData)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
            request.Content = new StringContent(JsonConvert.SerializeObject(someData), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await m_Client.SendAsync(request);
            BaseResponse response = new BaseResponse();
            response.ResponseStatus = (int)httpResponse.StatusCode;
            if (!httpResponse.IsSuccessStatusCode)
            {
                response.ResponseText = httpResponse.ReasonPhrase;
            }
            return response;
        }

        public async Task<BaseResponse> Update(string id, SomeData someData)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"{id}");
            request.Content = new StringContent(JsonConvert.SerializeObject(someData), System.Text.Encoding.UTF8, "application/json");
            SingleSomeData singleSomeData = new SingleSomeData();
            HttpResponseMessage httpResponse = await m_Client.SendAsync(request);
            BaseResponse response = new BaseResponse();
            response.ResponseStatus = (int)httpResponse.StatusCode;
            if (!httpResponse.IsSuccessStatusCode)
            {
                response.ResponseText = httpResponse.ReasonPhrase;
            }
            return response;
        }

        public async Task<BaseResponse> Delete(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{id}");
            HttpResponseMessage httpResponse = await m_Client.SendAsync(request);

            BaseResponse response = new BaseResponse();
            response.ResponseStatus = (int)httpResponse.StatusCode;
            if (!httpResponse.IsSuccessStatusCode)
            {
                response.ResponseText = httpResponse.ReasonPhrase;
            }
            return response;
        }
        private HttpClient m_Client;
    }
}
