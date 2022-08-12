using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_SigninPage
    {
        #region Properties and fields
        private IWebDriver _seleniumDriver;
        private string _signinPageUrl = AppConfigReader.SignInPageUrl;
        private IWebElement _emailField => _seleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement _submitButton => _seleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _errorList => _seleniumDriver.FindElement(By.ClassName("alert-danger")).FindElement(By.TagName("ol"));
        public string ErrorList
        {
            get { return _errorList.Text; }
        }
        #endregion

        #region Methods
        //public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        //public void VisitSignInPage() => _signInLink.Click();
        #endregion
        public AP_SigninPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_signinPageUrl);
        public void InputEmail(string email) => _emailField.SendKeys(email);
        public void InputPassword(string password) => _passwordField.SendKeys(password);
        public void ClickSubmit() => _submitButton.Click();
    }
}
