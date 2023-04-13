using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_C_.Entities
{
    public class Client
    {
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int BDId { get; set; }
        
        public Client()
        {
            Id = Guid.NewGuid();
        }
        public Client(string firstName, string lastName, byte[] photo, string email, string phone, string password, int bdId): this()
        {
            FirstName = firstName;
            LastName = lastName;
            ProfilePicture = new byte[photo.Length];
            Array.Copy(photo, ProfilePicture, photo.Length);
            Email = email;
            Phone = phone;
            Password = password;
            BDId = bdId;
        }

    }
}
