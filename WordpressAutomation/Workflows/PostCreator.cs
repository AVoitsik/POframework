using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class PostCreator
    {

        public static string PreviousTitle { get; set; }
        public static string PreviousBody { get; set; }
        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle)
                .WithBody(PreviousBody)
                .Publish();

            //NewPostPage.CreatePost("Searching posts, title")
            //    .WithBody("Searching posts, body")
            //    .Publish();
        }

        private static string CreateBody()
        {
            return CreateRandomString() + "body";
        }

       

        private static string CreateTitle()
        {
            return CreateRandomString() + "title";
        }

        private static string CreateRandomString()
        {
            var s = new StringBuilder();
            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" "); 
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" "); 
            }

            return s.ToString();
        }

        public static string[] Words = new[]
            {"red", "blue", "black", "white", "green", "grey"};

        public static string[] Articles = new[]
        {
            "cow", "dog", "cat", "horse", "pig", "elefant", "wolf"
        };


        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void Cleanup()
        {
            if (CreatedAPost)
                TrashPost();
        }

        private static void TrashPost()
        {
            ListPostsPage.TrashPost(PreviousTitle);
            Initialize();
        }

        public static bool CreatedAPost
        {
            get { return !String.IsNullOrEmpty(PreviousTitle); }
        }
    }
}
