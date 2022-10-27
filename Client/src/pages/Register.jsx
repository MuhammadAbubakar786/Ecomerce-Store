import { useFormik } from "formik";
import { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import styled from "styled-components";
import { SignUp as SignUpAction } from "../Api/SignUp";
import {
  InitialValues,
  validationSchema,
} from "../FormValidations/SignUpSchema";
import useAuth from "../Hooks/useAuth";
import { mobile } from "../responsive";
const USER_TYPE = {
  CUSTOMER: "Customer",
  SELLLER: "Seller",
};
const LOGIN_SOURCE = {
  GMAIL: "Gmail",
  FACEBOOK: "Facebook",
  MANUAL: "Manual",
};
const Container = styled.div`
  width: 100vw;
  height: 100vh;
  background: linear-gradient(
      rgba(255, 255, 255, 0.5),
      rgba(255, 255, 255, 0.5)
    ),
    url("https://images.pexels.com/photos/6984661/pexels-photo-6984661.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940")
      center;
  background-size: cover;
  display: flex;
  align-items: center;
  justify-content: center;
`;

const Wrapper = styled.div`
  width: 40%;
  padding: 20px;
  background-color: white;
  ${mobile({ width: "75%" })}
`;

const Title = styled.h1`
  font-size: 24px;
  font-weight: 300;
`;

const Form = styled.form`
  display: flex;
  flex-wrap: wrap;
`;

const Input = styled.input`
  flex: 1;
  min-width: 90%;
  padding: 10px;
`;

const Agreement = styled.span`
  font-size: 12px;
  margin: 20px 0px;
`;

const Button = styled.button`
  width: 40%;
  border: none;
  padding: 15px 20px;
  background-color: teal;
  color: white;
  cursor: pointer;
`;
const ErrorMessageText = styled.p`
  color: red;
  font-size: 12px;
`;
const Register = () => {
  const { setAuth } = useAuth();
  const navigate = useNavigate();
  const location = useLocation();
  const from = location.state?.from?.pathname || "/";
  const [UserType, setUserType] = useState(USER_TYPE.CUSTOMER);

  const formik = useFormik({
    initialValues: InitialValues,
    validationSchema: validationSchema,
    onSubmit: (values, { resetForm }) => {
      const SignUpUser = {
        FirstName: values.firstname,
        LastName: values.lastName,
        UserName: values.username,
        Email: values.email,
        Password: values.password,
        ConfirmPassword: values.password,
        Source: LOGIN_SOURCE.MANUAL,
        EmailVerified: false,
        Role: UserType,
      };
      SignUpAction(SignUpUser)
        .then((response) => {
          if (response.status === 200) {
            const accessToken = response?.data?.token;
            const roles = response?.data?.userRoles?.$values;
            const user = response?.data?.key;
            setAuth({ user, roles, accessToken });
            navigate(from, { replace: true });
          }
        })
        .catch((error) => {
          console.log("error", error);
        });
    },
  });
  return (
    <Container>
      <Wrapper>
        <Title>CREATE AN ACCOUNT</Title>
        <Form onSubmit={formik.handleSubmit}>
          <div style={{ width: "100%" }}>
            <Input
              placeholder="First Name"
              type="text"
              name="firstname"
              onChange={formik?.handleChange}
              value={formik?.values?.firstname}
            />
            <ErrorMessageText>
              {formik.touched.firstname && formik.errors.firstname ? (
                <div className="text-red-500">{formik.errors.firstname}</div>
              ) : null}
            </ErrorMessageText>
          </div>
          <div style={{ width: "100%" }}>
            <Input
              placeholder="last name"
              type="text"
              name="lastname"
              onChange={formik?.handleChange}
              value={formik?.values?.lastname}
            />
            <ErrorMessageText>
              {formik.touched.lastname && formik.errors.lastname ? (
                <div className="text-red-500">{formik.errors.lastname}</div>
              ) : null}
            </ErrorMessageText>
          </div>
          <div style={{ width: "100%" }}>
            <Input
              placeholder="username"
              type="text"
              name="username"
              onChange={formik?.handleChange}
              value={formik?.values?.username}
            />
            <ErrorMessageText>
              {formik.touched.username && formik.errors.username ? (
                <div className="text-red-500">{formik.errors.username}</div>
              ) : null}
            </ErrorMessageText>
          </div>
          <div style={{ width: "100%" }}>
            <Input
              type="email"
              placeholder="email"
              name="email"
              onChange={formik?.handleChange}
              value={formik?.values?.email}
            />
            <ErrorMessageText>
              {formik.touched.email && formik.errors.email ? (
                <div className="text-red-500">{formik.errors.email}</div>
              ) : null}
            </ErrorMessageText>
          </div>
          <div style={{ width: "100%" }}>
            <Input
              type="password"
              placeholder="password"
              name="password"
              onChange={formik?.handleChange}
              value={formik?.values?.password}
            />
            <ErrorMessageText>
              {formik.touched.password && formik.errors.password ? (
                <div className="text-red-500">{formik.errors.password}</div>
              ) : null}
            </ErrorMessageText>
          </div>
          <div style={{ width: "100%" }}>
            <Input
              type="password"
              placeholder="confirm password"
              name="repeatPassword"
              onChange={formik?.handleChange}
              value={formik?.values?.repeatPassword}
            />
            <ErrorMessageText>
              {formik.touched.repeatPassword && formik.errors.repeatPassword ? (
                <div className="text-red-500">
                  {formik.errors.repeatPassword}
                </div>
              ) : null}
            </ErrorMessageText>
          </div>
          <Agreement>
            By creating an account, I consent to the processing of my personal
            data in accordance with the <b>PRIVACY POLICY</b>
          </Agreement>
          <Button type="submit">CREATE</Button>
        </Form>
      </Wrapper>
    </Container>
  );
};

export default Register;
