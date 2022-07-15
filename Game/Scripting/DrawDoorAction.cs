using Security.Game.Casting;
using Security.Game.Services;
using Security.Game.Directing;

namespace Security.Game.Scripting
{
    public class DrawDoorAction : Action
    {
        private VideoService videoService;
        private KeyboardService keyboardService;
        private int Westdoor_Value;
        private int Eastdoor_Value;
        
        public DrawDoorAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (keyboardService.IsKeyDown(Constants.WESTDOOR_BUTTON))
            {
                WestDoor westdoor = (WestDoor)cast.GetFirstActor(Constants.WESTDOOR_GROUP);
                Body westdoorbody = westdoor.GetBody();
                if (westdoor.IsDebug())
                {
                    Rectangle westdoorrectangle = westdoorbody.GetRectangle();
                    Point westdoorsize = westdoorrectangle.GetSize();
                    Point westdoorpos = westdoorrectangle.GetPosition();
                    videoService.DrawRectangle(westdoorsize, westdoorpos, Constants.PURPLE, false);
                }
                Image westdoorimage = westdoor.GetImage();
                Point westdoorposition = westdoorbody.GetPosition();
                videoService.DrawImage(westdoorimage, westdoorposition);
            }

            else if (keyboardService.IsKeyUp(Constants.WESTDOOR_BUTTON))
            {

            }

            if (keyboardService.IsKeyDown(Constants.EASTDOOR_BUTTON))
            {
                EastDoor eastdoor = (EastDoor)cast.GetFirstActor(Constants.EASTDOOR_GROUP);
                Body eastdoorbody = eastdoor.GetBody();
                if (eastdoor.IsDebug())
                {
                    Rectangle eastdoorrectangle = eastdoorbody.GetRectangle();
                    Point eastdoorsize = eastdoorrectangle.GetSize();
                    Point eastdoorpos = eastdoorrectangle.GetPosition();
                    videoService.DrawRectangle(eastdoorsize, eastdoorpos, Constants.PURPLE, false);
                }

                Image eastdoorimage = eastdoor.GetImage();
                Point eastdoorposition = eastdoorbody.GetPosition();
                videoService.DrawImage(eastdoorimage, eastdoorposition);
                
            }

            else if (keyboardService.IsKeyUp(Constants.EASTDOOR_BUTTON))
            {
                
            }

            ///EastDoor eastdoor = (EastDoor)cast.GetFirstActor(Constants.EASTDOOR_GROUP);
            //Body eastdoorbody = eastdoor.GetBody();
            //if (eastdoor.IsDebug())
            //{
              //  Rectangle eastdoorrectangle = eastdoorbody.GetRectangle();
                //Point eastdoorsize = eastdoorrectangle.GetSize();
                //Point eastdoorpos = eastdoorrectangle.GetPosition();
                //videoService.DrawRectangle(eastdoorsize, eastdoorpos, Constants.PURPLE, false);
            //}

            //Image eastdoorimage = eastdoor.GetImage();
            //Point eastdoorposition = eastdoorbody.GetPosition();
            //videoService.DrawImage(eastdoorimage, eastdoorposition);
        }
    }
}