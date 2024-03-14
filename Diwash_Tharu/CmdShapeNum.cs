using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{/// <summary>
/// this class is use to get the words and values form the multi line and single line 
/// </summary>
    public class CmdShapeNum : Command_Praser
    { 
        /// <summary>
        /// this method will get the value like circle 90 it will store the 90 only value 
        /// </summary>
     public int[] ActionValues { get; set; }
       
        
        /// <summary>
        /// this code will store the bothe the words as well as the thir respective number
        /// </summary>
        /// <param name="actionWords"></param>
        /// <param name="actionValues"></param>
        public CmdShapeNum(Action actionWords, int[] actionValues)
         {
        ActionWord = actionWords;
        ActionValues = actionValues;
         }

    }
}
