import React, { useState } from "react";

import TaskForm from "./TaskForm";

function CreateTask(){
    const [showForm, setShowForm] = useState(false);

    const handleNewTaskClick = () => {
        setShowForm(true); // フォームを表示
    };

    const handleTaskSubmit = (newTask) => {
        // 新しいタスクを登録する処理
        console.log("New Task:", newTask);
        setShowForm(false); // フォームを閉じる
    };

    return (
        <div className="gantt-container">
            <button onClick={handleNewTaskClick}>New Task</button>
            {showForm && <TaskForm onSubmit={handleTaskSubmit} />}
        </div>
    );
}

export default CreateTask;