using Raylib_cs;
using Security.Game.Casting;
using Security.Game.Services;


namespace Security.Game.Scripting
{
    public class EndDrawingAction : Action
    {
        private VideoService videoService;
        
        public EndDrawingAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            videoService.FlushBuffer();
        }
    }
}