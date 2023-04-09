using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_C_.Entities
{
    internal class Room
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }
        public bool HasBalcony { get; set; }
        public Room()
        {
            Id = Guid.NewGuid();
        }
    }
}
