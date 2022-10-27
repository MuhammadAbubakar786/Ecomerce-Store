import {
  ADD_ANNOUCEMENT,
  DELETE_ANNOUCEMENT,
  EDIT_ANNOUCEMENT,
  GET_ANNOUCEMENT,
} from "../Constants";
function AnnoucementReducer(AnnoucementState = [], action) {
  switch (action.type) {
    case GET_ANNOUCEMENT:
      return action.payload;
    case ADD_ANNOUCEMENT:
      return [...AnnoucementState, action.payload];
    case DELETE_ANNOUCEMENT:
      return AnnoucementState.filter(
        (item) => item.announcementId !== action.payload.toString()
      );
    case EDIT_ANNOUCEMENT:
      return AnnoucementState.map((item) => {
        if (item.announcementId === action.payload.announcementId) {
          return {
            ...item,
            ...action.payload,
          };
        } else {
          return item;
        }
      });
    default:
      return AnnoucementState;
  }
}

export default AnnoucementReducer;
