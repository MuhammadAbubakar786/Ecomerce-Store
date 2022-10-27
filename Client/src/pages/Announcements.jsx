import dateFormat from "dateformat";
import { useFormik } from "formik";
import React from "react";
import styled from "styled-components";
import { AddAnnoucement } from "../Api/Annoucement";
import DatePicker from "../components/DatePicker";
import {
  InitialValues,
  validationSchema,
} from "../FormValidations/AnnoucementSchema";
import useAuth from "../Hooks/useAuth";
import DashBoard from "./DashBoard";
const ErrorMessageText = styled.p`
  color: red;
  font-size: 12px;
`;
const Announcements = () => {
  const { auth, setAuth } = useAuth();
  const formik = useFormik({
    initialValues: InitialValues,
    validationSchema: validationSchema,
    onSubmit: (values, { resetForm }) => {
      const Announcement = {
        fromDate: values.fromDate,
        toDate: values.toDate,
        description: values.description,
        announcementId: values?.announcementId ?? 0,
        userId: auth?.user?.id,
      };
      AddAnnoucement(Announcement)
        .then((res) => {})
        .catch((error) => console.log("error", error));
    },
  });
  return (
    <>
      <DashBoard />
      <div className="row d-flex justify-content-center m-5">
        <div className="col-md-8">
          <div className="card">
            <h5 className="card-header">Add Annoucement</h5>
            <div className="card-body">
              <form onSubmit={formik.handleSubmit}>
                <div className="form-group">
                  <label htmlFor="exampleAnnoucement">Annoucement</label>
                  <input
                    type="text"
                    className="form-control"
                    id="exampleAnnoucement"
                    placeholder="Enter Annoucement"
                    name="description"
                    onChange={formik?.handleChange}
                    value={formik?.values?.description}
                  />
                  <ErrorMessageText>
                    {formik.touched.description && formik.errors.description
                      ? formik.errors.description
                      : null}
                  </ErrorMessageText>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3 mb-md-0">
                    <DatePicker
                      id="fromDate"
                      label="From Date"
                      value={dateFormat(formik.values.fromDate, "yyyy-mm-dd")}
                      type="date"
                      size="small"
                      fullWidth
                      onChange={formik.handleChange}
                      error={
                        formik.touched.fromDate &&
                        Boolean(formik.errors.fromDate)
                      }
                      helperText={
                        formik.touched.fromDate && formik.errors.fromDate
                      }
                    />
                  </div>
                  <div className="col-md-6">
                    <DatePicker
                      id="toDate"
                      label="To Date"
                      value={dateFormat(formik.values.toDate, "yyyy-mm-dd")}
                      type="date"
                      size="small"
                      fullWidth
                      onChange={formik.handleChange}
                      error={
                        formik.touched.toDate && Boolean(formik.errors.toDate)
                      }
                      helperText={formik.touched.toDate && formik.errors.toDate}
                    />
                  </div>
                </div>
                <div className="row my-3">
                  <div className="col-md-12 d-flex justify-content-center align-items-center">
                    <button type="submit" className="btn btn-primary w-75">
                      Submit
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Announcements;
