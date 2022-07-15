using System;
using System.Collections.Generic;


namespace Security.Game.Casting
{

    public class OpenWestDoor : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        private string location;

        public OpenWestDoor(Body body, Image image, bool debug = false) : base(debug)
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
    }
}