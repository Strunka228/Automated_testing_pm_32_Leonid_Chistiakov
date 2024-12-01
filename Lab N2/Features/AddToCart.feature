@setup_feature
Feature: Add to Cart
  As a standard user
  I want to add a product to the cart
  So that I can proceed to checkout

  Scenario: Add product to cart
    Given I am logged in as "standard_user"
    When I add the product "Sauce Labs Backpack" to the cart
    Then the product "Sauce Labs Backpack" should be in the cart
