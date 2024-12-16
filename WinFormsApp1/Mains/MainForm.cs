
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.Encodings.Web;
using Timer = System.Threading.Timer;
using System.Threading.Tasks;
using System.Media;
namespace WindowsFormsApp
{
    public class MainForm : Form 
    {
        private Paddle paddle;
        private SoundPlayer soundPlayer;
        private string path = "C:\\Users\\ali\\Downloads\\spooky-scary-wind-rising_70bpm.wav";
        private BrickLogic brickLogic;
        private ResizeHandler handler = new ResizeHandler();
        private GameLoop loop;
        private readonly CancellationTokenSource cts = new();
        private KeyListeners listeners;
        Ball ball;
        public MainForm()
        {
            soundPlayer = new SoundPlayer(path);
            soundPlayer.PlayLooping();
            brickLogic = new BrickLogic(this);
            components();
            subscriptions();
            formParams();
            loop = new GameLoop(paddle, ball, this);
            loop.startGame();
        }

        
        public void components()
        { 
            brickLogic = new BrickLogic(this);
            brickLogic.DrawBricks(); 
            brickLogic.MakeBricks();
            paddle = new Paddle() { Location = new Point(Width/3, 500) }; 
            Console.WriteLine(Height); 
            Controls.Add(paddle); 
            ball = new Ball {
                Dock = DockStyle.Fill, 
                Location = new Point(Width / 2, Height / 2),
            };            
            Controls.Add(ball);         
        }
        private void formParams()
        {
            this.BackColor = Color.Black;                                              
            this.Size = new Size(1200, 800);                                           
            this.Text = "HorrorBall";                                             
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

        public void Add(Panel panel)
        {
            Controls.Add(panel);
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