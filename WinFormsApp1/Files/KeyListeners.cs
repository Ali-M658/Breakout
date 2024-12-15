using System;
using WindowsFormsApp;
using static WindowsFormsApp.Paddle;

namespace WindowsFormsApp
{
    public class KeyListeners
    {
        private readonly Paddle paddle;
        public KeyListeners(Paddle paddle)
        {
            this.paddle = paddle;
        }
        
        public void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    paddle.Direction = -1;
                    //This one works
                    break;
                case Keys.D:
                    paddle.Direction = 1;
                    break;
                default:
                    break;
            }
        }

        public void MainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            // Stop movement when keys are released
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                paddle.Direction = 0;
            }
        }
    }
}

