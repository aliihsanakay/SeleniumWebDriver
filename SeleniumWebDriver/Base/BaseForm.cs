using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumWebDriver.Base
{
 public   class BaseForm:Form
    {
     public   IWebDriver driver;
        
        public BaseForm()
        {
            var relativePath = @"C:\Users\ALI\source\repos\EdgeDriverTest\EdgeDriverTest\bin\Debug\netcoreapp2.1";
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");//full screen ekran açar
            driver = new ChromeDriver(relativePath, options);

        }
        public void QuitSeleniumDriver()
        {
            driver.Quit();
        }
    }
}
