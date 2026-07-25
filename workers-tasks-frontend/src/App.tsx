import React, { lazy, Suspense, useState } from "react";
import CodeEditor from "@uiw/react-textarea-code-editor";
import "./App.css";
import { fetchSchedule, ScheduleResponse } from "./api";

const Schedule = lazy(() => import("./Schedule"));

function App() {
  async function optimize() {
    try {
      const requestData = JSON.parse(scheduleRequest!);
      const responseData = await fetchSchedule(requestData);
      setScheduleResponse(responseData);
      setError(undefined);
    } catch (e) {
      setScheduleResponse(undefined);
      setError(e as Error);
    }
  }

  const [scheduleRequest, setScheduleRequest] = useState<string>("");
  const [scheduleResponse, setScheduleResponse] = useState<ScheduleResponse>();
  const [error, setError] = useState<Error>();

  return (
    <div className="App">
      <h1>Workers and Tasks</h1>
      <CodeEditor
        className="input-textarea"
        language="json"
        value={scheduleRequest}
        onChange={(event) => {
          setScheduleRequest(event.target.value);
        }}
        padding={20}
        data-color-mode="light"
      ></CodeEditor>
      <br />
      <button type="submit" onClick={optimize}>
        Рассчитать
      </button>
      <Suspense fallback={<p>Loading...</p>}>
        {scheduleResponse && <Schedule data={scheduleResponse} />}
      </Suspense>
      {error && (
        <pre className="error-text">Произошла ошибка: {error.message}</pre>
      )}
    </div>
  );
}

export default App;
