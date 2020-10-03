import React from 'react';
import {
  AppBar,
  IconButton,
  Toolbar,
  Typography
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Menu } from '@material-ui/icons';

const useStyles = makeStyles((theme) => ({
  toolbar: {
    justifyContent: 'space-between',
  }
}));

const Header = (props) => {

  const classes = useStyles();

  return (
    <AppBar position='static'>
      <Toolbar className={classes.toolbar}>
        <Typography variant="h6">
          Hujak ORG
        </Typography>
        <IconButton
          edge="end"
          color="inherit"
          aria-label="menu"
          onClick={() => props.setOpen(!props.open)}
        >
          <Menu />
        </IconButton>
      </Toolbar>
    </AppBar>
  );
};

export default Header;