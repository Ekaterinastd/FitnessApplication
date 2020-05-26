using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;

namespace FitnessApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        private const string ExercisesFileName = "exercises.dat";
        private const string ActivitiesFileName = "exercises.dat";
        private readonly User user;


        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ActivitiesFileName) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name); 
            if(act==null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(ExercisesFileName) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(ExercisesFileName, Exercises);
            Save(ActivitiesFileName, Activities);

        }
    }
}
