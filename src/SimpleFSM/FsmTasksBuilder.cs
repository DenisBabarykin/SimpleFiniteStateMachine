using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFSM
{
    public class FsmTasksBuilder
    {
        public static List<FsmTask> Build(List<string> inputStrings)
        {
            if (inputStrings == null)
                throw new ArgumentNullException(nameof(inputStrings));

            List<FsmTask> fsmTasks = new List<FsmTask>();
            int tasksCount = inputStrings.Count(s => s == ".") / 2;

            for (int i = 0, j = 0; i < tasksCount; i++)
            {
                string taskName = inputStrings[j++];

                var fsmDescription = new List<string>();
                while (inputStrings[j] != ".")
                    fsmDescription.Add(inputStrings[j++]);
                j++;

                var inputSequences = new List<string>();
                while (inputStrings[j] != ".")
                    inputSequences.Add(inputStrings[j++]);
                j++;

                fsmTasks.Add(new FsmTask(taskName, fsmDescription, inputSequences));
            }

            return fsmTasks;
        }
    }
}
