using System.Collections.Generic;
using Security.Game.Casting;


namespace Security
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Security Guard";
        public static int FRAME_RATE = 60;
        // DIFFICULTY
        public static int ROBOT_DIFFICULTY = 15;
        public static int MOVE_TIME = 5;
        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";
        public static string OFFICE_BUTTON = "z";
        public static string ROOM1_BUTTON = "b";
        public static string ROOM2_BUTTON = "v";
        public static string HWALL_BUTTON = "c";
        public static string EWALL_BUTTON = "x";
        public static string WESTDOOR_BUTTON = "g";
        public static string EASTDOOR_BUTTON = "h";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";
        public static string STAGE_NAME = "Stage";
        public static string ROOM1_NAME = "Party Room 1";
        public static string ROOM2_NAME = "Party Room 2";
        public static string WHALL_NAME = "West Hallway";
        public static string EHALL_NAME = "East Hallway";
        public static string OFFICE_NAME = "Office";

        public static string GAME_WIN = "game_win";
        // LEVELS
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;
        //ROBOT
        public static string ROBOT_GROUP = "robot";
        public static string ROBOT_IMAGE = "Assets/Images/000.png";
        public static int ROBOT_HEIGHT = 200;
        public static int ROBOT_WIDTH = 200;

        // Doors
        public static string WESTDOOR_GROUP = "westdoor";
        public static string WESTDOOR_CLOSED_IMAGE = "Assets/Images/WestDoor_Closed.png";
        public static string WESTDOOR_OPEN_IMAGE = "Assets/Images/WestDoor_Open.png";
        public static int WESTDOOR_HEIGHT = 200;
        public static int WESTDOOR_WIDTH = 200;
        public static string EASTDOOR_GROUP = "eastdoor";
        public static string EASTDOOR_CLOSED_IMAGE = "Assets/Images/EastDoor_Closed.png";
        public static string EASTDOOR_OPEN_IMAGE = "Assets/Image/EastDoor_Open.png";
        public static int EASTDOOR_HEIGHT = 200;
        public static int EASTDOOR_WIDTH = 200;
        // HUD
        public static int HUD_MARGIN = 15;
        public static string CLOCK_GROUP = "clock";
        public static string LIVES_GROUP = "lives";
        public static string BATTERY_GROUP = "battery";
        public static string CLOCK_FORMAT = "TIME LEFT: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string BATTERY_FORMAT = "BATTERY: {0}%";
        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string CLOCKING_IN = "CLOCKING IN";
        public static string WAS_GOOD_GAME = "GAME OVER";
        //ROOM NAMES

    }
}