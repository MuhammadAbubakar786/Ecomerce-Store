import Axios from "../Apiconfig";
export const GetBusinessCategories = async () => {
  return await Axios.get(`Account/GetBusinessCategory`);
};
