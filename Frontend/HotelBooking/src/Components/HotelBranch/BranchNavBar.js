import * as React from 'react';
import { useLocation } from 'react-router-dom';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
// import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import logo from '../../Assets/logo/web_logo.png';
import {jwt_decode} from '../HotelGroup/GuestToken';

const onLoggedIn = [
  { name: 'HotelHome', link: '/hotelhome' },
  { name: 'Branch Home', link: '/hotelbranch' },
  { name: 'Update Status', link: '/hotelbranch/branch/update-roomstatus' },
];

const onLoggedOut = [
  { name: 'HotelHome', link: '/hotelhome' },
  { name: 'Login', link: '/hotelbranch/branch/branch-login' },
  { name: 'Signup', link: '/hotelbranch/branch/branch-signup' },
];

const settingsOnLoggedIn = [
  { name: 'Profile', link: '/hotelbranch/branch/update-branch-profile' },
  { name: 'UpdateProfile', link: '/hotelbranch/branch/update-branch-profile' },
  { name: 'Logout', link: '/hotelbranch/branch/branch-logout' },
];

function BranchNavBar() {
  const [anchorElNav, setAnchorElNav] = React.useState(null);
  const [anchorElUser, setAnchorElUser] = React.useState(null);
  const [pages, setPages] = React.useState(onLoggedOut);
  const [settings, setSettings] = React.useState([]);
  const location = useLocation();

  React.useEffect(() => {
    const token = localStorage.getItem('branch-token');

    if (token) {
      try {
        const decode = jwt_decode(token);
        const role = decode['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        if (role === 'hotelBranch') {
          setPages(onLoggedIn);
          setSettings(settingsOnLoggedIn);
        }
      } catch (e) {
        console.error('Invalid token', e);
        setPages(onLoggedOut);
      }
    } else {
      setPages(onLoggedOut);
    }
  }, []);

  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  // Determine if current path should hide certain buttons
  const hideLoginButton = location.pathname === '/hotelbranch/branch/branch-login';
  const hideSignupButton = location.pathname === '/hotelbranch/branch/branch-signup';

  return (
    <AppBar position="static" sx={{ background: 'linear-gradient(45deg, #f44336 30%, #00ae20 90%)' }}>
      <Container maxWidth="lg">
        <Toolbar disableGutters>

          {/* Mobile Menu Icon */}
          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
            <IconButton
              size="large"
              aria-label="open drawer"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
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
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: 'block', md: 'none' },
              }}
            >
              {pages.map((page) => (
                <MenuItem key={page.name} onClick={handleCloseNavMenu}>
                  <Button sx={{ textAlign: 'center' }} component="a" href={page.link}>
                    {page.name}
                  </Button>
                </MenuItem>
              ))}
            </Menu>
          </Box>

          {/* Logo Display */}
          <Box sx={{ flexGrow: 1, display: 'flex', justifyContent: 'flex-start', alignItems: 'center' }}>
            <img src={logo} alt="logo" style={{ height: 40 }} />
          </Box> 

          {/* Navigation Buttons */}
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }, justifyContent: 'flex-end' }}>
            {pages.map((page) => (
              !((page.name === 'Login' && hideLoginButton) || (page.name === 'Signup' && hideSignupButton)) && (
                <Button
                  key={page.name}
                  href={page.link}
                  onClick={handleCloseNavMenu}
                  sx={{ my: 2, color: 'white', display: 'block' }}
                >
                  {page.name}
                </Button>
              )
            ))}
          </Box>

          {/* User Avatar and Menu */}
          <Box sx={{ flexGrow: 0, display: 'flex', alignItems: 'center'}}>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar alt="User" src="/static/images/avatar/1.jpg" /> 
              </IconButton>
            </Tooltip>
            <Menu
              sx={{ mt: '45px' }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) => (
                <MenuItem key={setting.name} onClick={handleCloseUserMenu}>
                  <Button sx={{ textAlign: 'center' }}component="a" href={setting.link}>
                    {setting.name}
                  </Button>
                </MenuItem>
              ))}
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}

export default BranchNavBar;