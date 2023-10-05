<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/259895910/23.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T885407)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

*Files to look at*:
* [CustomGanttEditor.cs](CS/EF/GanttSolution/GanttSolution.Win/Editors/CustomGanttEditor.cs) 
* [RibbonCustomizationWindowController.cs](CS/EF/GanttSolution/GanttSolution.Win/Controllers/RibbonCustomizationWindowController.cs)
* [ITask.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/ITask.cs)
* [Task.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/Task.cs)

# How to Use the Gantt Control to Display a List of Tasks in XAF WinForms Apps

## Scenario

This example demonstrates the simplest integration solution for the WinForms [Gantt Control](https://docs.devexpress.com/WindowsForms/401173/controls-and-libraries/gantt-control/gantt-control) in XAF WinForms. Gantt will display a list of business objects (tasks) as a project schedule:
![image](https://user-images.githubusercontent.com/14300209/82027691-4d5a0b00-969d-11ea-936f-a68f863d9f8a.png)

## Implementation Steps

**Step 1.** Add the [GanttSolution.Module/BusinessObjects/ITask.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/ITask.cs) file to your *YourSolutionName.Module* project. Implement the *GanttSolution.Module.BusinessObjects.ITask* interface in the business class that will be a task record in the Gantt Control data source (research *GanttSolution.Module.BusinessObjects.Task.cs* for details).

**Step 2.** Add the following files to the *YourSolutionName.Win* project and build your solution:
  
  - *GanttSolution.Win\Controllers\RibbonCustomizationWindowController.cs*
  - *GanttSolution.Win\Editors\CustomGanttEditor.cs*
  
For more information on custom List Editors and related customization scenarios, see [List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors) | [How to: Access the List Editor's Control](https://docs.devexpress.com/eXpressAppFramework/112814/task-based-help/scheduler-and-notifications/how-to-access-the-list-editors-control).

**Step 3.** Invoke the Model Editor for the *YourSolutionName.Win* project, navigate to the `Views | YourTaskClass_ListView` node and set **EditorType** to `GanttSolution.Module.Win.Editors.CustomGanttEditor`. For more information, see [Customize List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors#customize-list-editors).

**NOTE**: This example is not a complete solution. Thoroughly test, extend and modify its code to meet your business requirements.

---
To integrate ASPxGantt into an XAF ASP.NET project, create a custom list editor as we described at [T831607 - Web - How to use ASPxGantt in XAF](https://supportcenter.devexpress.com/internal/ticket/details/T831607#)
