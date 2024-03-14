using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{
   public class ShapeMaker
    {
        // Single instance of the ShapeFactory class.
        private static ShapeMaker _instance;

     

        private ShapeMaker() { }

        // Returns only the single instance of the ShapeFactory class, creating it the first time.
        public static ShapeMaker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShapeMaker();
                }
                return _instance;
            }
        }
/// <summary>
/// this code will make the  image of different  daigram  in the pictire box
/// </summary>
/// <param name="commandShape">get  the command </param>
/// <param name="position">get the position where to build</param>
/// <param name="fill">wether to fill  the shap or not</param>
/// <param name="penColor">choosing the pen color </param>
/// <returns></returns>
/// <exception cref="ArgumentException"></exception>
public Shapes CreateShape(CmdShapeNum commandShape, Point position, bool fill, Color penColor)
        {
            switch (commandShape.ActionWord)
            {
                case Action.rectangle:
                    return new Rectangles(position, fill, penColor, commandShape.ActionValues[0], commandShape.ActionValues[1]);
                case Action.circle:
                    return new Circle(position, fill, penColor, commandShape.ActionValues[0]);
                case Action.triangle:
                    return new Triangle(position, fill, penColor, commandShape.ActionValues[0],commandShape.ActionValues[1],commandShape.ActionValues[1]);
                case Action.drawto:
                    return new Line(position, fill, penColor, new Point(commandShape.ActionValues[0], commandShape.ActionValues[1]));
                case Action.square:
                    return new Square(position, fill, penColor, commandShape.ActionValues[0]);
                default:
                    throw new ArgumentException("Invalid command! of Shape");
            }
        }

    }
}