import { useQuery } from "react-query";
import { GetPricingPlans } from "../Api/PricingPlans";
import { useDispatch } from "react-redux";
import { GET_PRICING_PLAN } from "../Redux/Constants";
export function usePricingPlan() {
  const dispatch = useDispatch();
  return useQuery(["AllPackages"], ({ queryKey }) => GetPricingPlans(), {
    onSuccess: (data) => {
      if (data) {
        dispatch({
          type: GET_PRICING_PLAN,
          payload: data?.data?.key.$values,
        });
      }
    },
  });
}
