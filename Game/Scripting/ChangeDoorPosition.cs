using System.Collections.Generic;
using Security.Game.Casting;
using Security.Game.Services;


namespace Security.Game.Scripting
{
    public class ChangeDoorPosition : Action
    {
        ChangeDoorPosition(){
        }
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeDoorPosition(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }
        public void Execute(Cast cast, Script script, ActionCallback callback){
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            if (keyboardService.IsKeyPressed(Constants.WESTDOOR_BUTTON))
            {
                stats.changeWestDoor();
            }
            if (keyboardService.IsKeyPressed(Constants.EASTDOOR_BUTTON))
            {
                stats.changeEastDoor();
            }
            

        }
    }
}