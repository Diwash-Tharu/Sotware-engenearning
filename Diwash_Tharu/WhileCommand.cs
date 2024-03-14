using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Diwash_Tharu
{
    /// <summary>
    /// Represents a while loop command in a command parser.
    /// </summary>
    public class WhileCommand: Command_Praser
    {
        /// <summary>
        /// Gets or sets the state of the while loop.
        /// </summary>
        public bool whileStates { get; set; }
        /// <summary>
        /// Gets or sets the start index of the while loop.
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// Gets or sets the end index of the while loop.
        /// </summary>
        public int EndIndex { get; set; }
        /// <summary>
        /// Gets or sets the loop count associated with the while loop.
        /// </summary>
        public int LoopCount { get; set; }
        /// <summary>
        /// Constructor used to create a new instance of the <see cref="whilecommand"/> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        /// <param name="loopCount">The loop count.</param>
        public WhileCommand(Action actionWord, int loopCount, bool whileState, int startIndex, int endIndex)
        {
            ActionWord = actionWord;
            LoopCount = loopCount;
            whileStates = whileState;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
