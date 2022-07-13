using System;
using System.Collections.Generic;


namespace Security.Game.Casting
{

    public class EastDoor : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        private string location;

        public EastDoor(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }
        
        public Body GetBody()
        {
            return body;
        }

        public Image GetImage()
        {
            return image;
        }

        public string GetLocation()
        {
            return location;
        }

        public void ChangeLocation(string newlocation)
        {
            location = newlocation;
        }

        public void ChangePosition(int doorposition)
        {
            if (doorposition == 1){
                doorposition = 0;
            }
            else if(doorposition == 0){
                doorposition = 1;
            }
        }
    }
}