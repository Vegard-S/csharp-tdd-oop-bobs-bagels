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

        //act
        basket.Add(2);

        //assert
        Assert.That(basket._products[0].SKU, Is.EqualTo("BGLP"));
    }

    [Test]
    public void RemoveBagel()
    {
        //arrange
        Basket basket = new Basket();
        basket.Add(2);
        basket.Add(4);

        //act
        basket.Remove(2);

        //assert
        Assert.That(basket._products[0].SKU, Is.EqualTo("BGLS"));
    }

    [Test]
    public void CheckFull()
    {
        //arrange
        Basket basket = new Basket();
        basket.Add(2);
        basket.Add(4);
        basket.Add(1);

        //act
        bool checkFull = basket.CheckFull();

        //assert
        Assert.IsTrue(checkFull);
    }


    [Test]
    public void ChangeCapacity()
    {
        //arrange
        Basket basket = new Basket();
        basket.Add(2);
        basket.Add(4);
        basket.Add(1);

        //act
        bool checkFull = basket.CheckFull();
        basket.ChangeCapacity(3);
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
        basket.Add(2);
        basket.Add(4);
        basket.Add(1);

        //act
        bool result = basket.CheckIfExists(2);
        bool result2 = basket.CheckIfExists(3);

        //assert
        Assert.IsTrue(result);
        Assert.IsFalse(result2);
    }


    [Test]
    public void BasketTotal()
    {
        //arrange
        Basket basket = new Basket();
        basket.Add(2);
        basket.Add(4);
        basket.Add(1);

        //act
        double result = basket.BasketTotal();

        //assert
        Assert.That(result, Is.EqualTo(1.37));
    }
    
    [Test]
    public void ShowBagelPrice()
    {
        //arrange
        Basket basket = new Basket();


        //act
        double result = basket.ShowBagelPrice(1);

        //assert
        Assert.That(result, Is.EqualTo(0.49));
    }

   
    [Test]
    public void AddFilling() 
    {
        //arrange
        Bagel bagel = new Bagel(1, "BGLO", 0.49, "Bagel", "Onion");
        Filling filling = new Filling(9, "FILB", 0.12, "Filling", "Bacon");

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
        double result = basket.ShowFillingPrice(9);

        //assert
        Assert.That(result, Is.EqualTo(0.12));
    }

    [Test]
    public void CheckInventory()
    {
        //arrange
        Basket basket = new Basket();


        //act
        bool result = basket.CheckInventory(1);
        bool result2 = basket.CheckInventory(15);

        //assert
        Assert.IsTrue(result);
        Assert.IsFalse(result2);
    }
    

}