using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ConsoleApplication.Classes
{
    class Post
    {
        // ATRIBUTES
        private string user;
        private string text;

        // CONSTRUCTOR
        public Post(string user, string text)
        {
            this.user = user;
            this.text = text;
        }

        // METHODS

        // GETTERS AND SETTERS
        public string User { get => user; set => user = value; }
        public string Text { get => text; set => text = value; }
    }
}
