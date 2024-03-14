using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diwash_Tharu
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// this the instanc of the class and point is the referenc of the class
        /// </summary>

        private Pointers point = new Pointers();
        /// <summary>
        /// checking the  command with the
        /// </summary>
        private const string ShapesCommandValid = @"^([a-zA-Z]+)\s*(\d+)?\s*(\d+)?\s*(\d+)?$";
        private Process process = new Process();
        private readonly ShapeMaker shapeFactory = ShapeMaker.Instance;

        List<String> methodname = new List<String>();
        Dictionary<string, int> variables = new Dictionary<string, int>();
        /// <summary>
        /// creating  the dictionary  and name as the _dictionaryOfVariables
        /// </summary>
        Dictionary<string, int> _dictionaryOfVariables = new Dictionary<string, int>();
        Graphics g;

        /// <summary>
        /// this is the main method
        /// </summary>
        public Form1()
        {

            // Initialize synchronizationContext in the constructor

            InitializeComponent();
            g = DispalyPictureBox.CreateGraphics();
        }
        /// <summary>
        /// this will display the graphic image inside this paint box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispalyPictureBox_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics;
            point.Draw(g);
        }
        /// <summary>
        /// get the command from the single line commnad 
        /// and send to the btn click command 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void singleLineCommand_KeyDown(object sender, KeyEventArgs e)
       {
            //Checks if Enter key is pressed
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            RunBtn.PerformClick();
            /// stop the enter sound
            /// this code will halp to keep scilent the sound when we ente the keywords
            e.Handled = true;
            e.SuppressKeyPress = true;

        }
        /// <summary>
        ///this method is used for the multi threading 
        /// </summary>
        private void multiThreadHande()
        {
            Action<string> executeCommand = text =>
            {
                MethodInvoker action = delegate
                {
                    excuitCommand(text);
                };

                if (multiLinetxt.InvokeRequired)
                {
                    Monitor.Enter(this);
                    try { multiLinetxt.BeginInvoke(action); }
                    finally { Monitor.Exit(this); }
                }
                else { action(); }
            };

            Thread thread1 = new Thread(() => executeCommand(mulLineCmdTwo.Text));
            Thread thread2 = new Thread(() => executeCommand(multiLinetxt.Text));

            thread1.Start();
            thread2.Start();
        } 
        

        /// <summary>
        /// this mehto is usde when the use click on the run button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunBtn_Click(object sender, EventArgs e)
        {
            String commandMultiTwo = mulLineCmdTwo.Text;
            String commandMultiOne = multiLinetxt.Text.ToLower();
            String singleLine = singleLineCommand.Text.ToLower();
            if (singleLine.ToLower().Equals("candle"))
            {
                Form2 form2 = new Form2();
                form2.Show();
            }

           else if (commandMultiTwo == "" && singleLineCommand.Text.Trim().ToLower() == "run")
            {
                excuitCommand(commandMultiOne);
            }
           else if (commandMultiOne == "" && singleLineCommand.Text.Trim().ToLower() == "run")
            {
                excuitCommand(commandMultiTwo);
            }
            else if (commandMultiTwo != "" && commandMultiOne != "")
            {
                /// this is used to call the multi threading 
                multiThreadHande();
            }
            else
            {
                excuitCommand(singleLineCommand.Text.Trim().ToLower());
            }
        }
        /// <summary>
        /// this method is used for the executing the code
        /// </summary>
        /// <param name="mulilinecommand">this the method which calculate the command when you write mutiple command</param>
        public void excuitCommand(String mulilinecommand)
        { 
            try
            {
                 // Draws a new cursor before every command in case it gets covered by another shape
                    point.Draw(g);
                /// this condition check the if condition weather the  enter commad has method or not
                if (mulilinecommand.ToLower().Contains("method"))
                {
                    string[] inputSplitByLines = mulilinecommand.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    int startIndex = Array.IndexOf(inputSplitByLines, "method");
                    int endIndex = Array.IndexOf(inputSplitByLines, "endmethod");
                    //string[] inputSplitByLines = multiLinetxt.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string loopInput = "";

                    // Creating a new input string for the loop, this will include all the lines from beginning of loop declaration till and "endloop" type command
                    for (int loopCounter = startIndex + 1; loopCounter <= endIndex - 1; loopCounter++)
                    {
                        loopInput += inputSplitByLines[loopCounter] + "\r\n";
                    }
                    string[] methodsData = loopInput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string methodNameData = methodsData[0];//getting the name of the function 
                    String[] methodName = methodNameData.Split(' ');
                    String[] names = Methodexecuit(methodName[1]);//getiing the function name like function diwash(a,b) it get diwash
                    String methodname = names[0];// storing the metho call name

                    String methodVariableone = names[1];// assigned  first variable name
                    String methodVariablTwo = names[2];// assgned second variable name
                    //string methodInitilizeName = string.Join(", ", methodInit);
                    String[] namesMethod = methodCallLast(mulilinecommand, methodname);
                    // it check waethe the method has the  method has parameter or not
                    if (namesMethod[0].StartsWith(methodname) && !namesMethod[1].Trim().ToLower().Equals("no"))
                    {
                        String variableOne = namesMethod[1];
                        String variableTwo = namesMethod[2];
                        String assigvaribale = methodVariableone + "=" + variableOne + "\r\n" + methodVariablTwo + "=" + variableTwo + "\r\n";
                        mulilinecommand = assigvaribale + mulilinecommand.Substring(0);
                    }

                }
                /// check wether there are some code or not inside the multiline command 
                if (mulilinecommand != string.Empty)
                {

                    //this code will store all the command insde the commandslist
                    List<Command_Praser> commandsList = process.Parse(mulilinecommand, _dictionaryOfVariables);

                    for (int i = 0; i < commandsList.Count; i++)
                    {
                        // IfConditon command = (IfConditon)commandsList[i];
                        if (commandsList[i] is IfConditon)
                        {
                            IfConditon commands = (IfConditon)commandsList[i];
                            if (commands.IfState)
                            {
                                continue; // This will execute any code inside the if statement since it evaluates to true
                            }
                            else
                            {
                                i = commands.EndIndex; // This will skip any code inside the if statements since it evaluates to false
                            }
                        }
                        //checking waether the command whie or not 
                        else if (commandsList[i] is WhileCommand)
                        {
                            WhileCommand commandsWhile = (WhileCommand)commandsList[i];
                            if (commandsWhile.whileStates)
                            {

                                int number = commandsWhile.LoopCount;

                                string[] inputSplitByLines = mulilinecommand.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                string loopInput = "";

                                // Creating a new input string for the loop, this will include all the lines from beginning of loop declaration till and "endloop" type command
                                for (int loopCounter = commandsWhile.StartIndex + 1; loopCounter <= commandsWhile.EndIndex - 1; loopCounter++)
                                {
                                    loopInput += inputSplitByLines[loopCounter] + "\r\n";
                                }

                                for (int loopIndex = 0; loopIndex < number; loopIndex++)
                                {
                                    List<Command_Praser> loopCommandsList = process.Parse(loopInput, _dictionaryOfVariables);
                                    for (int j = 0; j < loopCommandsList.Count; j++)
                                    {
                                        if (!(loopCommandsList[j] is CmdShapeNum))
                                        {
                                            continue;
                                        }
                                        displaycommand(g, (CmdShapeNum)loopCommandsList[j]);
                                    }
                                }

                            }
                            else
                            {
                                i = commandsWhile.EndIndex;
                            }
                            // Assuming commandsList[i] is of type WhileCommand




                        }
                        /// check weather the conditon has the method or not
                        else if (commandsList[i] is MethodCondition)
                        {
                            MethodCondition commandsMehod = (MethodCondition)commandsList[i];
                            if (commandsMehod.Methodcall)
                            {
                                string[] inputSplitByLines = mulilinecommand.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                string loopInput = "";

                                // Creating a new input string for the loop, this will include all the lines from beginning of loop declaration till and "endloop" type command
                                for (int loopCounter = commandsMehod.StartIndex + 1; loopCounter <= commandsMehod.EndIndex - 1; loopCounter++)
                                {
                                    loopInput += inputSplitByLines[loopCounter] + "\r\n";
                                }

                                List<Command_Praser> loopCommandsList = process.Parse(loopInput, _dictionaryOfVariables);
                                //replacement of above code
                                for (int j = 0; j < loopCommandsList.Count; j++)
                                {
                                    if (!(loopCommandsList[j] is CmdShapeNum))
                                    {
                                        continue;
                                    }
                                    displaycommand(g, (CmdShapeNum)loopCommandsList[j]);
                                }
                            }
                            else
                            {
                                i = commandsMehod.EndIndex;
                            }

                        }

                        else if (commandsList[i] is CmdShapeNum)
                        {
                            /// execuing the command wehna all the cammand are passed
                            displaycommand(g, (CmdShapeNum)commandsList[i]);
                        }
                    }
                }

                // it check the validation from tha command RUN any command
                else if (Regex.IsMatch(singleLineCommand.Text.Trim().ToLower(), ShapesCommandValid) || singleLineCommand.Text.Trim().ToLower() == "run")
                {
                    CmdShapeNum commandShapeNum = process.DrawShape_WithNumbers(singleLineCommand.Text);
                    displaycommand(g, commandShapeNum);

                    //singleLineCommand.Text = "";
                    //errorMessage.Text = string.Empty;
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.DarkRed(errorMessage);
                    errorMessage.Text = "INVALID COMMAND:\n" + singleLineCommand.Text;
                }
                singleLineCommand.Text = "";
                errorMessage.Text = string.Empty;
             


            }
            //throw the exceptin argument  when there is any kind of error 
            catch (ArgumentException exception)
            {
                errorMessage.Text = string.Empty;
                errorMessage.Text = exception.Message;

            }
            //it is unser define excepion class
            catch (NegativeNumberException exception)
            {
                errorMessage.Text = string.Empty;
                errorMessage.Text = exception.Message;

            }
            //thrwo thw exception agrument when the error occur 
            catch (Exception exception)
            {
                errorMessage.Text = string.Empty;
                errorMessage.Text = "UNEXPECTED ERROR: \n " + exception.Message;
            }
            Thread.Sleep(300);
        }


/// <summary>
/// this method check wather the metho name is there or not and if it has than it give valid 
/// </summary>
/// <param name="methodInitlized"></param>
/// <returns></returns>
        private string[] Methodexecuit(String methodInitlized)
        {
            String variable = methodInitlized;// name of the method to be call  add(a,b)
            String[] variableNameOne = variable.Split('(');//spleading on the this basic  now this will seprate add   a,b)
           // String[] variableNameTwo = variable.Split(')');// we will get add  (a,b
            String methodname = variableNameOne[0];//this contain add
            String variableOne = variableNameOne[1];// it contain  a,b)
            string variableNames = string.Join(" ", variableOne);// conerting arrya to string
            String[] parameters = variableNames.Split(',');
            int numberOfParameters = parameters.Length;
            if (numberOfParameters == 1)
            {
                String paramaterOne = "no";// this is parameter one that is a
                string ParamaterTwo = "no";// this conatin another paramer that is b
                string[] methodInitiliz = { methodname, paramaterOne, ParamaterTwo };
                return methodInitiliz;
            }
            else
            {
                String paramaterOne = parameters[0];// this is parameter one that is a
                String paramaterConvert = parameters[1];
           
                string ParamaterTwo = paramaterConvert.Replace(")", string.Empty);// this conatin another paramer that is b
                string[] methodInitiliz = { methodname, paramaterOne, ParamaterTwo};
                return methodInitiliz;
            }
        }
        /// <summary>
        /// this method is used to check weathe the function is cllled or not
        /// </summary>
        /// <param name="methodCallLast"></param>
        /// <param name="MethodName"></param>
        /// <returns></returns>
         private String[] methodCallLast(String methodCallLast,String MethodName) 
        {
            string[] inputSplitByLines = methodCallLast.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // Iterate through each line of input
            foreach (string s in inputSplitByLines)
            {
                // Trim and convert the line to lowercase for easier matching
                string line = s.Trim().ToLower();
                if(line.ToLower().Trim().StartsWith(MethodName))
                {
                     string[] data= Methodexecuit(line);
                    return data;
                }
            }
            return null;
        }
        /// <summary>
        /// this method will make accept the command and draw inside the picture box 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="command"></param>
        private void displaycommand(Graphics g, CmdShapeNum command)
        {
            switch (command.ActionWord)
            {
                //when the user enter the move to comand 
                case Action.moveto:
                    {
                        point.MoveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                        point.Draw(g);
                        break;
                    }
                case Action.fillon:
                    {
                        point.Fill = true;
                        Fill.Text = "Fill Color On";
                        break;
                    }
                case Action.filloff:
                    {
                        point.Fill = false;
                        Fill.Text = "Fill Color Off";
                        break;
                    } 
                /// this will reste the command whole canvas
                case Action.reset:
                    {
                        point.MoveTo(point.initalPosition);
                        point.ChangePenColor(point.initalPenColor); // Resets cursor to default color (Red)
                        point.ChangeFillState(point.initalFill); // Resets cursor to default fill state (false ie; no fill)
                        point.Draw(g);
                        colorlab.Text = "pen color: Red";
                        break;
                    }
                    ///  clear the pictue box
                case Action.clear:
                    {
                        Refresh();
                        multiLinetxt.Text = "";
                        break;
                    }
                    ///initilize the pen color
                case Action.penred:
                    {
                        point.PenColor = Color.Red;
                        colorlab.Text = "pen color: Red";
                        break;
                    }
                case Action.pengreen:
                    {
                        point.PenColor = Color.Green;
                        colorlab.Text = "pen color: Green";
                        break;
                    }
                case Action.penblue:
                    {
                        point.PenColor = Color.Blue;
                        colorlab.Text = "pen color: Blue";
                        break;
                    }
                default:
                    {
                        /// this comand will run when user inter the different shave command 
                         Shapes shape = shapeFactory.CreateShape(command, point.Position, point.Fill, point.PenColor);
                         shape.Draw(g);
                         point.MoveTo(shape.Position);
                         point.Draw(g);
                        break;

                    }
            }
        }
        /// <summary>
        /// this method will check the syntax it wil run all the commadn except the making the shaop or we can say the ecxep main eixuation command 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyntaxBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(singleLineCommand.Text.ToLower()!="")
                {
                    List<Command_Praser> commandsList = process.Parse(singleLineCommand.Text.ToLower(), _dictionaryOfVariables);
                    CmdShapeNum commandShapeNum = process.DrawShape_WithNumbers(singleLineCommand.Text);
                }
                else if (multiLinetxt.Text != string.Empty)
                {
                    List<Command_Praser> commandsList = process.Parse(multiLinetxt.Text, _dictionaryOfVariables);
                    for (int i = 0; i < commandsList.Count; i++)
                    {
                        if (commandsList[i] is CmdShapeNum)
                        {
                        }
                    }
                }
                singleLineCommand.Text = "";

            }
            ///this will trhow the exception if any wrond commadn entered
            catch (ArgumentException exception)
            {
                errorMessage.Text = string.Empty;
                errorMessage.Text = exception.Message;
            }
            catch (NegativeNumberException exception)
            {
                errorMessage.Text = string.Empty;
                errorMessage.Text = exception.Message;
            }
            catch (Exception exception)
            {
                errorMessage.Text = string.Empty;
                errorMessage.Text = "UNEXPECTED ERROR:\n" + exception.Message;
            }
        }
        /// <summary>
        /// this method is used for the to open the txt filw where the user has inter the command 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
           // load.Filter = TextFileTxt;
            load.RestoreDirectory = true;

            if (load.ShowDialog() == DialogResult.OK)
            {
                multiLinetxt.Text = System.IO.File.ReadAllText(load.FileName);
            }

        }
        /// <summary>
        /// this method will sava all the command or words from the milti text line to inside our file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog save = new SaveFileDialog
            {
                FileName = "Commands.txt",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(mulLineCmdTwo.Text=="")
                    {
                        System.IO.File.WriteAllText(save.FileName, multiLinetxt.Text);
                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else 
                    {
                        System.IO.File.WriteAllText(save.FileName, mulLineCmdTwo.Text);
                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

    }
    
}
