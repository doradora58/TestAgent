export async function fetchTasks() {
    const response = await fetch("http://0.0.0.0:50000/Tasks", {
        headers: {
            "Content-Type": "application/json",
            "Accept": "*/*",
        },
    });
    if (!response.ok) {
        throw new Error("Failed to fetch tasks");
    }
    return response.json();
}
