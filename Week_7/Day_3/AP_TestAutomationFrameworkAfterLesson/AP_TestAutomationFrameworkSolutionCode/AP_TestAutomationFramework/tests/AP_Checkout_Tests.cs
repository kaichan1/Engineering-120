using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.tests
{
    public class AP_Checkout_Tests
    {
        private AP_Website<ChromeDriver> AP_Website = new();

        [Test]
        public void GivenIAmOnTheHomePage_WhenIAddAnItemToTheCart_ThenIGetAnItemInTheCart()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            Thread.Sleep(5000);
            AP_Website.AP_HomePage.ClickAddCart();
            Thread.Sleep(5000);
            var x = AP_Website.AP_HomePage.Products.FindElement(By.ClassName(""))
            Assert.That(, Does.Contain("Login - My Store"));
        }

        //[Test]
        //public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_ThenIShouldLandOnTheSignInPage()
        //{
        //    AP_Website.AP_HomePage.VisitHomePage();
        //    Thread.Sleep(5000);
        //    AP_Website.AP_HomePage.VisitSignInPage();
        //    Thread.Sleep(5000);
        //    Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Login - My Store"));
        //}

        //[Test]
        //public void GivenIAmOnTheSignInPage_WhenIEnterA4DigitPassword_ThenIGetAnErrorMessage()
        //{
        //    AP_Website.AP_SigninPage.VisitSignInPage();
        //    Thread.Sleep(5000);
        //    AP_Website.AP_SigninPage.InputEmail("myemail@email.com");
        //    AP_Website.AP_SigninPage.InputPassword("1234");
        //    AP_Website.AP_SigninPage.ClickSubmit();
        //    Thread.Sleep(5000);
        //    Assert.That(AP_Website.AP_SigninPage.ErrorList, Does.Contain("Invalid password"));
        //}
    }
}
