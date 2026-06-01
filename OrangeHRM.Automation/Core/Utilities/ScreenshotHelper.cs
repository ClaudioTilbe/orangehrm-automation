using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OrangeHRM.Automation.Core.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                string folder =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "Reports",
                        "Screenshots");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

                string fileName = $"{testName}_{timestamp}.png";

                string fullPath = Path.Combine(folder, fileName);

                screenshot.SaveAsFile(fullPath);

                LoggerHelper.Info($"Screenshot saved: {fullPath}");
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }




}
