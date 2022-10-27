import * as Yup from "yup";
export const InitialValues = {
  firstname: "",
  lastname: "",
  username: "",
  email: "",
  password: "",
  repeatPassword: "",
};
export const validationSchema = Yup.object().shape({
  username: Yup.string().required("Username is Required").label("Username"),
  email: Yup.string()
    .email("Please enter a valid email")
    .required("Eamil is Required")
    .label("Email"),
  password: Yup.string()
    .required("Please enter a password")
    .min(8, "Password too short")

    .test(
      "isValidPass",
      "Must contain at least one lowercase one uppercase one special and a number character",
      (value, context) => {
        const hasUpperCase = /[A-Z]/.test(value);
        const hasLowerCase = /[a-z]/.test(value);
        const hasNumber = /[0-9]/.test(value);
        const hasSymbole = /[!@#%&]/.test(value);
        let validConditions = 0;
        const numberOfMustBeValidConditions = 3;
        const conditions = [hasLowerCase, hasUpperCase, hasNumber, hasSymbole];
        conditions.forEach((condition) =>
          condition ? validConditions++ : null
        );
        if (validConditions >= numberOfMustBeValidConditions) {
          return true;
        }
        return false;
      }
    ),
  repeatPassword: Yup.string()
    .min(6)
    .when("password", {
      is: (val) => (val && val.length > 0 ? true : false),
      then: Yup.string().oneOf(
        [Yup.ref("password")],
        "Both password need to be the same"
      ),
    })
    .required("Confirm Password Required"),
});
