import React, { useEffect, useState } from 'react';
import { Spinner } from 'reactstrap';
import './App.css';
import { ApplicationViews } from './ApplicationViews';
import { onLoginStatusChange } from './modules/AuthManager';

function App() {

  const [isLoggedIn, setIsLoggedIn] = useState(null)

  useEffect(()=>{
    onLoginStatusChange(setIsLoggedIn);
  },[])

  if (isLoggedIn === null) {
    return <Spinner className="app-spinner dark" />;
  }
  return (
    <div className="App">
     <ApplicationViews  />
    </div>
  );
}

export default App;
