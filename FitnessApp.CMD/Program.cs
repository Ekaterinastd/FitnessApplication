using System;
using FitnessApp.BL.Controller;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствие");
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введите пол: ");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения: ");
            var birthDay = DateTime.Parse(Console.ReadLine());//tryParse
            Console.WriteLine("Введите вес: ");
            var weight = double.Parse(Console.ReadLine()); 
            Console.WriteLine("Введите рост: ");
            var height = double.Parse(Console.ReadLine());
            var userController = new UserController(name, gender, birthDay, weight,height);
            userController.Save();
        }
    }
}
