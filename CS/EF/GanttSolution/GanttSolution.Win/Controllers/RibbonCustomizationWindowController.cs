using DevExpress.ExpressApp;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGantt;
using DevExpress.XtraGantt.Ribbon;
using System;

namespace GanttSolution.Module.Win.Controllers {
    public class RibbonCustomizationWindowController : ViewController<ListView> {
        private GanttControl ganttControl;
        private RibbonControl ribbonControl;
        private GanttViewRibbonPage ganttViewRibbonPage;
        public RibbonCustomizationWindowController() : base() {
            TargetObjectType = typeof(GanttSolution.Module.BusinessObjects.MyTask);
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.ControlsCreated += View_ControlsCreated;
        }
        private void View_ControlsCreated(object sender, EventArgs e) {
            RibbonForm ribbonForm = Frame.Template as RibbonForm;
            if(ribbonForm != null && ribbonForm.Ribbon != null) {
                ribbonControl = ribbonForm.Ribbon;
                ganttControl = View.Editor?.Control as GanttControl;
                if(ribbonControl != null && ganttControl != null) {
                    AddGanttPageToRibbon();
                }
            }  
        }

        #region Initialization
        private void AddGanttPageToRibbon() {
            RibbonStatusBar ribbonStatusBar = new RibbonStatusBar();
            GanttBarController ganttBarController = new GanttBarController();
            GanttSplitViewRibbonPageGroup ganttSplitViewRibbonPageGroup = new GanttSplitViewRibbonPageGroup();
            ganttViewRibbonPage = new GanttViewRibbonPage();
            GanttAllowResizeBarCheckItem ganttAllowResizeBarCheckItem = new GanttAllowResizeBarCheckItem();
            GanttPanelVisibilityDefaultBarCheckItem ganttPanelVisibilityDefaultBarCheckItem = new GanttPanelVisibilityDefaultBarCheckItem();
            GanttPanelVisibilityBothBarCheckItem ganttPanelVisibilityBothBarCheckItem = new GanttPanelVisibilityBothBarCheckItem();
            GanttPanelVisibilityChartBarCheckItem ganttPanelVisibilityChartBarCheckItem = new GanttPanelVisibilityChartBarCheckItem();
            GanttPanelVisibilityTreeBarCheckItem ganttPanelVisibilityTreeBarCheckItem = new GanttPanelVisibilityTreeBarCheckItem();
            GanttPanelVisibilityBarSubItem ganttPanelVisibilityBarSubItem = new GanttPanelVisibilityBarSubItem();
            GanttFixedPanelDefaultBarCheckItem ganttFixedPanelDefaultBarCheckItem = new GanttFixedPanelDefaultBarCheckItem();
            GanttFixedPanelNoneBarCheckItem ganttFixedPanelNoneBarCheckItem = new GanttFixedPanelNoneBarCheckItem();
            GanttFixedPanelChartBarCheckItem ganttFixedPanelChartBarCheckItem = new GanttFixedPanelChartBarCheckItem();
            GanttFixedPanelTreeBarCheckItem ganttFixedPanelTreeBarCheckItem = new GanttFixedPanelTreeBarCheckItem();
            GanttFixedPanelBarSubItem ganttFixedPanelBarSubItem = new GanttFixedPanelBarSubItem();
            ganttControl.BeginInit();
            ribbonControl.BeginInit();
            ((System.ComponentModel.ISupportInitialize)ganttBarController).BeginInit();
            // 
            // ribbonControl
            // 
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbonControl.ExpandCollapseItem,
            ribbonControl.SearchEditItem,
            ganttAllowResizeBarCheckItem,
            ganttPanelVisibilityBarSubItem,
            ganttPanelVisibilityDefaultBarCheckItem,
            ganttPanelVisibilityBothBarCheckItem,
            ganttPanelVisibilityChartBarCheckItem,
            ganttPanelVisibilityTreeBarCheckItem,
            ganttFixedPanelBarSubItem,
            ganttFixedPanelDefaultBarCheckItem,
            ganttFixedPanelNoneBarCheckItem,
            ganttFixedPanelChartBarCheckItem,
            ganttFixedPanelTreeBarCheckItem});
            ribbonControl.Pages.AddRange(new RibbonPage[] {
            ganttViewRibbonPage});
            ribbonControl.StatusBar = ribbonStatusBar;
            ribbonStatusBar.Ribbon = ribbonControl;
            // 
            // ganttBarController
            // 
            ganttBarController.BarItems.Add(ganttAllowResizeBarCheckItem);
            ganttBarController.BarItems.Add(ganttPanelVisibilityDefaultBarCheckItem);
            ganttBarController.BarItems.Add(ganttPanelVisibilityBothBarCheckItem);
            ganttBarController.BarItems.Add(ganttPanelVisibilityChartBarCheckItem);
            ganttBarController.BarItems.Add(ganttPanelVisibilityTreeBarCheckItem);
            ganttBarController.BarItems.Add(ganttPanelVisibilityBarSubItem);
            ganttBarController.BarItems.Add(ganttFixedPanelDefaultBarCheckItem);
            ganttBarController.BarItems.Add(ganttFixedPanelNoneBarCheckItem);
            ganttBarController.BarItems.Add(ganttFixedPanelChartBarCheckItem);
            ganttBarController.BarItems.Add(ganttFixedPanelTreeBarCheckItem);
            ganttBarController.BarItems.Add(ganttFixedPanelBarSubItem);
            ganttBarController.Control = ganttControl;
            // 
            // ganttSplitViewRibbonPageGroup
            // 
            ganttSplitViewRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            ganttSplitViewRibbonPageGroup.ItemLinks.Add(ganttAllowResizeBarCheckItem);
            ganttSplitViewRibbonPageGroup.ItemLinks.Add(ganttPanelVisibilityBarSubItem);
            ganttSplitViewRibbonPageGroup.ItemLinks.Add(ganttFixedPanelBarSubItem);
            // 
            // ganttViewRibbonPage
            // 
            ganttViewRibbonPage.Groups.AddRange(new RibbonPageGroup[] {
            ganttSplitViewRibbonPageGroup});
            ganttViewRibbonPage.Text = "Gantt";
            // 
            // ganttPanelVisibilityBarSubItem
            // 
            ganttPanelVisibilityBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityDefaultBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityBothBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityChartBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(ganttPanelVisibilityTreeBarCheckItem)});
            // 
            // ganttFixedPanelBarSubItem
            // 
            ganttFixedPanelBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelDefaultBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelNoneBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelChartBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(ganttFixedPanelTreeBarCheckItem)});
            ganttControl.EndInit();
            ribbonControl.EndInit();
            ((System.ComponentModel.ISupportInitialize)ganttBarController).EndInit();
        }
		#endregion

		protected override void OnDeactivated() {
            View.ControlsCreated -= View_ControlsCreated;
            if(ribbonControl != null) {
                ribbonControl.Pages.Remove(ganttViewRibbonPage);
                ganttViewRibbonPage.Dispose();
            }
            base.OnDeactivated();
        }
    }
}
