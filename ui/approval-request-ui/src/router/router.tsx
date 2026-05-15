import { BrowserRouter, Routes, Route } from "react-router-dom";

import Request from "../pages/Request";

export default function AppRouter() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Request />} />
        <Route path="/request" element={<Request />} />
      </Routes>
    </BrowserRouter>
  );
}