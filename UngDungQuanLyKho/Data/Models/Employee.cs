using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungQuanLyKho.Data.Models
{
    class Employee
    {
        private string email;
        private string password;

        //Constructor khong chua tham so
        public Employee()
        {
        }

        //Constructor chua tham so
        public Employee(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        //Thuoc tinh get set de lay du lieu tu csdl ra
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
