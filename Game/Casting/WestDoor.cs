using System;
using System.Collections.Generic;


namespace Security.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class WestDoor : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        private string location;
        /// <summary>
        /// Constructs a new instance of Robot.
        /// </summary>
        public WestDoor(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }
        
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
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