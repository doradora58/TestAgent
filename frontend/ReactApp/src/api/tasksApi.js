import BASE_URL from "../config";
export async function fetchTasks() {
    const response = await fetch(BASE_URL+"/Tasks", {
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

export async function createTask(newTask) {
    const response = await fetch(BASE_URL + "/Tasks", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Accept": "*/*",
        },
        body: JSON.stringify(newTask),
    });

    if (!response.ok) {
        throw new Error("Failed to create task");
    }

    return response.json();
}
