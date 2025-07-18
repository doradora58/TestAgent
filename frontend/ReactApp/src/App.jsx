import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
    const [count, setCount] = useState(0);
    const tasks = [
        {
            id: '1',
            title: 'Develop',
            start: '2025-07-19',
            end: '2025-07-21'
        },
        {
            id: '2',
            title: 'Test',
            start: '2025-07-22',
            end: '2025-07-25'
        }
    ];
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
              {tasks.map((task) => (
                  <div key={task.id} className="task-bar">
                      <strong>{task.title}</strong>({task.start} ~ {task.end})
                  </div>
              ))}
          </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
