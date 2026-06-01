using OrangeHRM.Automation.Core.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OrangeHRM.Automation.Components
{
    public class EmployeeFormComponent : BaseComponent
    {

        public EmployeeFormComponent(IWebDriver driver) : base(driver) { }

        // =========================
        // DROPDOWNS
        // =========================

        public void SelectOption(By dropdownLocator, By optionsLocator, string optionText)
        {
            var dropdown = wait.Until(d => d.FindElement(dropdownLocator));
            dropdown.Click();

            wait.Until(d => d.FindElements(optionsLocator).Count > 0);

            var options = driver.FindElements(optionsLocator);

            var option = options.First(o =>
                o.Text.Trim().Equals(optionText, StringComparison.OrdinalIgnoreCase));

            option.Click();
        }

        // =========================
        // RADIO BUTTONS
        // =========================

        public void SelectRadioOption(string groupLabel, string optionText)
        {
            By locator = By.XPath(
                $"//label[text()='{groupLabel}']/ancestor::div[contains(@class,'oxd-input-group')]//label[normalize-space()='{optionText}']");

            var option = wait.Until(d => d.FindElement(locator));
            option.Click();
        }

        public string GetSelectedRadioOption(string groupLabel)
        {
            var radios = driver.FindElements(By.XPath(
                $"//label[text()='{groupLabel}']/ancestor::div[contains(@class,'oxd-input-group')]//input[@type='radio']"));

            foreach (var radio in radios)
            {
                if (radio.Selected)
                {
                    return radio.FindElement(By.XPath("./parent::label")).Text.Trim();
                }
            }

            return string.Empty;
        }



    }
}
