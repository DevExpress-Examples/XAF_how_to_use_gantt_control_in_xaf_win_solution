Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace GanttSolution.Module.BusinessObjects
    <DefaultClassOptions>
    Public Class Task
        Inherits BaseObject
        Implements ITask

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
            StartDate = Date.Today
            EndDate = Date.Today.AddDays(1)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub

        Private parent_Renamed As Task
        Public Property Parent() As Task
            Get
                Return parent_Renamed
            End Get
            Set(ByVal value As Task)
                SetPropertyValue(nameof(Parent), parent_Renamed, value)
            End Set
        End Property

        Private name_Renamed As String
        Public Property Name() As String Implements ITask.Name
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue(nameof(Name), name_Renamed, value)
            End Set
        End Property

        Private startDate_Renamed As Date
        Public Property StartDate() As Date Implements ITask.StartDate
            Get
                Return startDate_Renamed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(nameof(StartDate), startDate_Renamed, value)
            End Set
        End Property

        Private endDate_Renamed As Date
        Public Property EndDate() As Date Implements ITask.EndDate
            Get
                Return endDate_Renamed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(nameof(EndDate), endDate_Renamed, value)
            End Set
        End Property

        Private duration_Renamed As TimeSpan
        <Browsable(False)>
        Public Property Duration() As TimeSpan Implements ITask.Duration
            Get
                Return duration_Renamed
            End Get
            Set(ByVal value As TimeSpan)
                SetPropertyValue(nameof(Duration), duration_Renamed, value)
            End Set
        End Property

        Private progress_Renamed As Double
        Public Property Progress() As Double Implements ITask.Progress
            Get
                Return progress_Renamed
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(nameof(Progress), progress_Renamed, value)
            End Set
        End Property
        <Association("PredecessorTasks")>
        Public ReadOnly Property PredecessorTasks() As XPCollection(Of Task)
            Get
                Return GetCollection(Of Task)(nameof(PredecessorTasks))
            End Get
        End Property
        <Association("PredecessorTasks"), Browsable(False)>
        Public ReadOnly Property NotPredecessorTasks() As XPCollection(Of Task)
            Get
                Return GetCollection(Of Task)(nameof(NotPredecessorTasks))
            End Get
        End Property

#Region "ITask"
        <Browsable(False)>
        Public ReadOnly Property Id() As ITask Implements ITask.Id
            Get
                Return Me
            End Get
        End Property
        Private Property ITask_Parent() As ITask Implements ITask.Parent
            Get
                Return Parent
            End Get
            Set(ByVal value As ITask)
                Parent = DirectCast(value, Task)
            End Set
        End Property
        Private ReadOnly Property ITask_PredecessorTasks() As IList(Of ITask) Implements ITask.PredecessorTasks
            Get
                Return DirectCast(PredecessorTasks, IList(Of ITask))
            End Get
        End Property
#End Region
    End Class
End Namespace