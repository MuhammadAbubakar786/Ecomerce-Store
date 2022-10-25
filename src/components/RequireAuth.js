import React from "react";
import { Navigate, Outlet, useLocation } from "react-router-dom";
import useAuth from "../Hooks/useAuth";
const RequireAuth = ({ allowedRoles }) => {
  const { auth } = useAuth();
  const location = useLocation();
  console.log("allowedRoles", allowedRoles);
  console.log("auth", auth);
  return auth?.roles?.find((role) => allowedRoles?.includes(role?.roleId)) ? (
    <Outlet />
  ) : auth?.user ? (
    <Navigate to="/unauthorized" state={{ from: location }} replace />
  ) : (
    <>
      <Navigate to="/Login" state={{ from: location }} replace />
    </>
  );
};

export default RequireAuth;
