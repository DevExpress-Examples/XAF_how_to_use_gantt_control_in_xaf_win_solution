using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttSolution.Module.BusinessObjects {
    public interface IMyTask {
        IMyTask Id { get; }
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        TimeSpan Duration { get; set; }
        double Progress { get; set; }
        IMyTask Parent { get; set; }
        IList<IMyTask> PredecessorTasks { get; }
    }
}