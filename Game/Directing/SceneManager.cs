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
            else if (scene == Constants.STAGE_NAME){
                PrepareStage(cast, script);
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
            AddStats(cast);
            AddClock(cast);
            AddBattery(cast);
            AddLives(cast);
            AddDialog(cast, Constants.ENTER_TO_START);
            AddRobot(cast);
            AddMap(cast);
            AddEastDoor(cast);
            AddOpenEastDoor(cast);
            AddWestDoor(cast);
            AddOpenWestDoor(cast);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.NEW_GAME);
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
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.NEXT_LEVEL);
            AddDialog(cast, Constants.CLOCKING_IN);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.OFFICE_NAME, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(cast, script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }
        private void PrepareStage(Cast cast, Script script){
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.STAGE_NAME);
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddDialog(cast, Constants.STAGE_NAME);
            AddOutputActions(cast, script);
        }
        private void PreparePartyRoom1(Cast cast, Script script){
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.ROOM1_NAME);
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddDialog(cast, Constants.ROOM1_NAME);
            AddOutputActions(cast, script);
        }

        private void PreparePartyRoom2(Cast cast, Script script){
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.ROOM2_NAME);
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);    
            AddDialog(cast, Constants.ROOM2_NAME);
            AddOutputActions(cast, script);
        }

        private void PrepareWHall(Cast cast, Script script){
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.WHALL_NAME);
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script);
            AddDialog(cast, Constants.WHALL_NAME);    
            AddOutputActions(cast, script);
        }

        private void PrepareEHall(Cast cast, Script script){
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.EHALL_NAME);
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();;
            AddUpdateActions(script);   
            AddDialog(cast, Constants.EHALL_NAME); 
            AddOutputActions(cast, script);
        }

        private void PrepareOffice(Cast cast, Script script)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.OFFICE_NAME);
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();
            AddUpdateActions(script); 
            AddDialog(cast, Constants.OFFICE_NAME);   
            AddOutputActions(cast, script);
        
        }



        

        private void PrepareTryAgain(Cast cast, Script script)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.TRY_AGAIN);
            AddDialog(cast, Constants.CLOCKING_IN);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.OFFICE_NAME, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            
            AddUpdateActions(script);
            AddOutputActions(cast, script);
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.GAME_OVER);
            AddRobot(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);
            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            AddOutputActions(cast, script);
        }
        private void PrepareGameWin(Cast cast, Script script)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            stats.SetScene(Constants.GAME_WIN);
            AddDialog(cast, Constants.YOU_WIN);
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
            int y = Constants.CENTER_Y + Constants.ROBOT_HEIGHT /2;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.ROBOT_WIDTH, Constants.ROBOT_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.ROBOT_IMAGE);
            Robot robot = new Robot(body, image, false);
        
            cast.AddActor(Constants.ROBOT_GROUP, robot);
        }
        private void AddMap(Cast cast)
        {
            cast.ClearActors(Constants.MAP_GROUP);
        
            int x = Constants.CENTER_X - Constants.MAP_WIDTH;
            int y = Constants.CENTER_Y - (Constants.MAP_HEIGHT * 3/2);
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.MAP_WIDTH, Constants.MAP_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.MAP_IMAGE);
            Map map = new Map(body, image, false);
        
            cast.AddActor(Constants.MAP_GROUP, map);
        }
        private void AddEastDoor(Cast cast)
        {
            cast.ClearActors(Constants.EASTDOOR_GROUP);
        
            int x = Constants.SCREEN_WIDTH - Constants.EASTDOOR_WIDTH;
            int y = Constants.CENTER_Y - Constants.EASTDOOR_HEIGHT / 2;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.EASTDOOR_WIDTH, Constants.EASTDOOR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.WESTDOOR_CLOSED_IMAGE);
            EastDoor eastdoor = new EastDoor(body, image, false);
        
            cast.AddActor(Constants.EASTDOOR_GROUP, eastdoor);
        }

        private void AddOpenEastDoor(Cast cast)
        {
            cast.ClearActors(Constants.OPENEASTDOOR_GROUP);
        
            int x = Constants.SCREEN_WIDTH / 2 + Constants.EASTDOOR_WIDTH;
            int y = Constants.CENTER_Y - Constants.EASTDOOR_HEIGHT / 2;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.EASTDOOR_WIDTH, Constants.EASTDOOR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.WESTDOOR_OPEN_IMAGE);
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
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            Robot robot = (Robot)cast.GetFirstActor(Constants.ROBOT_GROUP);
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawMapAction(VideoService));
            if (stats.GetScene() == Constants.OFFICE_NAME){
                script.AddAction(Constants.OUTPUT, new DrawDoorAction(VideoService));
            }
            script.AddAction(Constants.OUTPUT, new DrawRobotAction(VideoService));  
            if (stats.currentScene == Constants.OFFICE_NAME || stats.currentScene == Constants.STAGE_NAME || 
            stats.currentScene == Constants.ROOM1_NAME || stats.currentScene == Constants.ROOM2_NAME || 
            stats.currentScene == Constants.EHALL_NAME || stats.currentScene == Constants.WHALL_NAME){
                            script.AddAction(Constants.OUTPUT, new ChangeCameraView(KeyboardService));
                            script.AddAction(Constants.OUTPUT, new ChangeDoorPosition(KeyboardService)); 
            }
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService)); 

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