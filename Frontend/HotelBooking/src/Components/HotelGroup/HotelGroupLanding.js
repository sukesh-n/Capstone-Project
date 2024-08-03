import React, { useEffect, useState } from 'react';
import {  Route, Routes, Navigate, useNavigate, useLocation } from 'react-router-dom';
import { Container, Box, Typography, Button, TextField, Link, CircularProgress } from '@mui/material';
import HotelGroupNavBar from './HotelGroupNavBar'; // Ensure this import is correct
import HotelBranchAccountManagement from './HotelBranchAccountManagement';

// Validation functions
const validateEmail = (email) => /\S+@\S+\.\S+/.test(email);
const validatePhone = (phone) => /^\d{10}$/.test(phone); 

// Login Component
const Login = ({ onLogin }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = () => {
    let isValid = true;

    if (!validateEmail(email)) {
      setEmailError('Invalid email format');
      isValid = false;
    } else {
      setEmailError('');
    }

    if (password.length < 5) {
      setPasswordError('Password must be at least 5 characters long');
      isValid = false;
    } else {
      setPasswordError('');
    }

    if (isValid) {
      onLogin(); 
      navigate('/'); 
    }
  };

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', padding: 2 }}>
      <Typography variant="h6">Please log in to continue</Typography>
      <TextField
        label="Email"
        variant="outlined"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        error={!!emailError}
        helperText={emailError}
        sx={{ mt: 2, width: '100%' }}
      />
      <TextField
        label="Password"
        type="password"
        variant="outlined"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        error={!!passwordError}
        helperText={passwordError}
        sx={{ mt: 2, width: '100%' }}
      />
      <Button
        variant="contained"
        color="primary"
        sx={{ mt: 2 }}
        onClick={handleSubmit}
      >
        Log In
      </Button>
      <Box sx={{ mt: 2 }}>
        <Link href="#" variant="body2" sx={{ mr: 2 }}>
          Forgot Password?
        </Link>
        <Link href="/register" variant="body2"> 
          Register as Hotel Group
        </Link>
      </Box>
    </Box>
  );
};

// Register Component
const Register = ({ onRegister }) => {
  const [hotelGroupName, setHotelGroupName] = useState('');
  const [hotelGroupManagerName, setHotelGroupManagerName] = useState('');
  const [hotelGroupEmail, setHotelGroupEmail] = useState('');
  const [hotelGroupPhone, setHotelGroupPhone] = useState('');
  const [password, setPassword] = useState('');
  const [errors, setErrors] = useState({
    hotelGroupName: '',
    hotelGroupManagerName: '',
    hotelGroupEmail: '',
    hotelGroupPhone: '',
    password: ''
  });
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [apiError, setApiError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async () => {
    const newErrors = { ...errors };
    let isValid = true;

    if (!hotelGroupName) {
      newErrors.hotelGroupName = 'Hotel Group Name is required';
      isValid = false;
    } else {
      newErrors.hotelGroupName = '';
    }

    if (!hotelGroupManagerName) {
      newErrors.hotelGroupManagerName = 'Manager Name is required';
      isValid = false;
    } else {
      newErrors.hotelGroupManagerName = '';
    }

    if (!validateEmail(hotelGroupEmail)) {
      newErrors.hotelGroupEmail = 'Invalid email format';
      isValid = false;
    } else {
      newErrors.hotelGroupEmail = '';
    }

    if (!validatePhone(hotelGroupPhone)) {
      newErrors.hotelGroupPhone = 'Phone number must be 10 digits';
      isValid = false;
    } else {
      newErrors.hotelGroupPhone = '';
    }

    if (password.length < 5) {
      newErrors.password = 'Password must be at least 5 characters long';
      isValid = false;
    } else {
      newErrors.password = '';
    }

    setErrors(newErrors);

    if (isValid) {
      setIsSubmitting(true);
      setApiError('');
      try {
        const response = await fetch('https://localhost:7233/api/GroupAccount/CreateGroupAccount', {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            hotelGroup: {
              hotelGroupName,
              hotelGroupManagerName,
              hotelGroupEmail,
              hotelGroupPhone
            },
            password
          })
        });
        if (!response.ok) {
          throw new Error('Failed to register');
        }

        const result = await response.json();
        onRegister(result.hotelGroup); 
        navigate('/response', { state: { data: result.hotelGroup } }); // Pass data using state

      } catch (error) {
        setApiError('An error occurred during registration. Please try again.');
        console.error("Registration Error:", error); 
      } finally {
        setIsSubmitting(false);
      }
    }
  };

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', padding: 2 }}>
      <Typography variant="h6">Register as Hotel Group</Typography>
      {apiError && <Typography color="error" variant="body2">{apiError}</Typography>}
      <TextField
        label="Hotel Group Name"
        variant="outlined"
        value={hotelGroupName}
        onChange={(e) => setHotelGroupName(e.target.value)}
        error={!!errors.hotelGroupName}
        helperText={errors.hotelGroupName}
        sx={{ mt: 2, width: '100%' }}
        disabled={isSubmitting}
      />
      <TextField
        label="Manager Name"
        variant="outlined"
        value={hotelGroupManagerName}
        onChange={(e) => setHotelGroupManagerName(e.target.value)}
        error={!!errors.hotelGroupManagerName}
        helperText={errors.hotelGroupManagerName}
        sx={{ mt: 2, width: '100%' }}
        disabled={isSubmitting}
      />
      <TextField
        label="Email"
        variant="outlined"
        value={hotelGroupEmail}
        onChange={(e) => setHotelGroupEmail(e.target.value)}
        error={!!errors.hotelGroupEmail}
        helperText={errors.hotelGroupEmail}
        sx={{ mt: 2, width: '100%' }}
        disabled={isSubmitting}
      />
      <TextField
        label="Phone"
        variant="outlined"
        value={hotelGroupPhone}
        onChange={(e) => setHotelGroupPhone(e.target.value)}
        error={!!errors.hotelGroupPhone}
        helperText={errors.hotelGroupPhone}
        sx={{ mt: 2, width: '100%' }}
        disabled={isSubmitting}
      />
      <TextField
        label="Password"
        type="password"
        variant="outlined"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        error={!!errors.password}
        helperText={errors.password}
        sx={{ mt: 2, width: '100%' }}
        disabled={isSubmitting}
      />
      <Button
        variant="contained"
        color="primary"
        sx={{ mt: 2 }}
        onClick={handleSubmit}
        disabled={isSubmitting}
      >
        {isSubmitting ? <CircularProgress size={24} /> : 'Register'}
      </Button>
      <Box sx={{ mt: 2 }}>
        <Link href="/" variant="body2" disabled={isSubmitting}> 
          Already have an account? Log In
        </Link>
      </Box>
    </Box>
  );
};


// Response Component
const Response = () => {
  const location = useLocation(); // Access data passed through state
  const navigate = useNavigate();
  const { data } = location.state || {}; // Default to empty object

  if (!data) {
    return <Navigate to="/" />; // Redirect if no data is available
  }

  const { hotelGroupName, hotelGroupManagerName, hotelGroupEmail, hotelGroupPhone, hotelGroupId } = data;

  const handleBackToLogin = () => {
    navigate('/'); // Navigate to Login
  };

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', padding: 2 }}>
      <Typography variant="h6">Registration Successful!</Typography>
      <Box sx={{ mt: 2 }}>
        <Typography variant="body1">Your Hotel Group has been registered with the following details:</Typography>
        <Typography variant="body1" sx={{ color: 'red' }}> Hotel Group ID: {hotelGroupId}</Typography>
        <Typography variant="body1">Hotel Group Name: {hotelGroupName}</Typography>
        <Typography variant="body1">Manager Name: {hotelGroupManagerName}</Typography>
        <Typography variant="body1">Email: {hotelGroupEmail}</Typography>
        <Typography variant="body1">Phone: {hotelGroupPhone}</Typography>
      </Box>
      <Button
        variant="contained"
        color="primary"
        sx={{ mt: 2 }}
        onClick={handleBackToLogin}
      >
        Go to Login
      </Button>
    </Box>
  );
};

// Menu Component
const Menu = ({ onAddBranch }) => (
  <Box sx={{ padding: 2 }}>
    <Typography variant="h6">Menu</Typography>
    <Button
      variant="contained"
      sx={{ mt: 2 }}
      color="primary"
      onClick={onAddBranch}
    >
      Add Branch
    </Button>
    <Button
      variant="contained"
      sx={{ mt: 2, ml: 2 }}
      color="primary"
      onClick={onAddBranch}
    >
      Update Branch
    </Button>
    <Button
      variant="contained"
      sx={{ mt: 2, ml: 2 }}
      color="primary"
      onClick={onAddBranch}
    >
      View Dashboard
    </Button>
  </Box>
);

// Main App Component with Routing
const HotelGroupLanding = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [showBranchAccount, setShowBranchAccount] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem('groupToken');
    setIsLoggedIn(!!token);
  }, []);

  const handleLogin = () => {
    localStorage.setItem('groupToken', 'someToken'); // Replace with real token
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    localStorage.removeItem('groupToken');
    setIsLoggedIn(false);
  };

  const handleShowBranchAccount = () => {
    setShowBranchAccount(true);
  };

  const handleBackToLogin = () => {
    // Reset state or perform actions needed when going back to login
  };

  return (
    <>
      <HotelGroupNavBar />
      <Container>
        <Typography variant="h4" sx={{ mt: 2, textAlign: 'center' }}>Hotel Group Home</Typography>
        <Routes>
          <Route path="/" element={isLoggedIn ? ( 
            showBranchAccount ? (
              <HotelBranchAccountManagement /> 
            ) : (
              <>
                <Menu onAddBranch={handleShowBranchAccount} />
                <Button
                  variant="contained"
                  color="secondary"
                  onClick={handleLogout}
                  sx={{ mt: 2 }}
                >
                  Log Out
                </Button>
              </>
            )
          ) : ( 
            <Login onLogin={handleLogin} /> 
          )} />
          <Route path="/register" element={<Register onRegister={() => {}} />} /> 
          <Route path="/response" element={<Response onBackToLogin={handleBackToLogin} />} /> 
          <Route path="*" element={<Navigate to="/" />} />
        </Routes>
      </Container>
    </>
  );
};

export default HotelGroupLanding;
