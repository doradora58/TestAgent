import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
    const [count, setCount] = useState(0);
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        const fetchTasks = async () => {
            try {
                const response = await fetch('http://localhost:5000/Tasks');
                const data = await response.json();
                setTasks(data);
            } catch (error) {
                console.error('Failed to fetch tasks:', error);
            }
        };
        fetchTasks();
    }, []);
    return (
        <>
            <div>
                <a href="https://vite.dev" target="_blank">
                    <img src={viteLogo} className="logo" alt="Vite logo" />
                </a>
                <a href="https://react.dev" target="_blank">
                    <img src={reactLogo} className="logo react" alt="React logo" />
                </a>
            </div>
            <h1>Vite + React</h1>
            <div className="card">
                <button onClick={() => setCount((count) => count + 1)}>
                    count is {count}
                </button>
                <p>
                    Edit <code>src/App.jsx</code> and save to test HMR
                </p>
            </div>
            <div className="chart-container">
                <h1>Gantt Chart</h1>
                {tasks.length > 0 ? (
                    tasks.map((task) => (
                    <div key={task.id} className="task-bar">
                            { task.id} : <strong>{task.title}</strong> ({task.dueDate})
                    </div>
                    ))
                ): (<p>Loading tasks...</p> // データがまだフェッチされていない場合のメッセージ
                )}
            </div>
            <p className="read-the-docs">
                Click on the Vite and React logos to learn more
            </p>
        </>
    )
}

export default App
