using System;
using System.Linq;
using System.Text;

using System.ComponentModel;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanttSolution.Module.BusinessObjects {
    [DefaultClassOptions]
    public class MyTask :BaseObject, IMyTask {
        public MyTask() {

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
        public virtual Guid Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        [Browsable(false)]
        public virtual TimeSpan Duration { get; set; }
        public virtual double Progress { get; set; }

        public virtual string PredecessorTasks { get; set; }

        #region ITask
       public Guid TaskId { get { return this.ID; } }


        #endregion
    }
}