import React, { useState, useEffect } from 'react';
import { Container, TextField, Button, Typography, Box, FormControl, InputLabel, Select, MenuItem, FormHelperText, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { useNavigate } from 'react-router-dom';
import { jwt_decode } from './GuestToken';

const AddBranch = () => {
  const navigate = useNavigate();
  const token = localStorage.getItem('group-token');
  const decode = jwt_decode(token);
  const GroupId = parseInt(decode.hotelGroupId, 10);

  const [hotelTypes, setHotelTypes] = useState([]);
  const [showForm, setShowForm] = useState(true); 
  const [branchData, setBranchData] = useState(null);

  useEffect(() => {
    if (!token) {
      navigate('/hotelgroup');
    }
  }, [token, navigate]);

  useEffect(() => {
    const fetchHotelTypes = async () => {
      try {
        const response = await fetch('https://localhost:7233/api/EnumHotelTypes');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setHotelTypes(data);
      } catch (error) {
        console.error('Error fetching hotel types:', error);
      }
    };

    fetchHotelTypes();
  }, []);

  const validationSchema = Yup.object({
    hotelBranchName: Yup.string()
      .required('Branch Name is required')
      .min(3, 'Branch Name must be at least 3 characters long'),
    hotelType: Yup.string()
      .required('Hotel Type is required'),
    hotelBranchManager: Yup.string()
      .required('Branch Manager is required'),
    hotelBranchEmail: Yup.string()
      .email('Invalid email format')
      .required('Branch Email is required'),
    hotelBranchPhone: Yup.string()
      .required('Branch Phone is required')
      .matches(/^\d{10}$/, 'Branch Phone must be exactly 10 digits'),
    password: Yup.string()
      .required('Password is required')
      .min(6, 'Password must be at least 6 characters long'),
  });

  const handleSubmit = async (values, { setSubmitting }) => {
    setSubmitting(true);

    const payload = {
      hotel: {
        hotelBranchId: 0,
        hotelGroupId: values.hotelGroupId,
        hotelGroup: {
          hotelGroupId: values.hotelGroupId,
          hotelGroupName: '',
          hotelGroupManagerName: '',
          hotelGroupEmail: '',
          hotelGroupPhone: ''
        },
        hotelBranchName: values.hotelBranchName,
        hotelType: values.hotelType,
        hotelBranchManager: values.hotelBranchManager,
        hotelBranchEmail: values.hotelBranchEmail,
        hotelBranchPhone: values.hotelBranchPhone
      },
      password: values.password
    };

    try {
      const response = await fetch('https://localhost:7233/api/BranchAccount/CreateBranchAccount', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload),
      });

      if (!response.ok) {
        const errorText = await response.text();
        console.error('Error response text:', errorText);
        throw new Error(`HTTP error ${response.status}: ${errorText}`);
      }

      const data = await response.json();
      console.log('Branch added successfully:', data);
      setBranchData(data); 
      setShowForm(false); 

    } catch (error) {
      console.error('Error adding branch:', error.message);
    } finally {
      setSubmitting(false);
    }
  };

  const renderTable = () => (
    <Container>
      <Typography variant="h6" gutterBottom>
        Branch added successfully
      </Typography>
      <TableContainer component={Paper} sx={{ mb: 2 }}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Hotel Branch ID</TableCell>
              <TableCell>Hotel Branch Name</TableCell>
              <TableCell>Hotel Group ID</TableCell>
              <TableCell>Hotel Type</TableCell>
              <TableCell>Branch Manager</TableCell>
              <TableCell>Branch Email</TableCell>
              <TableCell>Branch Phone</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {branchData && (
              <TableRow>
                <TableCell>{branchData.hotel.hotelBranchId}</TableCell> 
                <TableCell>{branchData.hotel.hotelBranchName}</TableCell>
                <TableCell>{branchData.hotel.hotelGroupId}</TableCell>
                <TableCell>{branchData.hotel.hotelType}</TableCell>
                <TableCell>{branchData.hotel.hotelBranchManager}</TableCell>
                <TableCell>{branchData.hotel.hotelBranchEmail}</TableCell>
                <TableCell>{branchData.hotel.hotelBranchPhone}</TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
      <Button 
        variant="contained" 
        color="primary" 
        onClick={() => navigate('/hotelgroup')}
      >
        Go back to Group home
      </Button>
    </Container>
  );

  return (
    <Container>
      <Typography variant="h4" gutterBottom align="center">
        Branch Creation Page
      </Typography>
      {showForm ? (
        <Formik
          initialValues={{
            hotelBranchName: '',
            hotelGroupId: GroupId,
            hotelType: '',
            hotelBranchManager: '',
            hotelBranchEmail: '',
            hotelBranchPhone: '',
            password: ''
          }}
          validationSchema={validationSchema}
          onSubmit={handleSubmit}
        >
          {({ isSubmitting, touched, errors }) => (
            <Form>
              <Box mb={2}>
                <Field
                  as={TextField}
                  name="hotelBranchName"
                  label="Branch Name"
                  fullWidth
                  variant="outlined"
                  helperText={<ErrorMessage name="hotelBranchName" />}
                  error={Boolean(touched.hotelBranchName && errors.hotelBranchName)}
                />
              </Box>
              <Box mb={2}>
                <FormControl fullWidth variant="outlined" error={Boolean(touched.hotelType && errors.hotelType)}>
                  <InputLabel id="hotel-type-label">Hotel Type</InputLabel>
                  <Field
                    as={Select}
                    name="hotelType"
                    labelId="hotel-type-label"
                    label="Hotel Type"
                  >
                    {hotelTypes.map((type) => (
                      <MenuItem key={type.id} value={type.id}>
                        {type.name}
                      </MenuItem>
                    ))}
                  </Field>
                  <FormHelperText><ErrorMessage name="hotelType" /></FormHelperText>
                </FormControl>
              </Box>
              <Box mb={2}>
                <Field
                  as={TextField}
                  name="hotelBranchManager"
                  label="Branch Manager"
                  fullWidth
                  variant="outlined"
                  helperText={<ErrorMessage name="hotelBranchManager" />}
                  error={Boolean(touched.hotelBranchManager && errors.hotelBranchManager)}
                />
              </Box>
              <Box mb={2}>
                <Field
                  as={TextField}
                  name="hotelBranchEmail"
                  label="Branch Email"
                  type="email"
                  fullWidth
                  variant="outlined"
                  helperText={<ErrorMessage name="hotelBranchEmail" />}
                  error={Boolean(touched.hotelBranchEmail && errors.hotelBranchEmail)}
                />
              </Box>
              <Box mb={2}>
                <Field
                  as={TextField}
                  name="hotelBranchPhone"
                  label="Branch Phone"
                  type="text"
                  fullWidth
                  variant="outlined"
                  helperText={<ErrorMessage name="hotelBranchPhone" />}
                  error={Boolean(touched.hotelBranchPhone && errors.hotelBranchPhone)}
                />
              </Box>
              <Box mb={2}>
                <Field
                  as={TextField}
                  name="password"
                  label="Password"
                  type="password"
                  fullWidth
                  variant="outlined"
                  helperText={<ErrorMessage name="password" />}
                  error={Boolean(touched.password && errors.password)}
                />
              </Box>
              <Button
                type="submit"
                variant="contained"
                color="primary"
                disabled={isSubmitting}
              >
                Add Branch
              </Button>
            </Form>
          )}
        </Formik>
      ) : (
        renderTable()
      )}
    </Container>
  );
};
export default AddBranch;