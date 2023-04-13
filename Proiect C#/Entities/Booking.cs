using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_C_.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Guid RoomId { get; set; }
        public decimal TotalCost { get; set; }
        public string Location { get; set; }
        public string Place { get; set; }
        public string Building { get; set; }
        public int RoomNumber { get; set; }
        public int BDId { get; set; }
        public RoomType RoomType { get; set; }
        public bool HasBalcony { get; set; }
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }

        public Booking()
        {
            Id = Guid.NewGuid();
        }
        public Booking(Client client, DateTime checkIn, DateTime checkOut, Room room, string location, string place, string building):this()
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            RoomId = room.Id;
            TotalCost = (decimal)Math.Round((checkOut - checkIn).TotalDays) * room.PricePerNight;
            Location = location;
            Place = place;
            Building = building;
            RoomNumber = room.Number;
            BDId = client.BDId;
            RoomType = room.Type;
            HasBalcony = room.HasBalcony;
            Floor = room.Floor;
            PricePerNight = room.PricePerNight;
        }
    }
}
