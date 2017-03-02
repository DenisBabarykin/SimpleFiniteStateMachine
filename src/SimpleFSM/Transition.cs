using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFSM
{
    public class Transition
    {
        /// <param name="state">Current state</param>
        /// <param name="newStatesByInputSymbols">Table with states to transit for every possible input symbol</param>
        public Transition(char state, Dictionary<char, char> newStatesByInputSymbols)
        {
            if (newStatesByInputSymbols == null)
                throw new ArgumentNullException(nameof(newStatesByInputSymbols));

            State = state;
            NewStatesByInputSymbols = newStatesByInputSymbols;
        }

        public char State { get; set; }

        public char GetNewState(char inputSymbol)
        {
            return NewStatesByInputSymbols[inputSymbol];
        }

        private Dictionary<char, char> NewStatesByInputSymbols { get; set; }
    }
}
