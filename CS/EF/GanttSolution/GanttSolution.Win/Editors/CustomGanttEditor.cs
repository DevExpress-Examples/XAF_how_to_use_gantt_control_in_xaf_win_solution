using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraGantt;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GanttSolution.Module.BusinessObjects;
using DevExpress.ExpressApp.EFCore;
using System.Windows.Controls;

namespace GanttSolution.Module.Win.Editors {
    [ListEditor(typeof(IMyTask), false)]
    public class CustomGanttEditor : ListEditor {
        private GanttControl control;
        private object controlDataSource;
        public CustomGanttEditor(IModelListView info) : base(info) { }
        public override SelectionType SelectionType {
            get { return SelectionType.Full; }
        }
        public override IList GetSelectedObjects() {
            if (control == null) {
                return new object[0] { };
            }
            object[] result = new object[1];
            result[0] = control.GetFocusedRow();
            return result;
        }
        private void Control_SelectedIndexChanged(object sender, EventArgs e) {
            OnSelectionChanged();
            OnFocusedObjectChanged();
        }
        private void Control_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            OnSelectionChanged();
        }
        public override void Refresh() {
            if (control == null)
                return;
            try {
                control.BeginUpdate();
                var lst = ((ProxyCollection)controlDataSource).OriginalCollection as EFCoreCollection;
                var lst2 = lst.Cast<object>().ToList();
                control.DataSource = lst2;
                control.RefreshDataSource();
            }
            finally {
                control.EndUpdate();
            }
        }
        private void DataSource_ListChanged(object sender, ListChangedEventArgs e) {
            Refresh();
        }
        protected override void AssignDataSourceToControl(object dataSource) {
            if (controlDataSource != dataSource) {
                IBindingList oldBindable = controlDataSource as IBindingList;
                if (oldBindable != null) {
                    oldBindable.ListChanged -= new ListChangedEventHandler(DataSource_ListChanged);
                }
                controlDataSource = dataSource;
                IBindingList bindable = controlDataSource as IBindingList;
                if (bindable != null) {
                    bindable.ListChanged += DataSource_ListChanged;
                }
                Refresh();
            }
        }
        protected override object CreateControlsCore() {
            control = new GanttControl();
            foreach (IModelColumn column in Model.Columns) {
                var ganttColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                ganttColumn.Caption = column.Caption;
                ganttColumn.FieldName = column.PropertyName;
                ganttColumn.Name = column.PropertyName + "Column";
                ganttColumn.Visible = true;
                ganttColumn.SortIndex = column.SortIndex;
                ganttColumn.Format.FormatString = column.DisplayFormat;
                ganttColumn.Format.FormatType = DevExpress.Utils.FormatType.Custom;
                control.Columns.Add(ganttColumn);
            }
            //var ganttColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            //ganttColumn.Caption = "Name";
            //ganttColumn.FieldName = "Name";
            //ganttColumn.Visible = true;
            //control.Columns.Add(ganttColumn);
            control.KeyFieldName = "Id";
            control.ParentFieldName = "MyParent";
            control.ChartMappings.TextFieldName = nameof(IMyTask.Name);
            control.ChartMappings.StartDateFieldName = nameof(IMyTask.StartDate);
            control.ChartMappings.FinishDateFieldName = nameof(IMyTask.EndDate);
            control.ChartMappings.ProgressFieldName = nameof(IMyTask.Progress);
            control.ChartMappings.PredecessorsFieldName = nameof(IMyTask.PredecessorTasks);
            control.AllowTouchGestures = DevExpress.Utils.DefaultBoolean.True;
            control.OptionsBehavior.ScheduleMode = DevExpress.XtraGantt.Options.ScheduleMode.Auto;
            control.OptionsCustomization.AllowModifyTasks = DevExpress.Utils.DefaultBoolean.True;
            control.OptionsCustomization.AllowModifyDependencies = DevExpress.Utils.DefaultBoolean.True;
            control.OptionsCustomization.AllowModifyProgress = DevExpress.Utils.DefaultBoolean.True;
            //control.SelectionChanged += Control_SelectedIndexChanged;
            //control.FocusedNodeChanged += Control_FocusedNodeChanged;
            //control.MouseDoubleClick += Control_MouseDoubleClick;
            //control.KeyDown += Control_KeyDown;
            Refresh();
            return control;
        }
        private void Control_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            OnSelectionChanged();
            OnFocusedObjectChanged();
        }
        private void Control_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                GanttControlHitInfo hitInfo = control.CalcHitInfo(e.Location);
                if (hitInfo.ChartHitTest?.ItemInfo != null) {
                    OnProcessSelectedItem();
                }
            }
        }
        private void Control_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                OnProcessSelectedItem();
            }
        }
        public override object FocusedObject {
            get {
                return control?.GetFocusedRow();
            }
        }
        public override void Dispose() {
            controlDataSource = null;
            base.Dispose();
        }
    }
}

