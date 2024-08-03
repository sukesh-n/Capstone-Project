import React from 'react';
import { Routes, Route} from 'react-router-dom';
import GuestBrowsingPage from './GuestBrowsingPage';
import GuestNavBar from './GuestNavBar';
import ManageBookings from './ManageBookings'; 
import GuestProfile from './GuestProfile';
import GuestLogin from './GuestLogin';
import GuestFlier from './GuestFlier';
import GuestSignUp from './GuestSignUp';

const GuestHome = () => {
  const isLoggedIn = localStorage.getItem('guest-token') !== null;

  return (
    <>
      <GuestNavBar />
      <Routes>
        <Route path="/guesthome" element={<GuestFlier />} />
        <Route path="/guest/book" element={<GuestBrowsingPage />} />
        {/* <Route path="/guest/book" element={isLoggedIn ? <GuestBrowsingPage /> : <GuestLogin />} /> */}
        <Route path="/guest/manage-bookings" element={isLoggedIn ? <ManageBookings /> : <GuestLogin />} />
        <Route path="/guest/guest-profile" element={isLoggedIn ? <GuestProfile /> : <GuestLogin />} />
        <Route path="/guest/guest-login" element={<GuestLogin />} />
        <Route path="/guest/signup" element={<GuestSignUp />} />
        <Route path="/" element={<GuestFlier />} />
      </Routes>
    </>
  );
};

export default GuestHome;