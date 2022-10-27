import Axios from "../Apiconfig";
export const SignUp = async (singUpUser) => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.post(`Account/RegisterAccount`, singUpUser, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
export const SignIn = async (singInUser) => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.post(`Account/UserSignIn`, singInUser, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
