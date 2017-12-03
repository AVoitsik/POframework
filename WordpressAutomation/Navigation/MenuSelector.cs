using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class MenuSelector
    {
        public static void Select(string TopLevelMenu, string SubMenu)
        {
            var menuPost = Driver.Instance.FindElement(By.Id(TopLevelMenu));
            menuPost.Click();

            var addNew = Driver.Instance.FindElement(By.LinkText(SubMenu));
            addNew.Click();
        }
    }
}