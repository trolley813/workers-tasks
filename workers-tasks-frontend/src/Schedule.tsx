import { ScheduleResponse } from "./api";

function Schedule({ data }: { data: ScheduleResponse }) {
  return (
    <>
      <h3>
        Время завершения всех задач:{" "}
        {new Date(data.finishTime).toLocaleString()}
      </h3>
      <table>
        <thead>
          <tr>
            <th>№ задачи</th>
            <th>№ исполнителя</th>
            <th>Время начала</th>
            <th>Время окончания</th>
          </tr>
        </thead>
        <tbody>
          {data.items.map((item, index) => (
            <tr key={index}>
              <td>{item.taskId}</td>
              <td>{item.workerId}</td>
              <td>{new Date(item.start).toLocaleString()}</td>
              <td>{new Date(item.finish).toLocaleString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default Schedule;
