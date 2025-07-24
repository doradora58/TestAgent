import React, { useState } from "react";

import TaskForm from "./TaskForm";

function CreateTask(){
    const [showForm, setShowForm] = useState(false);

    const handleNewTaskClick = () => {
        setShowForm(true); // �t�H�[����\��
    };

    const handleTaskSubmit = (newTask) => {
        // �V�����^�X�N��o�^���鏈��
        console.log("New Task:", newTask);
        setShowForm(false); // �t�H�[�������
    };

    return (
        <div className="gantt-container">
            <button onClick={handleNewTaskClick}>New Task</button>
            {showForm && <TaskForm onSubmit={handleTaskSubmit} />}
        </div>
    );
}

export default CreateTask;