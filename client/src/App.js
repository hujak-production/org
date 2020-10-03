import React, { useEffect } from 'react';
import { Router, Switch, Route } from 'react-router-dom';
import { history } from './utils/history';
import axios from 'axios';

import { makeStyles } from '@material-ui/core/styles';
import { Container, Box } from '@material-ui/core';
import Home from './components/Home';
import Sidebar from './components/Sideabar';
import Header from './components/Header';

const useStyles = makeStyles((theme) => ({
  container: {
    backgroundColor: 'white',
    padding: 0,
    height: '100%'
  },
  content: {
    padding: 15,
  }
}));

const App = () => {

  const classes = useStyles();

  useEffect(() => {
    axios.get('https://192.168.0.220:44316/company')
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      })
  });

  const [open, setOpen] = React.useState(false);

  return (
    <Router history={ history }>
      <Container className={classes.container} fixed>
        <Header open={open} setOpen={setOpen}/>
        <Sidebar open={open} setOpen={setOpen}/>
        <Box className={classes.content}>
          <Switch>
            <Route exact path='/' component={ Home }/>
          </Switch>
        </Box>
      </Container>
    </Router>
  );
};

export default App;
