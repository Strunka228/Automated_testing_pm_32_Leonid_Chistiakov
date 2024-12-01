using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddToCart(string productName)
        {
            // Очікуємо 10 секунд, поки елемент з'явиться на сторінці
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            By productLocator = By.CssSelector($"button[data-test='add-to-cart-{productName.ToLower().Replace(" ", "-")}']");

            bool isElementFound = false;

            for (int i = 0; i < 10; i++) // Максимум 10 секунд очікування
            {
                try
                {
                    var element = _driver.FindElement(productLocator);
                    element.Click();
                    isElementFound = true;
                    break;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(1000); // Чекаємо 1 секунду і пробуємо знову
                }
            }

            if (!isElementFound)
            {
                throw new NoSuchElementException($"Unable to locate and click element: {productLocator}");
            }
        }
    }
}