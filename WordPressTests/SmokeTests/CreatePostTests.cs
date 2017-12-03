using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordPressTests
{
     [TestClass]
    public class CreatePostTests:WordpressTest
    {

        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title").WithBody("Hi, this is the body...").Publish();

            NewPostPage.GotoNewPost();
            Assert.AreEqual(PostPage.Title, "This is the test post title","Title did not match new post");

        }

    }
}
