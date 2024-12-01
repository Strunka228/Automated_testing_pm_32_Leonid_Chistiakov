using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void VerifyProductInCart(string productName)
        {
            // Локатор продукту в кошику
            var productLocator = By.XPath($"//div[text()='{productName}']");
            var product = _driver.FindElement(productLocator);

            if (product == null)
            {
                throw new NotFoundException($"Product '{productName}' not found in the cart.");
            }
        }
    }
}
