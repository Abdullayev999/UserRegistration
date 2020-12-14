using System.Text;
using System.Threading;

namespace Program
{
    public class User
    {
        private string name;
        private string surname;
        private int age;
        private StringBuilder login;
        private StringBuilder password;

        public override string ToString()
        {
            return $"Name    : {name}\n   Surname : {surname}\n   Age     : {age}\n   Login   : {login}\n   Password: {password}\n";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set 
            {
                if (value>=0&&value<=100) age = value;
                else age = 0;
            }
        }
        public StringBuilder Login
        {
            get { return login; }
            set { login = value; }
        }
        public StringBuilder Password
        {
            get { return password;  }
            set { password = value; }
        }
    }
}