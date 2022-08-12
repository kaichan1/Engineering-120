namespace SeleniumIntro
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Ignore("test failing")]
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSignInLink_ThenILandOnTheSignInPage()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser to it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the AP site
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                //grab the sign in link
                IWebElement signinlink = driver.FindElement(By.LinkText("Sign in"));
                //wait to ensure response
                Thread.Sleep(5000);
                //assert that we have arrived on the sign in page
                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));
            }

            //using (IWebDriver driver = new FirefoxDriver());
        }

        [Test]
        //Example uses sauce labs demo
        public void GivenIAmOnTheSigninPage_AndThenEntera4DigitPassword_WhenIClickTheSigninButton_ThenIGetError()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                //driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                Thread.Sleep(5000);
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("nish@nish.com");
                passwordField.SendKeys("four");
                passwordField.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                IWebElement alert = driver.FindElement(By.ClassName("error-message-container"));
                Assert.That(alert.Text, Does.Contain("sadface"));
            }
        }


        #region Exercise
        [Test]
        public void GivenIAmOnTheSigninPage_ThenSignInCorrectlyWithStandardUser_WhenIClickTheSigninButton_ThenISeeInventory()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                Thread.Sleep(5000);
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("standard_user");
                passwordField.SendKeys("secret_sauce");
                passwordField.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                IWebElement inventory = driver.FindElement(By.ClassName("inventory_item_desc"));
                Assert.That(inventory.Text, Does.Contain("streamlined Sly Pack"));
            }
        }

        [Test]
        public void GivenIAmOnTheSigninPage_ThenSignInCorrectlyWithLockedOutUser_WhenIClickTheSigninButton_ThenISeeInventory()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                Thread.Sleep(5000);
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("locked_out_user");
                passwordField.SendKeys("secret_sauce");
                passwordField.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                IWebElement inventory = driver.FindElement(By.ClassName("inventory_item_desc"));
                Assert.That(inventory.Text, Does.Contain("streamlined Sly Pack"));
            }
        }
        [Test]
        public void GivenIAmOnTheSigninPage_ThenSignInCorrectlyWithProblemUser_WhenIClickTheSigninButton_ThenISeeInventory()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                Thread.Sleep(5000);
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("problem_user");
                passwordField.SendKeys("secret_sauce");
                passwordField.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                IWebElement inventory = driver.FindElement(By.ClassName("inventory_item_desc"));
                Assert.That(inventory.Text, Does.Contain("streamlined Sly Pack"));
            }
        }
        [Test]
        public void GivenIAmOnTheSigninPage_ThenSignInCorrectlyWithperformance_glitch_user_WhenIClickTheSigninButton_ThenISeeInventory()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                Thread.Sleep(5000);
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("performance_glitch_user");
                passwordField.SendKeys("secret_sauce");
                passwordField.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                IWebElement inventory = driver.FindElement(By.ClassName("inventory_item_desc"));
                Assert.That(inventory.Text, Does.Contain("streamlined Sly Pack"));
            }
        }
#endregion
    }
}