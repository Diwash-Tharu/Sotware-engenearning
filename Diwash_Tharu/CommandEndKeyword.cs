using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash_Tharu
{
    public class CommandEndKeyword : Command_Praser
    {
        /// <summary>
        /// Constructor used to create a new instance of the <see cref="CommandEndKeyword" /> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        public CommandEndKeyword(Action actionWord)
        {
            ActionWord = actionWord;
        }
    }
}
