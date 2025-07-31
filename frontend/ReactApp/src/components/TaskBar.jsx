import "../styles/GanttChart.css"
import {useState } from "react"
function TaskBar({ task, startDate, onRemove, onEdit }) {
    const [showOptions, setShowOptions] = useState(false);
    const startOffset =
        (new Date(task.plannedTerm.startDate) - new Date(startDate)) / (1000 * 60 * 60 * 24);
    const width =
        (new Date(task.plannedTerm.endDate) - new Date(task.plannedTerm.startDate)) / (1000 * 60 * 60 * 24) *50;
    const toggleOptions = () => {
        setShowOptions((prevState) => !prevState);
    };
    return (
        <div
            className={`gantt-bar ${task.status.toLowerCase().replace(" ", "-")}`}
            style={{ marginLeft: `${startOffset * 50}px`, width: `${width}px` }}
            onClick={toggleOptions}
        >
            <span>
                {task.title}: {task.status}
            </span>
            {showOptions && (
                <div className="options-modal">
                    <button onClick={() => { onEdit(task); setShowOptions(false); }}>Edit</button>
                    <button onClick={() => { onRemove(task.id); setShowOptions(false); }}>Remove</button>
                </div>
            )}
        </div>
    );
}

export default TaskBar;
