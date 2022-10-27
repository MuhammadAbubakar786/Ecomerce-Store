import axios from "axios";
import { useFormik } from "formik";
import React from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";
import { AddBanner } from "../Api/Annoucement";
import { ImgUrl } from "../Apiconfig";
import {
  InitialValues,
  validationSchema,
} from "../FormValidations/BannerSchema";
import useAuth from "../Hooks/useAuth";
import { ADD_BANNER } from "../Redux/Constants";
import DashBoard from "./DashBoard";
const ErrorMessageText = styled.p`
  color: red;
  font-size: 12px;
`;
const Banner = () => {
  const { auth, setAuth } = useAuth();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const formik = useFormik({
    initialValues: InitialValues,
    validationSchema: validationSchema,
    onSubmit: (values, { resetForm }) => {
      const Banner = {
        description: values.description,
        title: values.title,
        bannerImage: values.bannerImage,
        id: values?.id ?? 0,
        userId: auth?.user?.id,
      };
      console.log("Banner", Banner);
      AddBanner(Banner)
        .then((res) => {
          if (res.status === 200) {
            dispatch({ type: ADD_BANNER, payload: res?.data?.key });
            navigate("/Banner", { replace: true });
          }
        })
        .catch((error) => console.log("error", error));
    },
  });
  const [UploadPerc, setUploadPerc] = React.useState(0);

  const uploadFile = ({ target: { files } }) => {
    let data = new FormData();
    data.append("file", files[0]);
    const options = {
      onUploadProgress: (progressEvent) => {
        const { loaded, total } = progressEvent;
        let percent = Math.floor((loaded * 100) / total);
        if (percent < 100) {
          setUploadPerc(percent);
        }
      },
    };
    axios.post(`${ImgUrl}api/account/UploadFile`, data, options).then((res) => {
      setUploadPerc(100);
      formik.setFieldValue("bannerImage", ImgUrl + res?.data?.key);
      setTimeout(() => {
        setUploadPerc(0);
      }, 1000);
    });
  };
  return (
    <>
      <DashBoard />
      <div className="row d-flex justify-content-center m-5">
        <div className="col-md-8">
          <div className="card">
            <h5 className="card-header">Add Banners</h5>
            <div className="card-body">
              <form onSubmit={formik.handleSubmit}>
                <div className="form-group">
                  <label htmlFor="exampleAnnoucement">Banner Title</label>
                  <input
                    type="text"
                    className="form-control"
                    id="Title"
                    placeholder="Enter Title"
                    name="title"
                    onChange={formik?.handleChange}
                    value={formik?.values?.title}
                  />
                  <ErrorMessageText>
                    {formik.touched.title && formik.errors.title
                      ? formik.errors.title
                      : null}
                  </ErrorMessageText>
                </div>
                <div className="row">
                  <div className="col-md-12 mb-3 mb-md-0">
                    <label htmlFor="exampleAnnoucement">
                      Banner Description
                    </label>
                    <input
                      type="text"
                      className="form-control"
                      id="description"
                      placeholder="Enter Description"
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
                  <div className="col-md-6"></div>
                </div>
                <div className="row">
                  <div className="col-md-12 mb-3 mb-md-0">
                    <div className="mb-3">
                      <label htmlFor="bannerImage">Banner Image</label>
                      <input
                        type="file"
                        id="bannerImage"
                        onChange={uploadFile}
                        accept="image/*"
                      />
                    </div>
                  </div>
                  <div className="col-md-6 d-flex justify-content-center">
                    <div className="mb-3">
                      {UploadPerc > 0 && (
                        <div className="progress">
                          <div
                            className="progress-bar progress-bar-striped progress-bar-animated"
                            role="progressbar"
                            aria-valuenow={UploadPerc}
                            aria-valuemax={100}
                          />
                        </div>
                      )}
                    </div>
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

export default Banner;
