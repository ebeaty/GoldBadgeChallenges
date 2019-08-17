using System;
using System.Collections.Generic;
using Badge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeChallenge
{
    [TestClass]
    public class BadgeDictionary
    {
        BadgeRepo _repo = new BadgeRepo();

        [TestMethod]
        public void AddBadge()
        {
            _repo.Seed();

            _repo.AddBadgeToDictionary(112);

            Assert.IsTrue((_repo.GetListOfBadges()).ContainsKey(112));
        }

        [TestMethod]
        public void AddRoomToBadgeTest()
        {
            _repo.Seed();
            bool isAdded = false;

            _repo.AddRoomToBadge(111, "A111");

            List<string> rooms = _repo.GetListOfBadges()[111];
            foreach (string room in rooms)
            {
                if (room == "A111")
                {
                    isAdded = true;
                }
            }
            Assert.IsTrue(isAdded);
        }
    }
}
