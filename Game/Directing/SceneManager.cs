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
        public string CurrentScene;

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
            else if (scene == Constants.OFFICE_NAME)
            {
                PrepareOffice(cast, script);
            }
            else if (scene == Constants.OFFICE_NAME){
                PrepareOffice(cast, script);
            }
            else if (scene == Constants.ROOM1_NAME){
                PreparePartyRoom1(cast, script);
            }
            else if (scene == Constants.ROOM2_NAME){
                PreparePartyRoom2(cast, script);
            }
            else if (scene == Constants.WHALL_NAME){
                PrepareWHall(cast,script);
            }
            else if (scene == Constants.EHALL_NAME){
                PrepareEHall(cast, script);
            }
            else if (scene == Constants.GAME_WIN){
                PrepareGameWin(cast, script);
            }
        }

        // public static string ROOM1_NAME = "Party Room 1";
        // public static string ROOM2_NAME = "Party Room 2";
        // public static string WHALL_NAME = "West Hallway";
        // public static string EHALL_NAME = "East Hallway";
        // public static string OFFICE_NAME = "Office";
        private void PrepareNewGame(Cast cast, Script script)
        {
            CurrentScene = Constants.NEW_GAME;
            AddStats(cast);
            AddClock(cast);
            AddBattery(cast);
            AddLives(cast);
            AddDialog(cast, Constants.ENTER_TO_START);
            AddRobot(cast);
            AddEastDoor(cast);
            AddWestDoor(cast);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddOutputActions(cast, script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }


        private void PrepareNextLevel(Cast cast, Script script)
        {
            CurrentScene = Constants.NEXT_LEVEL;
            AddDialog(cast, Constants.CLOCKING_IN);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.OFFICE_NAME, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(cast, script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PreparePartyRoom1(Cast cast, Script script){
            CurrentScene = Constants.OFFICE_NAME;
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddOutputActions(cast, script);
            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.ROOM1_NAME);
        }

        private void PreparePartyRoom2(Cast cast, Script script){
            CurrentScene = Constants.OFFICE_NAME;
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddOutputActions(cast, script);
        }

        private void PrepareWHall(Cast cast, Script script){
            CurrentScene = Constants.OFFICE_NAME;
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddOutputActions(cast, script);
        }

        private void PrepareEHall(Cast cast, Script script){
            CurrentScene = Constants.OFFICE_NAME;
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();;
            AddUpdateActions(script);    
            AddOutputActions(cast, script);
        }

        private void PrepareOffice(Cast cast, Script script)
        {
            CurrentScene = Constants.OFFICE_NAME;
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddOutputActions(cast, script);
        
        }



        

        private void PrepareTryAgain(Cast cast, Script script)
        {
            CurrentScene = Constants.TRY_AGAIN;
            AddDialog(cast, Constants.CLOCKING_IN);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.OFFICE_NAME, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            
            AddUpdateActions(script);
            AddOutputActions(cast, script);
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddRobot(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);
            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            AddOutputActions(cast, script);
        }
        private void PrepareGameWin(Cast cast, Script script)
        {
            AddDialog(cast, Constants.WAS_GOOD_GAME);
            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            AddOutputActions(cast, script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------
        private void AddRobot(Cast cast)
        {
            cast.ClearActors(Constants.ROBOT_GROUP);
        
            int x = Constants.CENTER_X - Constants.ROBOT_WIDTH / 2;
            int y = Constants.CENTER_Y - Constants.ROBOT_HEIGHT / 2;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.ROBOT_WIDTH, Constants.ROBOT_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.ROBOT_IMAGE);
            Robot robot = new Robot(body, image, false);
        
            cast.AddActor(Constants.ROBOT_GROUP, robot);
        }

        private void AddEastDoor(Cast cast)
        {
            cast.ClearActors(Constants.EASTDOOR_GROUP);
        
            int x = Constants.SCREEN_WIDTH - Constants.EASTDOOR_WIDTH;
            int y = Constants.CENTER_Y - Constants.EASTDOOR_HEIGHT / 2;;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.EASTDOOR_WIDTH, Constants.EASTDOOR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.EASTDOOR_CLOSED_IMAGE);
            EastDoor eastdoor = new EastDoor(body, image, false);
        
            cast.AddActor(Constants.EASTDOOR_GROUP, eastdoor);
        }

        private void AddOpenEastDoor(Cast cast)
        {
            cast.ClearActors(Constants.OPENEASTDOOR_GROUP);
        
            int x = Constants.SCREEN_WIDTH - Constants.EASTDOOR_WIDTH;
            int y = Constants.CENTER_Y - Constants.EASTDOOR_HEIGHT / 2;;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.EASTDOOR_WIDTH, Constants.EASTDOOR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.EASTDOOR_OPEN_IMAGE);
            OpenEastDoor openeastdoor = new OpenEastDoor(body, image, false);
        
            cast.AddActor(Constants.OPENEASTDOOR_GROUP, openeastdoor);
        }

        private void AddWestDoor(Cast cast)
        {
            cast.ClearActors(Constants.WESTDOOR_GROUP);
        
            int x = Constants.WESTDOOR_WIDTH / 2;
            int y = Constants.CENTER_Y - Constants.WESTDOOR_HEIGHT / 2;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.WESTDOOR_WIDTH, Constants.WESTDOOR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.WESTDOOR_CLOSED_IMAGE);
            WestDoor westdoor = new WestDoor(body, image, false);
        
            cast.AddActor(Constants.WESTDOOR_GROUP, westdoor);
        }

        private void AddOpenWestDoor(Cast cast)
        {
            cast.ClearActors(Constants.OPENWESTDOOR_GROUP);
        
            int x = Constants.WESTDOOR_WIDTH / 2;
            int y = Constants.CENTER_Y - Constants.WESTDOOR_HEIGHT / 2;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.WESTDOOR_WIDTH, Constants.WESTDOOR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.WESTDOOR_OPEN_IMAGE);
            OpenWestDoor openwestdoor = new OpenWestDoor(body, image, false);
        
            cast.AddActor(Constants.OPENWESTDOOR_GROUP, openwestdoor);
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.PURPLE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddClock(Cast cast)
        {
            cast.ClearActors(Constants.CLOCK_GROUP);

            Text text = new Text(Constants.CLOCK_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.WHITE);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.CLOCK_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LIVES_GROUP, label);   
        }

        private void AddBattery(Cast cast)
        {
            cast.ClearActors(Constants.BATTERY_GROUP);

            Text text = new Text(Constants.BATTERY_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.BATTERY_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Cast cast, Script script)
        {
            Robot robot = (Robot)cast.GetFirstActor(Constants.ROBOT_GROUP);
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            if (CurrentScene == Constants.OFFICE_NAME){
                script.AddAction(Constants.OUTPUT, new DrawDoorAction(VideoService));
            }
            if (CurrentScene == robot.GetLocation()){
              script.AddAction(Constants.OUTPUT, new DrawRobotAction(VideoService));  
            }
 
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService)); 
            script.AddAction(Constants.OUTPUT, new ChangeCameraView(KeyboardService)); 
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
               
            script.AddAction(Constants.UPDATE, new TimeTracker());     
            script.AddAction(Constants.UPDATE, new RobotMoveDecision());     
        }
    }
}