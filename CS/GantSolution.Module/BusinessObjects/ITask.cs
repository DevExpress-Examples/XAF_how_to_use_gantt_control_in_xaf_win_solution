using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttSolution.Module.BusinessObjects {
    public interface ITask {
        ITask Id { get; }
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        TimeSpan Duration { get; set; }
        double Progress { get; set; }
        ITask Parent { get; set; }
        IList<ITask> PredecessorTasks { get; }
    }
}