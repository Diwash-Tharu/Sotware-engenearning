using System.ComponentModel;
using System.Drawing;

namespace Diwash_Tharu
{
    public class Pointers : Shapes
    {
        /// <summary>
        /// Blank constructor to create a Cursor object.
        /// </summary>
        public Pointers() : base()
        {

        }

        /// <summary>
        ///update the pointer position
        /// </summary>
        /// <param name="position">New position of the cursor.</param>
        public void MoveTo(Point position)
        {
            Position = position;
        }
        /// <summary>
        /// initilize the pen color inside the penColor
        /// </summary>
        /// <param name="penColor"></param>
        public void ChangePenColor(Color penColor)
        {
            PenColor = penColor;
        }
        /// <summary>
        /// initize the fill state in the command 
        /// </summary>
        /// <param name="fillState"></param>
        public void ChangeFillState(bool fillState)
        {
            Fill = fillState;
        }

        /// <summary>
        /// Draws a cursor on a WinForms control.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            var b = new SolidBrush(PenColor);
            g.FillRectangle(b, Position.X, Position.Y, 5, 8);
           
        }
    }
}