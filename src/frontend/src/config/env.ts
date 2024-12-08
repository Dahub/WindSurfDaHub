// API configuration
const DEFAULT_API_URL = 'http://localhost:5000';

export const API_CONFIG = {
    BASE_URL: (typeof import.meta.env.VITE_API_URL === 'string' ? import.meta.env.VITE_API_URL : DEFAULT_API_URL),
    ENDPOINTS: {
        LOGIN: '/api/users/login',
        REGISTER: '/api/users',
    }
} as const;
