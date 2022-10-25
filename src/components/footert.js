import React from "react";
import styled from "styled-components";
const Container = styled.div`
  display: flex;
  background-color: #fbf5f5;
`;
const Left = styled.div`
  flex: 1;
`;
const Title = styled.h1``;
const Desc = styled.div`
  margin-bottom: 20px;
`;
const Center = styled.div`
  flex: 1;
`;
const Right = styled.div`
  flex: 1;
`;
const FooterT = () => {
  return (
    <Container>
      <Left>
        <Title>BOGO</Title>
        <Desc>
          There are many variations of passages of Lorem Ipsum available, but
          the majority have suffered alteration in some form, by injected
          humour, or randomised words which don’t look even slightly believable.
        </Desc>
      </Left>
      <Center></Center>
      <Right></Right>
    </Container>
  );
};

export default FooterT;
