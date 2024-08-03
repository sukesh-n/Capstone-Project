import React from 'react';
import { Button, Container, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const GuestLogout = () => {
    const navigate = useNavigate();

    const handleLogout = () => {
        // Clear the token from localStorage
        localStorage.removeItem('token');
        
        // Navigate to the login page
        navigate('/guestlogin');
    };

    return (
        <Container>
        <Typography variant="h1" align="center" color="textPrimary" gutterBottom>Logout</Typography>
        <Button onClick={handleLogout} variant="contained" color="secondary">Logout</Button>
        </Container>
    );
};

export default GuestLogout;
