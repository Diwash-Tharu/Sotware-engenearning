using System.Drawing;
using System.Security.Cryptography;

namespace Diwash_Tharu
{
    /// <summary>
    /// A class that implements the <see cref="Shape" /> parent class and is used to create <see cref="Triangle" /> objects and draw them on a WinForms control.
    /// </summary>
    /// <seealso cref="Shape" />
    public class Triangle : Shapes
    {
        // Sets up default values for the blank constructor when the user doesn't pass any values. Currently unused in this program.
        private readonly int _defaultLength = 125;

        // Properties for other values used in the class.

        public int Length { get; set; }
        public int hypoten { get; set; }
        public int bases { get; set; }
        // Stores the side length of the Triangle

        // Creates 3 Point properties to store coordinates of Triangle vertices
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }

        /// <summary>
        /// this code is use to make the triangle 
        /// 
        /// </summary>
        public Triangle() : base()
        {
            Length = _defaultLength;
            SetupTriangleVertices(Length, hypoten, bases);
        }

        /// <summary>
        /// Main constructor to create a right-angled Triangle object with given parameters.
        /// </summary>
        /// <param name="position">current position.</param>
        /// <param name="fill">fill status of the code.</param>
        /// <param name="penColor">Current pen coloe.</param>
        
        public Triangle(Point position, bool fill, Color penColor, int lengthValue, int hypoten,int bases) : base(position, fill, penColor)
        {
            Length = lengthValue;
            SetupTriangleVertices(Length,hypoten,bases);
        }

        /// <summary>
        /// side lenght of the  right-angled Triangle.
        /// </summary>
        /// <param name="length">Length of the sides of the Triangle, used to setup the vertices.</param>
        private void SetupTriangleVertices(int length,int hypoten, int bases)
        {
            A = new Point(Position.X, Position.Y);
            B = new Point(Position.X, Position.Y + hypoten);
            C = new Point(Position.X + length, Position.Y + bases);
        }

        /// <summary>
        /// Draw the triangle of the code 
        /// </summary>
        public override void Draw(Graphics g)
        {
            // Creates an array of Points
            Point[] vertices = { A, B, C };

            if (!Fill)
            {
                // Draws a triangle
                var pen = new Pen(PenColor, 2);
                g.DrawPolygon(pen, vertices);
                pen.Dispose(); // Dispose of the pen to avoid memory leaks
                return; // Return to avoid drawing the fill
            }
            // Fills a triangle
            var brush = new SolidBrush(PenColor);
            g.FillPolygon(brush, vertices);
            brush.Dispose(); // Dispose of the brush to avoid memory leaks
        }
    }
}