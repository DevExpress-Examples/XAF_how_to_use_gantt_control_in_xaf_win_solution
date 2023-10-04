using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;

namespace GanttSolution.Module.BusinessObjects {
    [DefaultClassOptions]
    public class MyTask : BaseObject, IMyTask { 
        public MyTask(Session session)
            : base(session) {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
        private MyTask parent;
        public MyTask Parent {
            get { return parent; }
            set { SetPropertyValue(nameof(Parent), ref parent, value); }
        }
        private string name;
        public string Name {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }
        private DateTime startDate;
        public DateTime StartDate {
            get { return startDate; }
            set { SetPropertyValue(nameof(StartDate), ref startDate, value); }
        }
        private DateTime endDate;
        public DateTime EndDate {
            get { return endDate; }
            set { SetPropertyValue(nameof(EndDate), ref endDate, value); }
        }
        private TimeSpan duration;
        [Browsable(false)]
        public TimeSpan Duration {
            get { return duration; }
            set { SetPropertyValue(nameof(Duration), ref duration, value); }
        }
        private double progress;
        public double Progress {
            get { return progress; }
            set { SetPropertyValue(nameof(Progress), ref progress, value); }
        }
        [Association("PredecessorTasks")]
        public XPCollection<MyTask> PredecessorTasks {
            get {
                return GetCollection<MyTask>(nameof(PredecessorTasks));
            }
        }
        [Association("PredecessorTasks")]
        [Browsable(false)]
        public XPCollection<MyTask> NotPredecessorTasks {
            get {
                return GetCollection<MyTask>(nameof(NotPredecessorTasks));
            }
        }

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