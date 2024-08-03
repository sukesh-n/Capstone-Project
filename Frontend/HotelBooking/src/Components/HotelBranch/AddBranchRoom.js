import React, { useEffect, useState } from 'react';
import {
  Button,
  TextField,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  FormControlLabel,
  Checkbox,
  Box,
  Typography,
  Grid
} from '@mui/material';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper
  } from '@mui/material';
import { useForm, Controller } from 'react-hook-form';
import * as yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import { jwt_decode } from '../HotelGroup/GuestToken'; // Ensure you have jwt-decode installed

// Define validation schema
const schema = yup.object().shape({
  hotelBranchId: yup.number().required('Hotel Branch ID is required'),
  roomType: yup.object().shape({
    roomTypeName: yup.string().required('Room Type Name is required'),
    roomTypeDescription: yup.string().required('Room Type Description is required'),
    numberOfRooms: yup.number().positive('Number of rooms must be positive').required('Number of Rooms is required'),
    roomPrice: yup.number().positive('Room price must be positive').required('Room Price is required'),
    numberOfAdults: yup.number().positive('Number of adults must be positive').required('Number of Adults is required'),
    numberOfBed: yup.number().positive('Number of beds must be positive').required('Number of Beds is required'),
  }).required(),
  roomAmenities: yup.object().shape({
    roomTypeId: yup.number().required('Room Type ID is required'),
    isOnGroundFloor: yup.boolean().required(),
    hasWifi: yup.boolean().required(),
    hasTelevision: yup.boolean().required(),
    hasAirConditioner: yup.boolean().required(),
    hasRefrigerator: yup.boolean().required(),
    hasTelephone: yup.boolean().required(),
    hasAttachedBathroom: yup.boolean().required(),
    hasRoomService: yup.boolean().required(),
    hasLaundryService: yup.boolean().required(),
    hasDoorStepDeliveryService: yup.boolean().required(),
    isWithBreakfast: yup.boolean().required(),
    isWindowAvailable: yup.boolean().required(),
    isBalconyAvailable: yup.boolean().required(),
    isBeachViewAvailable: yup.boolean().required(),
  }).required()
});

const AddBranchRoom = () => {
  const token = localStorage.getItem('branch-token');
  const decoded = jwt_decode(token);
  const BranchId = decoded.hotelBranchId;
  const [roomTypes, setRoomTypes] = useState([]);
  const [showForm, setShowForm] = useState(true);
  const [submittedData, setSubmittedData] = useState(null);
  const { control, handleSubmit, formState: { errors }, setValue } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      hotelBranchId: BranchId,
      roomType: {
        roomTypeName: '', 
        roomTypeDescription: '',
        numberOfRooms: 1, 
        roomPrice: 1, 
        numberOfAdults: 1, 
        numberOfBed: 1, 
      },
      roomAmenities: {
        roomTypeId: 0, 
        isOnGroundFloor: false,
        hasWifi: false,
        hasTelevision: false,
        hasAirConditioner: false,
        hasRefrigerator: false,
        hasTelephone: false,
        hasAttachedBathroom: false,
        hasRoomService: false,
        hasLaundryService: false,
        hasDoorStepDeliveryService: false,
        isWithBreakfast: false,
        isWindowAvailable: false,
        isBalconyAvailable: false,
        isBeachViewAvailable: false,
      }
    }
  });

  useEffect(() => {
    const fetchRoomTypes = async () => {
      try {
        const response = await fetch('https://localhost:7233/api/EnumRoomTypes');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setRoomTypes(data);

        if (data.length > 0) {
          setValue('roomAmenities.roomTypeId', data[0].id);
        }
      } catch (error) {
        console.error('Error fetching room types:', error);
      }
    };

    fetchRoomTypes();
  }, [setValue]);

  const onSubmit = async (data) => {
    try {
      const selectedRoomType = roomTypes.find(
        (roomType) => roomType.name === data.roomType.roomTypeName
      );

      if (!selectedRoomType) {
        throw new Error('Selected room type not found!');
      }

      const dataToSend = {
        hotelBranchId: data.hotelBranchId,
        roomType: {
          roomTypeId: 0,
          hotelBranchId: data.hotelBranchId,
          roomTypeName: selectedRoomType.id,
          roomTypeDescription: data.roomType.roomTypeDescription,
          numberOfRooms: data.roomType.numberOfRooms,
          roomPrice: data.roomType.roomPrice,
          numberOfAdults: data.roomType.numberOfAdults,
          numberOfBed: data.roomType.numberOfBed,
          hotelBranch: { 
            hotelBranchId: 0, 
            hotelGroupId: 0,
            hotelGroup: {
              hotelGroupId: 0,
              hotelGroupName: 'string',
              hotelGroupManagerName: 'string',
              hotelGroupEmail: 'string',
              hotelGroupPhone: 'string',
            },
            hotelBranchName: 'string',
            hotelType: 0, 
            hotelBranchManager: 'string',
            hotelBranchEmail: 'string',
            hotelBranchPhone: 'string',
          },
        },
        roomAmenities: {
          hotelBranchId: data.hotelBranchId,
          roomTypeId: selectedRoomType.id,
          isOnGroundFloor: data.roomAmenities.isOnGroundFloor,
          hasWifi: data.roomAmenities.hasWifi,
          hasTelevision: data.roomAmenities.hasTelevision,
          hasAirConditioner: data.roomAmenities.hasAirConditioner,
          hasRefrigerator: data.roomAmenities.hasRefrigerator,
          hasTelephone: data.roomAmenities.hasTelephone,
          hasAttachedBathroom: data.roomAmenities.hasAttachedBathroom,
          hasRoomService: data.roomAmenities.hasRoomService,
          hasLaundryService: data.roomAmenities.hasLaundryService,
          hasDoorStepDeliveryService: data.roomAmenities.hasDoorStepDeliveryService,
          isWithBreakfast: data.roomAmenities.isWithBreakfast,
          isWindowAvailable: data.roomAmenities.isWindowAvailable,
          isBalconyAvailable: data.roomAmenities.isBalconyAvailable,
          isBeachViewAvailable: data.roomAmenities.isBeachViewAvailable,
          hotel: { 
            hotelBranchId: 0, 
            hotelGroupId: 0, 
            hotelGroup: {
              hotelGroupId: 0,
              hotelGroupName: 'string',
              hotelGroupManagerName: 'string',
              hotelGroupEmail: 'string',
              hotelGroupPhone: 'string',
            },
            hotelBranchName: 'string',
            hotelType: 0, 
            hotelBranchManager: 'string',
            hotelBranchEmail: 'string',
            hotelBranchPhone: 'string',
          },
          roomType: {
            roomTypeId: 0, 
            hotelBranchId: data.hotelBranchId,
            roomTypeName: selectedRoomType.id, 
            roomTypeDescription: 'string',
            numberOfRooms: 0,
            roomPrice: 0,
            numberOfAdults: 0,
            numberOfBed: 0,
            hotelBranch: {
              hotelBranchId: 0, 
              hotelGroupId: 0, 
              hotelGroup: {
                hotelGroupId: 0,
                hotelGroupName: 'string',
                hotelGroupManagerName: 'string',
                hotelGroupEmail: 'string',
                hotelGroupPhone: 'string',
              },
              hotelBranchName: 'string',
              hotelType: 0, 
              hotelBranchManager: 'string',
              hotelBranchEmail: 'string',
              hotelBranchPhone: 'string',
            },
          },
        },
      };


      console.log('Data to Send:', dataToSend);

      const response = await fetch('https://localhost:7233/api/HotelManagement/UpdateHotelBranchRooms', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
          // Add authorization headers if required by your API
        },
        body: JSON.stringify(dataToSend)
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const result = await response.json();
      console.log('Success:', result);
      setSubmittedData(result);
      setShowForm(false);
      // Handle success, e.g., show a success message or redirect
    } catch (error) {
      console.error('Error:', error);
      // Handle error, e.g., show an error message
    }
  };

  return (
    <Box p={3}>
      {showForm ? (
        // Form JSX
        <div>
                <Box p={3}>
            <Typography variant="h4" gutterBottom>
                Add Branch Room
            </Typography>
        
            <form onSubmit={handleSubmit(onSubmit)}>
                <Controller
                name="hotelBranchId"
                control={control}
                render={({ field }) => (
                    <TextField
                    {...field}
                    label="Hotel Branch ID"
                    type="number"
                    fullWidth
                    margin="normal"
                    helperText={errors.hotelBranchId?.message}
                    InputProps={{ readOnly: true }} 
                    error={!!errors.hotelBranchId}
                    />
                )}
                />
        
                <Typography variant="h6" gutterBottom>
                Room Type
                </Typography>
        
                <Grid container spacing={2}>
                <Grid item xs={12} md={6}>
                    {roomTypes.length > 0 ? (
                    <Controller
                        name="roomType.roomTypeName"
                        control={control}
                        render={({ field }) => (
                        <FormControl fullWidth error={!!errors.roomType?.roomTypeName}>
                            <InputLabel>Room Type</InputLabel>
                            <Select {...field} label="Room Type">
                            {roomTypes.map((roomType) => (
                                <MenuItem key={roomType.id} value={roomType.name}>
                                {roomType.name}
                                </MenuItem>
                            ))}
                            </Select>
                            {errors.roomType?.roomTypeName && (
                            <Typography color="error" variant="caption">
                                {errors.roomType?.roomTypeName.message}
                            </Typography>
                            )}
                        </FormControl>
                        )}
                    />
                    ) : (
                    <div>Loading room types...</div>
                    )}
                </Grid>
        
                <Grid item xs={12} md={6}>
                    <Controller
                    name="roomType.roomTypeDescription"
                    control={control}
                    render={({ field }) => (
                        <TextField
                        {...field}
                        label="Room Type Description"
                        fullWidth
                        error={!!errors.roomType?.roomTypeDescription}
                        helperText={errors.roomType?.roomTypeDescription?.message}
                        />
                    )}
                    />
                </Grid>
                </Grid>
                
                <Controller
                name="roomType.numberOfRooms"
                control={control}
                render={({ field }) => (
                    <TextField
                    {...field}
                    label="Number of Rooms"
                    type="number"
                    fullWidth
                    margin="normal"
                    error={!!errors.roomType?.numberOfRooms}
                    helperText={errors.roomType?.numberOfRooms?.message}
                    />
                )}
                />
                <Controller
                name="roomType.roomPrice"
                control={control}
                render={({ field }) => (
                    <TextField
                    {...field}
                    label="Room Price"
                    type="number"
                    fullWidth
                    margin="normal"
                    error={!!errors.roomType?.roomPrice}
                    helperText={errors.roomType?.roomPrice?.message}
                    />
                )}
                />
                <Controller
                name="roomType.numberOfAdults"
                control={control}
                render={({ field }) => (
                    <TextField
                    {...field}
                    label="Number of Adults"
                    type="number"
                    fullWidth
                    margin="normal"
                    error={!!errors.roomType?.numberOfAdults}
                    helperText={errors.roomType?.numberOfAdults?.message}
                    />
                )}
                />
                <Controller
                name="roomType.numberOfBed"
                control={control}
                render={({ field }) => (
                    <TextField
                    {...field}
                    label="Number of Bed"
                    type="number"
                    fullWidth
                    margin="normal"
                    error={!!errors.roomType?.numberOfBed}
                    helperText={errors.roomType?.numberOfBed?.message}
                    />
                )}
                />
        
                <Typography variant="h6" gutterBottom>
                Room Amenities
                </Typography>
        
                <Grid container spacing={2}>
                <Grid item xs={12} md={6}>
                    <Controller
                    name="roomAmenities.isOnGroundFloor"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Is on Ground Floor"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasWifi"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Wifi"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasTelevision"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Television"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasAirConditioner"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Air Conditioner"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasRefrigerator"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Refrigerator"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasTelephone"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Telephone"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasAttachedBathroom"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Attached Bathroom"
                        />
                    )}
                    />
                </Grid>
                <Grid item xs={12} md={6}>
                    <Controller
                    name="roomAmenities.hasRoomService"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Room Service"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasLaundryService"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Laundry Service"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.hasDoorStepDeliveryService"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Has Door Step Delivery Service"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.isWithBreakfast"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Is With Breakfast"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.isWindowAvailable"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Is Window Available"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.isBalconyAvailable"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Is Balcony Available"
                        />
                    )}
                    />
                    <Controller
                    name="roomAmenities.isBeachViewAvailable"
                    control={control}
                    render={({ field }) => (
                        <FormControlLabel
                        control={<Checkbox {...field} />}
                        label="Is Beach View Available"
                        />
                    )}
                    />
                </Grid>
                </Grid>
                <Button type="submit" variant="contained" sx={{ mt: 3 }}>
                Submit
                </Button>
            </form>
            </Box>
        </div> 
      ) : (
        // Table JSX
        <div>
          <Typography variant="h4" gutterBottom>
            Submitted Room Details
          </Typography>
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Field</TableCell>
                  <TableCell>Value</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                
                <TableRow>
                  <TableCell>Room Type Id</TableCell>
                  <TableCell>{submittedData.roomType.roomTypeId}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Description</TableCell>
                  <TableCell>{submittedData.roomType.roomTypeDescription}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Number of Rooms</TableCell>
                  <TableCell>{submittedData.roomType.numberOfRooms}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Price</TableCell>
                  <TableCell>₹ {submittedData.roomType.roomPrice}.00</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>On Ground Floor</TableCell>
                  <TableCell>{submittedData.roomAmenities.isOnGroundFloor ? 'Yes' : 'No'}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Wifi</TableCell>
                  <TableCell>{submittedData.roomAmenities.hasWifi ? 'Yes' : 'No'}</TableCell>
                </TableRow>
                
              </TableBody>
            </Table>
          </TableContainer>
        </div>
      )}
    </Box>
  );
};

export default AddBranchRoom;