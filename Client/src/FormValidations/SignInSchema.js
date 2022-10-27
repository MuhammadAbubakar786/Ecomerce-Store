import * as Yup from "yup";
export const InitialValues = {
  email: "",
  password: "",
  repeatPassword: "",
};
export const validationSchema = Yup.object().shape({
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
});
