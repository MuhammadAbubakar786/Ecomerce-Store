import { combineReducers } from "redux";
import PricingPlanReducer from "./Reducers/PricingPlans";
import TestmonialReducer from "./Reducers/Testmonial";
import BusinessCategoryReducer from "./Reducers/BusinessCategories";
export default combineReducers({
  PricingPlanReducer,
  TestmonialReducer,
  BusinessCategoryReducer,
});
