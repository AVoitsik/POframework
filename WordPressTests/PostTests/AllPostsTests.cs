using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordPressTests.PostTests
{
    [TestClass]
    public class AllPostsTests:WordpressTest
    {
        [TestMethod]
        public void Added_Posts_ShowUp()
        {

            ListPostsPage.GoTo(PostType.Post);
            ListPostsPage.StoreCount();

            PostCreator.CreatePost();

            ListPostsPage.GoTo(PostType.Post);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts didn't increase");

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trach post");

        }

        [TestMethod]
        public void Can_Search_Posts()
        {

            PostCreator.CreatePost();
            //NewPostPage.GoTo();
            //NewPostPage.CreatePost("Searching posts, title")
            //    .WithBody("Searching posts, body")
            //    .Publish();

            //ListPostsPage.GoTo(PostType.Post);  change to Is At

            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            //Trash post(clean up)  - moved to PostCreator in TestCleanup(WOrdpressTests)
            //ListPostsPage.TrashPost(PostCreator.PreviousTitle);
        }

    }
}
