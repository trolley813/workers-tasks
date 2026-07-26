Тестовое задание к собеседованию

- `WorkersAndTasks` - серверная часть (C#, .NET 10)
- `workers-tasks-frontend` - клиентская часть (TypeScript, React 19)

## Формат запроса
```json
{
  "workers": [
    {
      "id": 1,
      "skillLevel": 5,
      "availableRange": {
        "startTime": "19:00",
        "endTime": "20:00"
      }
    },
    {
      "id": 2,
      "skillLevel": 3,
      "availableRange": {
        "startTime": "09:00",
        "endTime": "18:00"
      }
    },
    {
      "id": 3,
      "skillLevel": 1,
      "availableRange": {
        "startTime": "07:00",
        "endTime": "19:00"
      }
    }
  ],
  "tasks": [
    {
      "id": 1,
      "duration": 300,
      "priority": 1
    },
    {
      "id": 2,
      "duration": 200,
      "priority": 2
    },
    {
      "id": 3,
      "duration": 100,
      "priority": 3
    }
  ]
}
```

## Формат ответа
```json
{
  "finishTime": "2026-07-27T09:21:59.1816284+03:00",
  "items": [
    {
      "workerId": 2,
      "taskId": 3,
      "start": "2026-07-26T16:21:59.1816285+03:00",
      "finish": "2026-07-26T16:55:19.1816285+03:00"
    },
    {
      "workerId": 1,
      "taskId": 2,
      "start": "2026-07-26T19:00:00+03:00",
      "finish": "2026-07-26T19:40:00+03:00"
    },
    {
      "workerId": 3,
      "taskId": 1,
      "start": "2026-07-26T16:21:59.1816285+03:00",
      "finish": "2026-07-27T09:21:59.1816284+03:00"
    }
  ]
}
```