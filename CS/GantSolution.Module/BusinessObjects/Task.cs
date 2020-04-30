using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;

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
    [DefaultClassOptions]
    public class Task : BaseObject, ITask { 
        public Task(Session session)
            : base(session) {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
        private Task parent;
        public Task Parent {
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
        public XPCollection<Task> PredecessorTasks {
            get {
                return GetCollection<Task>(nameof(PredecessorTasks));
            }
        }
        [Association("PredecessorTasks")]
        [Browsable(false)]
        public XPCollection<Task> NotPredecessorTasks {
            get {
                return GetCollection<Task>(nameof(NotPredecessorTasks));
            }
        }

        #region ITask
        [Browsable(false)]
        public ITask Id { get { return this; } }
        ITask ITask.Parent {
            get { return Parent; }
            set { Parent = (Task)value; }
        }
        IList<ITask> ITask.PredecessorTasks {
            get {
                return (IList<ITask>)PredecessorTasks;
            }
        }
        #endregion
    }
}