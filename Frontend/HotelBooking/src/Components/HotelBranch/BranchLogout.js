import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const BranchLogout = () => {
    const navigate = useNavigate();
    const [isLoggedOut, setIsLoggedOut] = useState(false);

    useEffect(() => {
        if (isLoggedOut) {
            return;
        }

        const handleLogout = () => {
            const isConfirmed = window.confirm('Are you sure you want to logout?');
            
            if (isConfirmed) {
                localStorage.removeItem('branch-token');
                navigate('/hotelbranch/branch/branch-login', { replace: true });
                window.location.reload();
            } else {
                navigate(-1, { replace: true });
            }

            setIsLoggedOut(true);
        };

        handleLogout();
    }, [navigate, isLoggedOut]);

    return (
        <div>
            <h1>Logging out...</h1>
        </div>
    );
};

export default BranchLogout;
