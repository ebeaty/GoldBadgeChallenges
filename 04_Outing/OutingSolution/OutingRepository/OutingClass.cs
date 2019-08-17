using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingRepository
{
    public enum EventType
    {
        Golf =1,
        Bowling,
        AmusementPark,
        Concert
    }

    public class Outing
    {
        public EventType OutingType { get; set; }
        public int OutingAttendance { get; set; }
        public DateTime OutingDate { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalOutingCost { get; set; }

        public Outing() { }
        public Outing(EventType outingType, int outingAttendance, DateTime outingDate, double costPerPerson, double totalOutingCost)
        {
            OutingType = outingType;
            OutingAttendance = outingAttendance;
            OutingDate = outingDate;
            CostPerPerson = costPerPerson;
            TotalOutingCost = totalOutingCost;
        }
    }
}
