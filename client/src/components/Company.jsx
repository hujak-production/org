import React from 'react';
import { useParams } from 'react-router-dom';

const Company = (props) => {
  const {id} = useParams();

  return (
    <h1>Company: {id}</h1>
  );
};

export default Company;