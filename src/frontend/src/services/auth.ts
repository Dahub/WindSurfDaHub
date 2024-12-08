import axios from 'axios';
import { API_CONFIG } from '@/config/env';

const API_URL = 'http://localhost:5000/api'; // Adjust this URL to match your backend API

export interface LoginCredentials {
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  username: string;
}

const auth = {
  async login(credentials: LoginCredentials): Promise<AuthResponse> {
    try {
      const response = await axios.post(`${API_CONFIG.BASE_URL}${API_CONFIG.ENDPOINTS.LOGIN}`, credentials);
      const { token, username } = response.data;
      
      // Store the token
      localStorage.setItem('token', token);
      localStorage.setItem('username', username);
      
      return { token, username };
    } catch (error: any) {
      if (error.response?.status === 401) {
        throw new Error('Email ou mot de passe incorrect');
      }
      if (error.response?.data?.message) {        
        throw new Error(error.response.data.message);
      }
      throw new Error('Une erreur est survenue lors de la connexion');
    }
  },

  async register(email: string, username: string, password: string): Promise<void> {
    try {
      await axios.post(`${API_CONFIG.BASE_URL}${API_CONFIG.ENDPOINTS.REGISTER}`, {
        email,
        username,
        password
      });
    } catch (error: any) {
      if (error.response?.status === 400) {
        throw new Error(error.response.data.message || 'Données d\'inscription invalides');
      }
      if (error.response?.data?.message) {        
        throw new Error(error.response.data.message);
      }
      throw new Error('Une erreur est survenue lors de l\'inscription');
    }
  },

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
  },

  getCurrentUser() {
    const token = localStorage.getItem('token');
    const username = localStorage.getItem('username');
    return token ? { token, username } : null;
  },

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }
};

export default auth;
