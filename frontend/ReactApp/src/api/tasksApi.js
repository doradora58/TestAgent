export async function fetchTasks() {
    const response = await fetch("http://100.90.217.39:50000/Tasks", {
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
