using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFSM
{
    public class FsmTask
    {
        public FsmTask(string taskName, List<string> fsmDescription, List<string> inputSequences)
        {
            if (taskName == null)
                throw new ArgumentNullException(nameof(taskName));
            if (fsmDescription == null)
                throw new ArgumentNullException(nameof(fsmDescription));
            if (inputSequences == null)
                throw new ArgumentNullException(nameof(inputSequences));

            TaskName = taskName;
            FsmDescription = fsmDescription;
            InputSequences = inputSequences;
        }

        public string TaskName { get; set; }

        public List<string> FsmDescription { get; set; }

        public List<string> InputSequences { get; set; }
    }
}
