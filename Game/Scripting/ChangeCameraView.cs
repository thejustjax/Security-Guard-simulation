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

        public void ChangeSceneAction(KeyboardService keyboardService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback){
            if (keyboardService.IsKeyPressed(Constants.OFFICE_NAME))
            {
                callback.OnNext(nextScene);
            }
            if (keyboardService.IsKeyPressed(Constants.ROOM1_NAME))
            {
                callback.OnNext(nextScene);
            }
            if (keyboardService.IsKeyPressed(Constants.ROOM2_NAME))
            {
                callback.OnNext(nextScene);
            }
            if (keyboardService.IsKeyPressed(Constants.WHALL_NAME))
            {
                callback.OnNext(nextScene);
            }
            if (keyboardService.IsKeyPressed(Constants.EHALL_NAME))
            {
                callback.OnNext(nextScene);
            }

        }
    }
}