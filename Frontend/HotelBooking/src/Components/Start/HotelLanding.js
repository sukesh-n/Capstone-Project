import React from 'react';
import { Box, Card, CardContent, CardActionArea, Typography, Container, AppBar, Toolbar, IconButton, Menu, MenuItem } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { useNavigate } from 'react-router-dom';
import logo from '../../Assets/logo/web_logo.png';

const HotelLanding = () => {
    const navigate = useNavigate();
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);

    const handleMenuOpen = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleMenuClose = () => {
        setAnchorEl(null);
    };

    const navigateTo = (path) => {
        navigate(path);
        handleMenuClose();
    };

    return (
        <div>
            <AppBar position="static">
                <Toolbar>
                    <IconButton edge="start" color="inherit" aria-label="menu" onClick={handleMenuOpen}>
                        <MenuIcon />
                    </IconButton>
                    <Typography variant="h6" sx={{ flexGrow: 1 }}>
                        <img src={logo} alt="Logo" style={{ height: '40px' }} />
                    </Typography>
                    <Menu
                        anchorEl={anchorEl}
                        open={open}
                        onClose={handleMenuClose}
                    >
                        <MenuItem onClick={() => navigateTo('/home')}>Home</MenuItem>
                        <MenuItem onClick={() => navigateTo('/about')}>About</MenuItem>
                        <MenuItem onClick={() => navigateTo('/contact')}>Contact</MenuItem>
                    </Menu>
                </Toolbar>
            </AppBar>
            <Container>
                <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', mt: 4 }}>
                    <Typography variant="h4" gutterBottom>
                        Welcome to TravelStay
                    </Typography>
                    <Box sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center', gap: 2 }}>
                        <Card sx={{ maxWidth: 345 }}>
                            <CardActionArea onClick={() => navigate('/guesthome')}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                        Guest
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        Manage guest related activities.
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                        <Card sx={{ maxWidth: 345 }}>
                            <CardActionArea onClick={() => navigate('/hotelgroup')}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                        Group
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        Manage hotel groups.
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                        <Card sx={{ maxWidth: 345 }}>
                            <CardActionArea onClick={() => navigate('/hotelbranch')}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                        Branch
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        Manage hotel branches.
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                        <Card sx={{ maxWidth: 345 }}>
                            <CardActionArea onClick={() => navigate('/admin')}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                        Admin
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        Administer system settings.
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                    </Box>
                </Box>
            </Container>
        </div>
    );
};

export default HotelLanding;
