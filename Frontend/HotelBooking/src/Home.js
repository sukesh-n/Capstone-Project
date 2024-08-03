import '../src/Home.css';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import HotelGroupHome from './Components/HotelGroup/HotelGroupHome';
import HotelBranchHome from './Components/HotelBranch/HotelBranchHome';
import GuestHome from './Components/Guest/GuestHome';
import FullPageBackground from './Style/FullPageBackground';
import HotelLanding from './Components/Start/HotelLanding';
function Home() {
  return (
    <BrowserRouter>
    <FullPageBackground />
      <Routes>
        <Route exact path="/" element={<HotelLanding/>} />
        <Route exact path="/guesthome/*" element={<GuestHome />} />
        <Route exact path="/hotelgroup/*" element={<HotelGroupHome />} />
        <Route path="/hotelbranch/*" element={<HotelBranchHome />} />
        <Route path="*" element={<Navigate to="/" />} />
      </Routes>
    </BrowserRouter>
  );
}
export default Home;
// import DisplayFilteredHotels from "./Components/Guest/DisplayFiteredHotels";




// function Home() {
//     return (
//       <DisplayFilteredHotels />
//     );
// }
// export default Home;