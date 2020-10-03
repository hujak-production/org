import React from 'react';
import { useParams } from 'react-router-dom';
import {
  Typography,
  Chip,
  Divider,
  makeStyles
} from '@material-ui/core';
import { Today } from '@material-ui/icons';
import Employees from './Employees';

/**
 * Component styles.
 *
 * @type {(props?: any) => ClassNameMap<string>}
 */
const useStyles = makeStyles((theme) => ({
  title: {
    textTransform: 'uppercase',
    display: 'flex',
    alignItems: 'center',
    marginBottom: 15
  },
  date: {
    marginLeft: 15,
    fontSize: '16px'
  }
}));

/**
 * Company description component.
 *
 * @param props
 * @return React.ReactNode
 * @constructor
 */
const Company = (props) => {
  const { id } = useParams();
  const company = props.companies ? props.companies.find(company => company.id === parseInt(id)) : null;
  const classes = useStyles();

  console.log(company);

  if (company) {
    return (
      <div>
        <Typography
          color='primary'
          variant='h4'
          component='h2'
          className={ classes.title }
        >
          { company.name }
          <Chip
            icon={ <Today/> }
            label={ `${company.establishmentYear}` }
            color='primary'
            className={ classes.date }
          />
        </Typography>
        <Divider/>
        <Employees employees={ company.employees }/>
      </div>
    );
  }
  else {
    return null;
  }
};

export default Company;