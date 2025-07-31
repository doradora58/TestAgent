import React, { useState } from "react";

import TaskForm from "./TaskForm";
import { createTask } from "../api/tasksApi"

function CreateTask(){
    const [showForm, setShowForm] = useState(false);

    const handleNewTaskClick = () => {
        setShowForm(true);
    };

    const handleTaskSubmit = async (newTask) => {
        try {
            const response = await createTask(newTask);
            console.log("Task created:", response);
            setShowForm(false);
        } catch (error) {
            console.error("Error creating task:", error);
        }
    };

    return (
        <div className="gantt-container">
            <button onClick={handleNewTaskClick}>New Task</button>
            {showForm && <TaskForm onSubmit={handleTaskSubmit} />}
        </div>
    );
}

export default CreateTask;