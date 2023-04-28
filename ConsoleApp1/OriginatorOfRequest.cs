using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ChatRequestGenerator
    {

       MessageRequest[] message= new MessageRequest[]
            {
                 new MessageRequest { Role = "user", Content = "" },
            };

   
        public HttpContent GenerateChatRequest(string question)
            {
            ChatRequest chatResponse = new ChatRequest
            {
                    Model = "gpt-3.5-turbo",
                     
                    Messages = message
                };
                             
                message[0].Content = question;

            string json = JsonSerializer.Serialize(chatResponse, new JsonSerializerOptions { WriteIndented = true });
           
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");  // создать HttpContent из json строки

            return httpContent;

                      
            }

        }







    }

