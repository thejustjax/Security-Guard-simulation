using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawHudAction : Action
    {
        private VideoService videoService;
        
        public DrawHudAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            DrawLabel(cast, Constants.LEVEL_GROUP, Constants.LEVEL_FORMAT, stats.GetClock());
            DrawLabel(cast, Constants.LIVES_GROUP, Constants.LIVES_FORMAT, stats.GetLives());
            DrawLabel(cast, Constants.SCORE_GROUP, Constants.SCORE_FORMAT, stats.GetBattery());
        }

        // **********************************************************************************************
        // You found the bug. Great job!
        // **********************************************************************************************
        // todo: fix the bug by making sure the text value is set to the appropriate variable.
        private void DrawLabel(Cast cast, string group, string format, int data)
        {
            string theValueToDisplay = string.Format(format, data);
            
            Label label = (Label)cast.GetFirstActor(group);
            Text text = label.GetText();
            text.SetValue(string.Format(format, data));
            Point position = label.GetPosition();
            videoService.DrawText(text, position);
        }
    }
}