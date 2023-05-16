/*
 Đồ án cấu trúc dữ liệu & giải thuật
 Họ tên: Trần Thị Hạnh
        Đặng Thị Bích Ngọc

 Class: Admin
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTDL
{
    class Admin : User

    {
        //fields
        private string userName, password;
        private LinkedList<Admin> listAdmin;

        // Contructor
        public Admin()
        {
            listAdmin = new LinkedList<Admin>();
        }
        public Admin(string userName, string password)
        {
            listAdmin = new LinkedList<Admin>();
            this.UserName = userName;
            this.Password = password;
        }
        public Admin(string userName, string fullName, string address, string phoneNumber, string email) : base(userName, fullName, address, phoneNumber, email)
        {
            listAdmin = new LinkedList<Admin>();
            this.UserName = userName;
            this.FullName = fullName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        // properties
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }
    }
}
