import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Box, Button, Link, TextField, Typography } from '@mui/material';

const validateEmail = (email) => /\S+@\S+\.\S+/.test(email);

// Login Component
const HotelGroupLogin = ({ onLogin }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const [apiError, setApiError] = useState('');
  const navigate = useNavigate();
  const handleSubmit = async () => {
    let isValid = true;

    // Validate Email
    if (!validateEmail(email)) {
      setEmailError('Invalid email format');
      isValid = false;
    } else {
      setEmailError('');
    }

    // Validate Password
    if (password.length < 5) {
      setPasswordError('Password must be at least 5 characters long');
      isValid = false;
    } else {
      setPasswordError('');
    }

    if (isValid) {
      try {
        // Example API call for login
        const response = await fetch('https://localhost:7233/api/HotelGroupLogin/HotelGroupLogin', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            email,
            password,
            role: 'HotelGroup' // Include the role in the request payload
          }),
        });

        if (!response.ok) {
          throw new Error('Login failed');
        }

        const result = await response.json();
        console.log(result); // Handle login response as needed
        onLogin?.(); // Call onLogin if provided

        localStorage.setItem('group-token', result.token);
        navigate('/hotelgroup/group/group-profile');
      } catch (error) {
        console.error('Login error:', error);
        setApiError('Login failed. Please check your credentials.');
      }
    }
  };

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', padding: 2 }}>
      <Typography variant="h6">Please log in to continue</Typography>
      {apiError && (
        <Typography color="error" variant="body2" sx={{ mt: 2 }}>
          {apiError}
        </Typography>
      )}
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
        <Link href="/hotelgroup/group/group-signup" variant="body2">
          Register as Hotel Group
        </Link>
      </Box>
    </Box>
  );
};

export default HotelGroupLogin;
