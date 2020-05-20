using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public class EatingController: ControllerBase
    {
        private const string FoodFileName = "foods.dat";
        private const string EatingsFileName = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public List<Eating> Eatings { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eatings = GetAllEatings();
        }

        public bool Add(string foodName, double weight)
        {
            var food = Foods.SingleOrDefault(f => f.Name == foodName);
            
                
        }
        private List<Eating> GetAllEatings()
        {
            return Load<List<Eating>>(EatingsFileName) ?? new List<Eating>();
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FoodFileName) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FoodFileName, Foods);
            Save(EatingsFileName, Eatings);
        }
    }
}
