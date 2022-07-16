using System;
using Security.Game.Casting;
using Security.Game.Services;


namespace Security.Game.Scripting
{
    public class TimeTracker : Action
    {   
        public TimeTracker()
        {
            
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DateTime currentTime = DateTime.Now;
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            if(stats.GetStart() == new DateTime()){
                stats.SetStart(DateTime.Now);
            }
            TimeSpan elapsedTime = currentTime.Subtract(stats.GetStart());
            stats.SetTime(Constants.MAX_TIME-((elapsedTime.Minutes*60)+elapsedTime.Seconds));
            if (stats.GetClock() == 0){
                callback.OnNext(Constants.GAME_WIN);
            }
        }
    }
}