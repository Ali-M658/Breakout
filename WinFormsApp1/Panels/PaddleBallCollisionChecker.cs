using System;
using static System.Media.SoundPlayer;

namespace WindowsFormsApp
{
    public class PaddleBallCollisionChecker
    {
        public static void checkCollision(Paddle paddle, Ball ball)
        {
            ///Console.WriteLine(paddle.Top+" paddle top");
            Console.WriteLine(ball.Top + " ball top");
            //Console.WriteLine(paddle.Left + " paddle left");
            //Console.WriteLine(paddle.Right + " paddle right");
            Console.WriteLine(ball.Right + " ball right");
            Console.WriteLine(ball.Left + " ball left");
            if ((ball.Y >= (paddle.Bottom - 25) && ball.Y <= (paddle.Bottom - 19)) && (ball.Left >= paddle.Left && ball.Right <= paddle.Right)) {
                Console.WriteLine("If statement reached in PaddleBallCollisionChecker");
                ball.yspeed = -ball.yspeed;
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