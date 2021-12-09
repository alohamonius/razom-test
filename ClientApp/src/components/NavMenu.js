import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="flex justify-center navbar-expand-sm navbar-toggleable-sm border-bottom bg-black " light>
          <NavbarBrand className="text-white text-2xl text-center" tag={Link} to="/">FileUploaader-2000</NavbarBrand>
        </Navbar>
      </header>
    );
  }
}
