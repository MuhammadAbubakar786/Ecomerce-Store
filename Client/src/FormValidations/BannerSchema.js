import * as Yup from "yup";
export const InitialValues = {
  id: 0,
  bannerImage: "",
  title: "",
  description: "",
  userId: "",
};
export const validationSchema = Yup.object().shape({
  description: Yup.string()
    .required("Description is Required")
    .test("len", "Must be exactly 50 characters", (val) => val?.length <= 50)
    .label("Description"),
  title: Yup.string()
    .required("Please enter titlr")
    .test("len", "Must be exactly 25 characters", (val) => val?.length <= 25)
    .label("FromDate"),
});
