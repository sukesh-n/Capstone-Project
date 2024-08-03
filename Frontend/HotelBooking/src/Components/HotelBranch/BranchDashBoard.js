import React from 'react';
import { Typography, Card, CardActionArea, CardContent, Container, Box } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const BranchDashBoard = () => {
    const navigate = useNavigate();

    // Handler functions to navigate to different routes
    const onUpdateBranchDetails = () => {
        navigate('/hotelbranch/branch/update-branch-profile');
    };

    const onAddRoomTypeAndImages = () => {
        navigate('/hotelbranch/branch/add-room');
    };

    const onViewCurrentBookings = () => {
        navigate('/hotelbranch/branch/view-current-bookings');
    };

    return (
        <Container>
            <Typography variant="h4" gutterBottom style={{ marginTop: 16 }}>
                Branch Dashboard
            </Typography>
            <Box display="flex" flexDirection="column" gap={2}>
                <Card onClick={onUpdateBranchDetails} sx={{ cursor: 'pointer' }}>
                    <CardActionArea>
                        <CardContent>
                            <Typography variant="h6">Update Your Branch Details</Typography>
                            <Typography variant="body2" color="textSecondary">
                                Update your branch details including name and contact information.
                            </Typography>
                        </CardContent>
                    </CardActionArea>
                </Card>
                <Card onClick={onAddRoomTypeAndImages} sx={{ cursor: 'pointer' }}>
                    <CardActionArea>
                        <CardContent>
                            <Typography variant="h6">Add Room Type and Images</Typography>
                            <Typography variant="body2" color="textSecondary">
                                Add or modify room types and upload images for the branch.
                            </Typography>
                        </CardContent>
                    </CardActionArea>
                </Card>
                <Card onClick={onViewCurrentBookings} sx={{ cursor: 'pointer' }}>
                    <CardActionArea>
                        <CardContent>
                            <Typography variant="h6">View Current Bookings on Your Branch</Typography>
                            <Typography variant="body2" color="textSecondary">
                                View the dashboard to see an overview of current bookings.
                            </Typography>
                        </CardContent>
                    </CardActionArea>
                </Card>
            </Box>
        </Container>
    );
};

export default BranchDashBoard;
