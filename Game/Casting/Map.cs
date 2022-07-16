using System;
using System.Collections.Generic;


namespace Security.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Map : Actor
    {
        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Robot.
        /// </summary>
        public Map(Body body, Image image, bool debug = false) : base(debug)
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

    }
}