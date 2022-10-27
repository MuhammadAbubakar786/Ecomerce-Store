import { useQuery } from "react-query";
import { useDispatch } from "react-redux";
import { GetAnnoucements, GetBanner } from "../Api/Annoucement";
import { GET_ANNOUCEMENT, GET_BANNER } from "../Redux/Constants";
export function useAnnoucement() {
  const dispatch = useDispatch();
  return useQuery(["Annoucement"], ({ queryKey }) => GetAnnoucements(), {
    onSuccess: (data) => {
      if (data) {
        dispatch({
          type: GET_ANNOUCEMENT,
          payload: data?.data?.key.$values,
        });
      }
    },
  });
}
export function useBanner() {
  const dispatch = useDispatch();
  return useQuery(["Banner"], ({ queryKey }) => GetBanner(), {
    onSuccess: (data) => {
      if (data) {
        dispatch({
          type: GET_BANNER,
          payload: data?.data?.key.$values,
        });
      }
    },
  });
}
