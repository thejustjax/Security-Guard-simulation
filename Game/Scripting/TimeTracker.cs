using System;
using Security.Game.Casting;
using Security.Game.Services;


namespace Security.Game.Scripting
{
    public class TimeTracker : Action
    {   
        private double delay;
        private DateTime start;

        
        public TimeTracker(double delay, DateTime start)
        {
            this.delay = delay;
            this.start = start;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);
            if (elapsedTime.Seconds > delay)
            {
                stats.SetTime(120-elapsedTime.Seconds);
            }
        }
    }
}