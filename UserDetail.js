import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';

const UserDetail = () => {
  const { userid } = useParams();

  const [userData, setUserData] = useState({})

  useEffect(() => {
    console.log(userid);
    fetch("http://localhost:21384/api/User/GetUserViewById/" + userid).then((res) => {
      return res.json();
    }).then((resp) => {
      setUserData(resp);
    }).catch((err) => {
      console.error(err.message);
    });

  }, []);
 if(userData[0]!=null)
 {
    return (
      <div className="container mt-4 details_wrapper ">
        <div className="card">
          <div className="card-header bg-primary text-white">
            <h2>User Details</h2>
          </div>
          <div className="card-body">
            {userData &&
              <table className="table">
                <tbody>
                  <tr>
                    <td>User First Name:</td>
                    <td>{userData[0].firstName}</td>
                  </tr>
                  <tr>
                    <td>User Id:</td>
                    <td>{userData[0].userId}</td>
                  </tr>
                  <tr>
                    <td>User Last Name:</td>
                    <td>{userData[0].lastName}</td>
                  </tr>
                  <tr>
                    <td>User Address:</td>
                    <td>{userData[0].address}</td>
                  </tr>
                  <tr>
                    <td>User Mobile Number:</td>
                    <td>{userData[0].mobileNumber}</td>
                  </tr>
                  <tr>
                    <td>User Role:</td>
                    <td>{userData[0].roleName}</td>
                  </tr>
                  <tr>
                    <td>User Department:</td>
                    <td>{userData[0].departmentName}</td>
                  </tr>
                  <tr>
                    <td>User Manager:</td>
                    <td>{userData[0].managerName}</td>
                  </tr>
                </tbody>
              </table>
            }
            <div className="clearfix"></div>
            <Link className="btn btn-danger" to="/">
              Back to Dashboard
            </Link>
          </div>
        </div>
      </div>



    )

  }

}

export default UserDetail