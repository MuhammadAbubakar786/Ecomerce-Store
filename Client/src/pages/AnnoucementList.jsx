import { CreateOutlined, Delete, ToggleOff } from "@mui/icons-material";
import { Box } from "@mui/system";
import { DataGrid } from "@mui/x-data-grid";
import dateformat from "dateformat";
import * as React from "react";
import { useDispatch, useSelector } from "react-redux";
import { ActiveInActiveAnnoucement } from "../Api/Annoucement";
import useAuth from "../Hooks/useAuth";
import { EDIT_ANNOUCEMENT } from "../Redux/Constants";
import DashBoard from "./DashBoard";
export default function AnnouncementList() {
  const list = useSelector((state) =>
    state?.AnnoucementReducer.map((e) => {
      e.createdDate = dateformat(e?.createdDate, "dd mmm,yyyy");
      e.fromDate = dateformat(e?.fromDate, "dd mmm,yyyy");
      e.toDate = dateformat(e?.toDate, "dd mmm,yyyy");

      return { ...e, id: e.announcementId };
    })
  );
  const { auth, setAuth } = useAuth();
  const dispatch = useDispatch();
  const columns = [
    { field: "description", headerName: "Annoucement", width: 500 },
    { field: "fromDate", headerName: "From Date", width: 130 },
    { field: "toDate", headerName: "To Date", width: 130 },
    { field: "active", headerName: "Active", width: 130 },
    {
      field: "action",
      headerName: "Action",
      sortable: false,
      renderCell: (params) => {
        const onClick = (e) => {};
        const ActiveHandler = (e) => {
          ActiveInActiveAnnoucement(params?.id, auth?.user?.id)
            .then((res) => {
              if (res.status === 200) {
                dispatch({
                  type: EDIT_ANNOUCEMENT,
                  payload: res?.data?.key,
                });
              }
            })
            .catch((error) => {
              console.log("esdror", error);
            });
        };

        return (
          <>
            <CreateOutlined onClick={onClick} />
            <Delete onClick={onClick} />
            <ToggleOff onClick={ActiveHandler} />
          </>
        );
      },
    },
  ];

  const rows = [
    {
      id: 1,
      description: "Snow",
      fromDate: "Jon",
      toDate: "john",
      active: false,
    },
    {
      id: 2,
      description: "Snow",
      fromDate: "Jon",
      toDate: "john",
      active: false,
    },
    {
      id: 3,
      description: "Snow",
      fromDate: "Jon",
      toDate: "john",
      active: false,
    },
    {
      id: 4,
      description: "Snow",
      fromDate: "Jon",
      toDate: "john",
      active: false,
    },
    {
      id: 5,
      description: "Snoe",
      fromDate: "Jon",
      toDate: "john",
      active: false,
    },
  ];
  return (
    <>
      <DashBoard />
      <div className="row d-flex justify-content-center m-5">
        <div className="col-md-8">
          <div className="card">
            <h5 className="card-header">Annoucement List</h5>
            <div className="card-body">
              <Box sx={{ height: 400, width: "100%" }}>
                <DataGrid rows={list} columns={columns} />
              </Box>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
