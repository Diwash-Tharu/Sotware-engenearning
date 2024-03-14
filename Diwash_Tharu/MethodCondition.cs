using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Diwash_Tharu
{
    public class MethodCondition: Command_Praser
    {/// <summary>
    /// this will store method name  and set them 
    /// </summary>
        public  string methodName
        {   get; 
            set; 
        }/// <summary>
        /// this will set the method is call's name 
        /// </summary>
        public bool Methodcall
        {
           get;
            set;
        }/// <summary>
        /// this will set the starting adn ending value of the method
        /// </summary>
        public int EndIndex { get; set; }
        public int StartIndex { get; set; }

        /// <summary>
        /// this code will store the bothe the words as well as the thir respective number
        /// </summary>
        /// <param name="actionWords"></param>
        /// <param name="actionValues"></param>
        public MethodCondition(Action actionWords, string methodNameInilized, bool methodcall, int startIndex, int endIndex)
        {
            ActionWord = actionWords;
            methodName = methodNameInilized;
            Methodcall = methodcall;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }


    }
}
