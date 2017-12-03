using System;
using OpenQA.Selenium;
using System.Threading;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
            
        }



        public static CreatePostComand CreatePost(string title)
        {
            var command = new CreatePostComand(title);

            return command;
        }

        public class CreatePostComand
        {
            private readonly string title;
            private string body;
            public CreatePostComand(string title)
            {
                this.title = title;
            }

            public CreatePostComand WithBody(string body)
            {
                this.body = body;
                return this;
            }

            public void Publish()
            {
                Driver.Instance.FindElement(By.ClassName("mce-close")).Click();
                Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

                Driver.Instance.SwitchTo().Frame("content_ifr");
                Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
                Driver.Instance.SwitchTo().DefaultContent();

                Driver.Wait(TimeSpan.FromSeconds(5));
                Driver.Instance.FindElement(By.Id("publish")).Click();

            }
        }

        public static void GotoNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            //return Driver.Instance.FindElement(By.Id("icon-edit-pages")) != null;

            var h1s = Driver.Instance.FindElements(By.TagName("h1"));
            if (h1s.Count > 0)
            {
                var check = h1s[0].Text;
                return h1s[0].Text == "Edit Page";
            }
            return false;
        }

        public static object Title 
        { 
            
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }
    }
}
