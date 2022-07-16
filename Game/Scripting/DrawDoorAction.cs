using Security.Game.Casting;
using Security.Game.Services;
using Security.Game.Directing;

namespace Security.Game.Scripting
{
    public class DrawDoorAction : Action
    {
        private VideoService videoService;
        private KeyboardService keyboardService;
        private int Westdoor_Value = 0;
        private int Eastdoor_Value = 0;
        
        public DrawDoorAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (Westdoor_Value == 1)
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

            else if (Westdoor_Value == 0)
            {
                OpenWestDoor openwestdoor = (OpenWestDoor)cast.GetFirstActor(Constants.OPENWESTDOOR_GROUP);
                Body openwestdoorbody = openwestdoor.GetBody();
                if (openwestdoor.IsDebug())
                {
                    Rectangle openwestdoorrectangle = openwestdoorbody.GetRectangle();
                    Point openwestdoorsize = openwestdoorrectangle.GetSize();
                    Point openwestdoorpos = openwestdoorrectangle.GetPosition();
                    videoService.DrawRectangle(openwestdoorsize, openwestdoorpos, Constants.PURPLE, false);
                }
                Image openwestdoorimage = openwestdoor.GetImage();
                Point openwestdoorposition = openwestdoorbody.GetPosition();
                videoService.DrawImage(openwestdoorimage, openwestdoorposition);
            }

            if (Eastdoor_Value == 1)
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

            else if (Eastdoor_Value == 0)
            {
                OpenEastDoor openeastdoor = (OpenEastDoor)cast.GetFirstActor(Constants.OPENEASTDOOR_GROUP);
                Body openeastdoorbody = openeastdoor.GetBody();
                if (openeastdoor.IsDebug())
                {
                    Rectangle openeastdoorrectangle = openeastdoorbody.GetRectangle();
                    Point openeastdoorsize = openeastdoorrectangle.GetSize();
                    Point openeastdoorpos = openeastdoorrectangle.GetPosition();
                    videoService.DrawRectangle(openeastdoorsize, openeastdoorpos, Constants.PURPLE, false);
                }
                Image openeastdoorimage = openeastdoor.GetImage();
                Point openeastdoorposition = openeastdoorbody.GetPosition();
                videoService.DrawImage(openeastdoorimage, openeastdoorposition);
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