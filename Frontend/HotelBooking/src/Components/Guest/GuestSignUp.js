import React, { useState } from 'react';
import { Container, TextField, Button, Typography, Box, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { useNavigate } from 'react-router-dom';

const DisplayData = ({ data,onGoBack }) => {

    console.log(data);
    return (
        <TableContainer component={Paper} style={{ marginTop: 16 }}>
            <Typography variant="h6" style={{ padding: 16 }}>Response Data:</Typography>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell><strong>Field</strong></TableCell>
                        <TableCell><strong>Value</strong></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    <TableRow>
                        <TableCell>Guest ID</TableCell>
                        <TableCell>{data.guest.guestId}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Guest Name</TableCell>
                        <TableCell>{data.guest.guestName}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Guest Email</TableCell>
                        <TableCell>{data.guest.guestEmail}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Guest Phone</TableCell>
                        <TableCell>{data.guest.guestPhone}</TableCell>
                    </TableRow>
                    <TableRow>
                    <TableCell><Button
                            type="submit"
                            variant="contained"
                            color="secondary"
                            onClick={onGoBack}
                        >
                            Go Back to Log In
                        </Button>
                    </TableCell>
                    </TableRow>
                </TableBody>
                
            </Table>

        </TableContainer>
    );
};

const GuestSignUp = () => {
    const [submittedData, setSubmittedData] = useState(null);

    const initialValues = {
        guestName: '',
        guestEmail: '',
        guestPhone: '',
        password: '',
    };
    const navigate = useNavigate();
    const validationSchema = Yup.object({
        guestName: Yup.string()
            .required('Guest name is required')
            .min(2, 'Guest name must be at least 2 characters long'),
        guestEmail: Yup.string()
            .email('Invalid email format')
            .required('Email is required'),
        guestPhone: Yup.string()
            .required('Phone number is required')
            .length(10, 'Phone number must be exactly 10 digits'),
        password: Yup.string()
            .required('Password is required')
            .min(6, 'Password must be at least 6 characters long'),
    });

    const handleSubmit = async (values, { setSubmitting, resetForm }) => {
        setSubmitting(true);

        try {
            const response = await fetch('https://localhost:7233/api/GuestAccount/CreateGuestAccount', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    guest: {
                        guestId: 0,
                        guestName: values.guestName,
                        guestEmail: values.guestEmail,
                        guestPhone: values.guestPhone,
                        lastlogin: new Date().toISOString(),
                    },
                    password: values.password,
                }),
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const result = await response.json();
            console.log(result);
            setSubmittedData(result);
            resetForm(); 
        } catch (error) {
            console.error('Error:', error);
        } finally {
            setSubmitting(false);
        }
    };

    const handlePhoneChange = (event, field, form) => {
        const { value } = event.target;
        const numericValue = value.replace(/[^0-9]/g, '');
        form.setFieldValue(field.name, numericValue);
    };
    const handleGoBack = () => {
        navigate('/guesthome/guest/guest-login'); // Use navigate here
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" gutterBottom>
                Guest Sign Up
            </Typography>

            {submittedData ? (
                <DisplayData data={submittedData} onGoBack={handleGoBack} />
            ) : (
                <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}
            >
                {({ isSubmitting, touched, errors, setFieldValue }) => (
                    <Form>
                        <Box mb={2}>
                            <Field
                                as={TextField}
                                name="guestName"
                                label="Guest Name"
                                fullWidth
                                variant="outlined"
                                helperText={<ErrorMessage name="guestName" />}
                                error={touched.guestName && Boolean(errors.guestName)}
                            />
                        </Box>
                        <Box mb={2}>
                            <Field
                                as={TextField}
                                name="guestEmail"
                                label="Guest Email"
                                type="email"
                                fullWidth
                                variant="outlined"
                                helperText={<ErrorMessage name="guestEmail" />}
                                error={touched.guestEmail && Boolean(errors.guestEmail)}
                            />
                        </Box>
                        <Box mb={2}>
                            <Field
                                as={TextField}
                                name="guestPhone"
                                label="Guest Phone"
                                type="text"
                                fullWidth
                                variant="outlined"
                                inputProps={{
                                    maxLength: 10,
                                }}
                                onChange={(event) => handlePhoneChange(event, { name: 'guestPhone' }, { setFieldValue })}
                                helperText={<ErrorMessage name="guestPhone" />}
                                error={touched.guestPhone && Boolean(errors.guestPhone)}
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
                                error={touched.password && Boolean(errors.password)}
                            />
                        </Box>
                        <Button
                            type="submit"
                            variant="contained"
                            color="primary"
                            disabled={isSubmitting}
                        >
                            Sign Up
                        </Button>
                    </Form>
                )}
            </Formik>
            )}


            
        </Container>
    );
};

export default GuestSignUp;