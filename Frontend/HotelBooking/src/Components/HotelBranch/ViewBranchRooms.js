import React, { useState, useEffect } from 'react';
import { jwt_decode } from '../HotelGroup/GuestToken'; // Make sure this path is correct
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';

const ViewBranchRooms = () => {
    const [rooms, setRooms] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchRooms = async () => {
            try {
                const token = localStorage.getItem('branch-token');
                if (!token) {
                    throw new Error('No token found');
                }

                // Decode token to get HotelBranchId
                const decodedToken = jwt_decode(token);
                console.log(decodedToken);
                const hotelBranchId = parseInt(decodedToken.hotelBranchId); // Adjust according to your token payload structure
                console.log(hotelBranchId);
                if (!hotelBranchId) {
                    throw new Error('HotelBranchId not found in token');
                }

                const response = await fetch(`https://localhost:7233/api/HotelManagement/GetHotelBranchRooms?hotelBranchId=${hotelBranchId}`, {
                    headers: {
                        Authorization: `Bearer ${token}`
                    },
                });

                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const data = await response.json();
                console.log(data);  
                setRooms(data);
            } catch (err) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchRooms();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;

    return (
        <TableContainer component={Paper}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Hotel Branch ID</TableCell>
                        <TableCell>Room Type ID</TableCell>
                        <TableCell>Room Type Name</TableCell>
                        <TableCell>Current Available Rooms</TableCell>
                        <TableCell>Number of Current Bookings</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rooms.map((room) => (
                        <TableRow key={`${room.hotelBranchId}-${room.roomTypeId}`}>
                            <TableCell>{room.hotelBranchId}</TableCell>
                            <TableCell>{room.roomTypeId}</TableCell>
                            <TableCell>{room.roomTypeName}</TableCell>
                            <TableCell>{room.currentAvailableRooms}</TableCell>
                            <TableCell>{room.noOfCurrentBookings}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default ViewBranchRooms;
