using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVatTuKhoHang.QuanLyVatTuKhoHang.Models
{
    public class Employee
    {
        //an cac truong du lieu
        private string username;
        private string password;

        //tao constructor cho method employee
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
