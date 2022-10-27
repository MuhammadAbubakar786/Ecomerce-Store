import { useQuery } from "react-query";
import { useDispatch } from "react-redux";
import { GET_BUSINESS_CATEGORY } from "../Redux/Constants";
import { GetBusinessCategories } from "../Api/BusinessCategories";
export function useBusinessCategories() {
  const dispatch = useDispatch();
  return useQuery(
    ["GetBusinessCategories"],
    ({ queryKey }) => GetBusinessCategories(),
    {
      onSuccess: (data) => {
        // const compareStrings = (a, b) => {
        //   //do something i.e. a.toLowerCase(); b.toLowerCase()
        //   return a < b ? -1 : a > b ? 1 : 0;
        // };
        // let x = data?.data?.key.$values.sort((a, b) => compareStrings(a, b));
        if (data) {
          dispatch({
            type: GET_BUSINESS_CATEGORY,
            payload: data?.data?.key.$values,
          });
        }
      },
    }
  );
}
