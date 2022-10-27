import { CreateOutlined, Delete } from "@mui/icons-material";
import { Box } from "@mui/system";
import { DataGrid } from "@mui/x-data-grid";
import dateformat from "dateformat";
import * as React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { DeleteBanner } from "../Api/Annoucement";
import useAuth from "../Hooks/useAuth";
import { DELETE_BANNER } from "../Redux/Constants";
import DashBoard from "./DashBoard";
export default function AnnouncementList() {
  const list = useSelector((state) =>
    state?.BannerReducer?.map((e) => {
      e.createdDate = dateformat(e?.createdDate, "dd mmm,yyyy");
      return e;
    })
  );
  const { auth, setAuth } = useAuth();
  const dispatch = useDispatch();
  const columns = [
    { field: "title", headerName: "Title", width: 150 },
    { field: "description", headerName: "Description", width: 400 },
    { field: "createdDate", headerName: "Date", width: 200 },
    {
      field: "bannerImage",
      headerName: "Banner",
      width: 300,
      height: 500,
      renderCell: (params) => {
        return (
          <img
            src={params?.row?.bannerImage}
            alt=""
            width={200}
            style={{ objectFit: "contain", height: 500 }}
          />
        );
      },
    },

    {
      field: "action",
      headerName: "Action",
      sortable: false,
      renderCell: (params) => {
        const onClick = (e) => {
          return console.log(params?.row?.bannerImage);
        };
        const DeleteHandler = (e) => {
          DeleteBanner(params?.id)
            .then((res) => {
              if (res.status === 200) {
                dispatch({ type: DELETE_BANNER, payload: res?.data?.key });
              }
            })
            .catch((error) => console.log("error", error));
        };
        return (
          <>
            <CreateOutlined onClick={onClick} />
            <Delete onClick={DeleteHandler} />
          </>
        );
      },
    },
  ];

  return (
    <>
      <DashBoard />
      <div className="row d-flex justify-content-center m-5">
        <div className="col-md-12">
          <div className="card">
            <h5 className="card-header">Annoucement List</h5>
            <Link to="/NewBanner">
              <button type="button" className="btn btn-primary ms-3 mt-2">
                Add New
              </button>
            </Link>
            <div className="card-body">
              <Box sx={{ height: 500, width: "100%" }}>
                <DataGrid rows={list} columns={columns} rowHeight={300} />
              </Box>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
