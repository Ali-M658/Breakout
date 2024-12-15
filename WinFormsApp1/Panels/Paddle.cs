using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json;


namespace WindowsFormsApp
{

    public class Paddle : Panel
    {
        // Set a point of left for later

        [JsonInclude] private int direction = 0;

        [JsonInclude] private int speed = 10;
    
        public int Direction
        {
            get => direction;
            set => direction = value;
        }
       
        public int Speed
        {
            get => speed;
            set => speed = value;
        }

        public Paddle()
        {
            // Set the initial size and appearance of the paddle
            this.Size = new Size(100, 20); // Default size of the paddle
            this.BackColor = Color.ForestGreen; // Default color of the paddle
            this.BorderStyle = BorderStyle.FixedSingle; // Optional border for the paddle
            SetBounds(this.Location.X, this.Location.Y, Width, Height);
        }
        
        
        public void Move()
        {
            if (Parent == null) return;
            int nextLeft = this.Left + (direction * speed);
            // Smart
            if (nextLeft >= 0 && nextLeft + this.Width <= this.Parent.ClientSize.Width)
            {
                this.Left = nextLeft;
            }
        }
    }
}