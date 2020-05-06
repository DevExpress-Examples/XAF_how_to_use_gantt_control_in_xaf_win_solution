
*Files to look at*:
* [CustomGanttEditor.cs](./CS/GantSolution.Module.Win/Editors/CustomGanttEditor.cs) (VB: [CustomGanttEditor.vb](./VB/GantSolution.Module.Win/Editors/CustomGanttEditor.vb))
* [RibbonCustomizationWindowController.cs](./CS/GantSolution.Module.Win/Controllers/RibbonCustomizationWindowController.cs) (VB: [CustomGanttEditor.vb](./VB/GantSolution.Module.Win/Controllers/RibbonCustomizationWindowController.vb))

# How to use Gantt Control in an XAF WinForms solution

### Scenario

This example demonstrates a possible integration of the [Gantt Control](https://docs.devexpress.com/WindowsForms/401173/controls-and-libraries/gantt-control/gantt-control) in XAF. This control represents a list of business objects as a project schedule:
![preview4](https://user-images.githubusercontent.com/14300209/80727769-c9d1e300-8b0e-11ea-98e4-45f4731e6c84.png)

### Implementation Steps

**Step1.** Copy the [GantSolution.Module/BusinessObjects/ITask.cs](.CS/GantSolution.Module/BusinessObjects/ITask.cs) file to your *YourSolutionName.Module* project. Implement the *GanttSolution.Module.BusinessObjects.ITask* interface in the business class that will represents a record in Gantt Control data source.

**Step2.** Copy the following files to the *YourSolutionName.Module.Win* project:
  
  - GantSolution.Module.Win\Controllers\RibbonCustomizationWindowController.cs
  - GantSolution.Module.Win\Editors\CustomGanttEditor.cs

**Step3.** Build your solution.

**Step4.** Set *GanttSolution.Module.Win.Editors.CustomGanttEditor* as an editor for the list view of the class from Step1. Refer to the following article to learn how to change a list editor's type: [Customize List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors#customize-list-editors).




### Important Note
Please take special note that this example is not a complete solution. Its main purpose to show the way to integrate [GanttControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGantt.GanttControl). Extend and modify this editor to meet your business requirements. Thoroughly test it before using in production.
