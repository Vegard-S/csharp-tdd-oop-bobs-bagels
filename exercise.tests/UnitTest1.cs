using exercise.main.Shop;
using exercise.main.Shop.Products;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddBagel()
    {
        //arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");

        //act
        basket.Add(bagel);
        

        //assert
        Assert.That(basket._products[0].SKU, Is.EqualTo("BGLO"));
    }
    
    [Test]
    public void RemoveBagel()
    {
        //arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Bagel bagel2 = new Bagel(2, "BGLS", 0.39, "Bagel", "Plain");
        basket.Add(bagel);
        basket.Add(bagel2);

        //act
        basket.Remove(bagel);

        //assert
        Assert.That(basket._products[0].SKU, Is.EqualTo("BGLS"));
        Assert.That(basket._products[0].Variant, Is.EqualTo("Plain"));
    }
    
    [Test]
    public void CheckFull()
    {
        //arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Bagel bagel2 = new Bagel(2, "BGLS", 0.39, "Bagel", "Plain");
        Bagel bagel3 = new Bagel(3, "BGLS", 0.39, "Bagel", "Plain");
        basket.Add(bagel);
        basket.Add(bagel2);
        basket.Add(bagel3);


        //act
        bool checkFull = basket.CheckFull();

        //assert
        Assert.IsTrue(checkFull);
        Assert.That(basket._products.Count(), Is.EqualTo(2));
    }

    
    [Test]
    public void ChangeCapacity()
    {
        //arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Bagel bagel2 = new Bagel(2, "BGLS", 0.39, "Bagel", "Plain");
        Bagel bagel3 = new Bagel(3, "BGLS", 0.39, "Bagel", "Plain");
        basket.Add(bagel);
        basket.Add(bagel2);
        basket.Add(bagel3);

        //act
        bool checkFull = basket.CheckFull();
        basket.ChangeCapacity(4);
        bool checkFull2 = basket.CheckFull();


        //assert
        Assert.IsTrue(checkFull);
        Assert.IsFalse(checkFull2);
    }
    
    [Test]
    public void CheckIfExists()
    {
        //arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Bagel bagel2 = new Bagel(2, "BGLS", 0.39, "Bagel", "Plain");
        basket.Add(bagel);
        basket.Add(bagel2);


        Bagel bagel3 = new Bagel(3, "BGLE", 0.49, "Bagel", "Everything");

        //act
        bool result = basket.Remove(bagel);
        bool result2 = basket.Remove(bagel3);

        //assert
        Assert.IsTrue(result);
        Assert.IsFalse(result2);
    }

    

    [Test]
    public void BasketTotal()
    {
        //arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Bagel bagel2 = new Bagel(2, "BGLS", 0.39, "Bagel", "Plain");

        basket.Add(bagel);
        basket.Add(bagel2);


        //act
        double result = basket.BasketTotal;

        //assert
        Assert.That(result, Is.EqualTo(0.88));
    }

    
    
    [Test]
    public void ShowBagelPrice()
    {
        //arrange
        Basket basket = new Basket();


        //act
        double result = basket.ShowBagelPrice("BGLO");
        double result2 = basket.ShowBagelPrice("COFB");
        double result3 = basket.ShowBagelPrice("FILB");

        //assert
        Assert.That(result, Is.EqualTo(0.49));
        Assert.That(result2, Is.EqualTo(0));
        Assert.That(result3, Is.EqualTo(0));
    }

    
   
    [Test]
    public void AddFilling() 
    {
        //arrange
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Filling filling = new Filling(1, "FILB", 0.12, "Filling", "Bacon");

        //act
        bagel.AddFilling(filling);
        

        //assert
        Assert.That(bagel.Fillings.Count, Is.EqualTo(1));
    }

    [Test]
    public void ShowFillingPrice()
    {
        //arrange
        Basket basket = new Basket();


        //act
        double result = basket.ShowFillingPrice("BGLO");
        double result2 = basket.ShowFillingPrice("COFB");
        double result3 = basket.ShowFillingPrice("FILB");

        //assert
        Assert.That(result, Is.EqualTo(0));
        Assert.That(result2, Is.EqualTo(0));
        Assert.That(result3, Is.EqualTo(0.12));
    }
    
    [Test]
    public void CheckInventory()
    {
        //arrange
        Basket basket = new Basket();


        //act
        bool result = basket.CheckInventory("BGLO");
        bool result2 = basket.CheckInventory("BGLA");

        //assert
        Assert.IsTrue(result);
        Assert.IsFalse(result2);
    }
    
    [Test]
    public void CheckDiscountTotal()
    {

        // Arrange
        Basket basket = new Basket();

        basket.ChangeCapacity(100);

        // Add 7 onion bagels
        for (int i = 0; i < 7; i++)
        {
            basket.Add(new Bagel(i, "BGLO", 0.49, "Bagel", "Onion"));
        }

        // Add 13 plain bagels
        for (int i = 0; i < 13; i++)
        {
            basket.Add(new Bagel(i + 7, "BGLP", 0.39, "Bagel", "Plain"));
        }

        // Add 2 coffees
        basket.Add(new Coffee(0, "COFB", 0.99, "Coffee", "Black"));
        basket.Add(new Coffee(1, "COFB", 0.99, "Coffee", "Black"));

        // Act
        double total = basket.NewBasketTotal();

        // Assert
        // Discounts
        // - 6 onion = 2.49
        // - 12 plain = 3.99
        // - 2 coffee combos  2 * 1.25 = 2.50
        // Total = 2.49 + 3.99 + 2.50 = 8.98
        Assert.That(total, Is.EqualTo(8.98));


    }
}