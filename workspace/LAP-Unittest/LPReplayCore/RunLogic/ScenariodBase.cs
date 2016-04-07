using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.RunLogic
{
    class ScenariodBase : IScenario
    {
        public IStep[] ChildSteps
        {
            get { throw new NotImplementedException(); }
        }

        public event PrePostStepDelegate PreStepAction;

        public event PrePostStepDelegate PostStepAction;


        public string Name
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

        public Action ActionToRun
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

        public void Run()
        {
            PreStepAction(this);

            foreach (IStep step in ChildSteps)
            {
                step.Run();
            }
            PostStepAction(this);
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

        public List<string> Tags
        {
            get { throw new NotImplementedException(); }
        }
    }
}
