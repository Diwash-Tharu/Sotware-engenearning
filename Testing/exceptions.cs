using Diwash_Tharu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    /// <summary>
    /// this method is used to check empty enter data 
    /// </summary>
    [TestClass()]
    public class errorexceptio
    {
        [TestClass()]
        public class ExceptionTests
        {
            private readonly Process _parser = new Process();

            [TestMethod()]
            [ExpectedException(typeof(ArgumentNullException), "Input cannot be null")]
            public void ParseInput_InvalidCommand_EmptyInput()
            {
                //arrange
                string input = "";

                // act
                _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
            }

           
        }
    }
}
