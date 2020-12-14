using System;
using System.Text;

/* Напишите программу, которая показвает менью выбора (Зарегистрироваться / Войти),при выборе регистрации
   от пользователя требуется ввести имя, фамилию и возраст (логин должен сгенерировать с этих данных). А
   пароль будет сгенерирован Рандомно (при этом может состоять из любых символов (буквы, числа, знаки)).
   По окончанию регистрации пользователь возвращается на главное менью, где он может зарегистрировать еще 
   один аккаун или же сделать вход в систему. Все аккаунты храните в массиве классов аккаутн. И если сможете
   сделайте пароль при вхоте на учетную запись скрытой (символами *).*/

namespace Program
{

    class Program
    {

        static void GenerationPassword(User user)
        {
            Random rand = new Random();
            int size = 2;
            user.Password = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                user.Password.Append(user.Name[rand.Next(user.Name.Length)]);
                user.Password.Append(rand.Next(user.Age));
                user.Password.Append(user.Surname[rand.Next(user.Surname.Length)]);
            }
        }
        static void GenerationLogin(User user)
        {
            Random rand = new Random();
            int size = 3;
            user.Login = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    user.Login.Append(user.Name[rand.Next(user.Name.Length)]);
                    user.Login.Append(user.Surname[rand.Next(user.Surname.Length)]);
                }

                user.Login.Append('_');
                user.Login.Append(user.Age);

                
        }

        static void Main(string[] args)
        {
            int action;
            User_arr arr=new User_arr();
            User user;
            string login;
            do
            {


                Console.WriteLine("1 - Sign up\n" +
                                  "2 - Sign in\n" +
                                  "3 - Print all users\n" +
                                  "4 - Exit");
                action = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (action == 1)
                {
                    user = new User();
                    Console.WriteLine("Please , Sign up !!!");

                    Console.Write("Enter Name    : ");
                    user.Name = Console.ReadLine();

                    Console.Write("Enter Surname : ");
                    user.Surname = Console.ReadLine();

                    Console.Write("Enter  Age    : ");
                    user.Age = Convert.ToInt32(Console.ReadLine());

                    GenerationLogin(user);
                    GenerationPassword(user);

                    arr.Add(user);
                    Console.WriteLine($"Registration was successful\n\nPlease remember your data!!\n" +
                                      $"login    : {user.Login}\n" +
                                      $"password : {user.Password}\n");
                    
                }
                else if (action == 2)
                {
                    Console.WriteLine("Enter data for Sign in");
                    Console.WriteLine("Login:");
                    login = Console.ReadLine();
                    Console.WriteLine("Password:");

                    StringBuilder pass = new StringBuilder();
                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            Console.Write("\b \b");
                            pass.Remove((pass.Length - 1), 1);
                        }
                        else
                        {
                            pass.Append(key.KeyChar);
                            Console.Write('*');
                        }
                    }

                    if (arr.ChekLogAndPass(login, pass.ToString()))
                    {
                        Console.WriteLine("\nWelcome\n");

                        do
                        {
                            Console.WriteLine("1 - Come back\n2 - exit");
                            action = Convert.ToInt32(Console.ReadLine());

                            Console.Clear();

                            if (action == 1)
                            {
                                Console.WriteLine("You come back");
                                break;
                            }
                            else if (action == 2)
                            {
                                Console.WriteLine("You exit proqram");
                                return;
                            }
                            else Console.WriteLine("Incorrect choice");
                            
                        } while (true);
                    }
                    else  Console.WriteLine("\nWrong data!!!\n");
                }
                else if (action == 3)
                {
                    if (arr.Empty())
                    {
                        Console.WriteLine();
                        arr.PrintAll();
                    }
                    else Console.WriteLine("Nobody registered\n");
                    
                   
                }
                else if (action == 4)
                {
                    Console.WriteLine("You exit proqram");
                    break;
                }
                else Console.WriteLine("Incorrect choice");
                
            } while (true);
        }
    }
}
