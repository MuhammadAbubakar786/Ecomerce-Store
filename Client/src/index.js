import { configureStore } from "@reduxjs/toolkit";
import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import * as ReactDOMClient from "react-dom/client";
import { QueryClient, QueryClientProvider } from "react-query";
import { ReactQueryDevtools } from "react-query/devtools";
import { Provider } from "react-redux";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { applyMiddleware, compose } from "redux";
import thunk from "redux-thunk";
import App from "./App";
import { AuthProvider } from "./context/AuthProvider";
import "./index.css";
import combineReducers from "./Redux/RootReducer";
const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = configureStore(
  { reducer: combineReducers },
  composeEnhancer(applyMiddleware(thunk))
);
const queryClient = new QueryClient();
const root = ReactDOMClient.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <QueryClientProvider client={queryClient}>
      <Provider store={store}>
        <AuthProvider>
          <ReactQueryDevtools initialIsOpen />
          <Routes>
            <Route path="/*" element={<App />} />
          </Routes>
        </AuthProvider>
      </Provider>
    </QueryClientProvider>
  </BrowserRouter>
);
