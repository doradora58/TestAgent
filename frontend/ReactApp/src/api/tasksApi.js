export async function fetchTasks() {
    const response = await fetch("http://webapi:50000/Tasks");
    if (!response.ok) {
        throw new Error("Failed to fetch tasks");
    }
    return response.json();
}
