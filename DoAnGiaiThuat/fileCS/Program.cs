/*
 Đồ án cấu trúc dữ liệu & giải thuật
 Họ tên: Trần Thị Hạnh
        Đặng Thị Bích Ngọc

 Class: program
 * */
 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CTDL
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        //ghi file cho employee khi da dang nhap 
        static void WriteFileLogged(LinkedList<Employee> listEmpl, string username)
        {
            ReadFileLogged(listEmpl, username);
            //hien thi thoi gian dang nhap
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string temp = $"Da dang nhap {dt}";
            try
            {
                using (StreamWriter sW = new StreamWriter($"EmployeePrivateInformation\\{username}.txt"))
                {
                    for (LinkedListNode<Employee> p = listEmpl.First; p != null; p = p.Next)
                    {
                        if (p.Value.UserName == username)
                        {
                            sW.Write("");
                            break;
                        }
                        break;
                    }
                }
                using (StreamWriter sW = new StreamWriter($"EmployeePrivateInformation\\{username}.txt",true))
                {
                    for (LinkedListNode<Employee> p = listEmpl.First; p != null; p = p.Next)
                    {
                        if (p.Value.UserName == username)
                        {
                            sW.WriteLine($"{ p.Value.UserName}#{p.Value.FullName}#{p.Value.Address}#{p.Value.PhoneNumber}#{p.Value.Email}#{temp}");
                            break;
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file!!");
            }
        }
        //Doc file cho employee khi da dang nhap 
        static void ReadFileLogged(LinkedList<Employee> listEmpl, string username)
        {
            try
            {
                using (StreamReader sR = new StreamReader($"EmployeePrivateInformation\\{username}.txt"))
                {

                    while (sR.Peek() != -1)
                    {
                        string[] t = sR.ReadLine().Split('#');
                        Employee empl = new Employee(t[0], t[1], t[2], t[3], t[4], t[5]);
                        listEmpl.AddLast(empl);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
        }
        //doi mat khau tu dong cho employee khi dang nhap lan dau tien
        static void CheckFirstLogin(LinkedList<Employee> listEmpl, string username)
        {
            try
            {
                using (StreamReader sR = new StreamReader($"EmployeePrivateInformation\\{username}.txt"))
                {
                    while (sR.Peek() != -1)
                    {
                        string[] t = sR.ReadLine().Split('#');
                        if (t[5] == "Chua dang nhap lan dau")
                        {
                            Console.Clear();
                            ChangePassWord(listEmpl, username);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
            return;
        }
        //chuc nang cua employee : doi mat khau
        //cap nhat lai mat khau
        static void UpdatePassWords(LinkedList<Employee> empl, string username)
        {
            Console.WriteLine(username);
            using (StreamWriter sW = new StreamWriter("Employees.txt"))
            {
                for (LinkedListNode<Employee> p = empl.First; p != null; p = p.Next)
                {                
                        sW.WriteLine($"{p.Value.UserName}#{p.Value.PassWord}");
                }
            }
        }
        //thay doi mat khau
        static void ChangePassWord(LinkedList<Employee> empl, string userName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\t*****************************************");
            Console.WriteLine("\t*\t\t\t\t\t*");
            Console.WriteLine("\t*\t   THAY DOI MAT KHAU\t\t*");
            Console.WriteLine("\t*\t\t\t\t\t*");
            Console.WriteLine("\t*****************************************");
            Console.ForegroundColor = ConsoleColor.Green;
        nhapLai1:
            Console.WriteLine();
            Console.Write("\t\tNhap Mat khau cu : ");
            string oldPassWord = maskPass();
            string newPassWord1 = "";
            string newPassWord2 = "";
            for (LinkedListNode<Employee> p = empl.First; p != null; p = p.Next)
            {
               if(p.Value.UserName == userName)
                {
                    if (CheckPassWordOld(oldPassWord) == true)
                    {
                    nhapLai:
                        Console.WriteLine();
                        Console.Write("\t\tNhap Mat khau moi : ");
                        p.Value.PassWord = maskPass();
                        newPassWord1 = p.Value.PassWord;
                        Console.Write("\t\tNhap Mat khau moi lan 2 : ");
                        p.Value.PassWord = maskPass();
                        newPassWord2 = p.Value.PassWord;
                        Console.WriteLine();
                        if (newPassWord1 != newPassWord2)
                        {
                            Console.WriteLine("*Mat khau moi khong trung nhau");
                            goto nhapLai;
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("*Mat khau cu khong dung!!");
                        goto nhapLai1;
                    }
                }
            }
            UpdatePassWords(empl, userName);
            Console.WriteLine("Thay doi mat khau thanh cong!!");
        }
        //kiem tra mat khau cu 
        public static bool CheckPassWordOld(string passWord)
        {
            //  Admin p = new Admin();

            string[] line = File.ReadAllLines(@"Employees.txt");
            for (int i = 0; i < line.Length; i++)
            {
                string[] t = line[i].Split('#');
                if (passWord.Equals(t[1]))
                {
                    return true;
                }
            }
            return false;
        }
        //chuc nang cua employee : in thong tin 
        static void PrintListInformationEmployee2(LinkedList<Employee> ListEmp)
        {
            Console.WriteLine($"********************THONG TIN CA NHAN*****************");
            foreach (var item in ListEmp)
            {
                Console.WriteLine($"\nUser name: { item.UserName}\nFull name : {item.FullName}\nAddress : {item.Address}\nPhone number : {item.PhoneNumber}\nEmail : {item.Email}\nLich su dang nhap : {item.DangNhap}\n");
            }
        }
        //doc usename cua tung employee trong cac file con cua employee
        static LinkedList<Employee> ReadFileInformationEmployee2(string path)
        {
            LinkedList<Employee> listEmpl = new LinkedList<Employee>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        Employee empl = new Employee(t[0], t[1], t[2], t[3], t[4]);
                        listEmpl.AddLast(empl);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
            return listEmpl;
        }
        //chuc nang employee : dang nhap va xuat ra mot username tuong ung
        public static string FunctionLoginEmployee()
        {
            int count = 0;
            string userName, passWord;
        t:
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t*****************************************");
            Console.WriteLine("\t*\t\t\t\t\t*");
            Console.WriteLine("\t*\t\tDANG NHAP\t\t*");
            Console.WriteLine("\t*\t\t\t\t\t*");
            Console.WriteLine("\t*****************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("\t\tUser : ");
            userName = Console.ReadLine();
            Console.Write("\t\tPass : ");
            passWord = maskPass();
            Console.WriteLine();
            count++;

            if (LoginEmployee(userName, passWord) == false && count < 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Tai khoan hoac mat khau sai!!.\nBan con {3 - count} lan nhap ");
                goto t;
            }
            if (count == 3 && LoginEmployee(userName, passWord) == false)
            {
                Console.WriteLine("Qua 3 lan dang nhap , ban bi thoat chuong trinh");
            }
            if (LoginEmployee(userName, passWord) == true)
            {
                return userName;
            }
            return $"1";
        }
        // chức năng đăng nhập 
        public static bool LoginEmployee(string nameUser, string passWord)
        {
            //  Admin p = new Admin();

            string[] line = File.ReadAllLines(@"Employees.txt");
            for (int i = 0; i < line.Length; i++)
            {
                string[] t = line[i].Split('#');
                if (nameUser.Equals(t[0]) && passWord.Equals(t[1]))
                {
                    return true;
                }
            }
            return false;
        }
        //dang nhap admin vao cacs chuc nang
        public static bool FunctionLoginAdmin()
        {
            int count = 0;
            string nameUser, passWord;
        t:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\t*****************************************");
            Console.WriteLine("\t*\t\t\t\t\t*");
            Console.WriteLine("\t*\t\tDANG NHAP\t\t*");
            Console.WriteLine("\t*\t\t\t\t\t*");
            Console.WriteLine("\t*****************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("\t\tUser : ");
            nameUser = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\tPass : ");
            passWord = maskPass();
            Console.WriteLine();
            count++;

            if (LoginAdmin(nameUser, passWord) == false && count < 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Tai khoan hoac mat khau sai!!.\nBan con {3 - count} lan nhap ");
                goto t;
            }
            if (count == 3 && LoginAdmin(nameUser, passWord) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Qua 3 lan dang nhap , ban bi thoat chuong trinh");
            }

            return (LoginAdmin(nameUser, passWord) == true);

        }
        // chức năng đăng nhập 
        public static bool LoginAdmin(string nameUser, string passWord)
        {
            //  Admin p = new Admin();

            string[] line = File.ReadAllLines(@"Administrators.txt");
            for (int i = 0; i < line.Length; i++)
            {
                string[] t = line[i].Split('#');
                if (nameUser.Equals(t[0]) && passWord.Equals(t[1]))
                {
                    return true;
                }

            }
            return false;
        }
        // hàm làm mật khẩu dấu sao 
        static string maskPass()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
        //chức năng cua admin : cap nhat thong tin cua employee
        static void UpdateInformationEmployee(LinkedList<User> listEmp,LinkedList<Employee> listEmp2)
        {
            nhapLai:
            Console.Write("Nhap user name can cap nhat thong tin : ");
            string username = Console.ReadLine();
            if (CheckUsernameExit(username))
            {
                Console.WriteLine("**************CAP NHAT THONG TIN************");
                Console.WriteLine("1. Cap nhat ho ten");
                Console.WriteLine("2. Cap nhat dia chi ");
                Console.WriteLine("3. Cap nhat so dien thoai");
                Console.WriteLine("4. Cap nhat dia chi email");
                Console.WriteLine("5. Phim khac de thoat");
                int chon = 0;
                do
                {
                    Console.Write("Chon : ");
                    int.TryParse(Console.ReadLine(), out chon);
                    for (LinkedListNode<User> p = listEmp.First; p != null; p = p.Next)
                    {
                        if (p.Value.UserName == username)
                        {
                            if (chon == 1)
                            {
                                Console.WriteLine("Nhap ho ten can thay doi : ");
                                p.Value.FullName = Console.ReadLine();
                            }else if(chon == 2)
                            {
                                Console.WriteLine("Nhap dia chi can thay doi : ");
                                p.Value.Address = Console.ReadLine();
                            }else if(chon == 3)
                            {
                                Console.WriteLine("Nhap so dien thoai can thay doi : ");
                                p.Value.PhoneNumber = Console.ReadLine();
                            }else if(chon== 4)
                            {
                                Console.WriteLine("Nhap dia chi email can thay doi : ");
                                p.Value.Email = Console.ReadLine();
                            }
                        }
                    }
                } while (chon >= 1 && chon <= 4);
                WriteNewFileUserAfterRemove(listEmp);
                WriteNewFileEmployeePrivate(listEmp, username);
                Console.WriteLine("***********CAP NHAT THANH CONG*********");
            }
            else
            {
                Console.WriteLine("Username khong ton tai!!");
                goto nhapLai;
            }
        }
        //ghi lai file cap nhat
        static void WriteNewFileEmployeePrivate(LinkedList<User> listEmpl, string username)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter($"EmployeePrivateInformation\\{username}.txt"))
                {
                    for (LinkedListNode<User> p = listEmpl.First; p != null; p = p.Next)
                    {
                        if (p.Value.UserName == username)
                        {
                            sW.WriteLine($"{ p.Value.UserName}#{p.Value.FullName}#{p.Value.Address}#{p.Value.PhoneNumber}#{p.Value.Email}#Chua dang nhap lan dau");
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file!!");
            }
        }
        //ghi lai file sau khi cap nhat (xoa va cap nhat thong tin)
        static void WriteNewFileUserAfterRemove(LinkedList<User> listUser)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter("username.txt"))
                {
                    for (LinkedListNode<User> p = listUser.First; p != null; p = p.Next)
                    {
                        sW.WriteLine($"{ p.Value.UserName}#{p.Value.FullName}#{p.Value.Address}#{p.Value.PhoneNumber}#{p.Value.Email}");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file!!");
            }
        }
        //kiem tra username co ton tai khong
        static bool CheckUsernameExit(string username)
        {
            //kiem tra username co ton tai hay khong?
            LinkedList<Employee> listEmp2 = ReadFileEmployee("Employees.txt");
            for (LinkedListNode<Employee> p = listEmp2.First; p != null; p = p.Next)
            {
                if (p.Value.UserName == username)
                {
                    return true;
                }
            }
            return false;
        }
        //chuc nag cua admin : tim va hien thi thong tin employee theo username
        static void FindAndPrintInformationEmployee( LinkedList<Employee> listEmp)
        {
            nhapLai:
            Console.Write("Nhap user name can tim : ");
            string username = Console.ReadLine();
            if (CheckUsernameExit(username))
            {
                LinkedList<Employee> listFind = new LinkedList<Employee>();
                for (LinkedListNode<Employee> p = listEmp.First; p != null; p = p.Next)
                {
                    if (p.Value.UserName == username)
                    {
                        listFind.AddLast(p.Value);
                    }
                }
                PrintListInformationEmployee(listFind);
            }
            else
            {
                Console.WriteLine("Username khong ton tai!!");
                goto nhapLai;
            }
        }
        //chuc nang cua admin : xoa nhan vien
        static void RemoveEmployee(LinkedList<User> listUser, LinkedList<Employee> listEmp)
        {
            nhapLai:
            Console.Write("Nhap user name can xoa : ");
            string username = Console.ReadLine();
            if (CheckUsernameExit(username))
            {
                File.Delete($"EmployeePrivateInformation\\{username}.txt");
                for (LinkedListNode<Employee> p = listEmp.First; p != null; p = p.Next)
                {
                    if (p.Value.UserName == username)
                    {
                        listEmp.Remove(p);
                        break;
                    }
                }
                WriteNewFileEmployeeAfterRemove(listEmp);
                for (LinkedListNode<User> p = listUser.First; p != null; p = p.Next)
                {
                    if (p.Value.UserName == username)
                    {
                        listUser.Remove(p);
                        break;
                    }
                }
                WriteNewFileUserAfterRemove(listUser);
                Console.WriteLine("Xoa thanh cong!!!");
            }
            else
            {
                Console.WriteLine("Username khong ton tai!!!");
                goto nhapLai;
            }
           
        }
        static void RemoveInformationEmployee(LinkedList<User> listUser, string username)
        {
            for (LinkedListNode<User> p = listUser.First; p != null; p = p.Next)
            {
                if (p.Value.UserName == username)
                {
                    listUser.Remove(p);
                    break;
                }
            }
            WriteNewFileUserAfterRemove(listUser);
            Console.WriteLine("Xoa thanh cong!!!");
        }
        //cap nhat thanh file moi khi xoa mot employee
        static void WriteNewFileEmployeeAfterRemove(LinkedList<Employee> listEmpl)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter("Employees.txt"))
                {
                    for (LinkedListNode<Employee> p = listEmpl.First; p != null; p = p.Next)
                    {
                        sW.WriteLine($"{p.Value.UserName}#{p.Value.PassWord}");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file!!");
            }
        }
       
        //chuc nang cua admin : them nhan vien
        static void AddEmployee(LinkedList<Employee> arrEm)
        {
            arrEm.AddLast(InputEmployee());
            WriteFileEmployee(arrEm);
            Console.WriteLine("Them nhan vien thanh cong!!");
        }
        //Nhap thong tin
        static Employee InputEmployee()
        {
            Employee em = new Employee();
            string userNameNew = "";
            LinkedList<Employee> listEmp = ReadFileEmployee("Employees.txt");
            Console.WriteLine("****************Nhap Thong Tin*************");
        nhapLai: Console.Write("Nhap ten dang nhap : ");
            em.UserName = Console.ReadLine();
            userNameNew = em.UserName;
            for (LinkedListNode<Employee> p = listEmp.First; p != null; p = p.Next)
            {
                if (p.Value.UserName == userNameNew)
                {
                    Console.WriteLine("Ten dang nhap da ton tai!!");
                    goto nhapLai;
                }
            }
            Console.Write("Nhap mat khau mac dinh : ");
            em.PassWord = Console.ReadLine();
            Console.Write("Nhap ho ten : ");
            em.FullName = Console.ReadLine();
            Console.Write("Nhap dia chi : ");
            em.Address = Console.ReadLine();
            Console.Write("Nhap so dien thoai : ");
            em.PhoneNumber = Console.ReadLine();
            Console.Write("Nhap email : ");
            em.Email = Console.ReadLine();
            return em;
        }
        //kiem tra doc file employees.txt
        static void PrintListEmployee(LinkedList<Employee> ListEmp)
        {
            Console.WriteLine($"********************THONG TIN EMPLOYEE*****************");
            foreach (var item in ListEmp)
            {
                Console.WriteLine($"\nUser name: { item.UserName}\nPassword : {item.PassWord}");
            }
        }
        //ghi file employee
        static void WriteFileEmployee(LinkedList<Employee> listEmpl)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter("username.txt", true))
                {
                    for (LinkedListNode<Employee> p = listEmpl.First; p != null; p = p.Next)
                    {
                        sW.WriteLine($"{p.Value.UserName}#{p.Value.FullName}#{p.Value.Address}#{p.Value.PhoneNumber}#{p.Value.Email}");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file username.txt!!");
            }
            try
            {
                using (StreamWriter sW = new StreamWriter("Employees.txt", true))
                {
                    for (LinkedListNode<Employee> p = listEmpl.First; p != null; p = p.Next)
                    {
                        sW.WriteLine($"{p.Value.UserName}#{p.Value.PassWord}");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file employee.txt!!");
            }
            try
            {
                for (LinkedListNode<Employee> p = listEmpl.First; p != null; p = p.Next)
                {
                    using (StreamWriter sw = new StreamWriter($"EmployeePrivateInformation\\{p.Value.UserName}.txt"))
                    {
                        for (LinkedListNode<Employee> p1 = listEmpl.First; p1 != null; p1 = p.Next)
                        {
                            sw.WriteLine($"{p1.Value.UserName}#{p1.Value.FullName}#{p1.Value.Address}#{p1.Value.PhoneNumber}#{p1.Value.Email}#Chua dang nhap lan dau");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong ghi duoc file cua tung employee rieng!!");
            }
        }
        //kiem tra doc file username.txt
        //in thong tin cua tat ca user
        static void PrintListInformationAllUser(LinkedList<User> listUser)
        {
            Console.WriteLine($"********************THONG TIN TAT CA USER*****************");
            foreach (var item in listUser)
            {
                Console.WriteLine($"\nUser name: { item.UserName}\nFull name : {item.FullName}\nAddress : {item.Address}\nPhone number : {item.PhoneNumber}\nEmail : {item.Email}\n");
            }
        }
        //in thong tin user - admin
        static void PrintListInformationAdmin(LinkedList<Admin> ListAd)
        {
            Console.WriteLine($"********************THONG TIN ADMIN*****************");
            foreach (var item in ListAd)
            {
                Console.WriteLine($"\nUser name: { item.UserName}\nFull name : {item.FullName}\nAddress : {item.Address}\nPhone number : {item.PhoneNumber}\nEmail : {item.Email}\n");
            }
        }
        //in thong tin user - employee
        static void PrintListInformationEmployee(LinkedList<Employee> ListEmp)
        {
            Console.WriteLine($"********************THONG TIN EMPLOYEE*****************");
            foreach (var item in ListEmp)
            {
                Console.WriteLine($"\nUser name: { item.UserName}\nFull name : {item.FullName}\nAddress : {item.Address}\nPhone number : {item.PhoneNumber}\nEmail : {item.Email}\n");
            }
        }
        //doc file Username.txt: doc thong tin cac user
        static LinkedList<User> ReadFileInformationAllUser(string path)
        {
            LinkedList<User> listUser = new LinkedList<User>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() != -1)
                {
                    string[] t = sr.ReadLine().Split('#');
                    User ad = new User(t[0], t[1], t[2], t[3], t[4]);
                    listUser.AddLast(ad);
                }
            }
            return listUser;
        }
        //doc file Username.txt: doc danh sach Admin 
        static LinkedList<Admin> ReadFileInformationAdmin(string path)
        {
            LinkedList<Admin> listAdm = new LinkedList<Admin>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        if (t[0].Contains("QL"))
                        {
                            Admin ad = new Admin(t[0], t[1], t[2], t[3], t[4]);
                            listAdm.AddLast(ad);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
            return listAdm;
        }
        //doc file Username.txt: doc danh sach employee 
        static LinkedList<Employee> ReadFileInformationEmployee()
        {
            LinkedList<Employee> listEmpl = new LinkedList<Employee>();
            try
            {
                using (StreamReader sr = new StreamReader("username.txt"))
                {
                    while (sr.Peek() != -1)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        if (t[0].Contains("NV"))
                        {
                            Employee empl = new Employee(t[0], t[1], t[2], t[3], t[4]);
                            listEmpl.AddLast(empl);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
            return listEmpl;
        }
        //doc file Administrators.txt : chua nameuser va password
        static LinkedList<Admin> ReadFileAdmin(string path)
        {
            LinkedList<Admin> listAd = new LinkedList<Admin>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        Admin empl = new Admin(t[0], t[1]);
                        listAd.AddLast(empl);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
            return listAd;
        }
        //doc file Employees.txt: luu tr? danh sách các employee 
        static LinkedList<Employee> ReadFileEmployee(string path)
        {
            LinkedList<Employee> listEmpl = new LinkedList<Employee>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        Employee empl = new Employee(t[0], t[1]);
                        listEmpl.AddLast(empl);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!");
            }
            return listEmpl;
        }
        static void Menu()
        {
            int chon1 = 0, chon2 = 0, chon3 = 0;
            do
            {
                Console.Clear();
                MenuChinh();
                Console.WriteLine("Chon vao chuc nang: ");
                int.TryParse(Console.ReadLine(), out chon1);
                switch (chon1)
                {
                    case 1:
                        Console.Clear();
                        if (FunctionLoginAdmin() == true)
                        {
                            Console.Clear();
                            menuAdmin();
                            do
                            {
                                // ham de dang nhap vao admin
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                menuAdmin();
                                int.TryParse(Console.ReadLine(), out chon2);
                                switch (chon2)
                                {
                                    case 1:
                                        //a.chuc nang cua admin : them nhan vien
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        //tao linkedlist employee rong
                                        LinkedList<Employee> listEmp3 = new LinkedList<Employee>();
                                        AddEmployee(listEmp3);
                                        break;
                                    case 2:
                                        //b.chuc nang cua admin : xoa nhan vien
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        //test doc file userName.txt chua username, va cac thong tin ca nhan cua employee
                                        LinkedList<User> user = ReadFileInformationAllUser("username.txt");
                                        //cap nhat lai file Employees.txt
                                        listEmp3 = ReadFileEmployee("Employees.txt");
                                        //xoa
                                        RemoveEmployee(user, listEmp3);
                                        break;
                                    case 3:
                                        //c.chuc nang cua admin :Tìm và hiển thị thông tin employee theo username
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        //test doc file userName.txt chua username, va cac thong tin ca nhan cua employee
                                        LinkedList<Employee> listEmp = ReadFileInformationEmployee();                                    
                                        FindAndPrintInformationEmployee(listEmp);
                                        break;
                                    case 4:
                                        //d.chuc nang cua admin : cap nhat thong tin cua employee
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        //cap nhat lai file Employees.txt
                                        listEmp = ReadFileInformationEmployee();
                                        //test doc file userName.txt chua username, va cac thong tin ca nhan cua tat ca cac user
                                        user = ReadFileInformationAllUser("username.txt");                                     
                                        UpdateInformationEmployee(user, listEmp);
                                        break;
                                    case 5:
                                        //Hien thi thong tin Employee
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        //cap nhat lai doc file thong tin employee
                                        listEmp = ReadFileInformationEmployee();
                                        PrintListInformationEmployee(listEmp);
                                        break;
                                    default:
                                        //thoat
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Quay ve menu chinh!!");
                                        break;
                                }

                                Console.ReadKey();
                            } while (chon2 >= 1 && chon2 <= 5);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap tai khoan hoac mat khau sai!!!");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        string userName = FunctionLoginEmployee();
                        //tao mot linkedlist employee rong
                        LinkedList<Employee> temp = new LinkedList<Employee>();
                        if (userName != "1")
                        {
                            //doc file cua tung ca nhan employee
                            LinkedList<Employee> employee = ReadFileInformationEmployee2($"EmployeePrivateInformation\\{userName}.txt");
                            //kiem tra lan dang nhap dau tien
                            //doc file Employees.txt
                            LinkedList<Employee> listEmp = ReadFileEmployee("Employees.txt");
                            CheckFirstLogin(listEmp, userName);
                            Console.Clear();
                            MenuEmployee();
                            do
                            {
                                // ham de dang nhap vao admin
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                MenuEmployee();
                                int.TryParse(Console.ReadLine(), out chon3);
                                //ghi len file "Da dang nhap" 
                                WriteFileLogged(employee, userName);
                                switch (chon3)
                                {
                                    case 1:
                                        //Xem thong tin tai khoan
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        ReadFileLogged(temp,userName);
                                        PrintListInformationEmployee2(temp);
                                        break;
                                    case 2:
                                        // Doi password
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        //doc file Employees.txt
                                        //cap nhat lai file "Employees.txt" 
                                        listEmp = ReadFileEmployee("Employees.txt");
                                        ChangePassWord(listEmp, userName);
                                        break;
                                    // Thoat
                                    default:
                                        Console.WriteLine("Quay ve menu chinh!!");
                                        break;
                                }
                                Console.ReadKey();
                            } while (chon3 >= 1 && chon3 <= 2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap tai khoan hoac mat khau sai!!!");
                        }
                        break;
                    default:
                        Console.WriteLine("Ban da thoat");
                        break;
                }
                Console.ReadKey();
            } while (chon1 >= 1 && chon1 <= 2);
        }
        static void MenuEmployee()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****************MENU EMPLOYEE******************");
            Console.WriteLine("\t 1. Xem thong tin tai khoan ");
            Console.WriteLine("\t 2. Doi password ");
            Console.WriteLine("\t 3. Thoat");
            Console.WriteLine("************************************************");
        }
        static void menuAdmin()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("******************MENU ADMIN******************");
            Console.WriteLine("\t 1. Them Employee");
            Console.WriteLine("\t 2. Xoa Employee ");
            Console.WriteLine("\t 3. Tim Employee");
            Console.WriteLine("\t 4. Cap Nhat Employee ");
            Console.WriteLine("\t 5 .Hien thi thong tin Employee");
            Console.WriteLine("\t 6. Thoat ");
        }
        static void MenuChinh()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*******************MENU******************");
            Console.WriteLine("*\t\t\t\t\t*");
            Console.WriteLine("*\t 1. Dang Nhap Admin\t\t*");
            Console.WriteLine("*\t 2. Dang Nhap Employee\t\t*");
            Console.WriteLine("*\t 3. Exit\t\t\t*");
            Console.WriteLine("*\t\t\t\t\t*");
            Console.WriteLine("*****************************************");
        }
    }
}
