import React, { useState } from "react";
import { Form, Button, Alert } from "react-bootstrap";
import { useNavigate } from 'react-router-dom';
import "./Login.css";
import { jwtDecode } from "jwt-decode";
const Login = () => {
  const [inputUsername, setInputUsername] = useState("");
  const [inputPassword, setInputPassword] = useState("");
  const [show, setShow] = useState(false);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

//   const history = useHistory();
    const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);

    const userData = {
      email: inputUsername,
      password: inputPassword
    };

    try {
        const response = await fetch("http://localhost:21384/api/Login/Login", {
          method: "POST",
          headers: {
            "Content-Type": "application/json"
          },
          body: JSON.stringify(userData)
        });

        if (response.ok) {
          const data = await response.json();
          localStorage.setItem("token", data.token);
          const decodedToken = jwtDecode(data.token);
          const userRole = decodedToken.role;

          console.log("Login successful");
            debugger;
          switch (userRole) {
            case "Admin":

            navigate("/user/showuser");
              break;
            case "Employee":
                navigate("/user/showuser");
            //   history.push("/user/dashboard");
              break;
            default:

            //   history.push("/default/dashboard");
              break;
          }
        } else {
          setShow(true);
        }
      } catch (error) {
        console.error("Error:", error);
      }

      setLoading(false);
    };


  return (
    <div
      className="sign-in__wrapper">
      <div className="sign-in__backdrop"></div>
      <Form className="shadow p-4 bg-white rounded" onSubmit={handleSubmit}>
        <div className="h4 mb-2 text-center">Sign In</div>
        {show ? (
          <Alert
            className="mb-2"
            variant="danger"
            onClose={() => setShow(false)}
            dismissible
          >
            Incorrect email or password.
          </Alert>
        ) : (
          <div />
        )}
        <Form.Group className="mb-2" controlId="email">
          <Form.Label>Email</Form.Label>
          <Form.Control
            type="email"
            value={inputUsername}
            placeholder="Email"
            onChange={(e) => setInputUsername(e.target.value)}
            required
          />
        </Form.Group>
        <Form.Group className="mb-2" controlId="password">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            value={inputPassword}
            placeholder="Password"
            onChange={(e) => setInputPassword(e.target.value)}
            required
          />
        </Form.Group>
        <Form.Group className="mb-2" controlId="checkbox">
          <Form.Check type="checkbox" label="Remember me" />
        </Form.Group>
        {!loading ? (
          <Button className="w-100" variant="primary" type="submit">
            Log In
          </Button>
        ) : (
          <Button className="w-100" variant="primary" type="submit" disabled>
            Logging In...
          </Button>
        )}
      </Form>
    </div>
  );
};

export default Login;