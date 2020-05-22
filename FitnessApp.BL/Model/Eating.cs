using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Приём пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Время приёма пищи
        /// </summary>
        public DateTime Moment { get; }
        public Dictionary<Food, double> Foods { get; }
        public User User { get; }

        /// <summary>
        /// Добавление продукта в приём пищи.
        /// </summary>
        /// <param name="food">Продукт.</param>
        /// <param name="weight">Вес продукта.</param>
        public void Add(Food food, double weight)
        {

            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
                Foods.Add(food, weight);
            else
                Foods[product] += weight;
        }
    }
}
