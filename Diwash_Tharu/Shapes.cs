using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{/// <summary>
/// inharitjng the Imageinterface class
/// </summary>
    public abstract class Shapes : ImageInterface
    {
       
        public  Point initalPosition = new Point(0, 0);
        public  bool initalFill = false;
        public  Color initalPenColor = Color.Red;
        /// <summary>
        /// getting the positon from the different methods and setting them 
        /// </summary>
        public Point Position { get; set; } 
        public bool Fill { get; set; }
        public Color PenColor { get; set; } 

        protected Shapes()
        {
            Position = initalPosition;
            Fill = initalFill;
            PenColor = initalPenColor;
        }
        /// <summary>
        /// codw will initilize for the postion, fill, pencolor
        /// </summary>
        /// <param name="position"></param>
        /// <param name="fill"></param>
        /// <param name="penColor"></param>
        protected Shapes(Point position, bool fill, Color penColor)
        {
            Position = position;
            Fill = fill;
            PenColor = penColor;
        }
       
        /// <summary>
        /// this is tha abstract class of the Draw of the class
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
    }
}

