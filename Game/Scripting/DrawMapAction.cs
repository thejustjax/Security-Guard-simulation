using Security.Game.Casting;
using Security.Game.Services;
using Security.Game.Directing;

namespace Security.Game.Scripting
{
    public class DrawMapAction : Action
    {
        private VideoService videoService;
        
        public DrawMapAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            Map map = (Map)cast.GetFirstActor(Constants.MAP_GROUP);
            Body body = map.GetBody();
            if (stats.currentScene == Constants.OFFICE_NAME || stats.currentScene == Constants.STAGE_NAME || 
            stats.currentScene == Constants.ROOM1_NAME || stats.currentScene == Constants.ROOM2_NAME || 
            stats.currentScene == Constants.EHALL_NAME || stats.currentScene == Constants.WHALL_NAME){
                if (map.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Image image = map.GetImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
    }
}