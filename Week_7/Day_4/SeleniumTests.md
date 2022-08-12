## Optional Walkthroughs

### Mouse Hover Action

```c#
public void GivenIAmOnTheDragAndDropPage_WhenIDragBoxAToBoxB_ThenTheBoxesHaveSwitchedPositions()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the drag and drop page<header>A</header>
                driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
                //Get Element - get box positions
                IWebElement columnA = driver.FindElement(By.Id("draggable"));
                IWebElement columnB = driver.FindElement(By.Id("droppable"));
                IWebElement output = driver.FindElement(By.Id("droppable")).FindElement(By.TagName("p"));
                ////Drag and drop item
                Actions action = new Actions(driver);
                action.DragAndDrop(columnA, columnB).Perform();
                Thread.Sleep(3000);
                //Assert - that box has changed
                Assert.That(output.Text, Is.EqualTo("Dropped!"));
            }
        }
```

### Handling Multiple Windows

```c#
[Test]
public void HandlingMultipleWindowsTest()
{
    using (IWebDriver driver = new ChromeDriver())
    {
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.computerhope.com/");
        //var homePage = driver.WindowHandles;
        var twitterLink = driver.FindElement(By.LinkText("Twitter"));
twitterLink.Click();
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        Thread.Sleep(5000);
        driver.Close();
        driver.SwitchTo().Window(driver.WindowHandles[0]);
        Assert.That(driver.Title, Is.EqualTo("Computer Hope's Free Computer Help"));
        var helpLink = driver.FindElement(By.LinkText("Help"));
        helpLink.Click();
        Assert.That(driver.Title, Is.EqualTo("Computer Online Help"));
        driver.Navigate().Back();
        Assert.That(driver.Title, Is.EqualTo("Computer Hope's Free Computer Help"));
        driver.Quit();
    }
}
```

The above is a poor test, however it's contrived example which can be used to help understand how to handle multiple windows.

### Handling basic Authorisation window with sign in 

```c#
[Test]
public void PopupSignInExample()
{
    using (var driver = new ChromeDriver())
    {
        driver.Manage().Cookies.DeleteAllCookies();
        driver.Manage().Window.Maximize();
        //we can inject the username and password (both which are "admin") into the URL 
        // http://username:password@practicesite.com
        driver.Navigate().GoToUrl("http://admin:admin@the-internet.herokuapp.com/basic_auth");
        var text = driver.FindElement(By.CssSelector("p")).Text;
        Assert.That(text, Does.Contain("Congratulations"));
    }
}
```

### Web Scraping

```c#
static void Main(string[] args)
{
    IReadOnlyCollection<IWebElement> results;
    using (var driver = new ChromeDriver())
    {
        driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        driver.Manage().Cookies.DeleteAllCookies();
        var search = driver.FindElement(By.Id("search_query_top"));
        search.SendKeys("Dress");
        search.SendKeys(Keys.Enter);
        results = driver.FindElements(By.ClassName("ajax_block_product"));
        using (StreamWriter sw = File.CreateText("results.csv"))
        {
            sw.WriteLine("item,price,in_stock");
            foreach (var item in results)
            {

                Console.WriteLine(item.Text);
                string result = "";
                string[] lines = item.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    result += line + ",";
                }
                sw.WriteLine(result);

            }
        }
    }
}
```

The line `string[] lines = item.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);`, can also be written as:

```c#
string[] stringSeparators = new string[] { "\r\n" };
string[] lines = item.Text.Split(stringSeparators, StringSplitOptions.None);
```

