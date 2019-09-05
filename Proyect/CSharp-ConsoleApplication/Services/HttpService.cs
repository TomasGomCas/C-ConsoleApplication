using CSharp_ConsoleApplication.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CSharp_ConsoleApplication.Services
{
    class HttpService
    {
        public static Muro getPosts()
        {

            HttpWebRequest request;
            request = WebRequest.Create("https://curriculum-213a8.firebaseio.com/Muro.json") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();

            JObject json = JObject.Parse(body);

            // Convert to object
            List<Post> posts = new List<Post>();
            foreach (var x in json)
            {
                Post post = new Post(x.Value["user"].ToString(), x.Value["text"].ToString());
                posts.Add(post);
            }
            return new Muro(posts);
        }

        public static void post()
        {
            Post post = new Post("paco", "soy super paco ¡¡");
            string postString = JsonConvert.SerializeObject(post);
            Console.WriteLine("ÑAÑAÑ: C" + postString);
            byte[] data = UTF8Encoding.UTF8.GetBytes(postString);

            HttpWebRequest request;
            request = WebRequest.Create("https://curriculum-213a8.firebaseio.com/Muro.json") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();

            Console.WriteLine(body);
        }

    } // END
}
