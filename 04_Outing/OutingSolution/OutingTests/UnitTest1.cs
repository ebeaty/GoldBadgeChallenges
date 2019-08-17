using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutingRepository;

namespace OutingTests
{
    [TestClass]
    public class UnitTest1
    {
        private OutingRepo _repo = new OutingRepo();

        [TestMethod]
        public void AddOuting()
        {
            //arrange
            Outing Styx = new Outing(EventType.Concert, 80, new DateTime(2019, 11, 27), 50, 4000);

            //act
            _repo.AddNewOuting(Styx);
            int count = _repo.GetList().Count;

            //assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void CostByType()
        {
            //arrange
            _repo.Seed();
            Outing GolfDay = new Outing(EventType.Golf, 20, new DateTime(2019, 08, 14), 20d, 400d);
            Outing GolfNight = new Outing(EventType.Golf, 10, new DateTime(2019, 08, 15), 20d, 200d);

            //act
            _repo.AddNewOuting(GolfDay);
            _repo.AddNewOuting(GolfNight);
            double golfTotal = _repo.CostByType(EventType.Golf);

            //assert
            Assert.AreEqual(600d, golfTotal);
        }

        [TestMethod]
        public void TotalCost()
        {
            //arrange
            _repo.Seed();
            Outing Bowling = new Outing(EventType.Bowling, 10, new DateTime(2019, 06, 06), 10d, 100d);

            //act
            _repo.AddNewOuting(Bowling);

            double outingTotal = _repo.TotalCost();

            //assert
            Assert.AreEqual(4600d, outingTotal);
        }
    }
}
