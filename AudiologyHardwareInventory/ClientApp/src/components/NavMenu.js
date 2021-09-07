import React, { Component } from 'react';
import { Nav, Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
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
            <div>
                <Nav defaultActiveKey="/counter" className="flex-column">
                    <NavLink tag={Link} className="text-dark" to="/"><span>Hearing Aid</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/chipset"><span>Mobile Phones</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/team-data"><span>Teams</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/"><span>Platforms</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/chipset"><span>Manufacturer</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/chipset"><span>Mobile Models</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/"><span>Hardware Type</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/chipset"><span>Manufacturer</span></NavLink>
                    <NavLink tag={Link} className="text-dark" to="/chipset"><span>Chipset Type</span></NavLink>
                  
                </Nav>
            </div>
        );
    }
}
