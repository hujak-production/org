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

const drawerWidth = 320;
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
  }
}));

const Sidebar = (props) => {

  const classes = useStyles();

  return (
    <Drawer
      variant='temporary'
      onClose={() => props.setOpen(false)}
      open={props.open}
      className={classes.drawer}
      classes={{
        paper: classes.drawerPaper,
      }}
    >
      <List>
        <ListItem button>
          <ListItemIcon><Add color='primary' className={classes.addIcon}/></ListItemIcon>
          <ListItemText>
            <Typography color='primary' variant="h6" component='p' className={classes.addBtn}>Add Company</Typography>
          </ListItemText>
        </ListItem>
        <Divider/>
      </List>
    </Drawer>
  );
};

export default Sidebar;