import DateAxis from "./DateAxis";
import TaskBar from "./TaskBar";
import "../styles/GanttChart.css"

function GanttChart({ tasks }) {
    const startDate = new Date(Math.min(...tasks.map(task => new Date(task.plannedTerm.startDate))));
    const endDate = new Date(Math.max(...tasks.map(task => new Date(task.plannedTerm.endDate))));

    const weekDates = [];
    let currentDate = new Date(startDate);

    while (currentDate <= endDate) {
        weekDates.push(new Date(currentDate));
        currentDate.setDate(currentDate.getDate() + 7);
    }

    return (
        <div className="gantt-container">
            <div className="week-lines">
                {weekDates.map((date, index) => {
                    const offset = (date - startDate) / (1000 * 60 * 60 * 24) * 50;
                    return (
                        <div
                            key={index}
                            className="week-line"
                            style={{ left: `${offset}px` }}
                        />
                    );
                })}
            </div>
            {tasks.map(task => (
                <TaskBar key={task.id} task={task} startDate={startDate} />
            ))}
        </div>
    );
}


export default GanttChart;
