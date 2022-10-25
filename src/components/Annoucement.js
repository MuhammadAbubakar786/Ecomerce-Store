import React from "react";
import styled from "styled-components";

const Container = styled.div`
  height: 30px;
  background-color: teal;
  color: #fff;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 500;
  font-size: 14;
`;
const Annoucement = () => {
  return <Container>Super Deal! Free Shipping on Order Over $50</Container>;
};

export default Annoucement;
