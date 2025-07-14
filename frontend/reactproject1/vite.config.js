import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
    build: {
        outDir: 'dist', // ���ꂪ�ʂ̃t�H���_�ɂȂ��Ă��Ȃ����m�F
        emptyOutDir: true
    },
    plugins: [react()],
    root: '.',
    server: {
        host: '0.0.0.0',
        port: 5001,
    }
})
