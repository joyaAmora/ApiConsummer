using ApiLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiConsumerDemo
{
    public static class SunProcessor
    {
        public static async Task<SunModel> LoadSunInfo(float latitude, float longitude)
        {
            string url;
            url = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&date=today";
            

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel sun = await response.Content.ReadAsAsync<SunResultModel>();
                    return sun.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }

}
