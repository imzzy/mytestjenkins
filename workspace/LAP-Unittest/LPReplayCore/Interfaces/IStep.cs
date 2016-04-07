using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Interfaces
{
    public delegate void PrePostStepDelegate (IStep step);

    //this step can map to the step_definition in cucumber
    public interface IStep
    {
        event PrePostStepDelegate PostStepAction;

        event PrePostStepDelegate PreStepAction;

        string Name { get; set; }

        Action ActionToRun { get; set; }

        void Run();

        RunDetails LastRunDetails
        {
            get; set;
        }
    }

    public interface IScenario : IStep
    {
        List<string> Tags { get; }
        IStep[] ChildSteps
        {
            get;
        }
    }

    public interface IFeature : IStep
    {
        List<string> Tags { get; }

        IScenario[] ChildScenario
        {
            get;
        }
    }

}
