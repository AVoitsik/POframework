using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
namespace WordPressTests
{
    [TestClass]
    public class PageTests : WordpressTest
    {

        
        [TestMethod]
        public void Can_Edit_A_Page()
        {

            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual(NewPostPage.Title, "Sample Page","Title did not match");




            //NewPostPage.GoTo();
            //NewPostPage.CreatePost("This is the test post title").WithBody("Hi, this is the body...").Publish();

            //NewPostPage.GotoNewPost();
            //Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post");

        }

        
    }
}
