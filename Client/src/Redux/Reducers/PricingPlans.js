import {
  ADD_PRICING_PLAN,
  DELETE_PRICING_PLAN,
  GET_PRICING_PLAN,
  EDIT_PRICING_PLAN,
} from "../Constants";
function PricingPlanReducer(userPlanState = [], action) {
  switch (action.type) {
    case GET_PRICING_PLAN:
      return action.payload;
    case ADD_PRICING_PLAN:
      return [...userPlanState, action.payload];
    case DELETE_PRICING_PLAN:
      return userPlanState.filter(
        (plan) => plan.id !== action.payload.toString()
      );
    case EDIT_PRICING_PLAN:
      return userPlanState.map((plan) => {
        if (plan.id === action.payload.id) {
          return {
            ...plan,
            ...action.payload,
          };
        } else {
          return plan;
        }
      });
    default:
      return userPlanState;
  }
}

export default PricingPlanReducer;
