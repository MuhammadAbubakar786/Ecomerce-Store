import {
  ADD_BUSINESS_CATEGORY,
  DELETE_BUSINESS_CATEGORY,
  GET_BUSINESS_CATEGORY,
  EDIT_BUSINESS_CATEGORY,
} from "../Constants";
function BusinessCategoryReducer(businessCategoryState = [], action) {
  switch (action.type) {
    case GET_BUSINESS_CATEGORY:
      return action.payload;
    case ADD_BUSINESS_CATEGORY:
      return [...businessCategoryState, action.payload];
    case DELETE_BUSINESS_CATEGORY:
      return businessCategoryState.filter(
        (category) => category.id !== action.payload.toString()
      );
    case EDIT_BUSINESS_CATEGORY:
      return businessCategoryState.map((category) => {
        if (category.id === action.payload.id) {
          return {
            ...category,
            ...action.payload,
          };
        } else {
          return category;
        }
      });
    default:
      return businessCategoryState;
  }
}

export default BusinessCategoryReducer;
