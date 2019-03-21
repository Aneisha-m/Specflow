using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Eng24SeleniumSpecflow
{
    [Binding]
    public class BbcLoginSteps
    {
        private IWebDriver _driver;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://bbc.co.uk");
            IWebElement loginButton = _driver.FindElement(By.Id("idcta-link"));
            loginButton.Click();
        }
        
        [Given(@"I entered a valid username")]
        public void GivenIEnteredAValidUsername()
        {
            IWebElement usernameField = _driver.FindElement(By.Id("user-identifier-input"));
            usernameField.SendKeys("testing@gurney.com");
        }
        
        [Given(@"I have entered a invalid password")]
        public void GivenIHaveEnteredAInvalidPassword()
        {
            IWebElement passwordField = _driver.FindElement(By.Id("password-input"));
            passwordField.SendKeys("12345678");
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            IWebElement submmitButton = _driver.FindElement(By.Id("submit-button"));
            submmitButton.Click();
        }
        
        [Then(@"I shlould see the appropriate error")]
        public void ThenIShlouldSeeTheAppropriateError()
        {
            IWebElement passwordError = _driver.FindElement(By.Id("form-message-password"));
            Assert.AreEqual("Sorry, that password isn't valid. Please include a letter.", passwordError.Text);
        }
    }
}
