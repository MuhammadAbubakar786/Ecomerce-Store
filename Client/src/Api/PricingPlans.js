import Axios from "../Apiconfig";
export const GetPricingPlans = async () => {
  // document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.get(`Packages/GetPackages`, null);
};
