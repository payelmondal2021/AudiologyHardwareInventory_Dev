import React, { Component } from 'react';
import ReactTable from "react-table";
import REACTDOM from "react-dom";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import './DefaultReactTable.css';
import axios from 'axios';

export class PopUpChipSet extends Component {
    static displayName = PopUpChipSet.name;
    constructor(props) {
        super(props);
        this.state = {
          
        }; 
    }
    
    render() {
        return (
            <div>
                <h1> </h1>
                
                <Modal isOpen={this.props.data.modal} fade={this.props.data.fade} toggle={this.props.toggle}>
                    <ModalHeader style={{ background: 'Highlight', color: 'white' }} toggle={this.props.toggle} >
                        <div >Chipset Details</div>
                    </ModalHeader>
                    <form onSubmit={this.props.handleSubmit}>
                        <ModalBody>
                            <div >
                                <label for="form7" class="pb-2">ChipSet Name</label><br></br>
                                <textarea required id="txtChipSetName" defaultValue={this.props.data.chipsetNameValue} name="name" placeholder="Please Enter ChipSet Name" rows="2" cols="60" />
                                <label for="form7" class="pb-2">Description</label><br></br>
                                <textarea required id="txtDescription" defaultValue={this.props.data.descriptionValue} placeholder="Please Enter Description" name="name2" rows="2" cols="60" />                               
                            </div>
                        </ModalBody>
                        <ModalFooter >
                            {/*<Button onClick={this.toggle}>OK</Button>{' '}*/}
                            {/*<input type="submit" value="Submit" />*/}
                            <Button type="submit" value="Submit">Submit</Button>{'  '}
                            <Button onClick={this.props.toggle}>Cancel</Button>
                        </ModalFooter>
                    </form>
                </Modal>

            </div>
        );
    }
}
