﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiConsumerDemo.Models
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient;

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
