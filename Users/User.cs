using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class User : IComparable
    {
        string firstName;
        string lastName;
        int dateOfBirth;
        string email;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }
        public string Email { get { return email; } set { email = value; } }

       public User(string firstName, string lastName, int dateOfBirth, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
        }
       public User()
        {

        }

        public virtual string PrintInfo()
        {
            return $"{this.firstName} {this.lastName} {this.dateOfBirth} {this.email}";
        }

        public int CompareTo(object obj)
        {
            User user = (User)obj;
            if (user.dateOfBirth < this.dateOfBirth) return -1;
            if (user.dateOfBirth > this.dateOfBirth) return 1;
            return 0;
        }

        public static void GetUser(List<User> theList)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("enter firstName");
                string userName = Console.ReadLine();
                Console.WriteLine("emter lastName");
                string userLastName = Console.ReadLine();
                Console.WriteLine("inser date of birth");
                int userDate = int.Parse(Console.ReadLine());
                Console.WriteLine("enter Email");
                string UserEmail = Console.ReadLine();

                User user1 = new User(userName, userLastName, userDate, UserEmail);
                theList.Add(user1);
                theList.Sort();
            }
            foreach (User user in theList)
            {
                Console.WriteLine($"firstName: {user.firstName} lastName: {user.LastName} date of birth: {user.DateOfBirth} Email: {user.Email}");
            }
        }



    }
}
