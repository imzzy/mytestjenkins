using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Interfaces
{

    public enum RunStatusEnum
    {
        Success,
        Failed,
        Running,
        Pending  //meaning the step is not implemented yet
    }

    public interface IRunDetails
    {
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        RunStatusEnum RunStatus { get; set; }
    }

    public class RunDetails : IRunDetails
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public RunStatusEnum RunStatus { get; set; }
    }
}
