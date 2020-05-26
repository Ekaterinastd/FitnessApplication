using System;
using System.Globalization;
using System.Resources;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.Write(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("веса");
                var height = ParseDouble("роста");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            while (true)
            {
                Console.WriteLine(userController.CurrentUser);
                Console.WriteLine("Что вы хотите делать?");
                Console.WriteLine("Е - ввести приём пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}гр.");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();                       
                        exerciseController.Add(exe.Activity,exe.Begin, exe.End); //TODO: сделать ввод только времени тренировки, а не полной даты
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}.");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadKey();
            }

        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("конец упражнения");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
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
            var product = new Food(foodName, prots, fats, carbs, calories);
            return (Food: product, Weight: weight);
        }

        /// <summary>
        /// Проверка поля типа дата.
        /// </summary>
        /// <returns>Дата.</returns>
        private static DateTime ParseDateTime(string value)
        {
            DateTime date;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;
                else
                    Console.WriteLine($"Неверный формат {value}.");
            }

            return date;
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
