import { useEffect } from "react";
import { Route, Routes, useLocation } from "react-router-dom";
import {
  AnnouncementList,
  Announcements,
  Banner,
  BannerList,
  Cart,
  DashBoard,
  Home,
  Login,
  ProductList,
  Register,
} from "./ComponentFile";
import Layout from "./components/Layout";
import RequireAuth from "./components/RequireAuth";
import { useAnnoucement, useBanner } from "./Hooks/useAnnoucement";
const Roles = {
  ADMIN: "3ccae34b-1295-480f-adbf-a5e4e686de30",
  SELLER: "408d95d5-b296-44be-8ddb-84254f50e147",
  CUSTOMER: "9aa11d14-dcda-4de9-8c4d-1d174a54542d",
};

function App() {
  const { status, data, isFetching } = useAnnoucement();
  const { status: BannerStatus } = useBanner();
  return (
    <>
      <ScrollTop />
      <div className="font-main text-text-black App">
        <Routes>
          <Route path="/" element={<Layout />}>
            {/* public routes */}
            <Route path="/" element={<Home />} />
            <Route path="ProductList" element={<ProductList />} />
            <Route path="Cart" element={<Cart />} />
            <Route path="Login" element={<Login />} />
            <Route path="Register" element={<Register />} />
            {/* Protected  Routes */}
            <Route element={<RequireAuth allowedRoles={[Roles.ADMIN]} />}>
              <Route path="Dashboard" element={<DashBoard />} />
              <Route path="Announcements" element={<Announcements />} />
              <Route path="AnnouncementList" element={<AnnouncementList />} />
              <Route path="Banner" element={<BannerList />} />
              <Route path="NewBanner" element={<Banner />} />
            </Route>
            <Route
              element={
                <RequireAuth allowedRoles={[Roles.ADMIN, Roles.SELLER]} />
              }
            ></Route>
          </Route>
        </Routes>
      </div>
    </>
  );
}
export default App;

const ScrollTop = () => {
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);

  return null;
};
