import tailwindcss from '@tailwindcss/vite'
import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), tailwindcss()],
  server: {
    port: 5173,
    // Em dev, /api/* é repassado para a API .NET: o front chama caminhos relativos
    proxy: {
      '/api': 'http://localhost:5080',
    },
  },
})
