Imports System
Imports System.Linq
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Persistent.BaseImpl
Imports Task = GanttSolution.Module.BusinessObjects.Task

Namespace GanttSolution.Module.DatabaseUpdate
    ' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim mainTask As Task = ObjectSpace.FindObject(Of Task)(New BinaryOperator(nameof(Task.Name), "Main Task"))
            If mainTask Is Nothing Then
                mainTask = ObjectSpace.CreateObject(Of Task)()
                mainTask.Name = "Main Task"
                mainTask.StartDate = Date.Today
                mainTask.EndDate = Date.Today.AddDays(14)
            End If
            Dim firstTask As Task = ObjectSpace.FindObject(Of Task)(New BinaryOperator(nameof(Task.Name), "First Task"))
            If firstTask Is Nothing Then
                firstTask = ObjectSpace.CreateObject(Of Task)()
                firstTask.Name = "First Task"
                firstTask.Parent = mainTask
                firstTask.StartDate = Date.Today
                firstTask.EndDate = Date.Today.AddDays(7)
            End If
            Dim secondTask As Task = ObjectSpace.FindObject(Of Task)(New BinaryOperator(nameof(Task.Name), "Second Task"))
            If secondTask Is Nothing Then
                secondTask = ObjectSpace.CreateObject(Of Task)()
                secondTask.Name = "Second Task"
                secondTask.Parent = mainTask
                secondTask.StartDate = Date.Today.AddDays(7)
                secondTask.EndDate = Date.Today.AddDays(14)
                secondTask.PredecessorTasks.Add(firstTask)
            End If
            ObjectSpace.CommitChanges()
        End Sub
        Public Overrides Sub UpdateDatabaseBeforeUpdateSchema()
            MyBase.UpdateDatabaseBeforeUpdateSchema()
        End Sub
    End Class
End Namespace
