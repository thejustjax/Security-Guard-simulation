using System;

namespace Security.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Stats : Actor
    {
        private int clock;
        private int lives;
        private int battery;

        private DateTime start = new DateTime();
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Stats(int clock = 120, int lives = 1, int battery = 100, 
                bool debug = false) : base(debug)
        {
            this.clock = clock;
            this.lives = lives;
            this.battery = battery;
        }

        /// <summary>
        /// Adds one level.
        /// </summary>
        public void SetTime(int time)
        {
            clock = time;
        }

        /// <summary>
        /// Adds an extra life.
        /// </summary>
        public void AddLife()
        {
            lives++;
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The given points.</param>
        public void RemoveBattery(int drain)
        {
            battery -= drain;
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns>The level.</returns>
        public int GetClock()
        {
            return clock;
        }

        /// <summary>
        /// Gets the lives.
        /// </summary>
        /// <returns>The lives.</returns>
        public int GetLives()
        {
            return lives;
        }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <returns>The score.</returns>
        public int GetBattery()
        {
            return battery;
        }

        /// <summary>
        /// Removes a life.
        /// </summary>
        public void RemoveLife()
        {
            lives--;
            if (lives <= 0)
            {
                lives = 0;
            }
        }
        public DateTime GetStart(){
            return start;
        }
        public void SetStart(DateTime newstart){
            start = newstart;
        }
        
        
    }
}