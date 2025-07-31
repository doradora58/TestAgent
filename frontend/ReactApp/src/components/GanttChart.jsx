import DateAxis from "./DateAxis";
import TaskBar from "./TaskBar";
import "../styles/GanttChart.css"

function GanttChart({ tasks ,setTasks}) {
    const startDate = new Date(Math.min(...tasks.map(task => new Date(task.plannedTerm.startDate))));
    const endDate = new Date(Math.max(...tasks.map(task => new Date(task.plannedTerm.endDate))));

    const weekDates = [];
    let currentDate = new Date(startDate);

    while (currentDate <= endDate) {
        weekDates.push(new Date(currentDate));
        currentDate.setDate(currentDate.getDate() + (window.innerWidth < 768 ? 1 : 7));
    }

    return (
        <div className="gantt-container">
            <DateAxis startDate={startDate} endDate={endDate} />

            {tasks.map(task => (
                <TaskBar key={task.id} task={task} startDate={startDate} setTasks={setTasks} />
            ))}
        </div>
    );
}


export default GanttChart;
