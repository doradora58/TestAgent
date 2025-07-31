import "../styles/GanttChart.css"
import { useState } from "react"
import { removeTask } from "../api/tasksApi"
import { fetchTasks } from "../api/tasksApi"
function TaskBar({ task, startDate, setTasks, onEdit }) {
    const [showOptions, setShowOptions] = useState(false);
    const startOffset =
        (new Date(task.plannedTerm.startDate) - new Date(startDate)) / (1000 * 60 * 60 * 24);
    const width =
        (new Date(task.plannedTerm.endDate) - new Date(task.plannedTerm.startDate)) / (1000 * 60 * 60 * 24) *50;
    const toggleOptions = () => {
        setShowOptions((prevState) => !prevState);
    };
    const handleRemove = async () => {
        try {
            const response = await removeTask(task.id);
            if (response.ok) {
                console.log("Task removed successfully!");
                const updatedTasks = await fetchTasks();
                setTasks(updatedTasks);
            } else {
                console.error("Failed to remove task:", response.statusText);
            }
        } catch (error) {
            console.error("Error while removing task:", error);
        } finally {
            setShowOptions(false);
        }
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
                    <button onClick={ handleRemove }>Remove</button>
                </div>
            )}
        </div>
    );
}

export default TaskBar;
