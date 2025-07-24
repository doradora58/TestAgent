
import "../styles/DateAxis.css"
function DateAxis({ startDate, endDate }) {
    const dates = [];
    let currentDate = new Date(startDate);

    while (currentDate <= endDate) {
        dates.push(new Date(currentDate));
        currentDate.setDate(currentDate.getDate() + 1);
    }

    let lastYear = null;
    let lastMonth = null;

    return (
        <div className="date-axis">
            {dates.map((date, index) => {
                const year = date.getFullYear();
                const month = date.getMonth() + 1;
                const day = date.getDate();

                const showYear = year !== lastYear;
                const showMonth = month !== lastMonth;

                lastYear = year;
                lastMonth = month;

                return (
                    <div key={index} className="date-bar">
                        {showYear && <div className="year">{year}</div>}
                        {showMonth && <div className="month">{month}</div>}
                        <div className="day">{day}</div>
                    </div>
                );
            })}
        </div>
    );
}

export default DateAxis;


