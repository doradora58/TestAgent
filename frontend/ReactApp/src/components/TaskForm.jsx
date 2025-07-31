import React, { useState } from "react";
import "../styles/TaskForm.css"
function TaskForm({ onSubmit }) {
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();
        const newTask = {
            description: description,
            title: title,
            plannedTerm: {
                startDate: startDate,
                endDate: endDate,
            },
        };
        onSubmit(newTask);
    };

    return (
        <form onSubmit={handleSubmit} className="task-form">
            <label>
                Title:
                <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
            </label>
            <label>
                Description:
                <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
            </label>
            <label>
                Start Date:
                <input type="date" value={startDate} onChange={(e) => setStartDate(e.target.value)} />
            </label>
            <label>
                End Date:
                <input type="date" value={endDate} onChange={(e) => setEndDate(e.target.value)} />
            </label>
            <button type="submit">Register</button>
        </form>
    );
}


export default TaskForm;