using CSharp_ConsoleApplication.Services;
using System;

namespace CSharp_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(HttpService.getPosts().ToString());
            HttpService.post();
            Console.WriteLine(HttpService.getPosts().ToString());

        }
    }
}
