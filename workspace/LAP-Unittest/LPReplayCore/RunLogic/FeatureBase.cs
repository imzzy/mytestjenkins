using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.RunLogic
{
    class FeatureBase : IFeature
    {
        public List<string> Tags
        {
            get { throw new NotImplementedException(); }
        }

        public IScenario[] ChildScenario
        {
            get { throw new NotImplementedException(); }
        }

        public event PrePostStepDelegate PostStepAction;

        public event PrePostStepDelegate PreStepAction;

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
            throw new NotImplementedException();
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
