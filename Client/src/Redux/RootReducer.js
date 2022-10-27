import { combineReducers } from "redux";
import AnnoucementReducer from "./Reducers/Annoucements";
import BannerReducer from "./Reducers/Banners";
import PricingPlanReducer from "./Reducers/PricingPlans";
import TestmonialReducer from "./Reducers/Testmonial";
export default combineReducers({
  PricingPlanReducer,
  TestmonialReducer,
  AnnoucementReducer,
  BannerReducer,
});
