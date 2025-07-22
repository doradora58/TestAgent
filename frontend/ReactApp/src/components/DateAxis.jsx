
import "../styles/GanttChart.css"
function DateAxis({ startDate, endDate }) {
    const dates = [];
    let currentDate = new Date(startDate);

    while (currentDate <= endDate) {
        dates.push(new Date(currentDate));
        currentDate.setDate(currentDate.getDate() + 1);
    }

    return (
        <div className="date-axis">
            {dates.map((date) => (
                <div key={date.toISOString()} className="date-bar">
                    {date.toLocaleDateString()}
                </div>
            ))}
        </div>
    );
}

export default DateAxis;
