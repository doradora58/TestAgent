import React, { useState } from "react";

import TaskForm from "./TaskForm";

function CreateTask(){
    const [showForm, setShowForm] = useState(false);

    const handleNewTaskClick = () => {
        setShowForm(true);
    };

    const handleTaskSubmit = (newTask) => {
        console.log("New Task:", newTask);
        setShowForm(false);
    };

    return (
        <div className="gantt-container">
            <button onClick={handleNewTaskClick}>New Task</button>
            {showForm && <TaskForm onSubmit={handleTaskSubmit} />}
        </div>
    );
}

export default CreateTask;