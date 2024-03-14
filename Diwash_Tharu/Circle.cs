using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{/// <summary>
/// this class use inheritance to imtroduce the code inside this class 
/// </summary>
    public class Circle:Shapes
    {
        /// <summary>
        /// inital raduis of the circle 
        /// </summary>
        private readonly int _defaultRadius = 85;
        private int Radius { get; set; }
        public Circle()
        {
            Radius = _defaultRadius;
        }
        /// <summary>
        /// this is the method to create the cirle 
        /// </summary>
        /// <param name="position">get the position</param>
        /// <param name="fill">get the boolean to fll the colo </param>
        /// <param name="penColor">get the pen color </param>
        /// <param name="radius">get the radius from the user</param>
        public Circle(Point position, bool fill, Color penColor, int radius) : base(position, fill, penColor)
        {
            Radius = radius;
        }
        public override void Draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a circle
                var pen = new Pen(PenColor, 2);
                g.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2); // Position if offset so that center of the circle is at the current cursor
                pen.Dispose(); // Dispose of the pen to avoid memory leaks
                return; // Return to avoid drawing the fill
            }
            // Fills a circle
            var brush = new SolidBrush(PenColor);
            g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose(); // Dispose of the brush to avoid memory leaks
        }
    }
}

