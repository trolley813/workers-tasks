export interface Worker {
    id: number,
    skillLevel: number,
    availableRange: {
        startTime: string,
        endTime: string
    }
}

export interface Task {
    id: number,
    duration: number,
    priority: number
}

export interface ScheduleRequest {
    workers: Worker[],
    tasks: Task[]
}

export interface ScheduleItem {
    workerId: number,
    taskId: number,
    start: string,
    finish: string
}

export interface ScheduleResponse {
    finishTime: string,
    items: ScheduleItem[]
}

export async function fetchSchedule(request: ScheduleRequest): Promise<ScheduleResponse> {
    try {
        const response = await fetch("http://localhost:5034/optimize", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request),
        })
        if (!response.ok) {
            const message = await response.json();
            throw new Error(`HTTP-запрос вернул статус ${response.status}: ${JSON.stringify(message)}`)
        }
        const schedule = await response.json();
        return schedule
    } catch (error) {
        console.error("Ошибка при запросе оптимизации: ", error)
        throw error
    }
}