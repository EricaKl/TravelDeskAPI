import React, { useEffect, useState, } from 'react';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrashAlt, faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import NewTravelRequest from './NewTravelRequest';
import 'bootstrap/dist/css/bootstrap.min.css';

import "./ShowUser.css";

const ShowUSer = () => {
    const [userData, setUserData] = useState(null);
    const [userRole, setUserRole] = useState('');
    const [showNewTravelRequestForm, setShowNewTravelRequestForm] = useState(false);
    const navigate = useNavigate();
    const [currentPage, setcurrentPage] = useState(1);
    const recordsPerPage = 5;
    const lastIndex = currentPage * recordsPerPage;
    const firstIndex = lastIndex - recordsPerPage;

    const handleNewTravelRequestClick = () => {
        setShowNewTravelRequestForm(true);
    };

    const EditFunction = (id) => {
        navigate("/user/edit/" + id)
    };

    const RemoveFunction = (id) => {
        if (window.confirm("Are you sure you want to remove?")) {
            fetch("http://localhost:21384/api/User/Delete/" + id, {
                method: "DELETE"
            }).then(() => {
                window.location.reload();
                alert(`Removed Successfully"`);
            }).catch((err) => {
                console.error(err.message);
            })
        }
    };



    const DetailFunction = (id) => {
        navigate("/user/detail/" + id)
    };

    const prePage = () => {
        if (currentPage > 1) {
            setcurrentPage(currentPage - 1);
        }
    };

    const changeCPage = (e) => {
        setcurrentPage(Number(e.target.textContent));
    };

    const nextPage = () => {
        if (currentPage < Math.ceil(userData.length / recordsPerPage)) {
            setcurrentPage(currentPage + 1);
        }
    };
    

    useEffect(() => {
        const myToken = localStorage.getItem('token');
        if (myToken) {
            const bearer = 'Bearer ' + myToken;
            fetch('http://localhost:21384/api/User/GetUserView', {
                method: 'GET',
                headers: {
                    Authorization: bearer
                }
            })
                .then((res) => res.json())
                .then((res) => {
                    setUserData(res);
                    const decodedToken = jwtDecode(myToken);
                    setUserRole(decodedToken.role);
                    // setUserRole(res.roleName);
                })
                .catch((err) => {
                    console.error(err.message);
                });
        }
    }, []);

    // if (!tokenReceived) {
    //     return (
    //         <div className="container">
    //             <h2>Permission Denied</h2>
    //         </div>
    //     );
    // }
    debugger;
    return (
        <div className='container showUSer-container'>
            {
                userRole == "Admin" ? (
                    <div className='card show-all-card'>
                        <div className='card-title showTable-title'>
                            {/* <h2> All Users</h2> */}
                        </div>
                        <div className='card-body'>
                            <div className='addNew-btn'>
                                <Link to="user/create" className="btn btn-success">Add New (+)</Link>
                            </div>
                            <table className='table table-striped'>
                                <thead >
                                    <tr>
                                        <td className='text-white bg-dark'>Id</td>
                                        <td className='text-white bg-dark'>First Name</td>
                                        <td className='text-white bg-dark'>Last Name</td>
                                        <td className='text-white bg-dark'>Role</td>
                                        <td className='text-white bg-dark'>Department</td>
                                        <td className='text-white bg-dark'>Manager Name</td>
                                        <td className='text-white bg-dark'>Action</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        userData &&
                                      userData.slice(firstIndex, lastIndex).map(item => (
                                            <tr key={item.id}>
                                                <td>{item.userId}</td>
                                                <td>{item.firstName}</td>
                                                <td>{item.lastName}</td>
                                                <td>{item.roleName}</td>
                                                <td>{item.departmentName}</td>
                                                <td>{item.managerName}</td>
                                                <td>
                                                    <a onClick={() => { EditFunction(item.userId) }} 
                                                    className='btn  btn-outline-dark'>
                                                        <FontAwesomeIcon icon={faEdit} />
                                                    </a>
                                                    <a onClick={() => { RemoveFunction(item.userId) }}
                                                     className='btn btn-outline-danger'>
                                                        <FontAwesomeIcon icon={faTrashAlt} />
                                                    </a>
                                                    <a onClick={() => { DetailFunction(item.userId) }}
                                                     className='btn btn-outline-primary'>
                                                        <FontAwesomeIcon icon={faInfoCircle} />
                                                    </a>
                                                </td>
                                            </tr>
                                        ))}
                                </tbody>
                            </table>
                               <nav>
                        <ul className='pagination'>
                            <li className='page-item'>
                                <a href="#" className='page-link' onClick={prePage}> Prev</a>
                            </li>
                            {userData && Array.from({ length: Math.ceil(userData.length / recordsPerPage) }).map((_, i) => (
                                <li className={`page-item ${currentPage === i + 1 ? 'active' : ''}`} key={i}>
                                    <a href="#" className='page-link' onClick={changeCPage}>{i + 1}</a>
                                </li>
                            ))}
                             <li className='page-item'>
                                <a href="#" className='page-link' onClick={nextPage}> Next</a>
                            </li>
                        </ul>
                    </nav>
                        </div>
                    </div>
                ) : userRole == "Employee" ? (
                    <div>
                        <button className="btn btn-success" onClick={handleNewTravelRequestClick}>
                            New Travel Request
                        </button>
                        
                    </div>
                     
                ) :(
                    <div>
                        <h2>Permission Denied</h2>
                    </div>
                )
            }   
            {showNewTravelRequestForm && <NewTravelRequest/>}

        </div>
    )
}

export default ShowUSer