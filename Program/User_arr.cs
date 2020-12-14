using System;
using System.Text;

namespace Program
{
    public class User_arr
    {
        private int index = 0;
        private int size = 5;
        private int capacity = 5;
        private User[] arr;
        public User_arr()
        {
            arr=new User[size];
        }

        public int Index => index;

        public int Size => size;

        public StringBuilder GetUserLogin(int index)
        {
            return arr[index].Login;
        }

        public bool Empty()
        {
            return index != 0;
        }
        public void PrintAll()
        {
            int count = 1;

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine($"{count++}) {arr[i]}");
            }
        }
        public void Add(User user)
        {
            if (index==size-1)CapacityUp();

            arr[index++] = user;
        }
        void CapacityUp()
        {
            size += capacity;
            User[] tmp = new User[size];

            for (int i = 0; i < index; i++)
                tmp[i] = arr[i];

            arr = tmp;
        }

        public bool ChekLogAndPass(string login,string password)
        {
            for (int i = 0; i < index; i++)
            {
                if (Convert.ToBoolean(String.Equals(arr[i].Login.ToString(), login)))
                {
                    if (Convert.ToBoolean(String.Equals(arr[i].Password.ToString(), password)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
    }
}