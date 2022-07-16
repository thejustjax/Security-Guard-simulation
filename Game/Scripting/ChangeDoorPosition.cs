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
            if (keyboardService.IsKeyPressed(Constants.WESTDOOR_BUTTON))
            {
                
            }
            if (keyboardService.IsKeyPressed(Constants.EASTDOOR_BUTTON))
            {
                
            }
            

        }
    }
}