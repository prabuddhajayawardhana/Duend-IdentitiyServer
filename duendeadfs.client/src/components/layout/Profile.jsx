import {  useAuth, withAuth } from 'oidc-react';
import { useEffect } from 'react';

function Profile() {
  const auth = useAuth();

  useEffect(() => {
    console.log(auth);
  });

  return <p>Hello {auth.profile}!</p>;
}

export default withAuth(Profile);