using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Mail;
using MaxMind.GeoIP2.Exceptions;

namespace ConsoleApp1
{
    public class SendReciever

    {
        private string openAiKey = "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";

        private string chatUriCoplet = "https://api.openai.com/v1/chat/completions";
        HttpClient httpClient;

        public SendReciever()
        {

            httpClient = new HttpClient()
            {
                DefaultRequestHeaders =
                 {
                     Authorization = AuthenticationHeaderValue.Parse($"Bearer {openAiKey}")
                 }
            };


        }

        public async Task<HttpResponseMessage> SendQestion(HttpContent content)
        {


            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(chatUriCoplet, content);
               
                return response;
                // обработка успешного ответа
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {

                    Console.WriteLine($"Bad Request {ex.Message}");
  
                }
                  Console.WriteLine($" {ex.Message}");
                return null;
            }

          
        }

        public async Task<string> ReadResponce(HttpResponseMessage response)
        {
            

            try
            {
                ChatAIResponce resp = await response.Content.ReadFromJsonAsync<ChatAIResponce>();
                return resp.Choices[0].Message.Content;
            }
            catch (HttpRequestException ex)
            {
              

                    Console.WriteLine($"{ex.Message}");

           
                return null;
            }


        }
    }


}

