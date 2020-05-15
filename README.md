
*Files to look at*:
* [CustomGanttEditor.cs](./CS/GanttSolution.Module.Win/Editors/CustomGanttEditor.cs) (VB: [CustomGanttEditor.vb](./VB/GanttSolution.Module.Win/Editors/CustomGanttEditor.vb))
* [RibbonCustomizationWindowController.cs](./CS/GanttSolution.Module.Win/Controllers/RibbonCustomizationWindowController.cs) (VB: [CustomGanttEditor.vb](./VB/GanttSolution.Module.Win/Controllers/RibbonCustomizationWindowController.vb))

# How to Use the Gantt Control to Display a List of Tasks in XAF WinForms Apps

## Scenario

This example demonstrates the simplest integration solution for the [Gantt Control](https://docs.devexpress.com/WindowsForms/401173/controls-and-libraries/gantt-control/gantt-control) in XAF. Gantt will display a list of business objects (tasks) as a project schedule:
![image](https://user-images.githubusercontent.com/14300209/82027691-4d5a0b00-969d-11ea-936f-a68f863d9f8a.png)

## Implementation Steps

**Step 1.** Add the [GanttSolution.Module/BusinessObjects/ITask.cs](.CS/GanttSolution.Module/BusinessObjects/ITask.cs) file to your *YourSolutionName.Module* project. Implement the *GanttSolution.Module.BusinessObjects.ITask* interface in the business class that will be a task record in the Gantt Control data source (research *GanttSolution.Module.BusinessObjects.Task.cs* for details).

**Step 2.** Add the following files to the *YourSolutionName.Module.Win* project and build your solution:
  
  - *GanttSolution.Module.Win\Controllers\RibbonCustomizationWindowController.cs*
  - *GanttSolution.Module.Win\Editors\CustomGanttEditor.cs*
  
For more information on custom List Editors and related customization scenarios, see [List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors) | [How to: Access the List Editor's Control](https://docs.devexpress.com/eXpressAppFramework/112814/task-based-help/scheduler-and-notifications/how-to-access-the-list-editors-control).

**Step 3.** Invoke the Model Editor for the *YourSolutionName.Module.Win* project, navigate to the `Views | YourTaskClass_ListView` node and set **EditorType** to `GanttSolution.Module.Win.Editors.CustomGanttEditor`. For more information, see [Customize List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors#customize-list-editors).

**NOTE**: This example is not a complete solution. Thoroughly test, extend and modify its code to meet your business requirements.
