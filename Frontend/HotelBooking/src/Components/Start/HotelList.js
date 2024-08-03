import React, { useState } from 'react';
import {
  TextField,
  Button,
  Grid,
  Box,
  IconButton,
  InputAdornment,
  InputLabel,
  Select,
  MenuItem,
  FormControl,
  createTheme,
  ThemeProvider,
  Typography
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import statesData from '../../Assets/data/states-data.json'; // Ensure this import is correct

const HotelList = () => {
  const states = statesData.states;

  const [adults, setAdults] = useState(1);
  const [children, setChildren] = useState(0);
  const [rooms, setRooms] = useState(1);
  const [selectedState, setSelectedState] = useState('');
  const [selectedDistrict, setSelectedDistrict] = useState('');
  const [checkInDate, setCheckInDate] = useState('');
  const [checkOutDate, setCheckOutDate] = useState('');

  // State for error handling
  const [errors, setErrors] = useState({
    checkInDate: '',
    checkOutDate: '',
    adults: '',
    children: '',
    rooms: '',
    state: '',
    district: ''
  });

  const handleAdultsChange = (operation) => {
    const newAdults = Math.max(adults + (operation === 'increment' ? 1 : -1), 1);
    setAdults(newAdults);
    validateField('adults', newAdults); 
  };

  const handleChildrenChange = (operation) => {
    const newChildren = Math.max(children + (operation === 'increment' ? 1 : -1), 0);
    setChildren(newChildren);
    validateField('children', newChildren); 
  };

  const handleRoomsChange = (operation) => {
    const newRooms = Math.max(rooms + (operation === 'increment' ? 1 : -1), 1);
    setRooms(newRooms);
    validateField('rooms', newRooms);
  };

  const theme = createTheme({
    palette: {
      primary: {
        main: '#f44336',
      },
      secondary: {
        main: '#00ae20',
        light: '#ff7961',
      },
    },
  });

  const handleStateChange = (event) => {
    const newState = event.target.value;
    setSelectedState(newState);
    setSelectedDistrict('');
    validateField('state', newState); 
  };

  const handleDistrictChange = (event) => {
    const newDistrict = event.target.value;
    setSelectedDistrict(newDistrict);
    validateField('district', newDistrict);
  };

  const getDistricts = () => {
    const state = states.find(s => s.state === selectedState);
    return state ? state.districts : [];
  };

  const validateField = (fieldName, value) => {
    const currentDate = new Date().toISOString().split('T')[0];
    let newError = '';

    switch (fieldName) {
      case 'checkInDate':
        if (!value) {
          newError = 'Check-in date is required';
        } else if (value < currentDate) {
          newError = 'Check-in date cannot be in the past';
        }
        break;
      case 'checkOutDate':
        if (!value) {
          newError = 'Check-out date is required';
        } else if (checkOutDate < checkInDate) {
          newError = 'Check-out date cannot be before check-in date';
        } else if (value < currentDate) {
          newError = 'Check-out date cannot be in the past';
        }
        break;
      case 'adults':
        if (value < 1) {
          newError = 'Number of adults is required';
        }
        if(adults < rooms && children === 0) {
            newError = 'Number of adults should be greater than or equal to number of rooms';
        }
        break;
      case 'rooms':
        if (value < 1) {
          newError = 'Number of rooms is required';
        }
        break;
      case 'state':
        if (!value) {
          newError = 'State is required';
        }
        break;
      case 'district':
        if (!value) {
          newError = 'District is required';
        }
        break;
      default:
        break;
    }

    setErrors(prevErrors => ({ ...prevErrors, [fieldName]: newError }));
  };


  const handleChange = (event, fieldName) => {
    const value = event.target.value;
    switch (fieldName) {
      case 'checkInDate':
        setCheckInDate(value);
        break;
      case 'checkOutDate':
        setCheckOutDate(value);
        break;
      default:
        break;
    }
    validateField(fieldName, value);
  };

  const handleSearch = () => {
    validateField('checkInDate', checkInDate);
    validateField('checkOutDate', checkOutDate);
    validateField('adults', adults);
    validateField('rooms', rooms);
    validateField('state', selectedState);
    validateField('district', selectedDistrict);

    if (Object.values(errors).some(error => error !== '')) {
      return;
    }

    const searchParams = {
      checkIn: checkInDate,
      checkOut: checkOutDate,
      adults,
      children,
      rooms,
      state: selectedState,
      district: selectedDistrict
    };
    console.log(JSON.stringify(searchParams, null, 2));
  };

  return (
    <Box p={2} bgcolor="background.paper" borderRadius={1} boxShadow={3}>
      <Typography variant="h5" gutterBottom align="center">
        Search Hotels
      </Typography>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            label="Check in"
            type="date"
            id="checkin-input"
            value={checkInDate}
            onChange={(e) => handleChange(e, 'checkInDate')} 
            fullWidth
            InputLabelProps={{ shrink: true }}
            error={Boolean(errors.checkInDate)}
            helperText={errors.checkInDate}
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            label="Check out"
            type="date"
            id="checkout-input"
            value={checkOutDate}
            onChange={(e) => handleChange(e, 'checkOutDate')} 
            fullWidth
            InputLabelProps={{ shrink: true }}
            error={Boolean(errors.checkOutDate)}
            helperText={errors.checkOutDate}
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            label="No of Adults"
            id="adults-input"
            value={adults}
            onChange={(e) => {
              const value = parseInt(e.target.value, 10);
              if (!isNaN(value)) {
                setAdults(Math.max(value, 1));
              }
            }}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton onClick={() => handleAdultsChange('decrement')}>
                    <RemoveIcon />
                  </IconButton>
                  <IconButton onClick={() => handleAdultsChange('increment')}>
                    <AddIcon />
                  </IconButton>
                </InputAdornment>
              ),
            }}
            inputProps={{ 'aria-label': 'No of Adults', min: 1, type: 'number' }}
            type="number"
            fullWidth
            error={Boolean(errors.adults)}
            helperText={errors.adults}
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            label="No of Children"
            id="children-input"
            value={children}
            onChange={(e) => {
              const value = parseInt(e.target.value, 10);
              if (!isNaN(value)) {
                setChildren(Math.max(value, 0)); 
              }
            }}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton onClick={() => handleChildrenChange('decrement')}>
                    <RemoveIcon />
                  </IconButton>
                  <IconButton onClick={() => handleChildrenChange('increment')}>
                    <AddIcon />
                  </IconButton>
                </InputAdornment>
              ),
            }}
            inputProps={{ 'aria-label': 'No of Children', min: 0, type: 'number' }}
            type="number"
            fullWidth
            error={Boolean(errors.children)}
            helperText={errors.children}
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <TextField
            label="No of Rooms"
            id="rooms-input"
            value={rooms}
            onChange={(e) => {
              const value = parseInt(e.target.value, 10);
              if (!isNaN(value)) {
                setRooms(Math.max(value, 1));
              }
            }}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton onClick={() => handleRoomsChange('decrement')}>
                    <RemoveIcon />
                  </IconButton>
                  <IconButton onClick={() => handleRoomsChange('increment')}>
                    <AddIcon />
                  </IconButton>
                </InputAdornment>
              ),
            }}
            inputProps={{ 'aria-label': 'No of Rooms', min: 1, type: 'number' }}
            type="number"
            fullWidth
            error={Boolean(errors.rooms)}
            helperText={errors.rooms}
          />
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <FormControl fullWidth error={Boolean(errors.state)}>
            <InputLabel>State</InputLabel>
            <Select
              value={selectedState}
              onChange={handleStateChange}
              label="State"
            >
              {states.map((state) => (
                <MenuItem key={state.state} value={state.state}>
                  {state.state}
                </MenuItem>
              ))}
            </Select>
            {errors.state && <Typography color="error">{errors.state}</Typography>}
          </FormControl>
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <FormControl fullWidth error={Boolean(errors.district)}>
            <InputLabel>District</InputLabel>
            <Select
              value={selectedDistrict}
              onChange={handleDistrictChange}
              label="District"
              disabled={!selectedState} 
            >
              {getDistricts().map((district) => (
                <MenuItem key={district} value={district}>
                  {district}
                </MenuItem>
              ))}
            </Select>
            {errors.district && <Typography color="error">{errors.district}</Typography>}
          </FormControl>
        </Grid>
        <Grid item xs={12}>
          <ThemeProvider theme={theme}>
            <Button variant="contained" color="secondary" fullWidth onClick={handleSearch}>
              Search Now
            </Button>
          </ThemeProvider>
        </Grid>
      </Grid>
    </Box>
  );
};

export default HotelList;