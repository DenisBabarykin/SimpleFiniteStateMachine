using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFSM
{
    public class FiniteStateMachine
    {
        public FiniteStateMachine(List<string> fsmDescription)
        {
            if (fsmDescription == null)
                throw new ArgumentNullException(nameof(fsmDescription));

            TransitionsTable = new List<Transition>();
            foreach (var transitionString in fsmDescription)
                TransitionsTable.Add(new Transition(transitionString[0], new Dictionary<char, char>() { { '0', transitionString[2] }, { '1', transitionString[4] } }));
        }

        /// <summary>Proceed input sequence through FSM</summary>
        /// <param name="inputSequence">Input sequence of '0' and '1' symbols</param>
        /// <returns>Sequence of the FSM execution</returns>
        public string Process(string inputSequence)
        {
            char currentState = '$';
            var statesSequence = new List<char>();
            statesSequence.Add(currentState);

            foreach (var symbol in inputSequence.ToArray())
            {
                currentState = TransitionsTable.Single(t => t.State == currentState).GetNewState(symbol);
                statesSequence.Add(currentState);
            }

            return new string(statesSequence.ToArray());
        } 

        private List<Transition> TransitionsTable { get; set; }
    }
}
