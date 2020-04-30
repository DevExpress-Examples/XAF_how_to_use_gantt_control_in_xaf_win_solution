Namespace GanttSolution.Module.BusinessObjects
    Public Interface ITask
        ReadOnly Property Id() As ITask
        Property Name() As String
        Property StartDate() As Date
        Property EndDate() As Date
        Property Duration() As TimeSpan
        Property Progress() As Double
        Property Parent() As ITask
        ReadOnly Property PredecessorTasks() As IList(Of ITask)
    End Interface
End Namespace