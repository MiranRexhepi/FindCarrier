// import './App.css';
// import { BrowserRouter, Route, Routes } from 'react-router-dom';
// import Navbar from './components/Navbar';
// import { Login } from './components/Login';
// import  Home  from './components/Home';
// import  {Dashboard}  from './components/Dashboard';
// import  {Doctor}  from './components/Doctor';
// import { ToastContainer } from 'react-toastify';
// import { Fragment } from 'react';

// function App() {
//   return (
//       <div>
//         <ToastContainer></ToastContainer>
//         <BrowserRouter>
//         <Routes>
//           {/* <Route path="/" element={<Dashboard />} /> */}
//           {/* <Route path="/" element={<Home />} /> */}
//           {/* <Route path="/doctor" element={<Doctor />} /> */}
//           <Route path="/" element={<Navbar />} />
//           <Route path="/login" element={<Login />} />
//         </Routes>
//       </BrowserRouter>
//       </div>
//   );
// }

// export default App;

//------------------------------------------------------------------------

import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Navbar from "./components/Navbar";
import { Login } from "./components/Login";
// import Home from './components/Home';
import { Dashboard } from "./components/Dashboard";
import { Doctor } from "./components/Doctor";
import { Nurse } from "./components/Nurse";
import { Patient } from "./components/Patient";
import Department from "./components/Department";
import { ToastContainer } from "react-toastify";
import { useState } from "react";
import Error from "./components/Error";
import Report from "./components/Report";
import RecordPatients from "./components/RecordPatients";
import { Appointment } from "./components/Appointment";
import HealthReport from "./components/HealthReport";
import Roles from "./components/Roles";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div>
      <ToastContainer></ToastContainer>
      <BrowserRouter>
        <Routes>
          <Route
            path="/login"
            element={<Login setIsLoggedIn={setIsLoggedIn} />}
          />
          <Route
            path="/dashboard"
            element={<Navbar isLoggedIn={isLoggedIn} />}
          />
          <Route path="/" element={<Dashboard setIsLoggedIn={isLoggedIn} />} />
          <Route
            path="/doctor"
            element={<Doctor setIsLoggedIn={isLoggedIn} />}
          />
          <Route path="/nurse" element={<Nurse setIsLoggedIn={isLoggedIn} />} />
          <Route
            path="/patient"
            element={<Patient setIsLoggedIn={isLoggedIn} />}
          />
          <Route
            path="/department"
            element={<Department setIsLoggedIn={isLoggedIn} />}
          />
          <Route
            path="/appointment"
            element={<Appointment setIsLoggedIn={isLoggedIn} />}
          />
          <Route
            path="/record-patients"
            element={<RecordPatients setIsLoggedIn={isLoggedIn} />}
          />
          <Route
            path="/health-report"
            element={<HealthReport setIsLoggedIn={isLoggedIn} />}
          />
          <Route path="/roles" element={<Roles setIsLoggedIn={isLoggedIn} />} />
          <Route path="*" element={<Error />} />
          <Route path="/report" element={<Report />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
