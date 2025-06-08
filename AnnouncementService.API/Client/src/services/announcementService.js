export async function getAnnouncements() {
    const response = await fetch('/api/announcements/all', {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`, 
        },
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while fetching announcements');
    }
    
    return data;
}

export async function getLiteAnnouncements() {
    const response = await fetch('https://localhost:5000/api/announcements/lite', {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json',
        },
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while fetching lite announcements');
    }
    return data;
}

export async function getAnnouncementByTitle(title) {
    const response = await fetch(`/api/announcements/bytitle/${encodeURIComponent(title)}`, {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
        },
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while fetching announcement by title');
    }
    return data;
}

export async function getAnnouncementsByCreatorId(creatorId) {
    const response = await fetch(`/api/announcements/bycreator/${encodeURIComponent(creatorId)}`, {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
        },
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while fetching announcement by creator ID');
    }
    return data;
}

export async function getAnnouncementById(id){
    const response = await fetch(`/api/announcements/byid/${encodeURIComponent(id)}`, {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
},
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while fetching announcement by ID');
    }
    return data;
}

export async function getSimilarAnnouncements(id) {
    const response = await fetch(`/api/announcements/similar/${encodeURIComponent(id)}`, {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
        },
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while fetching similar announcements');
    }
    return data;
}

export async function createAnnouncement(title, description) {
    const response = await fetch('/api/announcements/create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`,
        },
        body: JSON.stringify({ title, description }),
    });
    if (!response.ok) {
        const data = await response.json();
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while creating announcement');
    }
    return true;
}

export async function updateAnnouncement(id, title, description) {
    const response = await fetch(`/api/announcements/update`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`,
        },
        body: JSON.stringify({ id, title, description }),
    });
    if (!response.ok) {
        const data = await response.json();
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while updating announcement');
    }
    
    return true;
}

export async function deleteAnnouncement(id) {
    const response = await fetch(`/api/announcements/delete/${encodeURIComponent(id)}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`,
        },
    });
    
    if (!response.ok) {
        const data = await response.json();
        throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred while deleting announcement');
    }
    return true;
}