using System;
using System.Linq;
using System.Text;

using System.ComponentModel;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;

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

        public virtual IList<MyTask> PredecessorTasks { get; set; } = new ObservableCollection<MyTask>();



        #region ITask
        [Browsable(false)]
        public IMyTask Id { get { return this; } }
        IMyTask IMyTask.Parent {
            get { return Parent; }
            set { Parent = (MyTask)value; }
        }
        IList<IMyTask> IMyTask.PredecessorTasks {
            get {
                return (IList<IMyTask>)PredecessorTasks;
            }
        }
        #endregion
    }
}