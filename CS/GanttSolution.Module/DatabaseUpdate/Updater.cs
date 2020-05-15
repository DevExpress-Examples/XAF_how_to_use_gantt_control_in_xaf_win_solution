using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using Task = GanttSolution.Module.BusinessObjects.Task;

namespace GanttSolution.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Task mainTask = ObjectSpace.FindObject<Task>(new BinaryOperator(nameof(Task.Name), "Main Task"));
            if(mainTask == null) {
                mainTask = ObjectSpace.CreateObject<Task>();
                mainTask.Name = "Main Task";
                mainTask.StartDate = DateTime.Today;
                mainTask.EndDate = DateTime.Today.AddDays(14);
            }
            Task firstTask = ObjectSpace.FindObject<Task>(new BinaryOperator(nameof(Task.Name), "First Task"));
            if(firstTask == null) {
                firstTask = ObjectSpace.CreateObject<Task>();
                firstTask.Name = "First Task";
                firstTask.Parent = mainTask;
                firstTask.StartDate = DateTime.Today;
                firstTask.EndDate = DateTime.Today.AddDays(7);
            }
            Task secondTask = ObjectSpace.FindObject<Task>(new BinaryOperator(nameof(Task.Name), "Second Task"));
            if(secondTask == null) {
                secondTask = ObjectSpace.CreateObject<Task>();
                secondTask.Name = "Second Task";
                secondTask.Parent = mainTask;
                secondTask.StartDate = DateTime.Today.AddDays(7);
                secondTask.EndDate = DateTime.Today.AddDays(14);
                secondTask.PredecessorTasks.Add(firstTask);
            }
            ObjectSpace.CommitChanges();
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
    }
}
