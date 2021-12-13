
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            //User.GetUser(users);
            //Student student = new Student("anir", "man", 1995, "kjhsccghagcac", 10);
            //Console.WriteLine(student.PrintInfo());
            //GetInfoFromFile();
            //PrintToFile(users);
            //PrintFromFile();


            List<User> userList1 = new List<User>();
            Task10(userList1);

            void GetInformation(List<User> myList)
            {
                FileStream fs = new FileStream(@"C:\Files\info.txt", FileMode.Append);
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    foreach (User user in myList)
                    {
                        sr.WriteLine($"{user.FirstName} {user.LastName} {user.DateOfBirth} {user.Email}");
                    }
                }
            }
            GetInformation(users);

            void GetInfoFromFile()
            {
                FileStream iinfo = new FileStream(@"C:\Files\info.txt", FileMode.Open);
                using (StreamReader sr = new StreamReader(iinfo))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }

            void PrintToFile(List<User> userList)
            {
                foreach (User user in userList)
                {
                    FileStream saveName = new FileStream($@"C:\Files\{user.FirstName} {user.LastName}.txt", FileMode.Append);
                    using (StreamWriter sr = new StreamWriter(saveName))
                    {
                        sr.WriteLine($"{user.FirstName} {user.LastName} {user.DateOfBirth} {user.Email}");
                    }
                }
            }
            void PrintFromFile()
            {
                Console.WriteLine("enter fullname");
                string userPic = Console.ReadLine();
                FileStream print = new FileStream($@"C:\Files\{userPic}.txt", FileMode.Open);
                using (StreamReader ss = new StreamReader(print))
                {
                    Console.WriteLine(ss.ReadToEnd());
                }
            }


                
            static void Task10(List<User> userList1)
            {
                try
                {
                    Console.WriteLine("Hello User\nChoose Option :\n1. Add User\n2. Edit User\n3. Delete User\n4. Show User");
                    short userChoose = short.Parse(Console.ReadLine());
                    switch (userChoose)
                    {
                        case 1:
                            AddUser(userList1);
                            Task10(userList1);
                            break;
                        case 2:
                            EditUser(userList1);
                            Task10(userList1);

                            break;
                        case 3:
                            Removeuser(userList1);
                            Task10(userList1);

                            break;
                        case 4:
                            ShowUser(userList1);
                            Task10(userList1);

                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ ex.Message} try again");
                }
            }

            static void AddUser(List<User> userList1)
            {
                Console.WriteLine("Add User: ");
                try
                {
                    Console.WriteLine("Enter First Name :");
                    string userInputFname = Console.ReadLine();
                    Console.WriteLine("Enter lastName");
                    string userInputLname = Console.ReadLine();
                    Console.WriteLine("Enter date of birth");
                    int userInputDate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter email");
                    string userInputEmail = Console.ReadLine();

                    User newUser = new User(userInputFname, userInputLname, userInputDate, userInputEmail);
                    Console.WriteLine($"firstName :{userInputFname} lastName :{userInputLname} Birth :{userInputDate} Email :{userInputEmail}");
                    userList1.Add(newUser);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message} Try Again.");
                    AddUser(userList1);
                }
            }
            static void EditUser(List<User> userList2)
            {
                try
                {
                    Console.WriteLine("Enter user name");
                    string userInput = Console.ReadLine();

                    int result = CheckForUser(userInput, userList2);
                    if (result == -1) Console.WriteLine("User not Found");
                    else
                    {
                        Console.WriteLine("What do you want to change?\n1. First Name\n2. Last Name\n3. Birth Year\n4. Email");
                        short userPick = short.Parse(Console.ReadLine());

                        switch (userPick)
                        {
                            case 1:
                                Console.Write("Enter First Name : ");
                                string userNameInput = Console.ReadLine();
                                userList2[result].FirstName = userNameInput;
                                break;
                            case 2:
                                Console.Write("Enter Last Name : ");
                                string userLNameInput = Console.ReadLine();
                                userList2[result].LastName = userLNameInput;
                                break;
                            case 3:
                                Console.Write("Enter Birth Year : ");
                                int userInputDate = int.Parse(Console.ReadLine());
                                userList2[result].DateOfBirth = userInputDate;
                                break;
                            case 4:
                                Console.Write("Enter Email : ");
                                string userInputEmail= Console.ReadLine();
                                userList2[result].Email = userInputEmail;
                                break;
                        }
                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message} Try Again.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            static int CheckForUser(string name, List<User> userList3)
            {
                for (int i = 0; i < userList3.Count; i++)
                {
                    if (name.ToLower() == userList3[i].FirstName.ToLower()) return i;
                }
                return -1;
            }
            static void Removeuser(List<User> userList4)
            {
                try
                {
                    Console.WriteLine("Delete User\n Enter User Name : ");
                    string userInp= Console.ReadLine();

                    int result = CheckForUser(userInp, userList4);
                    if (result == -1) Console.WriteLine("No User Found");
                    else
                    {
                        for(int i = 0;i < userList4.Count; i++)
                        {
                            if (userList4[i].FirstName.ToLower() == userInp.ToLower()) userList4.RemoveAt(i);
                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            static void ShowUser(List<User> userList5)
            {
                try
                {
                    Console.Write("Present User\n Enter User Name : ");
                    string userInput = Console.ReadLine();

                    int result = CheckForUser(userInput, userList5);
                    if(result == -1) Console.WriteLine("No user Found");
                    else
                    {
                        for (int i = 0; i < userList5.Count; i++)
                        {
                            if (userInput.ToLower() == userList5[i].FirstName.ToLower()) Console.WriteLine(userList5[i].PrintInfo());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }








        }
    }
}