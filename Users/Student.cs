using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class Student:User
    {
        public int grade;

      public  Student(string firstName, string lastName, int dateOfBirth, string email,int grade):base(firstName, lastName, dateOfBirth, email)
        {
            this.grade = grade;
        }
        public Student()
        {

        }

        public override string PrintInfo()
        {
            return $"{base.PrintInfo()} {this.grade}";
        }
    }
}
