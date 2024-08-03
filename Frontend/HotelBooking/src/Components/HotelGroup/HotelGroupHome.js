import HotelGroupLogin from './HotelGroupLogin';
import HotelGroupNavBar from './HotelGroupNavBar';
import HotelGroupSignUp from './HotelGroupSignUp';
import HotelBranchAccountManagement from './HotelBranchAccountManagement';
import { Routes, Route } from 'react-router-dom';
import AddBranch from './AddBranch';

const HotelGroupHome = () => {
  const isGroupLoggedIn = localStorage.getItem('group-token') !== null;
  return (
    <>
      <HotelGroupNavBar />
      <Routes>
        <Route path="/hotelgroup" element={isGroupLoggedIn ? <HotelBranchAccountManagement /> : <HotelGroupLogin />} />
        <Route path="/group/group-profile" element={isGroupLoggedIn ? <HotelBranchAccountManagement /> : <HotelGroupLogin />} />
        <Route path="/group/group-login" element={<HotelGroupLogin />} />
        <Route path="/group/group-signup" element={<HotelGroupSignUp />} />
        <Route path="/group/add-branch" element={isGroupLoggedIn ? <AddBranch/> : <HotelGroupLogin />} />
        <Route path="/"element={isGroupLoggedIn ? <HotelBranchAccountManagement /> : <HotelGroupLogin />}  />
      </Routes>
    </>
  );
};
export default HotelGroupHome;