import React from 'react';
import {
  Typography,
  Table,
  TableBody,
  TableHead,
  TableCell,
  TableRow,
  IconButton,
  Button,
  makeStyles
} from '@material-ui/core';
import { Edit, Delete } from '@material-ui/icons';

/**
 * Component styles.
 *
 * @type {(props?: any) => ClassNameMap<string>}
 */
const useStyles = makeStyles((theme) => ({
  employees: {
    margin: '15px 0',
  },
  table: {
    marginTop: 15,
  },
  head: {
    backgroundColor: theme.palette.primary.main,
  },
  headCell: {
    color: theme.palette.common.white
  },
  addEmployeeBtn: {
    marginLeft: 15
  },
  deleteCompanyBtn: {
    backgroundColor: theme.palette.error.main,
    color: theme.palette.common.white,
    marginTop: 15
  }
}));

/**
 * Company description component.
 *
 * @param props
 * @return React.ReactNode
 * @constructor
 */
const Employees = (props) => {
  const { employees } = props;
  const classes = useStyles();

  return (
    <div className={ classes.employees }>
      <Typography
        variant='h5'
        component='h3'
      >
        Employees:
        <Button
          color='primary'
          variant='contained'
          className={ classes.addEmployeeBtn }>
          Add Employee
        </Button>
      </Typography>
      <Table aria-label="simple table" className={ classes.table }>
        <TableHead className={ classes.head }>
          <TableRow>
            <TableCell className={ classes.headCell }>Name</TableCell>
            <TableCell className={ classes.headCell }>Surname</TableCell>
            <TableCell className={ classes.headCell }>Birthday</TableCell>
            <TableCell className={ classes.headCell }>Job title</TableCell>
            <TableCell className={ classes.headCell }>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {
            employees.map(employee => <TableRow key={ employee.id }>
              <TableCell>{ employee.firstName }</TableCell>
              <TableCell>{ employee.lastName }</TableCell>
              <TableCell>{ employee.dateOfBirth }</TableCell>
              <TableCell>{ employee.jobTitle }</TableCell>
              <TableCell>
                <IconButton>
                  <Edit/>
                </IconButton>
                <IconButton>
                  <Delete/>
                </IconButton>
              </TableCell>
            </TableRow>)
          }
        </TableBody>
      </Table>
      <Button
        variant='contained'
        className={ classes.deleteCompanyBtn }>
        Delete company
      </Button>
    </div>
  );
};

export default Employees;