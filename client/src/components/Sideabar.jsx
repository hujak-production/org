import React from 'react';
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Typography,
  Divider
} from '@material-ui/core';
import { Add } from '@material-ui/icons';
import { makeStyles } from '@material-ui/core/styles';

import ListItemLink from './ListItemLink';

const drawerWidth = 320;

/**
 * Component styles.
 *
 * @type {(props?: any) => ClassNameMap<string>}
 */
const useStyles = makeStyles((theme) => ({
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
  },
  addIcon: {
    fontSize: '1.75em',
  },
  addBtn: {
    textTransform: 'uppercase',
    fontSize: '1em',
    fontWeight: 600,
  },
  button: {
    textTransform: 'uppercase',
    fontSize: '1em',
    fontWeight: 600,
  },
  list: {
    padding: 0
  },
  activeButton: {
    backgroundColor: '#3f57b552 !important'
  }
}));

/**
 * Sidebar component.
 *
 * @param props
 * @return React.ReactNode
 * @constructor
 */
const Sidebar = (props) => {

  const classes = useStyles();

  /**
   * Returns path to company route.
   *
   * @param id
   * @return {string}
   */
  const buildPath = (id) => {
    return `/company/${id}`;
  };

  return (
    <Drawer
      variant='temporary'
      onClose={ () => props.setOpen(false) }
      open={ props.open }
      className={ classes.drawer }
      classes={ {
        paper: classes.drawerPaper,
      } }
    >
      <List className={ classes.list }>
        <ListItem button className={ props.history.location.pathname === '/add' ? classes.activeButton : null }>
          <ListItemIcon><Add color='primary' className={ classes.addIcon }/></ListItemIcon>
          <ListItemText>
            <Typography color='primary' variant="h6" component='p' className={ classes.addBtn }>Add Company</Typography>
          </ListItemText>
        </ListItem>
        <Divider/>
        {
          props.companies ? props.companies.map(company => <ListItemLink
            key={ company.id }
            to={ buildPath(company.id) }
            className={ classes.button }
            active={props.history.location.pathname === buildPath(company.id) ? classes.activeButton : null}
            handleClick={() => props.setOpen(false)}
            text={ company.name }
            onClick={ () => {
              props.setOpen(false);
            } }/>) : null
        }
      </List>
    </Drawer>
  );
};

export default Sidebar;