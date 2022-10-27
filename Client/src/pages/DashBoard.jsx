import React from "react";
import styled from "styled-components";
import DashboardPills from "../components/DashboardPills";

const Container = styled.div`
  overflow: hidden;
  width: 100%;
  max-width: 100%;
  min-width: 100%;
  background-color: #f0f4f3;
  margin: 5% 0%;
  padding: 3%;
`;
const DashBoard = () => {
  return (
    <Container>
      <div className="row d-flex  my-4 my-md-5  flex-wrap">
        <DashboardPills color="dark" text="DashBoard" location="DashBoard" />
        <DashboardPills
          color="dark"
          text="Announcements"
          location="AnnouncementList"
        />
        <DashboardPills color="warning" text="Banners" location="Banner" />
        <DashboardPills color="info" text="Season" location="Season" />
        <DashboardPills
          color="success"
          text="Categories"
          location="Categories"
        />
        <DashboardPills color="primary" text="Products" location="Products" />
        <DashboardPills
          color="danger"
          text="Company Profile"
          location="CompanyProfile"
        />
      </div>
    </Container>
  );
};

export default DashBoard;
