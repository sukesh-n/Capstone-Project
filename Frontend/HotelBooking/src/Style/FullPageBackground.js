import React from 'react';
import { Box } from '@mui/material';
import { styled } from '@mui/system';

const GradientBackground = styled(Box)({
    position: 'fixed',     
    top: 0,
    left: 0,
    width: '100vw',        
    height: '100vh',       
    background: 'linear-gradient(90deg, rgba(235,246,255,1) 0%, rgba(202,253,255,1) 100%, rgba(255,0,0,1) 100%)',
    zIndex: -1,           
});

const FullPageBackground = () => {
    return (
        <GradientBackground />
    );
};

export default FullPageBackground;
