using System.Collections.Generic;
using Security.Game.Casting;
using Security.Game.Services;


namespace Security.Game.Scripting
{
    public class ChangeCameraView : Action
    {
        ChangeCameraView(){
            
        }
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeCameraView(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback){
            if (keyboardService.IsKeyPressed(Constants.OFFICE_BUTTON))
            {
                callback.OnNext(Constants.OFFICE_NAME);
            }
            if (keyboardService.IsKeyPressed(Constants.ROOM1_BUTTON))
            {
                callback.OnNext(Constants.ROOM1_NAME);
            }
            if (keyboardService.IsKeyPressed(Constants.ROOM2_BUTTON))
            {
                callback.OnNext(Constants.ROOM2_NAME);
            }
            if (keyboardService.IsKeyPressed(Constants.WHALL_BUTTON))
            {
                callback.OnNext(Constants.WHALL_NAME);
            }
            if (keyboardService.IsKeyPressed(Constants.EHALL_NAME))
            {
                callback.OnNext(Constants.EHALL_NAME);
            }

        }
    }
}