using Security.Game.Casting;
using Security.Game.Services;
using Security.Game.Directing;

namespace Security.Game.Scripting
{
    public class DrawRobotAction : Action
    {
        private VideoService videoService;
        
        public DrawRobotAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Robot robot = (Robot)cast.GetFirstActor(Constants.ROBOT_GROUP);
            Body body = robot.GetBody();
            if (robot.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Image image = robot.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}