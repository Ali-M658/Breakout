using System.ComponentModel;

namespace WindowsFormsApp;

public class GameLoop
{
    private Paddle paddle;
    private Ball ball;
    private MainForm form;
    private readonly CancellationTokenSource cts = new CancellationTokenSource();
    private int gameLoopTime = 8;
    
    public GameLoop(Paddle paddle, Ball ball, MainForm form)
    {
        this.paddle = paddle;
        this.ball = ball;
        this.form = form;
    }

    public async void startGame()
    {
        try
        {
            while (!cts.Token.IsCancellationRequested)
            {
                await Task.Delay(gameLoopTime, cts.Token);
                paddle.Move();
                ball.Move(10,10);
                PaddleBallCollisionChecker.checkCollision(paddle, ball);
                PaddleBallCollisionChecker.checkCollisionWithWall(ball, form.ClientSize.Width, form.ClientSize.Height);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        } 
    }
    public void stopGame()
    {
        cts.Cancel();
    }
}