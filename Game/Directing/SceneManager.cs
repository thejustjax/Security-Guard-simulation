using System;
using System.Collections.Generic;
using System.IO;
using Security.Game.Casting;
using Security.Game.Scripting;
using Security.Game.Services;


namespace Security.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.CAMERA_1)
            {
                PrepareCamera1(cast, script);
            }
            else if (scene == Constants.OFFICE)
            {
                PrepareOffice(cast, script);
            }
            else if (scene == Constants.JUMPSCARE)
            {
                PrepareJumpscare(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            

        }
    }
}