import { useQuery } from "react-query";
import { GetTestmonial } from "../Api/Testmonial";
import { useDispatch } from "react-redux";
import { GET_TESTMONIAL } from "../Redux/Constants";
export function useTestmonial() {
  const dispatch = useDispatch();
  return useQuery(["Testmonials"], ({ queryKey }) => GetTestmonial(), {
    onSuccess: (data) => {
      if (data) {
        dispatch({
          type: GET_TESTMONIAL,
          payload: data?.data?.key.$values,
        });
      }
    },
  });
}
