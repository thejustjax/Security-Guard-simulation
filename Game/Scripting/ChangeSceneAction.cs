using Security.Game.Casting;
using Security.Game.Services;


namespace Security.Game.Scripting
{
    public class ChangeSceneAction : Action
    {
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeSceneAction(KeyboardService keyboardService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (keyboardService.IsKeyPressed(Constants.ENTER))
            {
                callback.OnNext(nextScene);
            }
        }

        //<summery>
        // if the A key is clicked it will go to the start screen
        //</summery>
    }
}