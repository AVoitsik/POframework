using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {

            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "wp-login.php");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("http://localhost:14694/wp-login.php");

            //var check = Driver.Instance.Manage().Cookies.AllCookies;
            //Driver.Instance.Manage().Window.FullScreen();
            //var check2 = Driver.Instance.Manage().Logs.AvailableLogTypes;
            //var check3 = Driver.Instance.Manage().Timeouts().PageLoad = TimeSpan.MaxValue;

        
            
            //var check1 = Driver.Instance.Url;
            ////var check2 = Driver.Instance.CurrentWindowHandle;
            //var check3 = Driver.Instance.PageSource;
            //var check4 = Driver.Instance.Title;
            //var check5 = Driver.Instance.WindowHandles;


            //Driver.Instance.Navigate().GoToUrl("http://www.tut.by");
            //Driver.Instance.Navigate().Back();
            //Driver.Instance.Navigate().Forward();
            //Driver.Instance.Navigate().Refresh();

            var check = Driver.Instance.SwitchTo().ActiveElement();
            //var check1= Driver.Instance.SwitchTo().Alert();
            var check2 = Driver.Instance.SwitchTo().DefaultContent();
            //var check3 = Driver.Instance.SwitchTo().Frame(check);
            var check4 = Driver.Instance.SwitchTo().ParentFrame();
            //var check5= Driver.Instance.SwitchTo().Window();
            


        }


        public static LoginCommand LoginAs(string name)
        {
            return new LoginCommand(name);
        }


        public class LoginCommand
        {
            private string name;
            private string password;
            public LoginCommand(string name)
            {
                this.name = name;

            }
            public LoginCommand WithPassword(string pwd)
            {
                this.password = pwd;
                return this;
            }

            public void Login()
            {
                var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
               loginInput.SendKeys(name);

                var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
                passwordInput.SendKeys(password);

                var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
                loginButton.Click();
            }
        }
    }
}
