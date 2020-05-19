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
            var userController = new UserController(name);
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
            Console.ReadKey();
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
