namespace WindowsFormsApp;

public class Brick : Panel
{
    public bool hit { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Color BrickColor { get; set; }
    public int Score { get; set; }
    public Brick(int width, int height, Color brickColor,int x, int y, int score = 0)
    {
        this.Width = width;
        this.Height = height;
        this.BackColor = brickColor;
        // your properties
        this.X = x;
        this.Y = y;
        this.Location = new Point(X, Y);
        hit = false;
        this.Score = score;
        this.BrickColor = brickColor;
        this.Bounds = new Rectangle(this.X, this.Y, this.Width, this.Height);
    }

    public void Hit()
    {
        this.hit = true;
        if (this.Parent != null)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
            IncreaseScore(10);
        }
    }
    public void IncreaseScore(int amount)
    {
        this.Score += amount;
    }
}