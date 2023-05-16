/*
 Đồ án cấu trúc dữ liệu & giải thuật
 Họ tên: Trần Thị Hạnh
        Đặng Thị Bích Ngọc

 Class: User
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTDL
{
    class User
    {
        //Fields
        private string userName, passWord;
        private string fullName, address, phoneNumber, email;
        private LinkedList<User> listUser;
        //Constructor 
        public User()
        {
        }
        public User(string userName, string fullName, string address, string phoneNumber, string email)
        {
            this.UserName = userName;
            this.FullName = fullName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public User(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        //Properties
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
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

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }
    }
}
