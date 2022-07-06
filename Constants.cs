using System.Collections.Generic;
using Security.Game.Casting;


namespace Security
{
    public class Constants
    {
        //GAME
        public static string GAME_NAME = "Security";
        public static int FRAME_RATE = 60;
        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;
        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);
        //SCENES
        public static string NEW_GAME = "new_game";
        public static string CAMERA_1 = "camera_1";
        public static string OFFICE = "office";
        public static string GAME_OVER = "game_over";
        public static string JUMPSCARE = "jumpscare";
        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";
        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;
    }
}