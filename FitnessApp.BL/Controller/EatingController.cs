using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FoodFileName = "foods.dat";
        private const string EatingsFileName = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        //public bool Add(string foodName, double weight)
        //{
        //    var food = Foods.SingleOrDefault(f => f.Name == foodName);
        //    if (food != null)
        //    {
        //        Eating.Add(food, weight);
        //        Save();
        //        return true;
        //    }
        //    return false;
        //}

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>(EatingsFileName) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FoodFileName) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FoodFileName, Foods);
            Save(EatingsFileName, Eating);
        }
    }
}
