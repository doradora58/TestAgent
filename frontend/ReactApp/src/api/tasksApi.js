export async function fetchTasks() {
    const response = await fetch("http://webapi:50000/Tasks", {
        headers: {
            accept: "*/*",
        },
    });
    if (!response.ok) {
        throw new Error("Failed to fetch tasks");
    }
    return response.json();
}
