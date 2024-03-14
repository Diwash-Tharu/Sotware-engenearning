using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{
    /// <summary>
    /// Represents a square shape in a graphics context.
    /// </summary>
    internal class Square:Rectangles
    {
        ///private readonly int _defaultSideLength = 100;
        /// <summary>
        /// Gets or sets the side length of the square.
        /// </summary>
        private int SideLength { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with default properties.
        /// </summary>
        //public Square()
        //{
        //    SideLength = _defaultSideLength;
        //}
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with specified properties.
        /// </summary>
        /// <param name="position">The position of the square.</param>
        /// <param name="fill">Determines whether the square is filled or outlined.</param>
        /// <param name="penColor">The color of the square's pen (outline).</param>
        /// <param name="sideLength">The side length of the square.</param>
        public Square(Point position, bool fill, Color penColor, int sideLength) : base(position, fill, penColor, sideLength, sideLength)
        {
            SideLength = sideLength;
        }
        /// <summary>
        /// Draws the square on the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context on which to draw the square.</param>
        public override void Draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a rectangle
                var pen = new Pen(PenColor, 2);
                g.DrawRectangle(pen, Position.X, Position.Y, SideLength, SideLength);
                pen.Dispose(); // Dispose of the pen to avoid memory leaks
                return; // Return to avoid drawing the fill
            }
            // Fills a rectangle
            var brush = new SolidBrush(PenColor);
            g.FillRectangle(brush, Position.X, Position.Y, SideLength, SideLength);
            brush.Dispose(); // Dispose of the brush to avoid memory leaks
        }
    }
}