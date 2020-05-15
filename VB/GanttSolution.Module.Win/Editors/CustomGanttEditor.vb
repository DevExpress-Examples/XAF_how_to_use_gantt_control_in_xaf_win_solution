Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.XtraGantt
Imports System.ComponentModel
Imports GanttSolution.Module.BusinessObjects

Namespace GanttSolution.Module.Win.Editors
    <ListEditor(GetType(ITask), False)>
    Public Class CustomGanttEditor
        Inherits ListEditor
        Private ganttControl As GanttControl
        Private controlDataSource As Object
        Public Sub New(ByVal info As IModelListView)
            MyBase.New(info)
        End Sub
        Public Overrides ReadOnly Property SelectionType() As SelectionType
            Get
                Return SelectionType.Full
            End Get
        End Property
        Public Overrides Function GetSelectedObjects() As IList
            If ganttControl Is Nothing Then
                Return New Object() {}
            End If
            Dim result(0) As Object
            result(0) = ganttControl.GetFocusedRow()
            Return result
        End Function
        Private Sub Control_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            OnSelectionChanged()
            OnFocusedObjectChanged()
        End Sub
        Private Sub Control_ItemSelectionChanged(ByVal sender As Object, ByVal e As ListViewItemSelectionChangedEventArgs)
            OnSelectionChanged()
        End Sub
        Public Overrides Sub Refresh()
            If ganttControl Is Nothing Then
                Return
            End If
            Try
                ganttControl.BeginUpdate()
                ganttControl.DataSource = controlDataSource
                ganttControl.RefreshDataSource()
            Finally
                ganttControl.EndUpdate()
            End Try
        End Sub
        Private Sub DataSource_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
            Refresh()
        End Sub
        Protected Overrides Sub AssignDataSourceToControl(ByVal dataSource As Object)
            If controlDataSource IsNot dataSource Then
                Dim oldBindable As IBindingList = TryCast(controlDataSource, IBindingList)
                If oldBindable IsNot Nothing Then
                    RemoveHandler oldBindable.ListChanged, AddressOf DataSource_ListChanged
                End If
                controlDataSource = dataSource
                Dim bindable As IBindingList = TryCast(controlDataSource, IBindingList)
                If bindable IsNot Nothing Then
                    AddHandler bindable.ListChanged, AddressOf DataSource_ListChanged
                End If
                Refresh()
            End If
        End Sub
        Protected Overrides Function CreateControlsCore() As Object
            ganttControl = New GanttControl()
            For Each column As IModelColumn In Model.Columns
                Dim ganttColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
                ganttColumn.Caption = column.Caption
                ganttColumn.FieldName = column.PropertyName
                ganttColumn.Name = column.PropertyName & "Column"
                ganttColumn.Visible = True
                ganttColumn.SortIndex = column.SortIndex
                ganttControl.Columns.Add(ganttColumn)
            Next column
            ganttControl.KeyFieldName = NameOf(ITask.Id)
            ganttControl.ParentFieldName = NameOf(ITask.Parent)
            ganttControl.ChartMappings.TextFieldName = NameOf(ITask.Name)
            ganttControl.ChartMappings.StartDateFieldName = NameOf(ITask.StartDate)
            ganttControl.ChartMappings.FinishDateFieldName = NameOf(ITask.EndDate)
            ganttControl.ChartMappings.ProgressFieldName = NameOf(ITask.Progress)
            ganttControl.ChartMappings.PredecessorsFieldName = NameOf(ITask.PredecessorTasks)
            ganttControl.AllowTouchGestures = DevExpress.Utils.DefaultBoolean.True
            ganttControl.OptionsBehavior.ScheduleMode = DevExpress.XtraGantt.Options.ScheduleMode.Auto
            ganttControl.OptionsCustomization.AllowModifyTasks = DevExpress.Utils.DefaultBoolean.True
            ganttControl.OptionsCustomization.AllowModifyDependencies = DevExpress.Utils.DefaultBoolean.True
            ganttControl.OptionsCustomization.AllowModifyProgress = DevExpress.Utils.DefaultBoolean.True
            AddHandler ganttControl.SelectionChanged, AddressOf Control_SelectedIndexChanged
            AddHandler ganttControl.FocusedNodeChanged, AddressOf Control_FocusedNodeChanged
            AddHandler ganttControl.MouseDoubleClick, AddressOf Control_MouseDoubleClick
            AddHandler ganttControl.KeyDown, AddressOf Control_KeyDown
            Refresh()
            Return ganttControl
        End Function
        Private Sub Control_FocusedNodeChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs)
            OnSelectionChanged()
            OnFocusedObjectChanged()
        End Sub
        Private Sub Control_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                Dim hitInfo As GanttControlHitInfo = ganttControl.CalcHitInfo(e.Location)
                If hitInfo.ChartHitTest?.ItemInfo IsNot Nothing Then
                    OnProcessSelectedItem()
                End If
            End If
        End Sub
        Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Enter Then
                OnProcessSelectedItem()
            End If
        End Sub
        Public Overrides Property FocusedObject() As Object
            Get
                Return ganttControl?.GetFocusedRow()
            End Get
            Set(value As Object)
            End Set
        End Property
        Public Overrides Sub Dispose()
            controlDataSource = Nothing
            MyBase.Dispose()
        End Sub
    End Class
End Namespace

