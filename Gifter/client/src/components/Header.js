import React from "react";
//import { Link } from "react-router-dom";
import React, { useState, useContext } from 'react';
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap';
import { UserProfileContext } from "../providers/UserProfileProvider";

export default function Header() {
  const { isLoggedIn, logout } = useContext(UserProfileContext);
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

  return (
    // <nav className="navbar navbar-expand navbar-dark bg-info">
    //   <Link to="/" className="navbar-brand">
    //     GiFTER
    //   </Link>
    //   <ul className="navbar-nav mr-auto">
    //     <li className="nav-item">
    //       <Link to="/" className="nav-link">
    //         Feed
    //       </Link>
    //     </li>
    //     <li className="nav-item">
    //       <Link to="/posts/add" className="nav-link">
    //         New Post
    //       </Link>
    //     </li>
    //   </ul>
    // </nav>
          <Navbar color="dark" dark expand="md">
          <NavbarBrand tag={RRNavLink} to="/">Gifter</NavbarBrand>
          <NavbarToggler onClick={toggle} />
          <Collapse isOpen={isOpen} navbar>
            <Nav className="mr-auto" navbar>
              {isLoggedIn &&
                <>
                  <NavItem>
                    <NavLink tag={RRNavLink} to="/posts/add">Add Gipf</NavLink>
                  </NavItem>
                  <NavItem>
                    <a aria-current="page" className="nav-link"
                      style={{ cursor: "pointer" }} onClick={logout}>Logout</a>
                  </NavItem>
                </>
              }
              {!isLoggedIn &&
                <>
                  <NavItem>
                    <NavLink tag={RRNavLink} to="/login">Login</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={RRNavLink} to="/register">Register</NavLink>
                  </NavItem>
                </>
              }
            </Nav>
            <Nav navbar>
              {/* <NavItem>
                <a aria-current="page" className="nav-link"
                  href="https://www.youtube.com/watch?v=3N_ywhx6_K0"
                  target="_new">Grace Hopper on Letterman</a>
              </NavItem> */}
            </Nav>
          </Collapse>
        </Navbar>
  );
};

