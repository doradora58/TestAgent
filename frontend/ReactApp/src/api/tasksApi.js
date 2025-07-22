export async function fetchTasks() {
    const response = await fetch("http://localhost:5000/Tasks");
    if (!response.ok) {
        throw new Error("Failed to fetch tasks");
    }
    return response.json();
}
