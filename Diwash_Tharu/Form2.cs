using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diwash_Tharu
{

    public partial class Form2 : Form
    {
        private Timer flickerTimer;
        private Random random;
        private int flameHeight;
        public Form2()
        {
            InitializeComponent();

            // Set up the form

            this.BackColor = Color.Black;

            // Set up the flicker timer
            flickerTimer = new Timer();
            flickerTimer.Interval = 50; // Adjust the interval based on your preference
            flickerTimer.Tick += new EventHandler(Timer_Tick_1);

            // Set up the random number generator
            random = new Random();

            // Initialize flame height
            flameHeight = 100;

            // Start the flicker timer
            flickerTimer.Start();
        }

       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the candlestick
            e.Graphics.FillRectangle(Brushes.Gray, ClientRectangle.Width / 2 - 20, 250, 40, 250);

            // Draw the flame
            DrawFlame(e.Graphics, ClientRectangle.Width / 2, 250, flameHeight);
        }

        private void DrawFlame(Graphics g, int x, int y, int height)
        {
            // Draw the flame as an ellipse with a gradient
            Rectangle rectangle = new Rectangle(x - 20, y - height, 40, height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.Yellow, Color.Red, LinearGradientMode.Vertical))
            {
                g.FillEllipse(brush, rectangle);
            }
        }

        private void Timer_Tick_1(object sender, EventArgs e)
        {
            // Update flame height with a random value
            flameHeight += random.Next(-5, 5);

            // Ensure flame height stays within bounds
            if (flameHeight < 80)
                flameHeight = 80;
            else if (flameHeight > 120)
                flameHeight = 120;

            // Redraw the candle
            this.Invalidate();
        }
    }
}


