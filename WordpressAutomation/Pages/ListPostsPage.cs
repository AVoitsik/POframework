using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WordpressAutomation
{
    public class ListPostsPage
    {

        private static int lastCoint;

        public static int PreviousPostCount
        {
            get { return lastCoint; }
        }

        public static int CurrentPostCount
        {
            get { return GetPostsCount(); }
        }

        //refactor to make navigation
        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;
                case PostType.Post:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCoint = GetPostsCount();
        }


        private static int GetPostsCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(()=>links = row.FindElements(By.LinkText(title)));
                if (links.Count>0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }

            }


        }

        public static void SearchForPost(string searchString)
        {
            if (!IsAt)
                GoTo(PostType.Post);
            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButtom = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButtom.Click();   
        }

        public static bool IsAt
        {
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                {
                    var check = h1s[0].Text;
                    return h1s[0].Text == "Posts";
                }
                return false;
            }
        }
    }

    public enum PostType
    {
        Page,
        Post
    }
}
