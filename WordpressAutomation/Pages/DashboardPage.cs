using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class DashboardPage
    {
        //need to do it for all pages
        public static bool IsAt { 
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0) {
                    var check = h1s[0].Text;
                    return h1s[0].Text == "Dashboard";
                }
               return false;
            }
}
    }
}
