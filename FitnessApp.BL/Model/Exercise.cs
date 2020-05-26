using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            //Проверка
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException(nameof(activity));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public DateTime Start { get;}
        public DateTime Finish { get; }
        public Activity Activity { get;}

        public User User { get; }
    }
}
