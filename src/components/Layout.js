import { Outlet } from "react-router-dom";
import { Announcement, Footer, Navbar } from "../ComponentFile";

const Layout = () => {
  return (
    <main className="App">
      <Announcement />
      <Navbar />
      <Outlet />
      <Footer />
    </main>
  );
};

export default Layout;
