import { Footer } from './components/footer/Footer';
import { Header } from './components/header/Header';
import styles from './App.module.css'; 
import { Routes, Route, BrowserRouter } from 'react-router-dom';
import { Login } from './pages/login/Login';
import { Announcements } from './pages/announcements/Announcements';

export const App = () => (
  <BrowserRouter>
  <div className={styles.appContainer}>
    <Header />
      <Routes>
      <Route path="/" element={<Login/>} />
      <Route path="/announcements" element={<Announcements/>} />
    </Routes>
    <Footer />
  </div>
  </BrowserRouter>
);

export default App;
