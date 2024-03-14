using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Diwash_Tharu
{
    public class Process 
    {

        
        /// <summary>
        /// this code is used for the multi line code and to exucate the code
        /// </summary>
        private const string RegexDrawWithVariables = @"^([a-zA-Z]+)\s*([a-zA-Z]+)? ?([a-zA-Z]+)? ?([a-zA-Z]+)?$"; // "rectangle x y" or "circle x"
        private const string RegexWhileLoops = @"while.+"; // "while 10"
        private const string methodcheck =@"method.+";
        private const string methodCall = @"mymethod.+";
        private const string DrawShapesWithNumbers = @"^([a-zA-Z]+)\s*(\d+)?\s*(\d+)?\s*(\d+)?$";
       // List<string> methodcalls = new List<string>();

        //  private string methodCallName;


        //  public bool sCondition;
        public List<Command_Praser> Parse(string input, Dictionary<string, int> dict)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null");
            }
            // Split input into separate lines
            string[] inputSplitByLines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // List to hold the commands
                List<Command_Praser> commandsList = new List<Command_Praser>();
         
            // Iterate through each line of input
            foreach (string s in inputSplitByLines)
                {
                    // Trim and convert the line to lowercase for easier matching
                    string line = s.Trim().ToLower();
                
                int equalSignCount = line.Trim().Count(c => c == '=');
                    //foe endthe while loop and 
                    if (line.Trim().ToLower().Contains("endloop"))
                    {
                        Command_Praser command = new CommandEndKeyword(Action.end);
                        commandsList.Add(command);
                    }
                    //for ending the command
                    else if (line.Trim().ToLower().Contains("end"))
                    {
                        Command_Praser command = new CommandEndKeyword(Action.end);
                        commandsList.Add(command);
                    }
                    // WHILE LOOPS (example: "while 10")
                    else if (Regex.IsMatch(line.Trim().ToLower(), RegexWhileLoops))
                    {
                        int startIndex = Array.IndexOf(inputSplitByLines, line);
                        int endIndex = Array.IndexOf(inputSplitByLines, "endloop");
                        string[] inputSplitBySpaces = line.Split(' ');
                        String[] results = ConditioExcuite(inputSplitBySpaces[1], dict,endIndex);
                        String boolsCondition = results[0];
                        if (results[0].ToLower().Trim().Equals("true"))
                        {
                            bool sCondition = true;
                            Command_Praser command = new WhileCommand(Action.whileloop, int.Parse(results[1]), sCondition, startIndex, endIndex);
                            commandsList.Add(command);
                        }
                        else
                        {
                            bool sCondition = false;
                            Command_Praser command = new WhileCommand(Action.whileloop, int.Parse(results[1]), sCondition, startIndex, endIndex);
                            commandsList.Add(command);
                        }

                        // Create a CommandWhile object with the specified loop count
                    }
                // DRAW SHAPES WITH NUMBERS (example: "rectangle 100 150" or "circle 50")
                   else if (Regex.IsMatch(line.Trim().ToLower(), DrawShapesWithNumbers) && Enum.GetNames(typeof(Action)).Any(e => line.ToLower().Contains(e.ToLower())))
                    {
                            Command_Praser command = DrawShape_WithNumbers(line);
                            commandsList.Add(command);
                    }

                    //if the command cotntain the varable circle x
                    else if (Regex.IsMatch(line.Trim().ToLower(), RegexDrawWithVariables))
                    {
                        Command_Praser command = ParseDrawShape_WithVariables(line, dict);
                        commandsList.Add(command);
                    }
                    // VARIABLE ASSIGNMENT (example: "var x = 10" or "var x = y + 100")
                    // Match match = Regex.Match(line.Trim().ToLower(), "^[=]+$");

                    else if (equalSignCount == 1 && !line.Contains("<=")&& !line.Contains(">="))
                    {
                        // If the variable is already in the dictionary, replace it with the new value
                        string[] parts = line.Split('=');
                        string variableName = parts[0].Trim();
                        string expression = parts[1].Trim();
                        if (int.TryParse(expression, out int value))
                        {
                            // If the expression is a direct integer value assignment
                            //variables.SetVariable(variableName, value);

                            if (dict.ContainsKey(variableName))
                            {
                                // Key exists, update it with the new key

                                int updateValuekey = int.Parse(expression);
                                //int updateValuekey = variableCollection[expression];
                                dict.Remove(variableName); // Remove the old key-value pair
                                dict.Add(variableName, updateValuekey); // Add the new key-value pair                                                  
                            }
                            else
                            {
                                dict.Add(variableName, int.Parse(expression));
                            }
                        }
                        else
                        {
                            int result = CalculateExpression(dict, expression);
                            if (dict.ContainsKey(variableName))
                            {
                                // Key exists, update it with the new key

                                dict.Remove(variableName); // Remove the old key-value pair
                                dict.Add(variableName, result); // Add the new key-value pair

                            }
                            else
                            {
                                // Key does not exist, add a new key-value pair
                                dict.Add(variableName, result);
                            }
                        }
                    }
                    //  else if (Regex.IsMatch(line.Trim().ToLower(), RegexIfStatements))

                    //for endloop and end method
                    else if (line.Trim().Contains("if"))
                    {
                        // Find the line number where the if statement ends at using "endif" as the end of the if statement
                        int startIndex = Array.IndexOf(inputSplitByLines, line);
                        int endIndex = Array.IndexOf(inputSplitByLines, "endif");
                        bool result = ParseIfStatements(line, dict,input);

                        Command_Praser command = new IfConditon(Action.ifstatement, result, startIndex, endIndex);
                        commandsList.Add(command);
                    }
                    //for method cheking 
                    else if (Regex.IsMatch(line.Trim().ToLower(), methodcheck))
                    {
                        int startIndex = Array.IndexOf(inputSplitByLines, line);
                        int endIndex = Array.IndexOf(inputSplitByLines, "endmethod");
                        Command_Praser command = method(line, input, startIndex, endIndex);
                        commandsList.Add(command);
                    }
                    else if (line.Trim().ToLower().StartsWith(methodNameValue(input)))
                    { 
                      continue;
                    }
                    else
                    {
                        throw new ArgumentException("ERROR: ! Invalid command it muts be with in the command list  !");
                    }
                }
                // Return the list of commands
                return commandsList;
        }
        private string methodNameValue(string methodCallNames)
        {
            if(methodCallNames.Trim().Contains("method") && methodCallNames.Trim().Contains("endmethod"))
            {
            string startWord = "method";
            string endWord = "endmethod";
            // Call the method to extract substrings
            //  List<string> extractedStrings = ExtractStrings(multi, startWord, endWord);
            List<string> methodNameExct = ExtractStrings(methodCallNames.ToLower(), startWord, endWord);
            string methodCallName = string.Join(", ", methCallName(methodNameExct));

            return methodCallName;
            }
            else
            {
                return "null";
            }
        }
        private string methCallName(List<string> methodNameExct)
        {

            // method add(a,b)
            string methosData = string.Join(" ", methodNameExct);// this conatin whole list data
            string[] methodList = methosData.Split('\n', '\r');//spleting the data
            Console.WriteLine(methodList);
            String methodSetting = methodList[0];//getting first element form the list of method like method add(a,b)
            string[] Splitstex = methodSetting.Split(' ');// spleating the name of the method and method  it get the value like (method  add(a,b) )seprately

            String variable = Splitstex[1];// name of the method to be call  add(a,b)
            String[] variableNameOne = variable.Split('(');//spleading on the this basic  now this will seprate add   a,b)
            String methodNameCall = variableNameOne[0];

            //ring[] variableNameTwo = variable.Split(')');// we will get add  (a,b


            return methodNameCall;

        }

        private Command_Praser method(String line,String multicommand,int Start,int End)
        {
            String[] methodname = line.Split(' ');
            String methodParametes = methodname[1];

            String[] methoNameInitlized = methodParametes.Split('(');
            String methodNmae = methoNameInitlized[0];

            bool methocall = methodCallCheck(methodNmae, multicommand);
            Command_Praser command = new MethodCondition(Action.method, methodParametes, methocall,Start,End);
            return command;
        }

        private bool methodCallCheck(String methodNmae, String MultilInecommand)
        {
            if(MultilInecommand.ToLower().Contains("endmethod"))
            {
                string[] inputSplitByLines = MultilInecommand.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Iterate through each line of input
                foreach (string s in inputSplitByLines)
                {
                    // Trim and convert the line to lowercase for easier matching
                    string multiLine = s.Trim().ToLower();
                    if (multiLine.Trim().StartsWith(methodNmae, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new NegativeNumberException("method is not closed");
            }
        }
        //while cootition 
        public String[] ConditioExcuite(string condition, Dictionary<string, int> dict,int index)
        {
            if (index < 0)
            {
                throw new NegativeNumberException("while loop is not closed");
            }
            string[] expressions = {  "<=", ">=" ,"<", ">"};

            foreach (string exp in expressions)
            {
                if (condition.Contains(exp))
                {
                    string[] command = condition.Split(new string[] { exp }, StringSplitOptions.None);
                    string value1 = command[0].Trim();
                    string value2 = command[1].Trim();

                    if (dict.ContainsKey(value1))
                    {
                        int extractedValue = dict[value1];
                        //string value1 = extractedValue.ToString();
                        String[] allone = { extractedValue.ToString(), value2 };
                        String variableOne = allone[0];
                        String variableTwo = allone[1];
                        String[] result = CheckCondition(variableOne, variableTwo, exp);
                        return result;
                    }
                    if (dict.ContainsKey(value2))
                    {
                        int extractedValue = dict[value1];
                        String[] allone = { extractedValue.ToString(), value2 };
                        String variableOne = allone[0];
                        String variableTwo = allone[1];
                        String[] result = CheckCondition(variableOne, variableTwo, exp);
                        return result;
                    }
                }
            }
            throw new NotImplementedException("error in while loop");
        }
        private string[] CheckCondition(string value1, string value2, string exp)
        {
            // Implement your logic to check the condition based on value1, value2, and exp
            // Example: Compare values based on the operator (exp)
            int valueOne = int.Parse(value1);
            int valueTwo = int.Parse(value2);
            if (exp.Trim().Equals(">"))
            {
                if (valueOne > valueTwo)
                {
                    string grater = "true";
                    int value_1 = valueOne - valueTwo;
                    int absoluteValue = Math.Abs(value_1);
                    string number = absoluteValue.ToString();
                    string[] final = { grater, number };
                    return final;
                }
            }
            else if (exp.Trim().Equals("<"))
            {
                if (valueOne < valueTwo)
                {
                    string grater = "true";
                    int value_1 = valueOne - valueTwo;
                    int absoluteValue = Math.Abs(value_1);
                    string number = absoluteValue.ToString();
                    string[] final = { grater, number };
                    return final;
                }
            }
            else if (exp.Trim().Equals(">="))
            {
                if (valueOne >= valueTwo)
                {
                    string grater = "true";
                    int value_1 = valueOne - valueTwo;
                    int absoluteValue = Math.Abs(value_1) + 1;
                    string number = absoluteValue.ToString();
                    string[] final = { grater, number };
                    return final;
                }
            }
            else if (exp.Trim().Equals("<="))
            {
                if (valueOne <= valueTwo)
                {
                    string grater = "true";
                    int value_1 = (valueOne - valueTwo);
                    int absoluteValue = Math.Abs(value_1) + 1;
                    string number = absoluteValue.ToString();
                    string[] final = { grater, number };
                    return final;
                }
            }
            else
            {
                string grater = "false";
                string value_1 = "0";
                string[] final = { grater, value_1 };
                return final;
            }
            string graters = "false";
            string value_1s = "0";
            string[] finals = { graters, value_1s };
            return finals;
        }
        private static int CalculateExpression(Dictionary<string, int> dict, string expression)
        {
            //Check dictionary to replace values of x and y with their values to get the result
            foreach (KeyValuePair<string, int> entry in dict)
            {
                if (expression.Contains(entry.Key))
                {
                    expression = expression.Replace(entry.Key, entry.Value.ToString());
                   
                }
            }
            DataTable table = new DataTable();
            System.Data.DataRow row = table.NewRow();
            table.Columns.Add("expression", typeof(int), expression);
            table.Rows.Add(row);
            return (int)row["expression"];
        }
        private CmdShapeNum ParseDrawShape_WithVariables(string input, Dictionary<string, int> dict)
        {
            // Split the input into an array of strings
            string[] inputArray = input.Split(' ');

            // Check if the input is valid
            if (inputArray.Length < 2)
            {
                throw new ArgumentException("Invalid Command like circle");
            }

            // Check if the input is valid
            if (!Enum.TryParse(inputArray[0], true, out Action actionWord))
            {
                throw new ArgumentException("Invalid Command ");
            }

            // Check if the input is valid
            if (!dict.ContainsKey(inputArray[1]))
            {
                throw new ArgumentException("Invalid varibale in commane");
            }
            // Create a new CommandShape object and replaces values of x and y with the values in the dictionary
            CmdShapeNum commandShape = new CmdShapeNum(actionWord, new int[] { dict[inputArray[1]] });

            // Check if the input is valid
            if (inputArray.Length == 3)
            {
                // Check if the input is valid
                if (!dict.ContainsKey(inputArray[2]))
                {
                    throw new ArgumentException("Invalid input");
                }

                // Add the second value to the CommandShape object
                commandShape.ActionValues = commandShape.ActionValues.Concat(new int[] { dict[inputArray[2]] }).ToArray();
            }
            if(inputArray.Length==4)
            {
                if (!dict.ContainsKey(inputArray[3]))
                {
                    throw new ArgumentException("Invalid varibale in commane");
                }
                // Create a new CommandShape object and replaces values of x and y with the values in the dictionary
                commandShape.ActionValues = commandShape.ActionValues.Concat(new int[] { dict[inputArray[3]] }).ToArray();
            }

            return commandShape;
        }

        private bool ParseIfStatements(string input, Dictionary<string, int> dict,String cmd)
        {
            // Split the input into an array of strings
            string[] inputArray = input.Split(' ');
            if(!cmd.ToLower().Contains("endif"))
            {
                throw new ArgumentException("Invalid endif not closed");
            }
            // Check if the input is valid
            if (inputArray[0] != "if")
            {
                throw new ArgumentException("Invalid if");
            }

            // Check if the input is valid
            if (!dict.ContainsKey(inputArray[1]))
            {
                throw new ArgumentException("Invalid variable in if condition");
            }

            // Check if the input is valid like number in if coondition
            if (!int.TryParse(inputArray[3], out int variableValues))
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid and replace values of variables with the values from the dictionary
            if (inputArray[2] == ">")
            {
                if (dict[inputArray[1]] > variableValues)
                {
                    return true;
                }
            }
            else if (inputArray[2] == "<")
            {
                if (dict[inputArray[1]] < variableValues)
                {
                    return true;
                }
            }
            else if (inputArray[2] == "==")
            {
                if (dict[inputArray[1]] == variableValues)
                {
                    return true;
                }
            }
            else if (inputArray[2] == "<=")
            {
                if (dict[inputArray[1]] == variableValues)
                {
                    return true;
                }
            }
            else if (inputArray[2] == ">=")
            {
                if (dict[inputArray[1]] == variableValues)
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }

            return false;
        }


        /// <summary>
        /// this method will seperate withe their commmand values and command
        /// </summary>
        /// <param name="inputFull">this will aceprt the coomand words</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public CmdShapeNum DrawShape_WithNumbers(string inputFull)
    {
        inputFull = inputFull.Trim().ToLower(); // Trim the input and convert it to lowercase
          
            // Split the input string into an array of strings, separated by spaces
            string[] inputSplitBySpaces = inputFull.ToLower().Split(' ');

        if (inputSplitBySpaces.Length >= 5)
        {
            throw new ArgumentException("ERROR: Too many parameters passed!");
        }
        string stringCommand = inputSplitBySpaces[0];
        Action command = ParseAction_CommandName(stringCommand);
        Action actionWord = command ;
            
            if (actionWord == Action.run || actionWord == Action.reset || actionWord == Action.clear || actionWord == Action.fillon 
                || actionWord == Action.filloff||actionWord==Action.penblue || actionWord == Action.pengreen || actionWord == Action.penred)
        {
            return new CmdShapeNum(actionWord, null);
        }
            ///adding to the striing  paraslist
        List<string> stringParamsList = new List<string>();
        for (int i = 1; i < inputSplitBySpaces.Length; i++)
        {
            stringParamsList.Add(inputSplitBySpaces[i]);
        }
        string[] stringParams = stringParamsList.ToArray();
        int[] actionParams = valideCommandParameters(stringParams);
        // Uses the parsed command string and command parameters to create and return a Command
        return new CmdShapeNum(actionWord, actionParams);
    }


        /// <summary>
        /// retuen the respective enmus action
        /// </summary> this check weather the enter commadn is valid or not withe the comparing with tne emums
        /// <param name="input"></param>
        /// <returns></returns>
    public Action ParseAction_CommandName(string input)
    {
        input = input.Split()[0].Trim().ToLower(); // Cleans the input string by removing any extra words (if any) in the input string
        switch (input)
        {
            case "rectangle":
                return Action.rectangle;
            case "circle":
                return Action.circle;
            case "triangle":
                return Action.triangle;
            case "drawto":
                return Action.drawto;
            case "square":
                return Action.square;
            case "moveto":
                return Action.moveto;
            case "reset":
                return Action.reset;
            case "clear":
                return Action.clear;
            case "fillon":
                return Action.fillon;
            case "filloff":
                return Action.filloff;
            case "penred":
                 return Action.penred;
            case "pengreen":
                  return Action.pengreen;
            case "penblue":
                  return Action.penblue;
            case "run":
                return Action.run;
            default:
                return Action.none;
        }
    }
        /// <summary>
        /// checking wether the enter parametrs are postivie and do not exceed
        /// </summary>
        /// <param name="inputStringArray"> this check weathr the enter parameter are with in the range or not</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
    private int[] valideCommandParameters(string[] inputStringArray)
    {
            int[] inputIntArray;

            try
            {
                // Converts each element of the string array to an int
                inputIntArray = Array.ConvertAll(inputStringArray, int.Parse);
            }
            catch (FormatException)
            {
                // Throws an exception if any of the elements in the inputStringArray cannot be parsed to int
                throw new ArgumentException("ERROR: Invalid parameters, please use int!", inputStringArray.ToString());
            }

            // Checks if parameters are negative and throws an error if it is
            for (int i = 0; i < inputIntArray.Length; i++)
            {
                if (inputIntArray[i] < 0)
                   
                throw new ArgumentException("ERROR: Negative parameters are not allowed!");
            }

            // Checks if any of the parameters are greater than the window size (900x500)
            if (inputIntArray.Length == 2)
            {
                // When there are 2 parameters, check if they are greater than 900 and 500 respectively
                if (inputIntArray[0] > 900)
                {
                    throw new NegativeNumberException("The prameter has to be a more than 900");
                }

                if (inputIntArray[1] > 500)
                {
                    throw new NegativeNumberException("The prameter has to be a more than 500");
                }
            }
            else if (inputIntArray.Length == 1)
            {
                
                if (inputIntArray[0] > 500)
                {
                    throw new NegativeNumberException("The prameter has to be a more than 500");
                    
                }
            }
            return inputIntArray;
        }
        /// <summary>
        /// this method check wathet the method is call or not in the command
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startWord"></param>
        /// <param name="endWord"></param>
        /// <returns></returns>
        static List<string> ExtractStrings(string input, string startWord, string endWord)
        {
            List<string> extractedStrings = new List<string>();

            int startIndex = 0;
            int endIndex;

            while ((startIndex = input.IndexOf(startWord, startIndex)) != -1)
            {
                endIndex = input.IndexOf(endWord, startIndex + startWord.Length);

                if (endIndex != -1)
                {
                    string extractedString = input.Substring(startIndex, endIndex - startIndex + endWord.Length);
                    extractedStrings.Add(extractedString);
                    startIndex = endIndex + endWord.Length;
                }
                else
                {
                    break; // End word not found, break the loop
                }
            }
            return extractedStrings;
        } 
    }
}

