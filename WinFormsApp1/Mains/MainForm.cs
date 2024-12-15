
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.Encodings.Web;
using Timer = System.Threading.Timer;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class MainForm : Form 
    {
        private Paddle paddle;
        private Brick brick;
        private BrickLogic brickLogic;
        private ResizeHandler handler = new ResizeHandler();
        private GameLoop loop;
        private readonly CancellationTokenSource cts = new();
        private int delayTime = 8;
        private KeyListeners listeners;
        Ball ball;
        private Components components;
        public MainForm()
        {
            paddle = new Paddle();
            ball = new Ball();
            components = new Components(this);
            components.components();
            subscriptions();
            formParams();
            loop = new GameLoop(paddle, ball, this);
            loop.startGame();
        }

        private void formParams()
        {
            this.BackColor = Color.Black;                                              
            this.Size = new Size(1200, 800);                                           
            this.Text = "BrickBall (wip)";                                             
            this.KeyPreview = true;                                                    
            this.FormBorderStyle = FormBorderStyle.FixedDialog;                        
            this.MaximizeBox = true;                                                                                
        }
        
        private void subscriptions()
        {            
            Resize += new EventHandler(handlers);                                                                           
            listeners = new KeyListeners(paddle);                                                                           
            this.KeyDown += listeners.MainForm_KeyDown;                                                                     
            this.KeyUp += listeners.MainForm_KeyUp;                                                                         }
        private void handlers(object? sender, EventArgs e)
        {
            handler.ResizeHandlers(this, new Panel[] { paddle, ball });
        }

        [STAThread]
        public static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}