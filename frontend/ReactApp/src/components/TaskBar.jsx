import "../styles/GanttChart.css"
function TaskBar({ task, startDate }) {
    const startOffset =
        (new Date(task.plannedTerm.startDate) - new Date(startDate)) / (1000 * 60 * 60 * 24);
    const width =
        (new Date(task.plannedTerm.endDate) - new Date(task.plannedTerm.startDate)) / (1000 * 60 * 60 * 24) *50;

    return (
        <div
            className={`gantt-bar ${task.status.toLowerCase().replace(" ", "-")}`}
            style={{ marginLeft: `${startOffset * 50}px`, width: `${width}px` }}
        >
            {task.title}: {task.status}
        </div>
    );
}

export default TaskBar;
