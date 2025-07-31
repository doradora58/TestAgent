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

export async function removeTask(taskId) {
    try {
        const response = await fetch(BASE_URL + `/Tasks/${taskId}`, {
            method: 'DELETE'
        });
        if (response.ok) {
            console.log('Task successfully removed!');
        } else {
            console.error('Failed to remove task:', response.statusText);
        }
    } catch (error) {
        console.error('Error while removing task:', error);
    }
};