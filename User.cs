using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public enum Role 
    {
    Admin=0,
    User,
    Guest
    }

    [Serializable]
    class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Role UserRole { get; set; }

        public User(string login, string pass, string address, string pnumber, Role urole)
        {
            Login = login;
            Password = pass;
            Address = address;
            PhoneNumber = pnumber;
            UserRole = urole;
        }

        public override string ToString()
        {
            return $"{UserRole} - {Login}: {PhoneNumber}";
        }
    }
}
