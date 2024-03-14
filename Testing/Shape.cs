using Diwash_Tharu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Diwash_Tharu.Action;

namespace Testing
{
    /// <summary>
    /// this testing method will test  circle wih the differnt multiple command 
    /// </summary>
    [TestClass()]
    public class DrawingCircles
    {
        private Process process = new Process();

        [TestMethod()]
        public void Action_DrawingCircle_WithParameters()
        {
            // arrange
            string input = "circle 100 150";

            // act
            Action action = process.ParseAction_CommandName(input); // Parse the input and get the action

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }



    }
    /// <summary>
    /// tasting to make different line and it works or not
    /// </summary>
    [TestClass()]
    
    public class DrawingLines
    {
        private readonly Process process = new Process();

        [TestMethod()]
        public void Action_DrawingLine_WithParameters()
        {
            //arrange
            string input = "drawto 125 210";

            // act
            Action action = process.ParseAction_CommandName(input); // Parse the input and get the action

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.drawto, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.triangle, action);
        }

        /// <summary>
        /// assert will chenter erther the actual value is similar with the assert or not 
        /// </summary>
        [TestMethod()]
        public void Action_DrawingLine_WithNoParameters()
        {
            //arrange
            string input = "drawto";

            // act
            Action action = process.ParseAction_CommandName(input); // Parse the input and get the action

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.drawto, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.triangle, action);
        }


       
    }
    /// <summary>
    ///  in the method we have made the equilateral trangle and tasted it 
    /// </summary>
    [TestClass()]
    public class DrawingTriangles
    {
        private readonly Process _parser = new Process();

        [TestMethod()]
        public void ParseAction_DrawingTriangle_WithParameters()
        {
            //arrange
            string input = "triangle 225";

            // act
            Action action = _parser.ParseAction_CommandName(input); // Parse the input and get the action

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.triangle, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
        }

        /// <summary>
        /// checking the trangle without the parametrs 
        /// </summary>
        [TestMethod()]
        public void ParseAction_DrawingTriangle_WithZeroParameters()
        {
            //arrange
            string input = "triangle";

            // act
            Action action = _parser.ParseAction_CommandName(input); // Parse the input and get the action

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.triangle, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
        }

        /// <summary>
        /// checking withe the different text formte 
        /// </summary>
        [TestMethod()]
        public void ParseAction_DrawingTriangle_WithDifferentCase()
        {
            //arrange
            string input = "tRiAnGlE";

            // act
            Action action = _parser.ParseAction_CommandName(input); // Parse the input and get the action

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.triangle, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
        }

        /// <summary>
        /// this below tasting method is used to tast the trangle with the different  parametr 
        /// </summary>
        [TestClass()]
        public class DrawingRectangles
        {
            private readonly Process _parser = new Process();

            [TestMethod()]
            public void ParseAction_DrawingRectangle_WithZeroParameters()
            {
                // arrange
                string input = "rectangle";

                // act
                Action action = _parser.ParseAction_CommandName(input); // Parse the input and get the action

                // assert
                Assert.IsNotNull(action);
                Assert.AreEqual(Action.rectangle, action); // Assert that the action is a rectangle
                Assert.AreNotEqual(Action.square, action); // Assert that the action is not a square
                Assert.AreNotEqual(Action.circle, action);
            }
            /// <summary>
            /// testing with the wright command and parameters
            /// </summary>
            [TestMethod()]
            public void ParseAction_DrawingRectangle_WithParameters()
            {
                // arrange
                string input = "rectangle 100 150";

                // act
                Action action = _parser.ParseAction_CommandName(input); // Parse the input and get the action

                // assert
                Assert.IsNotNull(action);
                Assert.AreEqual(Action.rectangle, action);
                Assert.AreNotEqual(Action.circle, action);
            }

            /// <summary>
            /// testing with the upper case words and  we can the shape of the rectangle 
            /// </summary>
            [TestMethod()]
            public void ParseAction_DrawingRectangle_WithDifferentCase()
            {
                // arrange
                // giving the command 
                string input = "RECTANGLE 100 150";

                // act
                Action action = _parser.ParseAction_CommandName(input); // Parse the input and get the action

                // assert
                Assert.IsNotNull(action);
                Assert.AreEqual(Action.rectangle, action);
                Assert.AreNotEqual(Action.circle, action);
            }
            /// <summary>
            /// testing withe  the lower case letter
            /// </summary>
            [TestMethod()]
            public void ParseInput_DrawingRectangle_WithParameters()
            {
                // arrange
                string input = "rectangle 100 150";

                // act
                CmdShapeNum commandShape = _parser.DrawShape_WithNumbers(input); // Parse the input and get the command

                // assert
                Assert.IsNotNull(commandShape);
                Assert.AreEqual(Action.rectangle, commandShape.ActionWord);
                Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
                Assert.AreNotEqual(Action.square, commandShape.ActionWord);
                Assert.AreEqual(100, commandShape.ActionValues[0]);
                Assert.AreEqual(150, commandShape.ActionValues[1]);
                Assert.AreEqual(2, commandShape.ActionValues.Length);
            }
            /// <summary>
            /// testing the rectagle eith the different text formate in the words
            /// </summary>
            [TestMethod()]
            public void ParseInput_DrawingRectangle_WithDifferentCase()
            {
                // arrange
                string input = "rEcTaNgLe 100 150";

                // act
                CmdShapeNum commandShape = _parser.DrawShape_WithNumbers(input); // Parse the input and get the command/ Parse the input and get the command

                // assert
                Assert.IsNotNull(commandShape);
                Assert.AreEqual(Action.rectangle, commandShape.ActionWord);
                Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
                Assert.AreNotEqual(Action.square, commandShape.ActionWord);
                Assert.AreEqual(100, commandShape.ActionValues[0]);
                Assert.AreEqual(150, commandShape.ActionValues[1]);
                Assert.AreEqual(2, commandShape.ActionValues.Length);
            }

        }
    }
    [TestClass()]
    public class VariableDeclarationTest
    {
        Process parser = new Process();
        private Process process = new Process();
       /// <summary>
       /// this method will check weather the enter command with variable is command like circle x
       /// </summary>
        [TestMethod()]
        public void Parse_VariableDeclaration_SingleVariableOnly()
        {
            // ARRANGE
            string input = "radius = 50\r\ncircle radius";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = process.Parse(input, dictionary);

            Assert.AreEqual(50, dictionary["radius"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(1, dictionary.Count);
        }
        [TestMethod()]
        public void Parse_VariableDeclaration_SingleVariableOnlyWithCaseSesnative()
        {
            // ARRANGE
            string input = "radius = 50\r\ncircle Radius";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = process.Parse(input, dictionary);

            Assert.AreEqual(50, dictionary["radius"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(1, dictionary.Count);
        }
        [TestMethod()]
        public void Parse_VariableDeclaration_DoubleVariableOnlyWith()
        {
            // ARRANGE
            string input = "weith = 50\r\nheight = 100\r\nrectangle weith height";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = process.Parse(input, dictionary);

            Assert.AreEqual(50, dictionary["weith"]);
            Assert.AreEqual(100, dictionary["height"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(2, dictionary.Count);
        }
      //  [TestMethod()]
        public void Parse_VariableDeclaration_DouneCassCaseSesnative()
        {
            // ARRANGE
            string input = "radius = 50\r\ncircle radius";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = process.Parse(input, dictionary);

            Assert.AreEqual(50, dictionary["radius"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(1, dictionary.Count);
        }


        [TestMethod()]
        public void Parse_VariableDeclaration_MultipleVariables()
        {
            // ARRANGE
            string input = "x = 50\r\ncircle x\r\ny = 125\r\n x = x + 20\r\nrectangle x y";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = parser.Parse(input, dictionary);

            // ASSERT
            Assert.AreEqual(2, commands.Count);
            Assert.AreEqual(Action.rectangle, commands[1].ActionWord);
            Assert.AreEqual(Action.circle, commands[0].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));

            Assert.IsInstanceOfType(commands[0], typeof(CmdShapeNum));
            // Checking values in the dictionary
            Assert.AreEqual(70, dictionary["x"]);
            Assert.AreEqual(125, dictionary["y"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(2, dictionary.Count);
        }
        [TestMethod()]
        public void Parse_VariableDeclaration_MultipleVariablesWithDifferentCase()
        {
            // ARRANGE
            string input = "x = 50\r\ncircle x\r\ny = 125\r\n x = x + 20\r\nrectangle X y";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = parser.Parse(input, dictionary);

            // ASSERT
            Assert.AreEqual(2, commands.Count);
            Assert.AreEqual(Action.rectangle, commands[1].ActionWord);
            Assert.AreEqual(Action.circle, commands[0].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));

            Assert.IsInstanceOfType(commands[0], typeof(CmdShapeNum));
            // Checking values in the dictionary
            Assert.AreEqual(70, dictionary["x"]);
            Assert.AreEqual(125, dictionary["y"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(2, dictionary.Count);
        }
        [TestMethod()]
        public void Parse_VariableDeclaration_MultipleVariablesWithDifferentCase_two()
        {
            // ARRANGE
            string input = "x = 50\r\ncircle x\r\ny = 125\r\n x = X + 20\r\nrectangle x Y";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command_Praser> commands = parser.Parse(input, dictionary);

            // ASSERT
            Assert.AreEqual(2, commands.Count);
            Assert.AreEqual(Action.rectangle, commands[1].ActionWord);
            Assert.AreEqual(Action.circle, commands[0].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));

            Assert.IsInstanceOfType(commands[0], typeof(CmdShapeNum));
            // Checking values in the dictionary
            Assert.AreEqual(70, dictionary["x"]);
            Assert.AreEqual(125, dictionary["y"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(2, dictionary.Count);
        }
    }


    [TestClass()]
    public class IfStatementsTest
    {
        Process parser = new Process();

        [TestMethod()]
        public void Parse_IfStatements_ReturnsTrue()
        {
            // ARRANGE
            string input = "x = 50\r\nif x > 25\r\ncircle x\r\nendif";

            // ACT
            List<Command_Praser> commands = parser.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(3, commands.Count);
           
            Assert.AreEqual(Action.ifstatement, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            Assert.AreEqual(Action.end, commands[2].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(IfConditon));
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandEndKeyword));
            // Check if the if statement is correct
            Assert.AreEqual(true, ((IfConditon)commands[0]).IfState);
            Assert.AreEqual(1, ((IfConditon)commands[0]).StartIndex);
            Assert.AreEqual(3, ((IfConditon)commands[0]).EndIndex);
        }

        [TestMethod()]
        public void Parse_IfStatements_ReturnsFalse()
        {
            // ARRANGE
            string input = "y = 100\r\nif y < 25\r\ncircle y\r\nendif";

            // ACT
            List<Command_Praser> commands = parser.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(3, commands.Count);
     
            Assert.AreEqual(Action.ifstatement, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            Assert.AreEqual(Action.end, commands[2].ActionWord);
            // Checking types of commands

            Assert.IsInstanceOfType(commands[0], typeof(IfConditon));
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandEndKeyword));
            // Check if the if statement is correct
            Assert.AreEqual(false, ((IfConditon)commands[0]).IfState);
            Assert.AreEqual(1, ((IfConditon)commands[0]).StartIndex);
            Assert.AreEqual(3, ((IfConditon)commands[0]).EndIndex);
        }
       
    }

     [TestClass()]
    public class WhileLoopsTest
    {
       Process process = new Process();

        [TestMethod()]
        public void Parse_WhileLoop_ReturnsTrue()
        {
            // ARRANGE
            string input = "a=1\r\nx = 50\r\nwhile a<10\r\n x = x + 10\r\ncircle x\r\nendloop";

            // ACT
            List<Command_Praser> commands = process.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(3, commands.Count);
            Assert.AreEqual(Action.whileloop, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            Assert.AreEqual(Action.end, commands[2].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(WhileCommand));
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandEndKeyword));
            // Check if the while loop is correct
            Assert.AreEqual(9, ((WhileCommand)commands[0]).LoopCount);
        }

        [TestMethod()]
        public void Parse_WhileLoop_ReturnsTrue_LessThan_Equals()
        {
            // ARRANGE
            string input = "a=1\r\nx = 50\r\nwhile a<=10\r\nx = x + 10\r\ncircle x\r\nendloop";

            // ACT
            List<Command_Praser> commands = process.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(3, commands.Count);
            Assert.AreEqual(Action.whileloop, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            Assert.AreEqual(Action.end, commands[2].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(WhileCommand));
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandEndKeyword));
            // Check if the while loop is correct
            Assert.AreEqual(10, ((WhileCommand)commands[0]).LoopCount);
        }
    }
    [TestClass()]
    public class Method
    {
        Process process = new Process();

        [TestMethod()]
        public void Parse_Method_ReturnsTrue()
        {
            // ARRANGE
            string input = "method diwash()\r\n circle 10\r\nendmethod\r\ndiwash()";

            // ACT
            List<Command_Praser> commands = process.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(3, commands.Count);
            Assert.AreEqual(Action.method, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            Assert.AreEqual(Action.end, commands[2].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(MethodCondition));
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandEndKeyword));
            // Check if the while loop is correct
            Assert.AreEqual(true, ((MethodCondition)commands[0]).Methodcall);
            Assert.AreEqual(0, ((MethodCondition)commands[0]).StartIndex);
            Assert.AreEqual(2, ((MethodCondition)commands[0]).EndIndex);
        }
        [TestMethod]
        public void Parse_Method_ReturnsTrue_With_parameters()
        {
            // ARRANGE
            string input = "method diwash(a,b)\r\n circle 20\r\nendmethod\r\ndiwash(20,30)";

            // ACT
            List<Command_Praser> commands = process.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(3, commands.Count);
            Assert.AreEqual(Action.method, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            Assert.AreEqual(Action.end, commands[2].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(MethodCondition));
            Assert.IsInstanceOfType(commands[1], typeof(CmdShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandEndKeyword));
            // Check if the method is correct
            Assert.AreEqual(true, ((MethodCondition)commands[0]).Methodcall);
            Assert.AreEqual(0, ((MethodCondition)commands[0]).StartIndex);
            Assert.AreEqual(2, ((MethodCondition)commands[0]).EndIndex);
        }
    }
}
