using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge
{
    public class BadgeObject
    {
        public int BadgeID { get; set; }
        public List<string> RoomAccess { get; set; }
    }

    public class BadgeRepo
    {
        private IDictionary<int, List<string>> _accessBadge = new Dictionary<int, List<string>>();

        public void Seed()
        {
            _accessBadge.Add(111, new List<string> { "A1", "A2" });
        }

        public void AddBadgeToDictionary(int badgeID)
        {
            _accessBadge.Add(badgeID, new List<string>());
        }

        public void AddRoomToBadge(int badgeID, string roomAccess)
        {
            var rooms = _accessBadge[badgeID];
            rooms.Add(roomAccess);
        }

        public IDictionary<int, List<string>> GetListOfBadges()
        {
            return _accessBadge;
        }
    }
}
