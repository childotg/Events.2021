using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Scraping
{
    internal class ScrapingTask
    {
        public ScrapingTask()
        {
        }

        public async Task RunAsync()
        {
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

            var driver = new RemoteWebDriver(
                new Uri("http://IP:3000/webdriver")
                , options);

            var baseUrl = "https://net.developerdays.pl/faq/";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            await Task.Delay(1000);


            var doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);

            var nodes=doc.DocumentNode.SelectNodes("//div[contains(@class,'vc_toggle ')]").ToArray();
            foreach (var node in nodes)
            {
                var title = node.SelectSingleNode("./div[@class='vc_toggle_title']").InnerText;
                var text = node.SelectSingleNode("./div[@class='vc_toggle_content']").InnerText;
                Console.WriteLine($"FAQ FOUND: ");
                Console.WriteLine($"Question: {title}");
                Console.WriteLine($"Answer: {text}");
            }
            

        }

        internal async Task SendEmail()
        {
            IWebDriver driver = new ChromeDriver(new ChromeOptions()
            {

            });

            var baseUrl = "https://net.developerdays.pl/contact/";
            driver.Navigate().GoToUrl(baseUrl);
            await Task.Delay(1000);

            driver.Manage().Window.Maximize();

            driver.Fill("//input[@name='your-name']", "Roberto Freato");
            driver.Fill("//input[@name='your-email']", "child@ocdstudio.net");
            driver.Fill("//input[@name='your-subject']", "Hello NETDdays");
            driver.Fill("//textarea[@name='your-message']", "Excuse me Maciej for the SPAM :)");
            driver.Click("//input[@type='submit']");
        }
    }

    public static class Extensions
    {
        public static IWebDriver Fill(this IWebDriver self, string xpath,string text)
        {
            var field = self.FindElement(By.XPath(xpath));
            field.Click();
            field.SendKeys(text);
            return self;
        }

        public static IWebDriver Click(this IWebDriver self,string xpath)
        {
            self.FindElement(By.XPath(xpath)).Click();
            return self;
        }
    }
}