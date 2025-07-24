import { useEffect, useState } from "react";
import GanttChart from "./components/GanttChart";
import { fetchTasks } from "./api/tasksApi";
import "./styles/App.css"

function App() {
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        const loadTasks = async () => {
            try {
                const data = await fetchTasks();
                setTasks(data);
            } catch (error) {
                console.error("Failed to fetch tasks:", error);
            }
        };
        loadTasks();
    }, []);

    return (
        <div>
            <h1>Delivery Plan Ve1</h1>
            <GanttChart tasks={tasks} />
        </div>
    );
}

export default App;
