using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Common
{
    public class Browser
    {
        private IWebDriver driver;

        public Browser (IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Capture a screenshot using Selenium IWebDriver
        /// </summary>
        /// <returns></returns>
        public string GetScreenshot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;

            return img;
        }

        public string SaveScreenshot()
        {
            var fileName = Guid.NewGuid().ToString();
            var directory = Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                 + "\\screenshots\\").FullName;
            string filePath = directory + fileName;

            var file = ((ITakesScreenshot)driver).GetScreenshot();
            file.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return filePath;
        }
    }
}
