using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using GanttSolution.Module.BusinessObjects;

namespace GanttSolution.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        MyTask mainTask = ObjectSpace.FindObject<MyTask>(new BinaryOperator(nameof(MyTask.Name), "Main Task"));
        if (mainTask == null) {
            mainTask = ObjectSpace.CreateObject<MyTask>();
            mainTask.Name = "Main Task";
            mainTask.StartDate = DateTime.Today;
            mainTask.EndDate = DateTime.Today.AddDays(14);
        }
        MyTask firstTask = ObjectSpace.FindObject<MyTask>(new BinaryOperator(nameof(MyTask.Name), "First Task"));
        if (firstTask == null) {
            firstTask = ObjectSpace.CreateObject<MyTask>();
            firstTask.Name = "First Task";
            firstTask.Parent = mainTask;
            firstTask.StartDate = DateTime.Today;
            firstTask.EndDate = DateTime.Today.AddDays(7);
        }
        MyTask secondTask = ObjectSpace.FindObject<MyTask>(new BinaryOperator(nameof(MyTask.Name), "Second Task"));
        if (secondTask == null) {
            secondTask = ObjectSpace.CreateObject<MyTask>();
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
