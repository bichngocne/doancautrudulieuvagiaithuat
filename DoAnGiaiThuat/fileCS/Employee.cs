/*
 Đồ án cấu trúc dữ liệu & giải thuật
 Họ tên: Trần Thị Hạnh
        Đặng Thị Bích Ngọc

 Class: Employee
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTDL
{
    class Employee : User
    {
        //Fields
        private string dangNhap;
        private LinkedList<Employee> listEmployee;


        //Constructor
        public Employee() : base()
        {
            listEmployee = new LinkedList<Employee>();
        }

        public Employee(string userName, string fullName, string address, string phoneNumber, string email,string dangNhap) : base(userName, fullName, address, phoneNumber, email)
        {
            this.DangNhap = dangNhap;
            listEmployee = new LinkedList<Employee>();
        }

        public Employee(string userName, string password) : base(userName, password)
        {
            this.UserName = userName;
            this.PassWord = password;
            listEmployee = new LinkedList<Employee>();
        }
        public Employee(string userName, string fullName, string address, string phoneNumber, string email) : base(userName, fullName, address, phoneNumber, email)
        {
            listEmployee = new LinkedList<Employee>();
            this.UserName = userName;
            this.FullName = fullName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
        //Properties
        public string DangNhap
        {
            get
            {
                return dangNhap;
            }

            set
            {
                dangNhap = value;
            }
        }
    }
}
