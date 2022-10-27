import {
  ADD_BANNER,
  DELETE_BANNER,
  EDIT_BANNER,
  GET_BANNER,
} from "../Constants";
function BannerReducer(bannerState = [], action) {
  console.log("bannerState", bannerState);
  switch (action.type) {
    case GET_BANNER:
      return action.payload;
    case ADD_BANNER:
      return [...bannerState, action.payload];
    case DELETE_BANNER:
      return bannerState?.filter(
        (banner) => banner.id.toString() !== action.payload.toString()
      );
    case EDIT_BANNER:
      return bannerState?.map((banner) => {
        if (banner.id === action.payload.id) {
          return {
            ...banner,
            ...action.payload,
          };
        } else {
          return banner;
        }
      });
    default:
      return bannerState;
  }
}

export default BannerReducer;
