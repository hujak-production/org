import React from 'react';
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText
} from '@material-ui/core';

const Sidebar = (props) => {
  return (
    <Drawer variant='temporary' onClose={() => props.setOpen(false)} open={props.open}>
      <List>
        <ListItem button>
          <ListItemText primary='Add company'/>
        </ListItem>
      </List>
    </Drawer>
  );
};

export default Sidebar;