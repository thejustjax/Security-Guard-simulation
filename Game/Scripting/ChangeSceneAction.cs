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
        
    }
}



// public static string OFFICE_BUTTON = "z";
// public static string ROOM1_BUTTON = "b";
// public static string ROOM2_BUTTON = "v";
// public static string HWALL_BUTTON = "c";
// public static string EWALL_BUTTON = "x";