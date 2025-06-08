export async function login(email, password) {
  const response = await fetch('https://localhost:5000/api/auth/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({ email, password }),
  });
  const data = await response.json();
  if (!response.ok) {
    throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred during login');
  }
  localStorage.setItem('token', data.token);
  return true;
}

export function logout() {
  localStorage.removeItem('token');
  window.location.href = '/';
}

export function getUserRoles() {
    const token = localStorage.getItem('token');
    if (!token) return [];

    const payload = JSON.parse(atob(token.split('.')[1])); 

    const roleKey = Object.keys(payload).find(key => key.includes("identity/claims/role"));
    const roleValue = roleKey ? payload[roleKey] : null;

    return Array.isArray(roleValue) ? roleValue : roleValue ? [roleValue] : [];
  }

  export async function register(email, userName, password) {
    const response = await fetch('https://localhost:5000/api/auth/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ email, password, userName }),
    })
    if (!response.ok) {
      const data = await response.json();
      throw new Error(data.errors?.join('\n') ?? 'Unknown error occurred during registration');
    }
    return true;
    };


  