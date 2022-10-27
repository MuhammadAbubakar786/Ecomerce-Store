import TextField from "@mui/material/TextField";
import React from "react";

export default function Index(props) {
  return (
    <TextField
      {...props}
      InputLabelProps={{
        shrink: true,
      }}
    />
  );
}
