using Security.Game.Casting;
using Security.Game.Services;
using System.Collections.Generic;
using System;

namespace Security.Game.Scripting
{
    public class RobotMoveDecision : Action
    {
        
        public void Execute(Cast cast, Script script, ActionCallback callback){
            Robot robot = (Robot)cast.GetFirstActor(Constants.ROBOT_GROUP);
            Body body = robot.GetBody();
            Random random = new Random();
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            if((stats.GetClock() % Constants.MOVE_TIME) == 0 && DateTime.Now.Millisecond < 15){
                if(random.Next(1,21) <= Constants.ROBOT_DIFFICULTY){
                    if (robot.GetLocation() == Constants.STAGE_NAME){
                            robot.ChangeLocation(Constants.ROOM1_NAME);
                    }
                    else if (robot.GetLocation() == Constants.ROOM1_NAME){
                            robot.ChangeLocation(Constants.ROOM2_NAME);
                    }
                    else if (robot.GetLocation() == Constants.ROOM2_NAME){
                        if (random.Next(0,2) == 1){
                            robot.ChangeLocation(Constants.EHALL_NAME);
                        }
                        else{
                            robot.ChangeLocation(Constants.WHALL_NAME);
                        } 
                    }
                    else if (robot.GetLocation() == Constants.EHALL_NAME || robot.GetLocation() == Constants.WHALL_NAME){
                        robot.ChangeLocation(Constants.OFFICE_NAME);
                    }
                    else if (robot.GetLocation() == Constants.OFFICE_NAME){
                        callback.OnNext(Constants.GAME_OVER);
                    }
                }
            }
        }
    }
}