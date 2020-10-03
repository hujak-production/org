import React, { useEffect, useState } from 'react';
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
  const [data, setData] = useState(null);
  const [open, setOpen] = React.useState(false);

  useEffect(() => {
    axios.get('https://192.168.0.220:44316/company')
      .then((response) => {
        setData(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }, []);

  return (
    <Router history={ history }>
      <Container className={classes.container} fixed>
        <Header open={open} setOpen={setOpen}/>
        <Sidebar open={open} setOpen={setOpen} companies={data} history={history}/>
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
