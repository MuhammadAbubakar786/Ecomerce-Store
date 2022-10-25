import {
  ADD_TESTMONIAL,
  DELETE_TESTMONIAL,
  GET_TESTMONIAL,
  EDIT_TESTMONIAL,
} from "../Constants";
function TestmonialReducer(testmonialState = [], action) {
  switch (action.type) {
    case GET_TESTMONIAL:
      return action.payload;
    case ADD_TESTMONIAL:
      return [...testmonialState, action.payload];
    case DELETE_TESTMONIAL:
      return testmonialState.filter(
        (testmonial) => testmonial.id !== action.payload.toString()
      );
    case EDIT_TESTMONIAL:
      return testmonialState.map((testmonial) => {
        if (testmonial.id === action.payload.id) {
          return {
            ...testmonial,
            ...action.payload,
          };
        } else {
          return testmonial;
        }
      });
    default:
      return testmonialState;
  }
}

export default TestmonialReducer;
