using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{
    /// <summary>
    /// Represents an if condition in a command parser.
    /// </summary>
    public class IfConditon:Command_Praser
    {
        /// <summary>
        /// it get the if value 
        /// </summary>
        public bool IfState { get; set; }
        /// <summary>
        /// Gets or sets the start index of the if condition.
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// Gets or sets the end index of the if condition.
        /// </summary>
        public int EndIndex { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="IfCondition"/> class.
        /// </summary>
        /// <param name="actionWord">The action word associated with the condition.</param>
        /// <param name="ifState">The state of the if condition.</param>
        /// <param name="startIndex">The start index of the if condition.</param>
        /// <param name="endIndex">The end index of the if condition.</param>
        public IfConditon(Action actionWord, bool ifState, int startIndex, int endIndex)
        {
            ActionWord = actionWord;
            IfState = ifState;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
