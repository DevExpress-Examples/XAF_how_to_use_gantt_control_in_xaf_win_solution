using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
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
        if(mainTask == null) {
            mainTask = ObjectSpace.CreateObject<MyTask>();
            mainTask.Name = "Main Task";
            mainTask.StartDate = DateTime.Today;
            mainTask.EndDate = DateTime.Today.AddDays(14);
        }
        MyTask firstTask = ObjectSpace.FindObject<MyTask>(new BinaryOperator(nameof(MyTask.Name), "First Task"));
        if(firstTask == null) {
            firstTask = ObjectSpace.CreateObject<MyTask>();
            firstTask.Name = "First Task";
            firstTask.Parent = mainTask;
            firstTask.StartDate = DateTime.Today;
            firstTask.EndDate = DateTime.Today.AddDays(7);
        }
        MyTask secondTask = ObjectSpace.FindObject<MyTask>(new BinaryOperator(nameof(MyTask.Name), "Second Task 1"));
        if(secondTask == null) {
            secondTask = ObjectSpace.CreateObject<MyTask>();
            secondTask.Name = "Second Task 1";
            secondTask.Parent = mainTask;
            secondTask.StartDate = DateTime.Today.AddDays(7);
            secondTask.EndDate = DateTime.Today.AddDays(14);
            secondTask.PredecessorTasks.Add(firstTask);
        }
        MyTask secondTask_2 = ObjectSpace.FindObject<MyTask>(new BinaryOperator(nameof(MyTask.Name), "Second Task 2"));
        if(secondTask_2 == null) {
            secondTask_2 = ObjectSpace.CreateObject<MyTask>();
            secondTask_2.Name = "Second Task 2";
            secondTask_2.Parent = mainTask;
            secondTask_2.StartDate = DateTime.Today.AddDays(7);
            secondTask_2.EndDate = DateTime.Today.AddDays(14);
            secondTask_2.PredecessorTasks.Add(firstTask);
        }

        ObjectSpace.CommitChanges();
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
    }
}
