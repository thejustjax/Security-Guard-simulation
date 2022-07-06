using System;
using Security.Game.Directing;
using Security.Game.Services;

namespace Security
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}
