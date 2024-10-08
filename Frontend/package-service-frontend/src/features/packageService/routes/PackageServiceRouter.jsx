import { Navigate, Route, Routes } from "react-router-dom";
import { NavBar, Footer } from "../components";
import { CreateOrder, CreateClient, Login, Portal, HomePage, ListAll, FindOrdersId, FindOrdersBySenderName } from "../pages";

export const PackageServiceRouter = () => {
  return (
    <div className="overflow-x-hidden bg-gray-100 w-screen h-screen bg-hero-pattern bg-no-repeat bg-cover">
      <NavBar />
      <div className="px-6 py-8">
        <div className="container justify-between mx-auto">
          <Routes>
            <Route path='/login' element={<Login />} />
            <Route path='/home' element={<HomePage />} />
            <Route path='/createorder' element={<CreateOrder />} />
            <Route path='/createclient' element={<CreateClient />} />
            <Route path='/portal' element={<Portal />} />
            <Route path='/listall' element={<ListAll />} />
            <Route path="/findorders/:orderId" element={<FindOrdersId />} />
            <Route path="/findnames/:senderName" element={<FindOrdersBySenderName />} />
            <Route path='/*' element={<Navigate to={"/home"} />} />
          </Routes>
        </div>
      </div>
      <Footer />
    </div>
  );
};
