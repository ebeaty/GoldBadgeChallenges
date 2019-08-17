using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingRepository
{
    public class OutingRepo
    {
        private List<Outing> _listOfOutings = new List<Outing>();

        public List<Outing> GetList()
        {
            return _listOfOutings;
        }

        public void AddNewOuting(Outing outing)
        {
            _listOfOutings.Add(outing);
        }

        public double CostByType(EventType eventType)
        {
            List<Outing> listOfOutings = GetOutingByType(eventType);
            double totalCost = 0.0d;
            foreach (Outing outing in listOfOutings)
            {
                totalCost += outing.TotalOutingCost;
            }
            return totalCost;
        }

        private List<Outing> GetOutingByType(EventType eventType)
        {
            List<Outing> outingList = new List<Outing>();
            foreach (Outing item in _listOfOutings)
            {
                if (item.OutingType == eventType)
                {
                    outingList.Add(item);
                }
            }
            return (outingList);

        }

        public double TotalCost()
        {
            double totalCost = 0.0d;
            foreach (Outing item in _listOfOutings)
            {
                totalCost += item.TotalOutingCost;
            }
            return totalCost;
        }

        public void Seed()
        {
            Outing kingsIsland = new Outing(EventType.AmusementPark, 100, new DateTime(2019, 10,31), 45d, 4500d);
            _listOfOutings.Add(kingsIsland);
        }
    }
}
