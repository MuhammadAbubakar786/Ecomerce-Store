import { useSelector } from "react-redux";
import styled from "styled-components";
import { useAnnoucement } from "../Hooks/useAnnoucement";

const Container = styled.div`
  height: 30px;
  background-color: teal;
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 14px;
  font-weight: 500;
`;

const Announcement = () => {
  const { status, data, isFetching } = useAnnoucement();

  const data1 = useSelector((item) =>
    item.AnnoucementReducer.find((e) => e.active === true)
  );
  return <Container>{data1?.description ?? ""}</Container>;
};

export default Announcement;
