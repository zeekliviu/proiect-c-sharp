using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_C_.Entities
{
    public class Room
    {
        public int Number { get; set; }
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }
        public bool HasBalcony { get; set; }
        public Room()
        {
        }
        public Room(int number, RoomType type, decimal pricePerNight, int floor, bool hasBalcony):this()
        {
            Number = number;
            Type = type;
            PricePerNight = pricePerNight;
            Floor = floor;
            HasBalcony = hasBalcony;
        }
    }
}
