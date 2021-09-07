import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import './Layout.css';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      //<div>
        
      //  <Container>
      //          <NavMenu />
      //    {this.props.children}
      //  </Container>
      //</div>
        <div class="container-fluid">
            <div class="row content">
                <div class="col-sm-2 sidenav">
 

                    <NavMenu />
        

                </div>
                <div class="col-sm-10 ">
                    {this.props.children}
                          
             
                </div>
            </div>
        </div>
    );
  }
}
