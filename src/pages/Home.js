import React from "react";
import Annoucement from "../components/Annoucement";
import { Categories } from "../components/Categories";
import Footer from "../components/Footer";
import { Navbar } from "../components/Navbar";
import { Newsletter } from "../components/Newsletter";
import Products from "../components/Products";
import Sidebar from "../components/Sidebar";

export const Home = () => {
  return (
    <div>
      <Annoucement />
      <Navbar />
      <Sidebar />
      <Categories />
      <Products />
      <Newsletter />
      <Footer />
    </div>
  );
};
