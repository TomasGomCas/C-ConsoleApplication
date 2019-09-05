using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ConsoleApplication.Classes
{
    class Muro
    {
        // ATRIBUTES
        private List<Post> posts;

        // CONSTRUCTOR
        public Muro(List<Post> posts)
        {
            this.posts = posts;
        }

        // METHODS

        // INHERITED METHODS
        public override string ToString()
        {
            string text = "";
            foreach (Post post in this.posts)
            {
                text = text + " // USER: " + post.User + " // TEXT: " + post.Text + "\n\n";
            }

            return text;
        }

        // GETTERS AND SETTERS
        internal List<Post> Posts { get => posts; set => posts = value; }

    } // END
}
