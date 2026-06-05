using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GanttSolution.Module.BusinessObjects {
    [DefaultClassOptions]
    public class MyTask : BaseObject, IMyTask {
        public MyTask() {

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
        public virtual MyTask Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        [Browsable(false)]
        public virtual TimeSpan Duration { get; set; }
        public virtual double Progress { get; set; }

        public virtual ObservableCollection<MyTask> PredecessorTasks { get; set; } = new ObservableCollection<MyTask>();
        [Browsable(false)]
        public virtual ObservableCollection<MyTask> SuccessorTasks { get; set; } = new ObservableCollection<MyTask>();

        #region ITask
        public IMyTask TaskId { get { return this; } }

        IMyTask IMyTask.Parent { get => Parent; set => Parent = (MyTask)value; }

        IList<IMyTask> IMyTask.PredecessorTasks => PredecessorTasks as IList<IMyTask>;


        #endregion
    }
}