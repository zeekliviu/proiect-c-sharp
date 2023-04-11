using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_C_.Entities
{
    internal class Booking
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Guid RoomId { get; set; }
        public decimal TotalCost { get; set; }
        public Booking()
        {
            Id = Guid.NewGuid();
        }
        public Booking(Client client):this()
        {
            ClientId = client.Id;
        }
    }
}
