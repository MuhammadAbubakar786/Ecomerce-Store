import { useFormik } from "formik";
import { Link, useNavigate } from "react-router-dom";
import styled from "styled-components";
import { SignIn as SignInAction } from "../Api/SignUp";
import {
  InitialValues,
  validationSchema,
} from "../FormValidations/SignInSchema";
import useAuth from "../Hooks/useAuth";
import { mobile } from "../responsive";

const Container = styled.div`
  width: 100vw;
  height: 100vh;
  background: linear-gradient(
      rgba(255, 255, 255, 0.5),
      rgba(255, 255, 255, 0.5)
    ),
    url("https://images.pexels.com/photos/6984650/pexels-photo-6984650.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940")
      center;
  background-size: cover;
  display: flex;
  align-items: center;
  justify-content: center;
`;

const Wrapper = styled.div`
  width: 25%;
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
  flex-direction: column;
`;

const Input = styled.input`
  flex: 1;
  min-width: 40%;
  padding: 10px;
`;

const Button = styled.button`
  width: 40%;
  border: none;
  padding: 15px 20px;
  background-color: teal;
  color: white;
  cursor: pointer;
  margin-bottom: 10px;
`;

const LinkText = styled.p`
  margin: 5px 0px;
  font-size: 12px;
  text-decoration: underline;
  cursor: pointer;
`;
const ErrorMessageText = styled.p`
  color: red;
  font-size: 12px;
`;
const Login = () => {
  const { setAuth } = useAuth();
  const navigate = useNavigate();
  const from = "/DashBoard";
  const formik = useFormik({
    initialValues: InitialValues,
    validationSchema: validationSchema,
    onSubmit: (values, { resetForm }) => {
      const SignInUser = {
        Email: values.email,
        Password: values.password,
        ConfirmPassword: values.password,
      };
      SignInAction(SignInUser)
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
        <Title>SIGN IN</Title>
        <Form onSubmit={formik.handleSubmit}>
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
          <Button type="submit">LOGIN</Button>
          <LinkText>
            <Link to="" className="text-link">
              DO NOT YOU REMEMBER THE PASSWORD?
            </Link>
          </LinkText>
          <LinkText>
            <Link to="/Register" className="text-link">
              CREATE A NEW ACCOUNT
            </Link>
          </LinkText>
        </Form>
      </Wrapper>
    </Container>
  );
};

export default Login;
