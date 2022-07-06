using System.Collections.Generic;
using Security.Game.Casting;
using Security.Game.Scripting.Raylib;
using Security.Game.Services;


namespace Security.Game.Directing
{
    /// <summary>
    /// A person who directs the game.
    /// </summary>
    public class Director : ActionCallback
    {
        private Cast cast;
        private Script script;
        private SceneManager sceneManager;
        private VideoService videoService;
        
        /// <summary>
        /// Constructs a new instance of Director using the given VideoService.
        /// </summary>
        /// <param name="videoService">The given VideoService.</param>
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
            this.cast = new Cast();
            this.script = new Script();
            this.sceneManager = new SceneManager();
        }

        /// </inheritdoc>
        public void OnNext(string scene)
        {
            sceneManager.PrepareScene(scene, cast, script);
        }
        
        /// <summary>
        /// Starts the game by running the main game loop for the given cast and script.
        /// </summary>
        public void StartGame()
        {
            OnNext(Constants.NEW_GAME);
            ExecuteActions(Constants.INITIALIZE);
            ExecuteActions(Constants.LOAD);
            while (videoService.IsWindowOpen())
            {

                // DoInputs
                ExecuteActions(Constants.INPUT);

                //DoUpdates
                ExecuteActions(Constants.UPDATE);

                //DoOutputs
                ExecuteActions(Constants.OUTPUT);
            }
            ExecuteActions(Constants.UNLOAD);
            ExecuteActions(Constants.RELEASE);
        }

        private void ExecuteActions(string group)
        {
            List<Action> actions = script.GetActions(group);
            foreach(Action action in actions)
            {
                action.Execute(cast, script, this);
            }
        }
    }
}



