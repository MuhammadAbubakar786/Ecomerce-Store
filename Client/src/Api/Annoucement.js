import Axios from "../Apiconfig";
export const AddAnnoucement = async (Announcement) => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.post(`HomePage/AddAnnouncement`, Announcement, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
export const GetAnnoucements = async () => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.get(`HomePage/GetAnnouncement`, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
export const ActiveInActiveAnnoucement = async (Id, UserId) => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.post(
    `HomePage/ActiveAnnouncement?Id=${Id}&userId=${UserId}`,
    {
      headers: {
        "Content-Type": "application/json",
        withCredentials: true,
      },
    }
  );
};
export const AddBanner = async (Banner) => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.post(`HomePage/AddBanner`, Banner, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
export const DeleteBanner = async (Id) => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.post(`HomePage/DeleteBanner?Id=${Id}`, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
export const GetBanner = async () => {
  document.cookie = `StdBrowserId=2de1df70-94ec-4be5-835a-caef6b72e066`;
  return await Axios.get(`HomePage/GetBanner`, {
    headers: {
      "Content-Type": "application/json",
      withCredentials: true,
    },
  });
};
