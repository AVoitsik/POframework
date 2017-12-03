using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace WordpressAutomation
{
    public  class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseAddress {
            get { return "http://localhost:56714/"; } 
        }

        public static void Initialize()
        {
           
           // options.AddAdditionalCapability("unexpectedAlertBehaviour",true);
            //ICapabilities cap = new DesiredCapabilities();
            //cap.
            Instance = new FirefoxDriver();
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--nosuch");
            DesiredCapabilities cap = new DesiredCapabilities();
            //Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            TurnOnWait();
        }


        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan fromSeconds)
        {
            Thread.Sleep((int)fromSeconds.TotalSeconds * 1000);
            //Thread.Sleep(fromSeconds);
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
