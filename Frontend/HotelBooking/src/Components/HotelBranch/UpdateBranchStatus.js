import React, { useState, useEffect } from 'react';
import { jwt_decode } from '../HotelGroup/GuestToken';
import { Card, CardContent, Typography, Switch, Button, TextField, Container, Grid } from '@mui/material';
import dayjs from 'dayjs';

const UpdateBranchStatus = () => {
    const [isAvailable, setIsAvailable] = useState(true);
    const [plannedClosureFrom, setPlannedClosureFrom] = useState(dayjs().format('YYYY-MM-DDTHH:mm'));
    const [plannedClosureTo, setPlannedClosureTo] = useState(dayjs().format('YYYY-MM-DDTHH:mm'));
    const [fetchedStatus, setFetchedStatus] = useState({
        isAvailable: true,
        plannedClosureFrom: dayjs().format('YYYY-MM-DDTHH:mm'),
        plannedClosureTo: dayjs().format('YYYY-MM-DDTHH:mm')
    });
    const [hotelBranchId, setHotelBranchId] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const fetchBranchStatus = async () => {
        try {
            const token = localStorage.getItem('branch-token');
            if (!token) {
                throw new Error('No token found');
            }

            const decodedToken = jwt_decode(token);
            const branchId = decodedToken.hotelBranchId;
            setHotelBranchId(branchId);

            const response = await fetch(`https://localhost:7233/api/HotelManagement/GetBranchStatus?branchId=${branchId}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const data = await response.json();
            setFetchedStatus({
                isAvailable: data.isAvailable,
                plannedClosureFrom: data.plannedClosureFrom,
                plannedClosureTo: data.plannedClosureTo
            });
            setIsAvailable(data.isAvailable);
            setPlannedClosureFrom(data.plannedClosureFrom);
            setPlannedClosureTo(data.plannedClosureTo);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchBranchStatus(); // Initial fetch
    }, []); // Empty dependency array ensures this effect runs only on mount

    const handleSwitchChange = (event) => {
        setIsAvailable(event.target.checked);
    };

    const handlePlannedClosureFromChange = (event) => {
        setPlannedClosureFrom(event.target.value);
    };

    const handlePlannedClosureToChange = (event) => {
        setPlannedClosureTo(event.target.value);
    };

    const handleUpdateClick = async () => {
        try {
            if (!hotelBranchId) {
                throw new Error('Branch ID is not available');
            }

            const response = await fetch('https://localhost:7233/api/HotelManagement/UpdateBranchStatus', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('branch-token')}`
                },
                body: JSON.stringify({
                    hotelBranchId: hotelBranchId,
                    isAvailable: isAvailable,
                    availableRooms: 0,
                    bookedRooms: 0,
                    plannedClosureFrom: plannedClosureFrom,
                    plannedClosureTo: plannedClosureTo,
                    lastUpdated: new Date().toISOString(),
                    hotelBranch: {
                        hotelBranchId: hotelBranchId,
                        hotelGroupId: 0,
                        hotelGroup: {
                            hotelGroupId: 0,
                            hotelGroupName: 'string',
                            hotelGroupManagerName: 'string',
                            hotelGroupEmail: 'string',
                            hotelGroupPhone: 'string'
                        },
                        hotelBranchName: 'string',
                        hotelType: 0,
                        hotelBranchManager: 'string',
                        hotelBranchEmail: 'string',
                        hotelBranchPhone: 'string'
                    }
                }),
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const data = await response.json();
            console.log('Branch status updated:', data);

            // Refresh the current status after update
            await fetchBranchStatus();
        } catch (err) {
            setError(err.message);
        }
    };

    const handleFetchStatusClick = () => {
        setLoading(true);
        fetchBranchStatus();
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    const now = dayjs();
    const isClosureExpired = dayjs(fetchedStatus.plannedClosureFrom).isBefore(now) && dayjs(fetchedStatus.plannedClosureTo).isBefore(now);

    return (
        <Container>
            <Typography variant="h4" gutterBottom>
                Update Branch Status
            </Typography>
            <Grid container spacing={3}>
                <Grid item xs={12} md={6}>
                    <Card style={{ backgroundColor: '#f5f5f5' }}>
                        <CardContent>
                            <Typography variant="h6">Current Status</Typography>
                            <Typography variant="body1">Status: {fetchedStatus.isAvailable ? 'Available' : 'Not Available'}</Typography>
                            {isClosureExpired ? (
                                <Typography variant="body1">No Planned Closure</Typography>
                            ) : (
                                <>
                                    <Typography variant="body1">Planned Closure From: {new Date(fetchedStatus.plannedClosureFrom).toLocaleString()}</Typography>
                                    <Typography variant="body1">Planned Closure To: {new Date(fetchedStatus.plannedClosureTo).toLocaleString()}</Typography>
                                </>
                            )}
                            <Button
                                variant="contained"
                                color="primary"
                                onClick={handleFetchStatusClick}
                                style={{ marginTop: '16px' }}
                            >
                                Fetch Status
                            </Button>
                        </CardContent>
                    </Card>
                </Grid>
                <Grid item xs={12} md={6}>
                    <Card style={{ backgroundColor: '#e3f2fd' }}>
                        <CardContent>
                            <Typography variant="h6">Update Status</Typography>
                            <div>
                                <Typography variant="body1">Is Available:</Typography>
                                <Switch
                                    checked={isAvailable}
                                    onChange={handleSwitchChange}
                                    color="primary"
                                />
                            </div>
                            <div style={{ marginTop: '16px' }}>
                                <TextField
                                    label="Planned Closure From"
                                    type="datetime-local"
                                    value={plannedClosureFrom}
                                    onChange={handlePlannedClosureFromChange}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                    fullWidth
                                    InputProps={{
                                        inputProps: { min: dayjs().format('YYYY-MM-DDTHH:mm') }
                                    }}
                                />
                            </div>
                            <div style={{ marginTop: '16px' }}>
                                <TextField
                                    label="Planned Closure To"
                                    type="datetime-local"
                                    value={plannedClosureTo}
                                    onChange={handlePlannedClosureToChange}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                    fullWidth
                                    InputProps={{
                                        inputProps: { min: dayjs().format('YYYY-MM-DDTHH:mm') }
                                    }}
                                />
                            </div>
                            <Button
                                variant="contained"
                                color="primary"
                                onClick={handleUpdateClick}
                                style={{ marginTop: '16px' }}
                            >
                                Update Status
                            </Button>
                        </CardContent>
                    </Card>
                </Grid>
            </Grid>
        </Container>
    );
};

export default UpdateBranchStatus;
