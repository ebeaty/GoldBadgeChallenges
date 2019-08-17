using System;
using System.Collections.Generic;
using CafeMenuRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeMenuTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AddItemToMenu()
        {
            //arrange
            MenuItem newItem = new MenuItem(4, "Pizza", "all the toppings", "all of them", 10.50);
            CafeMenuRepository repo = new CafeMenuRepository();
            repo.Seed();

            //act
            repo.AddMenuItem(newItem);

            //assert
            int actual = repo.GetMenu().Count;
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void RemoveMenuItem()
        {
            //arrange
            CafeMenuRepository repo = new CafeMenuRepository();
            repo.Seed();

            //act
            repo.RemoveItemFromMenu(1);

            //assert
            int actual = repo.GetMenu().Count;
            Assert.AreEqual(0, actual);
        }
    }
}
