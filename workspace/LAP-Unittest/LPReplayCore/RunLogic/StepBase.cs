using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Common
{
    //step class is used to group the different hierarchy of steps together, and to run in sequence.
    public class StepBase: IStep
    {
        public StepBase(string name, Action action)
        {
            Name = name;
            ActionToRun = action;
        }

        public string Name { get; set; }

        public IStep[] ChildSteps
        {
            get { throw new NotImplementedException(); }
        }

        public RunStatusEnum RunStatus
        {
            get { throw new NotImplementedException(); }
        }

        public Action ActionToRun {get; set;}

        public event PrePostStepDelegate PostStepAction;

        public event PrePostStepDelegate PreStepAction;

        public void Run()
        {
            PreStepAction.Invoke(this);

            //run the step action
            ActionToRun();

            PostStepAction.Invoke(this);
        }


        public RunDetails LastRunDetails
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
