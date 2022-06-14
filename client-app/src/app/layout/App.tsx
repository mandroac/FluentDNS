import { observer } from 'mobx-react-lite';
import React, { Fragment, useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Container } from 'semantic-ui-react';
import ProfilePage from '../../features/account/ProfilePage';
import SignUpSignInForm from '../../features/account/SignUpSignInForm';
import HomePage from '../../features/home/HomePage';
import RegisterDomainPage from '../../features/home/RegisterDomainPage';
import { useStore } from '../stores/store';
import LoadingComponent from './LoadingComponent';
import NavBar from './NavBar';

function App() {
  const {commonStore, userStore} = useStore();

  useEffect(() => {
    commonStore.token 
      ? userStore.getUser().finally(() => commonStore.setAppLoaded()) 
      : commonStore.setAppLoaded();
  }, [commonStore, userStore])

  if(!commonStore.appLoaded) return <LoadingComponent content='Loading app...' />
  return (
    <>
      <NavBar />
      <Container style={{ padding: '7em 0 4em 0' }} >
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='*' element={<HomePage />} />
          <Route path='login' element={<SignUpSignInForm />}/>
          <Route path='register' element={userStore.isLoggedIn ? <RegisterDomainPage /> : <SignUpSignInForm /> }/>
          <Route path='profile' element={userStore.isLoggedIn ? <ProfilePage /> : <SignUpSignInForm /> } />
        </Routes>
      </Container>

    </>
  );
}

export default observer(App);