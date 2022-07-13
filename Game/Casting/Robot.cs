using System;
using System.Collections.Generic;


namespace Security.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Robot : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;
        public List<int> moveList = new List<int>();

        private string location = Constants.STAGE_NAME;
        /// <summary>
        /// Constructs a new instance of Robot.
        /// </summary>
        public Robot(Body body, Image image, bool debug = false) : base(debug)
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

    }
}