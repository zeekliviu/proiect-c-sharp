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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePicture { get; set; }
        
        public Client()
        {
        }
        public Client(string firstName, string lastName, byte[] photo, string email, string phone): this()
        {
            FirstName = firstName;
            LastName = lastName;
            ProfilePicture = new byte[photo.Length];
            Array.Copy(photo, ProfilePicture, photo.Length);
            Email = email;
            Phone = phone;
        }
    }
}
