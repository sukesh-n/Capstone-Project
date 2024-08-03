import React, { useEffect, useState } from 'react';
import { Button, Card, CardActions, CardContent, Typography, Container, Grid, Chip, Menu, MenuItem, IconButton } from '@mui/material';
import { CircularProgress } from '@mui/material';
import { Hotel as HotelIcon, Star as StarIcon, CheckCircle as CheckCircleIcon, ExpandMore as ExpandMoreIcon } from '@mui/icons-material';
import { green, red } from '@mui/material/colors';

// Mock data structure (replace with API fetch)
const mockHotels = [
  {
    HotelId: 1,
    HotelBranchName: "Grand Plaza",
    IsAvailable: true,
    StartDate: "2024-08-01T00:00:00",
    EndDate: "2024-08-15T00:00:00",
    HotelType: "Luxury",
    RoomAmenities: {
      HasWifi: true,
      HasTelevision: true,
      HasAirConditioner: true,
      IsWithBreakfast: true,
      // Add other amenities as needed
    },
    HotelDemographics: {
      HotelAddressLine1: "123 Main St",
      HotelCity: "Metropolis",
      HotelState: "NY",
      HotelCountry: "USA",
      // Add other demographics as needed
    }
  },
  // Add more mock data or fetch from API
];

const DisplayFilteredHotels = () => {
  const [hotels, setHotels] = useState([]);
  const [loading, setLoading] = useState(true);
  const [anchorEl, setAnchorEl] = useState(null);
  const [selectedHotel, setSelectedHotel] = useState(null);

  useEffect(() => {
    const fetchHotels = async () => {
      try {
        // Replace with actual API call
        // const response = await fetch('YOUR_API_ENDPOINT');
        // const data = await response.json();
        const data = mockHotels; // Use mock data for now
        setHotels(data);
      } catch (error) {
        console.error('Error fetching hotels:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchHotels();
  }, []);

  if (loading) {
    return <CircularProgress />;
  }

  const handleClick = (event, hotel) => {
    setSelectedHotel(hotel);
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
    setSelectedHotel(null);
  };

  const open = Boolean(anchorEl);
console.log(open);
  return (
    <Container>
      <Grid container spacing={3}>
        {hotels.map((hotel) => (
          <Grid item xs={12} sm={6} md={4} key={hotel.HotelId}>
            <Card 
              variant="outlined"
              sx={{
                background: hotel.IsAvailable ? green[50] : red[50], // Background color based on availability
                borderColor: hotel.IsAvailable ? green[300] : red[300],
                boxShadow: 3,
                transition: '0.3s',
                '&:hover': {
                  boxShadow: 6,
                },
              }}
            >
              <CardContent>
                <Typography variant="h6" component="div" sx={{ mb: 1 }}>
                  {hotel.HotelBranchName}
                </Typography>
                <Chip
                  label={hotel.HotelType}
                  icon={<HotelIcon />}
                  color={hotel.HotelType === 'Luxury' ? 'primary' : 'secondary'}
                  sx={{ mb: 1 }}
                />
                <Typography color="textSecondary">
                  <StarIcon sx={{ verticalAlign: 'middle', mr: 0.5 }} />
                  {hotel.IsAvailable ? 'Available' : 'Not Available'}
                </Typography>
                <Typography color="textSecondary">
                  <CheckCircleIcon sx={{ verticalAlign: 'middle', mr: 0.5 }} />
                  {new Date(hotel.StartDate).toLocaleDateString()} - {new Date(hotel.EndDate).toLocaleDateString()}
                </Typography>
              </CardContent>
              <CardActions>
                <Button 
                  size="small" 
                  color="primary" 
                  variant="contained" 
                  onClick={() => handleViewHotel(hotel.HotelId)}
                >
                  View Hotel
                </Button>
                <Button 
                  size="small" 
                  color="secondary" 
                  variant="contained" 
                  onClick={() => handleBookHotel(hotel.HotelId)}
                >
                  Book Hotel
                </Button>
                <IconButton 
                  size="small" 
                  onClick={(event) => handleClick(event, hotel)}
                >
                  <ExpandMoreIcon />
                </IconButton>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>

      {/* Dropdown Menu */}
      <Menu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleClose}
      >
        {selectedHotel && (
          <>
            <MenuItem disabled>
              <Typography variant="h6">{selectedHotel.HotelBranchName} - Room Amenities</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Wifi: {selectedHotel.RoomAmenities.HasWifi ? 'Yes' : 'No'}</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Television: {selectedHotel.RoomAmenities.HasTelevision ? 'Yes' : 'No'}</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Air Conditioner: {selectedHotel.RoomAmenities.HasAirConditioner ? 'Yes' : 'No'}</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Breakfast: {selectedHotel.RoomAmenities.IsWithBreakfast ? 'Included' : 'Not Included'}</Typography>
            </MenuItem>
            <MenuItem disabled>
              <Typography variant="h6">{selectedHotel.HotelBranchName} - Demographics</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Address: {selectedHotel.HotelDemographics.HotelAddressLine1}, {selectedHotel.HotelDemographics.HotelCity}, {selectedHotel.HotelDemographics.HotelState}, {selectedHotel.HotelDemographics.HotelCountry}</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Zip Code: {selectedHotel.HotelDemographics.HotelZipCode}</Typography>
            </MenuItem>
            <MenuItem>
              <Typography>Nearest Airport: {selectedHotel.HotelDemographics.NearestAirport} (Distance: {selectedHotel.HotelDemographics.DistanceFromAirport} km)</Typography>
            </MenuItem>
          </>
        )}
      </Menu>
    </Container>
  );
};

// Dummy functions for button clicks
const handleViewHotel = (hotelId) => {
  console.log('View hotel:', hotelId);
  // Implement navigation to hotel details page
};

const handleBookHotel = (hotelId) => {
  console.log('Book hotel:', hotelId);
  // Implement booking functionality
};

export default DisplayFilteredHotels;
