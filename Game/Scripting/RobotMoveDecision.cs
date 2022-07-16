using Security.Game.Casting;
using Security.Game.Services;
using System.Collections.Generic;
using System;

namespace Security.Game.Scripting
{
    public class RobotMoveDecision : Action
    {
        public RobotMoveDecision(){
            
        }
        
        public void Execute(Cast cast, Script script, ActionCallback callback){
            Robot robot = (Robot)cast.GetFirstActor(Constants.ROBOT_GROUP);
            Body body = robot.GetBody();
            Random random = new Random();
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            WestDoor westdoor = (WestDoor)cast.GetFirstActor(Constants.WESTDOOR_GROUP);
            EastDoor eastdoor = (EastDoor)cast.GetFirstActor(Constants.EASTDOOR_GROUP);
            if((stats.GetClock() % Constants.MOVE_TIME) == 3 && !robot.moveList.Contains(stats.GetClock())){
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
                        if(stats.checkWestDoor()){
                            robot.ChangeLocation(Constants.OFFICE_NAME);
                        }
                        else{
                            stats.RemoveBattery(Constants.BATTERY_DRAIN);
                            robot.ChangeLocation(Constants.STAGE_NAME);
                        }
                    }
                    else if (robot.GetLocation() == Constants.OFFICE_NAME){
                        callback.OnNext(Constants.GAME_OVER);
                    }
                    robot.moveList.Add(stats.GetClock());
                }
            }
        }
    }
}