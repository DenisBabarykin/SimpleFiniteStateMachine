using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFSM
{
    public class FsmTasksProcessor
    {
        public static List<string> Process(List<FsmTask> fsmTasks)
        {
            if (fsmTasks == null)
                throw new ArgumentNullException(nameof(fsmTasks));

            var outputStrings = new List<string>();
            foreach (var fsmTask in fsmTasks)
            {
                outputStrings.Add(fsmTask.TaskName);
                var fsm = new FiniteStateMachine(fsmTask.FsmDescription);
                foreach (var inputSequence in fsmTask.InputSequences)
                {
                    outputStrings.Add(inputSequence);
                    outputStrings.Add(fsm.Process(inputSequence));
                }
            }
            return outputStrings;
        }
    }
}
