import React, { useEffect, useState } from 'react';
import { getLiteAnnouncements } from '../../services/announcementService';
import styles from './Announcements.module.css';

export function Announcements() {
  const [announcements, setAnnouncements] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    getLiteAnnouncements()
    .then(data => {
      setAnnouncements(data);
    })
    .catch(err => {
      setError(err.message || 'Failed to fetch announcements');
    })}, []);

  return (
    <div>
      <h2>Announcements</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <ul>
        {announcements.map(({ id, title, description }) => (
          <li key={id} className={styles.listItem}>
            <h3>{title}</h3>
            <p>{description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}