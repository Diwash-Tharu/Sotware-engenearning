using System.Drawing;

namespace Diwash_Tharu
{
   /// <summary>
   ///  it inheriate the  form the shapes  to use that function inside this class
   /// </summary>
    public class Line : Shapes
    {
        /// <summary>
        /// set the default position ofn the line 
        /// </summary>
        private readonly Point _defaultToPosition = new Point(250, 250);

        // Properties for other values used in the class.
        private Point ToPosition { get; set; } // Stores the coordinates of where the Line should end at

        /// <summary>
        /// Blank constructor to create a Line object, set to a constant default Point value.
        /// </summary>
        public Line() : base()
        {
            ToPosition = _defaultToPosition;
        }

        /// <summary>
        /// main construction to draw the line 
        /// </summary>
        /// <param name="currentPosition">Current position of the cursor.</param>
        /// <param name="fill">Current fill state of the cursor.</param>
        /// <param name="penColor">Current pen color from the cursor.</param>
        /// <param name="toPosition">Position where the Line should end at.</param>
        public Line(Point currentPosition, bool fill, Color penColor, Point toPosition) : base(currentPosition, fill, penColor)
        {
            ToPosition = toPosition;
        }

        /// <summary>
        /// Draws a Line to a given position on a WinForms control
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            var pen = new Pen(PenColor, 2);
            g.DrawLine(pen, Position.X, Position.Y, ToPosition.X, ToPosition.Y);
            Position = ToPosition;
            pen.Dispose(); // Dispose of the pen to avoid memory leaks
        }
    }
}
