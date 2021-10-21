using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetDDScraping
{
    class NetDDScrapingTask
    {
        public void Run()
        {
            #region "options"
            var options = new ChromeOptions();
            options.AddArgument("--disable-background-timer-throttling");
            options.AddArgument("--disable-backgrounding-occluded-windows");
            options.AddArgument("--disable-breakpad");
            options.AddArgument("--disable-component-extensions-with-background-pages");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-features=TranslateUI,BlinkGenPropertyTrees");
            options.AddArgument("--disable-ipc-flooding-protection");
            options.AddArgument("--disable-renderer-backgrounding");
            options.AddArgument("--enable-features=NetworkService,NetworkServiceInProcess");
            options.AddArgument("--force-color-profile=srgb");
            options.AddArgument("--hide-scrollbars");
            options.AddArgument("--metrics-recording-only");
            options.AddArgument("--mute-audio");
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            #endregion

            var driver = new RemoteWebDriver(
                new Uri("http://IP:3000/webdriver"), options);

            var basePath = "https://net.developerdays.pl/faq/";
            driver.Navigate().GoToUrl(basePath);
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();

            var html = driver.PageSource;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class,'vc_toggle ')]")
                .ToArray();

            foreach (var node in nodes)
            {
                var title = node.SelectNodes("./div").First().InnerText;
                var content = node.SelectNodes("./div").Skip(1)
                    .First().InnerText;
                Console.WriteLine($"Question: {title}");
                Console.WriteLine($"Answer: {content}");
            }

            driver.Dispose();
        }

        public void Run2()
        {
            var driver = new ChromeDriver();

            var basePath = "https://net.developerdays.pl/contact/";
            driver.Navigate().GoToUrl(basePath);
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();


            driver.Compile("//input[@name='your-name']","Rob");
            driver.Compile("//input[@name='your-email']", "child@ocdstudio.net");
            driver.Compile("//input[@name='your-subject']", "Hello Organizers!");
            driver.Compile("//textarea[@name='your-message']", "Sorry about that!");

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }

    public static class Extensions
    {
        public static IWebDriver Compile(this IWebDriver self,string xpath,
            string text)
        {
            var element = self.FindElement(By.XPath(xpath));
            element.Click();
            element.SendKeys(text);
            return self;
        }
    }
}
