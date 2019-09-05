using CSharp_ConsoleApplication.Classes;
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


    } // END
}
