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
    public class MyTask : IMyTask{
        public MyTask() {

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
        public virtual int MyTaskId { get; set; }

        public virtual int MyParent { get; set; }
        // public virtual IList<MyTask> Children { get; set; } = new ObservableCollection<MyTask>();
        public virtual string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        [Browsable(false)]
        public virtual TimeSpan Duration { get; set; }
        public virtual double Progress { get; set; }

        public virtual string PredecessorTasks { get; set; }
        //public virtual IList<MyTask> NotPredecessorTasks { get; set; } = new ObservableCollection<MyTask>();



        #region ITask
        [Browsable(false)]
        public int Id { get { return this.MyTaskId; } }
        int IMyTask.Parent {
            get { return MyParent; }
            set { MyParent = value; }
        }
        string IMyTask.PredecessorTasks {
            get {
                return PredecessorTasks;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion
    }
    //public class MyTask : BaseObject, IMyTask {
    //    public MyTask() {

    //        StartDate = DateTime.Today;
    //        EndDate = DateTime.Today.AddDays(1);
    //    }


    //    public virtual Guid MyParent { get; set; }
    //   // public virtual IList<MyTask> Children { get; set; } = new ObservableCollection<MyTask>();
    //    public virtual string Name { get; set; }
    //    public virtual DateTime StartDate { get; set; }
    //    public virtual DateTime EndDate { get; set; }
    //    [Browsable(false)]
    //    public virtual TimeSpan Duration { get; set; }
    //    public virtual double Progress { get; set; }

    //    public virtual string PredecessorTasks { get; set; }
    //    //public virtual IList<MyTask> NotPredecessorTasks { get; set; } = new ObservableCollection<MyTask>();



    //    #region ITask
    //    [Browsable(false)]
    //    public Guid Id { get { return this.ID; } }
    //    Guid IMyTask.Parent {
    //        get { return MyParent; }
    //        set { MyParent = value; }
    //    }
    //    string IMyTask.PredecessorTasks {
    //        get {
    //            return PredecessorTasks;
    //        }
    //    }
    //    #endregion
    //}
}