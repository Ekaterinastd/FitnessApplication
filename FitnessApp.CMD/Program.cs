using System;
using System.Runtime.InteropServices;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствие");
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if(userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("веса");
                var height = ParseDouble("роста");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите делать?");
            Console.WriteLine("Е - ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
               var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}гр.");
                }
            }
            Console.ReadKey();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта: ");
            var foodName = Console.ReadLine();
            var weight = ParseDouble("вес порции");           
            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("кол-во белков");
            var fats = ParseDouble("кол-во жиров");
            var carbs = ParseDouble("кол-во углеводов");
            var product = new Food(foodName,prots,fats,carbs,calories);
            return (Food:product, Weight: weight);
        }

        /// <summary>
        /// Проверка поля типа дата.
        /// </summary>
        /// <returns>Дата.</returns>
        private static DateTime ParseDateTime()
        {
            DateTime birhtDate;
            while (true)
            {
                Console.Write("Введите дату рождния (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birhtDate))
                    break;
                else
                    Console.WriteLine("Неверный формат даты рождения.");
            }

            return birhtDate;
        }

        /// <summary>
        /// Провека числовых полей.
        /// </summary>
        /// <param name="name">Имя поля.</param>
        /// <returns>Значение поля.</returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine($"Неверный формат {name}");
            }
        }
    }
}
