import React, { useEffect } from 'react';
import { Box, Card, CardActionArea, CardContent, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';

// Function to decode JWT
function jwt_decode(token) {
    if (!token) return {};
    let base64Url = token.split('.')[1];
    let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    let jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

// Define the Menu component using cards
const Menu = ({ groupName, onAddBranch, onUpdateBranch, onViewDashboard }) => (
    <Box sx={{ padding: 2, display: 'flex', flexDirection: 'column', gap: 2 }}>
        <Typography variant="h2" color="text.secondary" align="center">
            Hi, {groupName} Group
        </Typography>
        <Typography variant="h4" color="text.secondary" align="center">
            What would you like to do today?
        </Typography>
        <Card onClick={onAddBranch} sx={{ cursor: 'pointer' }}>
            <CardActionArea>
                <CardContent>
                    <Typography variant="h6">Add Branch</Typography>
                    <Typography variant="body2" color="textSecondary">
                        Add a new branch to the hotel group.
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
        <Card onClick={onUpdateBranch} sx={{ cursor: 'pointer' }}>
            <CardActionArea>
                <CardContent>
                    <Typography variant="h6">Update Branch</Typography>
                    <Typography variant="body2" color="textSecondary">
                        Update information of an existing branch.
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
        <Card onClick={onViewDashboard} sx={{ cursor: 'pointer' }}>
            <CardActionArea>
                <CardContent>
                    <Typography variant="h6">View Dashboard</Typography>
                    <Typography variant="body2" color="textSecondary">
                        View the dashboard to see an overview of your branches.
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
        {/* Uncomment and implement logout functionality if needed */}
        {/* <Card onClick={onLogout} sx={{ cursor: 'pointer' }}>
            <CardActionArea>
                <CardContent>
                    <Typography variant="h6">Logout</Typography>
                    <Typography variant="body2" color="textSecondary">
                        Logout from your account.
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card> */}
    </Box>
);

// Define the HotelBranchAccountManagement component
const HotelBranchAccountManagement = () => {
    const navigate = useNavigate();

    // Check for token and redirect if not present
    useEffect(() => {
        const token = localStorage.getItem('group-token');
        if (!token) {
            console.log('Token not found, redirecting to login');   
            navigate('/hotelgroup/group/group-login');
        }
    }, [navigate]);

    // Get the token and decode it
    const token = localStorage.getItem('group-token');
    const tokenDecoded = jwt_decode(token);
    const groupName = tokenDecoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] || 'Guest';

    // Handler for Add Branch
    const handleAddBranch = () => {
        navigate('/hotelgroup/group/add-branch');
    };

    // Handler for Update Branch
    const handleUpdateBranch = () => {
        navigate('/hotelgroup/group/update-branch');
    };

    // Handler for View Dashboard
    const handleViewDashboard = () => {
        navigate('/hotelgroup/group/groupdashboard');
    };

    // Handler for Logout
    // const handleLogout = () => {
    //     // Perform logout logic here, e.g., clearing tokens, etc.
    //     localStorage.removeItem('group-token'); // Clear token
    //     navigate('/login'); // Redirect to login
    // };

    return (
        <Menu
            groupName={groupName}
            onAddBranch={handleAddBranch}
            onUpdateBranch={handleUpdateBranch}
            onViewDashboard={handleViewDashboard}
            // onLogout={handleLogout}
        />
    );
};

export default HotelBranchAccountManagement;
