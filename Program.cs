using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientDemo;

class HttpClientDemo {
   static async Task Main (string[] args) {
      //var r = await LoginWithCookie ();
      //var r = await LoginWithHeaderValue ();
      var r = await TestValidateApiKey ();
   }

   static async Task<bool> LoginWithCookie() {
      var host = "https://localhost:7132";
      // Create a new HttpClientHandler with a CookieContainer
      var handler = new HttpClientHandler {
         //CookieContainer = new CookieContainer ()
      };
      //handler.CookieContainer.Add (new Uri (host), new Cookie ("orbiterToken", "CfDJ8JwSzECd2lJJiPgxS9In1z-FR8jBEeH5fBKVImNd-FdXS78KSifJkEmRW-NmrtA5YvBK09b_UeHyz90gc86IZO1miLD94Z0SX-ZfXY5YCkBuD0YoKCNVDmPksp4g6PtloXMDQnZENu3hKg007EITRAalMpxCvAC08mlkU3Kl_qQl4HNxMg1WnYaPRya1N60WvjpQFqhq44pxXPDRIsitK7xVNMNhey0L5HVNo4ZiFYeVhTOhwImEZR1ftRwzsPUZ5CL723ulJP2KCojLsJjo-hwM9XDbcAcG_J17Aa2I4HuigpZuyTH3MeI_vq44KVLulPkz9C5bAyXNrCA4dMvJkDYlKuSFzTVJq3CNuVNVmOtNhaH6qiUQdEkneCHHR7eFI7J9hxMIVL7Ur2_NETDbIpUh6AfYpSgUiFEk_CjFUtBx857dNq9dmAYAva74bFoN1R5UKxhYgZ7miDjii67-FVOjny_f0afaEuAsPUwcjg5MXGwHa5CWNzrrf0ojV2SqksiSlF3Ng7ygOrFU3nYm3bhwBRSURXgbpSXFDGuZWa_0eWDxLppr8SkANt2OxtcvxStLdwYci6tzkA_4eF6icJvSEAn3vCdxM3ZNqQCwoJFc4oKnIQEyFyzmOKu3zDTdcCBa_af7J-zevLtoVF5naczxhPndWDpHJgs8As1duiYlkwdTuMfvO5JlE4inE98riPoELpAj8ZyGxkw0v-NOpk-Y83K6OMIe6FVJOjyBn8yoVcvmXq27p8_N6eubtN5d3Um4WXpYxD_SJYlCeWjdOeBE7THktkqo2bIoFRWEu52LTdZLGkImVCXN8jUZRXPLMHGFgfAM5gKmkznQeEFT9hhOyfdr5Jujg2EWU-XQ5RrHawJavxO1qTiymd2-AVs-6fPA4uvqf206bfW6BSEXhCyuO_z6K3RYQjBO0YefLt-RA0usdztQ8wQvjmYI2HCcFFeyDK32c-sgQzAKzqu_MmnhagWKlKx4ZQuiem4gpHy425Dcl-6EqokHSU4wlnGB2XBeL0ruX8bKcPbotf8MySHMQN54Q2FJUxzW8jG0HLnLPjbTWqvOUf2QvWkDj9I8_dukUu8aJTgdRh3AjGFKiD3Evb98tCpTuPpa3A_fF49QYWe4Y_9aABbdt0mnzavjAemTNDSUm-fo2q_-wklkyDOUPu_DvU3ep8QozqANd4SNU_dG9l6qT8V9aiS_Gebz7lur_i55aPIkfGrNtbNVQME32a4HHy2HBFbxEfE5Eq1wN4sz4LanSH_NWTti28o-z5uce9LHq_dxO9TPoqBXkO4dGA1OORUWOFABomDYIc_Z-uNE0GVnPNI7w2lA9x89vX79j1KoPd0dEmiRs5goGu55nvK-kdWJ-aCTsxqPDNdyaBfGruopwhk79VjPv75ZlVSbqu02Sx5uld3GNHoiah4I2drgycQlhqDjWjiMyulENes1r_qNRousBPyLMNSWjbeSnkCfODqp9snCXYjV7U-uqaRBzFa-unmee85BvwoX"));

      // Create a new instance of HttpClient with the handler
      using HttpClient httpClient = new (handler);
      // Set the base address of the API
      httpClient.BaseAddress = new Uri (host);
      httpClient.DefaultRequestHeaders.Add ("x-orbiter-api-key", "ABCD12345");
      httpClient.DefaultRequestHeaders.Add ("x-orbiter-api-email", "ABCD12345");
      // Make a GET request
      HttpResponseMessage responseGet = await httpClient.GetAsync ("api/authPing");
      if (responseGet.IsSuccessStatusCode) {
         // Read the response content
         string responseBody = await responseGet.Content.ReadAsStringAsync ();
         Console.WriteLine ($"GET Response: {responseBody}");
      } else {
         Console.WriteLine ($"GET Request failed with status code: {responseGet.StatusCode}");
      }
      return true;
   }

   static async Task<bool> TestValidateApiKey() {
      var email = "naveenkumar@metamation.com";
      var apiKey = "WwxuABBGmMJ4yfdGicKM9CoHoX3Bwfqc8eTXW0vHJSA=";

      var host = "https://localhost:7132";
      // Create a new HttpClientHandler with a CookieContainer
      var handler = new HttpClientHandler ();
      using HttpClient httpClient2 = new (handler);
      httpClient2.BaseAddress = new Uri (host);
      httpClient2.DefaultRequestHeaders.Add ("email", email);
      httpClient2.DefaultRequestHeaders.Add ("apiKey", apiKey);

      // Make a GET request
      HttpResponseMessage responseGet2 = await httpClient2.GetAsync ("api/auth/validateApiKey");
      if (responseGet2.IsSuccessStatusCode) {
         // Read the response content
         string responseBody = await responseGet2.Content.ReadAsStringAsync ();
         Console.WriteLine ($"API KEY IS VALID");
      } else {
         Console.WriteLine ($"GET Request failed with status code: {responseGet2.StatusCode}");
      }
      return true;
   }

   static async Task<bool> LoginWithHeaderValue () {
      var email = "naveenkumar@metamation.com";
      var apiKey = ""; // "SERtz+bKZ2EgQBv6z4ImIDaBox6yjViPDXG8KQx+5cY=";

      var host = "https://localhost:7077";
      // Create a new HttpClientHandler with a CookieContainer
      var handler = new HttpClientHandler ();
      // Create a new instance of HttpClient with the handler
      using HttpClient httpClient = new (handler);
      httpClient.BaseAddress = new Uri (host);
      //httpClient.DefaultRequestHeaders.Add ("x-orbiter-api-key", apiKeyEncoded);
      httpClient.DefaultRequestHeaders.Add ("email", email);
      // Make a GET request
      HttpResponseMessage responseGet = await httpClient.GetAsync ("generateApiKey");
      if (responseGet.IsSuccessStatusCode) {
         // Read the response content
         string responseBody = await responseGet.Content.ReadAsStringAsync ();
         apiKey = responseBody;
         Console.WriteLine ($"GET Response: {responseBody}");
      } else {
         Console.WriteLine ($"GET Request failed with status code: {responseGet.StatusCode}");
      }

      //var apiKeyEncoded = WebUtility.UrlEncode (apiKey);

      using HttpClient httpClient2 = new (handler);
      httpClient2.BaseAddress = new Uri (host);
      httpClient2.DefaultRequestHeaders.Add ("email", email);
      httpClient2.DefaultRequestHeaders.Add ("apiKey", apiKey);

      // Make a GET request
      HttpResponseMessage responseGet2 = await httpClient2.GetAsync ("validateApiKey");
      if (responseGet2.IsSuccessStatusCode) {
         // Read the response content
         string responseBody = await responseGet2.Content.ReadAsStringAsync ();
         Console.WriteLine ($"GET Response: {responseBody}");
      } else {
         Console.WriteLine ($"GET Request failed with status code: {responseGet2.StatusCode}");
      }

      return true;
   }
}

