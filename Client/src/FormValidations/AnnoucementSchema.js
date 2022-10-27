import * as Yup from "yup";
export const InitialValues = {
  announcementId: 0,
  description: "",
  fromDate: new Date(),
  toDate: new Date(),
  userId: "",
};
export const validationSchema = Yup.object().shape({
  description: Yup.string()
    .required("Annoucement is Required")
    .label("Annoucement"),
  fromDate: Yup.string().required("Please enter fromDate").label("FromDate"),
  toDate: Yup.string().required("Please enter toDate").label("ToDate"),
});
