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
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
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

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }


        private void PrepareNextLevel(Cast cast, Script script)
        {
            AddDialog(cast, Constants.CLOCKING_IN);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PreparePartyRoom1(){

        }

        private void PreparePartyRoom2(){

        }

        private void PrepareWHall(){

        }

        private void PrepareEHall(){

        }

        private void PrepareOffice(){

        }



        

        private void PrepareTryAgain(Cast cast, Script script)
        {
            AddDialog(cast, Constants.CLOCKING_IN);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            
            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();
            AddUpdateActions(script);    
            AddOutputActions(script);
        
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------
        private void AddRobot(Cast cast)
        {
            cast.ClearActors(Constants.ROBOT_GROUP);
        
            int x = Constants.CENTER_X - Constants.ROBOT_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - - Constants.ROBOT_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.ROBOT_WIDTH, Constants.ROBOT_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.ROBOT_IMAGE);
            Robot robot = new Robot(body, image, false);
        
            cast.AddActor(Constants.ROBOT_GROUP, robot);
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
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

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRobotAction(VideoService));
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
        
        }
    }
}