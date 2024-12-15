namespace WindowsFormsApp;

public class Components
{
    BrickLogic brickLogic;
    Paddle paddle;
    private Ball ball;
    private MainForm form;

    public Components(MainForm form)
    {
        this.form = form;
    }
    public void components()
    {
        brickLogic = new BrickLogic(form);
        brickLogic.DrawBricks();
        brickLogic.MakeBricks();
        paddle = new Paddle() { Location = new Point(form.Width/3, 500) };     
        Console.WriteLine(form.Height);
        form.Controls.Add(paddle);            
        ball = new Ball { 
            Dock = DockStyle.Fill,                                                                                             
            BackColor = Color.Brown, 
            Location = new Point(form.Width / 2, form.Height / 2),
        };            
        form.Controls.Add(ball);         
    }
}