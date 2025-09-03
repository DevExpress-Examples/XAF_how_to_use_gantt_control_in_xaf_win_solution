<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/259895910/23.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T885407)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XAF WinForms - How to Use the Gantt Control to Display a List of Tasks

This example integrates the WinForms [Gantt Control](https://docs.devexpress.com/WindowsForms/401173/controls-and-libraries/gantt-control/gantt-control) in an XAF WinForms application. Gantt displays a list of business objects (tasks) as a project schedule.

![image](https://user-images.githubusercontent.com/14300209/82027691-4d5a0b00-969d-11ea-936f-a68f863d9f8a.png)

## Implementation Details

Follow the steps below to add the [Gantt Control](https://docs.devexpress.com/WindowsForms/401173/controls-and-libraries/gantt-control/gantt-control) to your application:

1. Implement a business class that contains task records in the Gantt Control data source (copy [ITask.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/ITask.cs) and [Task.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/Task.cs) files to *YourSolutionName.Module/BusinessObjects* folder).

1. Copy the following files to the *YourSolutionName.Win* project and build your solution:
    - [GanttSolution.Win/Controllers/RibbonCustomizationWindowController.cs](CS/EF/GanttSolution/GanttSolution.Win/Controllers/RibbonCustomizationWindowController.cs)
    - [GanttSolution.Win/Editors/CustomGanttEditor.cs](CS/EF/GanttSolution/GanttSolution.Win/Editors/CustomGanttEditor.cs)

1. Double click the *YourSolutionName.Win/Model.xafml* file to invoke the Model Editor. Navigate to the **Views** | **YourTaskClass_ListView** node and set `EditorType` to `GanttSolution.Module.Win.Editors.CustomGanttEditor`.

> **Note**
> This example is not a complete solution. You can test, extend, and modify its code to meet your business requirements.

## Files to Review
* [CustomGanttEditor.cs](CS/EF/GanttSolution/GanttSolution.Win/Editors/CustomGanttEditor.cs) 
* [RibbonCustomizationWindowController.cs](CS/EF/GanttSolution/GanttSolution.Win/Controllers/RibbonCustomizationWindowController.cs)
* [ITask.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/ITask.cs)
* [Task.cs](CS/EF/GanttSolution/GanttSolution.Module/BusinessObjects/Task.cs)

## Documentation
* [List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors)
* [How to: Access the List Editor's Control](https://docs.devexpress.com/eXpressAppFramework/112814/task-based-help/scheduler-and-notifications/how-to-access-the-list-editors-control)
* [Customize List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/concepts/ui-construction/list-editors#customize-list-editors)
* [Web - How to use ASPxGantt in XAF](https://supportcenter.devexpress.com/internal/ticket/details/T831607)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-win-gantt-control&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-win-gantt-control&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
