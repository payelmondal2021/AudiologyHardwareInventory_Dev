import React, { Component } from 'react';
import ReactTable from "react-table";
import REACTDOM from "react-dom";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import './DefaultReactTable.css';
import { PopUpChipSet } from './PopUpChipSet.js';
import axios from 'axios';

export class ChipSetOperation extends Component {
    static displayName = ChipSetOperation.name;

    constructor(props) {
        super(props);
        this.state = {
            data: {
                value1: "",
                value2: "",
                value3: ""
            },
            chipSetInfo: [], loading: true, modal: false, clicked: false, update: '', chipSetId: '', Button: 'Delete',
            fade: false, chipsetNameValue: '', descriptionValue: '', message: 'Loading....', visible: false
        };

        this.toggle = this.toggle.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    toggle(e) {
        this.setState({ chipsetNameValue: '', descriptionValue: ''});
        this.setState({
            modal: !this.state.modal,
            update: false
        });
        console.log('after setState: ', this.state);
    }

    handleSubmit(event) {

        if (this.state.update == false) {
            var chipSetName = document.getElementById('txtChipSetName').value;
            var description = document.getElementById('txtDescription').value;

            let chipSet = {
                chipSetId: 0,
                chipSetName: chipSetName,
                description: description,
            };
            fetch('/api/ChipSet', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(
                    chipSet
                )
            }).then(r => r.json()).then(res => {
                if (res) {
                    this.setState({ message: 'ChipSet Added Successfully' });
                }
            });
        }
        if (this.state.update == true) {
            let chipSet =
            {
                chipSetId: this.state.chipSetId,
                chipSetName: document.getElementById('txtChipSetName').value,
                description: document.getElementById('txtDescription').value,

            };
            fetch('/api/ChipSet/Update', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(
                    chipSet
                )

            }).then(res => {
                if (res) {
                    this.setState({ message: 'ChipSet details updated successfully' });
                    console.log("updated");
                    //window.location("api/Team");
                }
            });
        }
    }

    componentDidMount() {
        this.populateChipSetData();

    }
 
    onRowClick = (state, rowInfo, column, instance) => {
        return {

            onClick: e => {
                const btnId = e.target.dataset.id;
                this.setState({ chipSetId: rowInfo.row.chipSetId, chipsetNameValue: rowInfo.row.chipSetName, descriptionValue: rowInfo.row.description });
                if (btnId == "editButtonId") {
                    this.setState({
                        modal: !this.state.modal,
                        update: true
                    });
                
                }
                else if (btnId == "deleteButtonId") {

                    let chipSet =
                    {
                        chipSetId: rowInfo.row.chipSetId,
                        chipSetName: rowInfo.row.chipSetName,
                        description: rowInfo.row.description,
                        
                    };

                    fetch('/api/ChipSet/Delete', {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-type': 'application/json'
                        },
                        body: JSON.stringify(
                            chipSet
                        )

                    }).then(r => r.json()).then(res => {
                        if (res) {
                            this.setState({ message: 'Deleted' });
                        }
                    });

                }
                //if (

                //    e.target.type == "submit"

                //) {
                //    alert(rowInfo.original.name)
                //}              
            }
        }
    }

 

    render() {

       
        return (
            <div><br></br>
                <h2 id="tabelLabel" >Manage ChiSet</h2><br></br>
                <div>
                    <Button color='success' onClick={this.toggle}>Add ChipSet</Button>                                    
                    <PopUpChipSet data={this.state} toggle={this.toggle} handleSubmit={this.handleSubmit} />
                </div><br></br>
                <p><em>{this.state.message}</em></p>
                <br></br>
                <div>
                    
                    <ReactTable
                        getTdProps={this.onRowClick}
                        expandedRows={true}
                        data={this.state.chipSetInfo}
                        columns={[
                            {
                                columns: [
                                    {
                                        Header: () => <strong>ChipSet Id</strong>,
                                        accessor: 'chipSetId',
                                    },
                                    {
                                        Header: () => <strong>ChipSet Name</strong>,
                                        accessor: 'chipSetName',
                                    },
                                    {
                                        Header: () => <strong>Description</strong>,
                                        accessor: 'description',
                                    },
                                  
                                    {                                      
                                        Header: "Action",
                                        accessor: "Button",
                                        Cell: ({ row }) => (
                                            <div>
                                                <button data-id="editButtonId">
                                                    Edit
                                                </button> {' '}
                                                <button data-id="deleteButtonId">
                                                    Delete
                                                </button>
                                            </div>
                                        )

                                    }

                                ],
                            },
                        ]}
                        defaultPageSize={5}
                    />
                </div>
            </div>
        );
    }

    async populateChipSetData() {
        const response = await fetch('api/ChipSet');
        const data = await response.json();
        this.setState({ chipSetInfo: data, message: '' });
    }
}
