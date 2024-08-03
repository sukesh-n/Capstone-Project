import React, { useState } from 'react';
import { AppBar, Toolbar, Button, Container, Box, Menu, MenuItem, IconButton } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { useNavigate, Link, useLocation } from 'react-router-dom';
import logo from '../../Assets/logo/web_logo.png';

const GuestNavBar = () => {
    const onLoggedIn = [
        { name: 'Home', link: '/guesthome/' },
        { name: 'Book Now', link: '/guesthome/guest/book' },
        { name: 'Manage Bookings', link: '/guesthome/guest/manage-bookings' },
        { name: 'Profile', link: '/guesthome/guest/guest-profile' }
    ];

    const onLoggedOut = [
        { name: 'Home', link: '/guesthome/' },
        { name: 'Sign Up', link: '/guesthome/guest/signup' },
        { name: 'Hotel Owner?', link: '../hotelgroup' }
    ];

    const isLoggedIn = localStorage.getItem('guest-token') !== null;
    const navigate = useNavigate();
    const location = useLocation();
    const currentPath = location.pathname;

    const [anchorElNav, setAnchorElNav] = useState(null);

    const handleMenuOpen = (event) => {
        setAnchorElNav(event.currentTarget);
    };

    const handleMenuClose = () => {
        setAnchorElNav(null);
    };

    const handleLogout = () => {
        localStorage.removeItem('guest-token');
        navigate('/guesthome/guest/guest-login'); // Use absolute path
    };

    const shouldHideLoginButton = currentPath === '/guesthome/guest/guest-login' || currentPath === '/guesthome/guest/signup';
    const shouldHideSignupButton = currentPath === '/guesthome/guest/signup';

    // Filter out 'Sign Up' from `onLoggedOut` if we are on the sign-up page
    const filteredOnLoggedOut = shouldHideSignupButton 
        ? onLoggedOut.filter(page => page.name !== 'Sign Up') 
        : onLoggedOut;

    return (
        <AppBar position="static" sx={{ background: 'linear-gradient(45deg, #f44336 30%, #00ae20 90%)' }}>
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
                        <IconButton
                            size="large"
                            aria-label="open drawer"
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            onClick={handleMenuOpen}
                            color="inherit"
                        >
                            <MenuIcon />
                        </IconButton>
                        <Menu
                            id="menu-appbar"
                            anchorEl={anchorElNav}
                            anchorOrigin={{
                                vertical: 'bottom',
                                horizontal: 'left',
                            }}
                            keepMounted
                            transformOrigin={{
                                vertical: 'top',
                                horizontal: 'left',
                            }}
                            open={Boolean(anchorElNav)}
                            onClose={handleMenuClose}
                            sx={{
                                display: { xs: 'block', md: 'none' },
                            }}
                        >
                            {(isLoggedIn ? onLoggedIn : filteredOnLoggedOut).map((page) => (
                                <MenuItem
                                    key={page.name}
                                    onClick={() => {
                                        navigate(page.link);
                                        handleMenuClose();
                                    }}
                                >
                                    {page.name}
                                </MenuItem>
                            ))}
                        </Menu>
                    </Box>
                    <Box sx={{ flexGrow: 1, display: 'flex', justifyContent: { xs: 'flex-start', md: 'flex-start' }, alignItems: 'center' }}>
                        <img src={logo} alt="logo" style={{ height: 40 }} />
                    </Box>
                    <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }, justifyContent: 'flex-end' }}>
                        {(isLoggedIn ? onLoggedIn : filteredOnLoggedOut).map((page) => (
                            <Button
                                key={page.name}
                                color="inherit"
                                component={Link}
                                to={page.link}
                            >
                                {page.name}
                            </Button>
                        ))}
                    </Box>

                    {!shouldHideLoginButton && !isLoggedIn && (
                        <Button
                            color="inherit"
                            component={Link}
                            to="/guesthome/guest/guest-login"
                        >
                            Login
                        </Button>
                    )}
                    {isLoggedIn && (
                        <Button color="inherit" onClick={handleLogout}>
                            Logout
                        </Button>
                    )}
                </Toolbar>
            </Container>
        </AppBar>
    );
};

export default GuestNavBar;
