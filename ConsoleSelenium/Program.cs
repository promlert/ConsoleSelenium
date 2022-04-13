// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

//WebDriver driver = new ChromeDriver();
//DesiredCapabilities cap = driver.Capabilities.GetCapability<DesiredCapabilities>();
//driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), cap);
IWebDriver driver;
ChromeOptions options = new ChromeOptions();
//Set Chrome to work with headless mode
options.AddArgument("–no-sandbox");
options.AddArguments("-disable-gpu");
options.AddArguments("-disable-dev-shm-usage");
options.AddArgument("-incognito");
options.AddArgument("-start-maximized");
options.AddUserProfilePreference("security.cookie_behavior", 0);
//Opens Chrome and disabling popups       
options.AddArguments("disable-popup-blocking");


//options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
//options.AddAdditionalCapability(CapabilityType.Platform, "WIN10", true);
//options.AddAdditionalCapability("key", "key", true);
//options.AddAdditionalCapability("secret", "secret", true);
//options.AddAdditionalCapability("name", "Promlert", true);

driver = new RemoteWebDriver(new Uri("http://192.168.136.129:4444/wd/hub"), options.ToCapabilities(),
                TimeSpan.FromSeconds(600));
driver.Navigate().GoToUrl("https://www.google.com");
Console.WriteLine(driver.Title);

IWebElement query = driver.FindElement(By.Name("q"));
query.SendKeys("selenium c#");
query.Submit();
Console.WriteLine(driver.Title);

Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
ss.SaveAsFile(@".\Image.png",
ScreenshotImageFormat.Png);
//WebElement ele = driver.findElement(By.id("hplogo"));

//// Get entire page screenshot
//File screenshot = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
//BufferedImage fullImg = ImageIO.read(screenshot);

//// Get the location of element on the page
//Point point = ele.getLocation();

//// Get width and height of the element
//int eleWidth = ele.getSize().getWidth();
//int eleHeight = ele.getSize().getHeight();

//// Crop the entire page screenshot to get only element screenshot
//BufferedImage eleScreenshot = fullImg.getSubimage(point.getX(), point.getY(),
//    eleWidth, eleHeight);
//ImageIO.write(eleScreenshot, "png", screenshot);

//// Copy the element screenshot to disk
//File screenshotLocation = new File("C:\\images\\GoogleLogo_screenshot.png");
//FileUtils.copyFile(screenshot, screenshotLocation);

driver.Quit();

