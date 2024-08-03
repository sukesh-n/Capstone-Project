import React, { useState } from 'react';
import { Container, TextField, Button, Typography, Box, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { useNavigate } from 'react-router-dom';

// DisplayData Component
const DisplayData = ({ data, onGoBack }) => {
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
                        <TableCell>Hotel Group ID</TableCell>
                        <TableCell>{data.hotelGroup.hotelGroupId}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Hotel Group Name</TableCell>
                        <TableCell>{data.hotelGroup.hotelGroupName}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Manager Name</TableCell>
                        <TableCell>{data.hotelGroup.hotelGroupManagerName}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Email</TableCell>
                        <TableCell>{data.hotelGroup.hotelGroupEmail}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Phone</TableCell>
                        <TableCell>{data.hotelGroup.hotelGroupPhone}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>
                            <Button
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

// HotelGroupSignUp Component
const HotelGroupSignUp = () => {
    const [submittedData, setSubmittedData] = useState(null);
    const navigate = useNavigate();

    const initialValues = {
        hotelGroupName: '',
        hotelGroupManagerName: '',
        hotelGroupEmail: '',
        hotelGroupPhone: '',
        password: '',
    };

    const validationSchema = Yup.object({
        hotelGroupName: Yup.string()
            .required('Hotel Group Name is required')
            .min(2, 'Hotel Group Name must be at least 2 characters long'),
        hotelGroupManagerName: Yup.string()
            .required('Manager Name is required')
            .min(2, 'Manager Name must be at least 2 characters long'),
        hotelGroupEmail: Yup.string()
            .email('Invalid email format')
            .required('Email is required'),
        hotelGroupPhone: Yup.string()
            .required('Phone number is required')
            .length(10, 'Phone number must be exactly 10 digits'),
        password: Yup.string()
            .required('Password is required')
            .min(6, 'Password must be at least 6 characters long'),
    });

    const handleSubmit = async (values, { setSubmitting, resetForm }) => {
        setSubmitting(true);

        try {
            const response = await fetch('https://localhost:7233/api/GroupAccount/CreateGroupAccount', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    hotelGroup: {
                        hotelGroupName: values.hotelGroupName,
                        hotelGroupManagerName: values.hotelGroupManagerName,
                        hotelGroupEmail: values.hotelGroupEmail,
                        hotelGroupPhone: values.hotelGroupPhone,
                    },
                    password: values.password,
                }),
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const result = await response.json();
            setSubmittedData(result);
            resetForm(); 
        } catch (error) {
            console.error('Error:', error);
        } finally {
            setSubmitting(false);
        }
    };

    const handleGoBack = () => {
        navigate('/hotelgroup/group/group-login');
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" gutterBottom>
                Hotel Group Sign Up
            </Typography>

            {submittedData ? (
                <DisplayData data={submittedData} onGoBack={handleGoBack} />
            ) : (
                <Formik
                    initialValues={initialValues}
                    validationSchema={validationSchema}
                    onSubmit={handleSubmit}
                >
                    {({ isSubmitting, touched, errors }) => (
                        <Form>
                            <Box mb={2}>
                                <Field
                                    as={TextField}
                                    name="hotelGroupName"
                                    label="Hotel Group Name"
                                    fullWidth
                                    variant="outlined"
                                    helperText={<ErrorMessage name="hotelGroupName" />}
                                    error={touched.hotelGroupName && Boolean(errors.hotelGroupName)}
                                />
                            </Box>
                            <Box mb={2}>
                                <Field
                                    as={TextField}
                                    name="hotelGroupManagerName"
                                    label="Manager Name"
                                    fullWidth
                                    variant="outlined"
                                    helperText={<ErrorMessage name="hotelGroupManagerName" />}
                                    error={touched.hotelGroupManagerName && Boolean(errors.hotelGroupManagerName)}
                                />
                            </Box>
                            <Box mb={2}>
                                <Field
                                    as={TextField}
                                    name="hotelGroupEmail"
                                    label="Hotel Group Email"
                                    type="email"
                                    fullWidth
                                    variant="outlined"
                                    helperText={<ErrorMessage name="hotelGroupEmail" />}
                                    error={touched.hotelGroupEmail && Boolean(errors.hotelGroupEmail)}
                                />
                            </Box>
                            <Box mb={2}>
                                <Field
                                    as={TextField}
                                    name="hotelGroupPhone"
                                    label="Hotel Group Phone"
                                    type="text"
                                    fullWidth
                                    variant="outlined"
                                    inputProps={{
                                        maxLength: 10,
                                    }}
                                    helperText={<ErrorMessage name="hotelGroupPhone" />}
                                    error={touched.hotelGroupPhone && Boolean(errors.hotelGroupPhone)}
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

export default HotelGroupSignUp;
