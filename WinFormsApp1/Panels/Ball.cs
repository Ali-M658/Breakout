using System.Text.Json.Serialization;

namespace WindowsFormsApp;

public class Ball : Panel
{
    
    [JsonInclude] public int x = 300, y = 300;
    
    [JsonInclude] public int xspeed = 5;
    [JsonInclude] public int yspeed = 5;
    [JsonInclude] int ballWidth;
    [JsonInclude] int ballHeight;
    [JsonInclude] private int counter = 0;

    public int X
    {
        get => x;
        set => x = value;
    }
    public int Y
    {
        get => y;
        set => y = value;
    }
    public Ball()
    {
        this.Size = new Size(50, 50);
        this.DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        
        Graphics g = e.Graphics;
        
        ballWidth = 20;
        ballHeight = 20;
        
        using Pen pen = new Pen(Color.Red, 3);
        using SolidBrush brush = new SolidBrush(Color.LightSeaGreen);
        Rectangle ellipseRectangle = new Rectangle(X, Y, ballWidth, ballHeight);
        g.FillEllipse(brush, ellipseRectangle);
        
    }
    public void Move(int x,int y)
    {
        X += xspeed;
        Y += yspeed;
        Invalidate();
    }

    public void IncreaseSpeed()
    {
        if (counter < 5)
        {
        xspeed += xspeed > 0 ? 1 : -1;
        yspeed += yspeed > 0 ? 1 : -1;
        }
        counter++;
    }
}