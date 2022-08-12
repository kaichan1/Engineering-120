using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_HomePage
    {
        #region Properties and fields
        private IWebDriver _seleniumDriver;
        private string _homePageUrl = AppConfigReader.BaseUrl;
        private IWebElement _signInLink => _seleniumDriver.FindElement(By.LinkText("Sign in"));
        //private IWebElement _signInLink
        //{
        //    get { return _seleniumDriver.FindElement(By.LinkText("Sign in")); }
        //}
        private IWebElement _addCartButton => _seleniumDriver.FindElement(By.ClassName("button ajax_add_to_cart_button btn btn-default"));
        private IWebElement _checkout => _seleniumDriver.FindElement(By.ClassName("btn btn-default button-medium"));
        private IWebElement _products => _seleniumDriver.FindElement(By.ClassName("cart_block_list")).FindElement(By.ClassName("products"));
        public IWebElement Products => _products;

        #endregion
        public AP_HomePage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;



        #region Methods
        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void VisitSignInPage() => _signInLink.Click();
        public void ClickAddCart() => _addCartButton.Click();
        #endregion
    }
}
