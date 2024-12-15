using System;
using static System.Media.SoundPlayer;

namespace WindowsFormsApp
{
    public class PaddleBallCollisionChecker
    {
        public static void checkCollision(Paddle paddle, Ball ball)
        {
            //Console.WriteLine($"{paddle.Top-10} and {ball.Y} and {ball.X} and {paddle.Left} and  {paddle.Right}");
            if (ball.Y == (paddle.Top - 10) && (ball.X >= paddle.Left && ball.X <= paddle.Right)) 
            {
                ball.yspeed = -ball.yspeed;
            }
            
            else
            {
                int e = 0;
            }
        }

        public static void checkCollisionWithWall(Ball ball, int screenWidth, int screenHeight)
        {
            if (ball.X < 0 || ball.X > screenWidth)
            {
                ball.xspeed = -ball.xspeed;
                
            }

            if (ball.Y <= 0 || ball.Y >= screenHeight)
            {
                ball.yspeed = -ball.yspeed;
            }
        }
    }
}