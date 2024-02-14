import './App.css';
import Registration from './Components/Registration';
import Login from './Components/Login';
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import ShowUSer from './Components/ShowUSer';
import UserDetail from './Components/UserDetail';
import EditUser from './Components/EditUser';


function App() {
  return (
    <div className="App">
      {/* <h1>Travel App</h1> */}
      <BrowserRouter>
        <Routes>
        <Route path='/' exact element={<Login />}></Route>
          <Route path='/user/showuser' element={<ShowUSer />}>
          </Route>
          <Route path='/user/showuser/user/create' element={<Registration/>}></Route>
          <Route path="/user/detail/:userid" element={<UserDetail/>}> </Route>
          <Route path='/user/edit/:userid' element={<EditUser/>}></Route>
        </Routes>
      </BrowserRouter>
      {/* <Registration /> */}
      {/* <Login/> */}

    </div>
  );
}

export default App;
