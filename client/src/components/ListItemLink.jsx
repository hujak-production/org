import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import { Link as RouterLink } from 'react-router-dom';
import { Typography } from '@material-ui/core';

/**
 * ListItemLink component.
 * Add routing link to list item.
 *
 * @param props
 * @return {*}
 * @constructor
 */
const ListItemLink = (props) => {
  const { icon, text, to, className, active, handleClick } = props;

  const renderLink = React.useMemo(
    () => React.forwardRef((itemProps, ref) => <RouterLink to={ to } ref={ ref } { ...itemProps } />),
    [to],
  );

  return (
    <li>
      <ListItem button component={ renderLink } className={active} onClick={handleClick}>
        { icon ? <ListItemIcon>{ icon }</ListItemIcon> : null }
        <ListItemText>
          <Typography variant="h6" component='p' className={ className }>{ text }</Typography>
        </ListItemText>
      </ListItem>
    </li>
  );
};

export default ListItemLink;