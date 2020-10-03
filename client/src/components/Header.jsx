import React from 'react';
import {
  AppBar,
  IconButton,
  Toolbar,
  Typography,
  LinearProgress
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Menu } from '@material-ui/icons';

/**
 * Component styles.
 *
 * @type {(props?: any) => ClassNameMap<string>}
 */
const useStyles = makeStyles((theme) => ({
  toolbar: {
    justifyContent: 'space-between',
  }
}));

/**
 * Header component.
 *
 * @param props
 * @return React.ReactNode
 * @constructor
 */
const Header = (props) => {

  const classes = useStyles();

  return (
    <AppBar position='static'>
      <Toolbar className={classes.toolbar}>
        <Typography variant="h6">Hujak ORG</Typography>
        <IconButton
          edge="end"
          color="inherit"
          aria-label="menu"
          onClick={() => props.setOpen(!props.open)}
        >
          <Menu />
        </IconButton>
      </Toolbar>
      {
        props.loading ? <LinearProgress color='primary'/> : null
      }
    </AppBar>
  );
};

export default Header;