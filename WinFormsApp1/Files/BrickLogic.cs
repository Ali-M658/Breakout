namespace WindowsFormsApp;

public class BrickLogic
{
    private MainForm form;
    int brickCount = 15; //the brickcount and brick[] amount have to be the same
    Brick[] bricks;
    
    public BrickLogic(MainForm form)
    {
        this.form = form;
        bricks = new Brick[brickCount];
    }
    public void MakeBricks()
    {
        int level = 0;
        for (int i = 0; i < brickCount; i++)
        {
            if (i % 5 == 0 && i != 0)
            {
                level++;
            }
            Color color = Color.FromArgb(i, 15 * i, 10 * i);
            bricks[i] = new Brick(200,100,color,200*i,100*level);
        }
    }

    public void DrawBricks()
    {
        for (int i = 0; i < brickCount; i++)
        {
            form.Add(bricks[i]);
        }
    }
}
