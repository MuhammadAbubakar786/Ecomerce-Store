import React from "react";
import { useNavigate } from "react-router-dom";

const DashboardPills = ({ color, text, location }) => {
  const navigate = useNavigate();
  const from = `/${location}`;
  return (
    <div className="col-md-4 d-flex  justify-content-center align-items-center  mb-2">
      <button
        onClick={() => navigate(from, { replace: true })}
        type="button"
        className={`btn btn-${color} w-75 w-md-50 p-3 d-flex justify-content-center align-items-center fw-bold text-uppercase fs-sm-1 rounded`}
      >
        {text}
      </button>
    </div>
  );
};

export default DashboardPills;
