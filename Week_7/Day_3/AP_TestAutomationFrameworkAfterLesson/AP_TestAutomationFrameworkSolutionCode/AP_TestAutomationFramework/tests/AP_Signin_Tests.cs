namespace AP_TestAutomationFramework.tests
{
    public class Tests
    {
        private AP_Website<ChromeDriver> AP_Website = new();

        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_ThenIShouldLandOnTheSignInPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            Thread.Sleep(5000);
            AP_Website.AP_HomePage.VisitSignInPage();
            Thread.Sleep(5000);
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Login - My Store"));
        }

        [Test]
        public void GivenIAmOnTheSignInPage_WhenIEnterA4DigitPassword_ThenIGetAnErrorMessage()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
            Thread.Sleep(5000);
            AP_Website.AP_SigninPage.InputEmail("myemail@email.com");
            AP_Website.AP_SigninPage.InputPassword("1234");
            AP_Website.AP_SigninPage.ClickSubmit();
            Thread.Sleep(5000);
            Assert.That(AP_Website.AP_SigninPage.ErrorList, Does.Contain("Invalid password"));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}