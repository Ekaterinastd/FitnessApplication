using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    public class Food
    {
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калорийность на 100 гр. продукта.
        /// </summary>
        public double Calories { get; }

        public Food(string name)
        {
            //TODO: проверка
            Name = name;
        }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories) : this(name)
        {
            //TODO: проверка
            Proteins = proteins / 100;
            Fats = fats / 100;
            Carbohydrates = carbohydrates / 100;
            Calories = calories / 100;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
