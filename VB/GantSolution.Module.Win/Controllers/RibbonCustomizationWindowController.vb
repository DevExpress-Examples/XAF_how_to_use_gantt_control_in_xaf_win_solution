Imports DevExpress.ExpressApp
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraGantt
Imports DevExpress.XtraGantt.Ribbon
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace GantSolution.Module.Win.Controllers
    Public Class RibbonCustomizationWindowController
        Inherits ViewController(Of ListView)

        Private ganttControl As GanttControl
        Private ribbonControl As RibbonControl
        Private ganttViewRibbonPage As GanttViewRibbonPage
        Public Sub New()
            MyBase.New()
            TargetObjectType = GetType(GanttSolution.Module.BusinessObjects.Task)
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
        End Sub
        Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
            Dim ribbonForm As RibbonForm = TryCast(Frame.Template, RibbonForm)
            If ribbonForm IsNot Nothing AndAlso ribbonForm.Ribbon IsNot Nothing Then
                ribbonControl = ribbonForm.Ribbon
                ganttControl = TryCast(View.Editor?.Control, GanttControl)
                If ribbonControl IsNot Nothing AndAlso ganttControl IsNot Nothing Then
                    AddGanttPageToRibbon()
                End If
            End If
        End Sub

        #Region "Initialization"
        Private Sub AddGanttPageToRibbon()
            Dim ribbonStatusBar As New RibbonStatusBar()
            Dim ganttBarController As New GanttBarController()
            Dim ganttSplitViewRibbonPageGroup As New GanttSplitViewRibbonPageGroup()
            ganttViewRibbonPage = New GanttViewRibbonPage()
            Dim ganttAllowResizeBarCheckItem As New GanttAllowResizeBarCheckItem()
            Dim ganttPanelVisibilityDefaultBarCheckItem As New GanttPanelVisibilityDefaultBarCheckItem()
            Dim ganttPanelVisibilityBothBarCheckItem As New GanttPanelVisibilityBothBarCheckItem()
            Dim ganttPanelVisibilityChartBarCheckItem As New GanttPanelVisibilityChartBarCheckItem()
            Dim ganttPanelVisibilityTreeBarCheckItem As New GanttPanelVisibilityTreeBarCheckItem()
            Dim ganttPanelVisibilityBarSubItem As New GanttPanelVisibilityBarSubItem()
            Dim ganttFixedPanelDefaultBarCheckItem As New GanttFixedPanelDefaultBarCheckItem()
            Dim ganttFixedPanelNoneBarCheckItem As New GanttFixedPanelNoneBarCheckItem()
            Dim ganttFixedPanelChartBarCheckItem As New GanttFixedPanelChartBarCheckItem()
            Dim ganttFixedPanelTreeBarCheckItem As New GanttFixedPanelTreeBarCheckItem()
            Dim ganttFixedPanelBarSubItem As New GanttFixedPanelBarSubItem()
            ganttControl.BeginInit()
            ribbonControl.BeginInit()
            CType(ganttBarController, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' ribbonControl
            ' 
            ribbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() { ribbonControl.ExpandCollapseItem, ribbonControl.SearchEditItem, ganttAllowResizeBarCheckItem, ganttPanelVisibilityBarSubItem, ganttPanelVisibilityDefaultBarCheckItem, ganttPanelVisibilityBothBarCheckItem, ganttPanelVisibilityChartBarCheckItem, ganttPanelVisibilityTreeBarCheckItem, ganttFixedPanelBarSubItem, ganttFixedPanelDefaultBarCheckItem, ganttFixedPanelNoneBarCheckItem, ganttFixedPanelChartBarCheckItem, ganttFixedPanelTreeBarCheckItem})
            ribbonControl.Pages.AddRange(New RibbonPage() { ganttViewRibbonPage})
            ribbonControl.StatusBar = ribbonStatusBar
            ribbonStatusBar.Ribbon = ribbonControl
            ' 
            ' ganttBarController
            ' 
            ganttBarController.BarItems.Add(ganttAllowResizeBarCheckItem)
            ganttBarController.BarItems.Add(ganttPanelVisibilityDefaultBarCheckItem)
            ganttBarController.BarItems.Add(ganttPanelVisibilityBothBarCheckItem)
            ganttBarController.BarItems.Add(ganttPanelVisibilityChartBarCheckItem)
            ganttBarController.BarItems.Add(ganttPanelVisibilityTreeBarCheckItem)
            ganttBarController.BarItems.Add(ganttPanelVisibilityBarSubItem)
            ganttBarController.BarItems.Add(ganttFixedPanelDefaultBarCheckItem)
            ganttBarController.BarItems.Add(ganttFixedPanelNoneBarCheckItem)
            ganttBarController.BarItems.Add(ganttFixedPanelChartBarCheckItem)
            ganttBarController.BarItems.Add(ganttFixedPanelTreeBarCheckItem)
            ganttBarController.BarItems.Add(ganttFixedPanelBarSubItem)
            ganttBarController.Control = ganttControl
            ' 
            ' ganttSplitViewRibbonPageGroup
            ' 
            ganttSplitViewRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False
            ganttSplitViewRibbonPageGroup.ItemLinks.Add(ganttAllowResizeBarCheckItem)
            ganttSplitViewRibbonPageGroup.ItemLinks.Add(ganttPanelVisibilityBarSubItem)
            ganttSplitViewRibbonPageGroup.ItemLinks.Add(ganttFixedPanelBarSubItem)
            ' 
            ' ganttViewRibbonPage
            ' 
            ganttViewRibbonPage.Groups.AddRange(New RibbonPageGroup() { ganttSplitViewRibbonPageGroup})
            ganttViewRibbonPage.Text = "Gantt"
            ' 
            ' ganttPanelVisibilityBarSubItem
            ' 
            ganttPanelVisibilityBarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {
                New DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityDefaultBarCheckItem),
                New DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityBothBarCheckItem),
                New DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityChartBarCheckItem),
                New DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityTreeBarCheckItem)
            })
            ' 
            ' ganttFixedPanelBarSubItem
            ' 
            ganttFixedPanelBarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {
                New DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelDefaultBarCheckItem),
                New DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelNoneBarCheckItem),
                New DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelChartBarCheckItem),
                New DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelTreeBarCheckItem)
            })
            ganttControl.EndInit()
            ribbonControl.EndInit()
            CType(ganttBarController, System.ComponentModel.ISupportInitialize).EndInit()
        End Sub
        #End Region

        Protected Overrides Sub OnDeactivated()
            RemoveHandler View.ControlsCreated, AddressOf View_ControlsCreated
            If ribbonControl IsNot Nothing Then
                ribbonControl.Pages.Remove(ganttViewRibbonPage)
                ganttViewRibbonPage.Dispose()
            End If
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
