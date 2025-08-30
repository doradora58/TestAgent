import BASE_URL from "../config";
export async function fetchTasks() {
    console.log(" BASE_URL=" + BASE_URL);
    const response = await fetch(BASE_URL + "/Tasks", {
        headers: {
            "Content-Type": "application/json",
            "Accept": "*/*",
        },
    });
    if (!response.ok) {
        throw new Error("Failed to fetch tasks" + " BASE_URL="+BASE_URL);
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

    return response;
}

export async function removeTask(taskId) {

    const response = await fetch(BASE_URL + `/Tasks/${taskId}`, {
        method: 'DELETE'
    });
    if (response.ok) {
        console.log('Task successfully removed!');
    } else {
        console.error('Failed to remove task:', response.statusText);
    }
    return response;
};