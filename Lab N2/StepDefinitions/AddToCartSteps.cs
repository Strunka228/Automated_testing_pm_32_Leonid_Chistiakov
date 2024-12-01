using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemoTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_N2.StepDefinitions
{
    [Binding]
    public class AddToCartSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;

        public AddToCartSteps()
        {
            _driver = new ChromeDriver(); // Переконайтесь, що у вас встановлений ChromeDriver
            _loginPage = new LoginPage(_driver);
            _inventoryPage = new InventoryPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        [Given(@"I am logged in as ""(.*)""")]
        public void GivenIAmLoggedInAs(string username)
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage.Login(username, "secret_sauce");
        }

        [When(@"I add the product ""(.*)"" to the cart")]
        public void WhenIAddTheProductToTheCart(string productName)
        {
            _inventoryPage.AddToCart(productName);
        }

        [Then(@"the product ""(.*)"" should be in the cart")]
        public void ThenTheProductShouldBeInTheCart(string productName)
        {
            _cartPage.VerifyProductInCart(productName);
        }
    }
}
