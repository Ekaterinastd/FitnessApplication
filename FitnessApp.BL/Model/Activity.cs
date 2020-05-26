using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public Activity(string name, double caloriesPerMimute)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CaloriesPerMimute = caloriesPerMimute;
        }

        public override string ToString()
        {
            return Name;
        }
        public string Name { get;}
        public double CaloriesPerMimute { get; }
    }
}
