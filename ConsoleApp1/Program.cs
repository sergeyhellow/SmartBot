// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

SendReciever sendReciever = new SendReciever();
bool stopChating = true;
ChatRequestGenerator chatRequest = new ChatRequestGenerator();

Console.WriteLine("Ваш вопрос: ");
string question = Console.ReadLine();

while (stopChating)
{

    var content = chatRequest.GenerateChatRequest(question);
    string answer;
    var response = await sendReciever.SendQestion(content);
    if (response != null)
    {
        answer = await sendReciever.ReadResponce(response);
    }
    else
    {
        Console.WriteLine("Ошибка, программа закончена");
        return;
    }
  
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"МегаМозг: {answer}");
    Console.ResetColor();

    Console.WriteLine("Ваш вопрос (либо exit для выхода): ");
    question = Console.ReadLine();
    if (question == "exit")
    { stopChating = false; }

}
Console.WriteLine("Вышли диалога, нажмите клавишу для завершения программы");
Console.ReadLine();