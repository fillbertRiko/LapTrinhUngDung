using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVatTuKhoHang.Auth
{
    class Employee
    {
        private string username;
        private string password;

        public Employee()
        {
        }

        public Employee(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

    }

}
