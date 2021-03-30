using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        protected AppiumOptions opt;
        protected AppiumDriver<WindowsElement> session;
        public WebDriverWait wait;
        protected readonly string AppId = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\..\\..\\..\\..\\AVTest1\\bin\\debug\\AVTest1.exe";

        [OneTimeSetUp]
        public void SetupFixture()
        {
            opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", AppId);
            opt.AddAdditionalCapability("deviceName", "WindowsPC");
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), opt);
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            wait = new WebDriverWait(session, TimeSpan.FromSeconds(3));
        }

        [OneTimeTearDown]
        public void TestDownFixture()
        {
            session.CloseApp();
        }

        [Test]
        public void Test1()
        {
            wait.Until(e => e.FindElement(MobileBy.AccessibilityId("HWLabel"))).Text.Should().BeEquivalentTo("Hello World!");
        }
    }
}