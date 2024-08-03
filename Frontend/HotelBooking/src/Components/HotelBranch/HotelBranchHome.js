import BranchNavBar from "./BranchNavBar";
import BranchDashBoard from "./BranchDashBoard";
import { Routes, Route } from "react-router-dom";
import BranchLogin from "./BranchLogin";
import BranchSignUp from "./BranchSignUp";
import AddBranchRoom from "./AddBranchRoom";
import BranchBookings from "./BranchBookings";
import BranchLogout from "./BranchLogout";
import ViewBranchRooms from "./ViewBranchRooms";
import UpdateBranchStatus from "./UpdateBranchStatus";
const HotelBranchHome = () => {
  const token = localStorage.getItem('branch-token');
  if (!token) {
    
    <BranchLogin/>
  }
  var IsBranchLoggedIn = localStorage.getItem('branch-token') !== null
  return (
    <>
      <BranchNavBar/>
      <Routes>
        <Route path="/hotelbranch" element={(IsBranchLoggedIn) ? <BranchDashBoard/> : <BranchLogin/>} />
        <Route path="/branch/update-branch-profile" element={(IsBranchLoggedIn) ? <BranchDashBoard/> : <BranchLogin/>} />
        <Route path="/branch/branch-login" element={(IsBranchLoggedIn) ? <BranchDashBoard/> :<BranchLogin/>} />
        <Route path="/branch/branch-signup" element={(IsBranchLoggedIn) ? <BranchDashBoard/> :<BranchSignUp/>} />
        <Route path="/branch/branch-logout" element={(IsBranchLoggedIn) ? <BranchLogout/> : <BranchLogin/>} />
        <Route path="/branch/add-room" element={(IsBranchLoggedIn) ? <AddBranchRoom/> : <BranchLogin/>} />
        <Route path="/branch/view-rooms" element={(IsBranchLoggedIn) ? <ViewBranchRooms/> : <BranchLogin/>} />
        <Route path="/branch/view-current-bookings" element={(IsBranchLoggedIn) ? <BranchBookings/> : <BranchLogin/>} />
        <Route path="/branch/update-roomstatus" element={(IsBranchLoggedIn) ? <UpdateBranchStatus/> : <BranchLogin/>} />
        <Route path="/" element={(IsBranchLoggedIn) ? <BranchDashBoard/> : <BranchLogin/>} />        
      </Routes>
    </>
    
  );
};
export default HotelBranchHome;