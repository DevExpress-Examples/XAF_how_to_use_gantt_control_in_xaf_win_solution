using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttSolution.Module.BusinessObjects {
    public interface IMyTask {
        int Id { get; }
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        TimeSpan Duration { get; set; }
        double Progress { get; set; }
        int Parent { get; set; }
        // IList<IMyTask> PredecessorTasks { get; }
        string PredecessorTasks { get; }
    }
}