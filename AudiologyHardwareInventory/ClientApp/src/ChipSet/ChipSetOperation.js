import React, { Component } from 'react';
import ReactTable from 'react-table-6';
import REACTDOM from "react-dom";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import './DefaultReactTable.css';
import { PopUpChipSet } from './PopUpChipSet.js';
import Enumerable from 'linq';
import Swal from 'sweetalert2';



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
            chipSetInfo: [], loading: true, modal: false, clicked: false, update: '', chipSetId: '', Button: 'Delete', maxId: 0,
            fade: false, chipsetNameValue: '', descriptionValue: '', message: 'Loading....', visible: false,success:'done'
        };

        this.toggle = this.toggle.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.onRowClick = this.onRowClick.bind(this);
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
                chipSetId: this.state.maxId,
                chipSetName: chipSetName,
                description: description,
            };
            fetch('/api/ChipSet/Create', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(
                    chipSet
                )
            }).then(response => response.json())
                .then(

                    Swal.fire({
                        title: 'Successfully Saved the data',
                        confirmButtonText: 'OK',
                        icon: 'success'

                    }).then((result) => {
                        if (result.isConfirmed) {
                            this.setState({ modal: !this.state.modal, });
                            window.location.reload();
                        }
                    })
                );
        }
        if (this.state.update == true) {
            //event.preventDefault();
         
            this.setState({ update: false });
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

            }).then(response => response.json())
                .then(

                    Swal.fire({
                        title: 'Successfully Saved the data',
                        confirmButtonText: 'OK',
                        icon: 'success'

                    }).then((result) => {
                        if (result.isConfirmed) {
                            this.setState({ modal: !this.state.modal, });
                            window.location.reload();
                        }
                    })                                  
                );
        }    
         event.preventDefault();
        
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

                    }).then(response => response.json())
                        .then(                         
                            window.location.reload()
                        );                                      
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
                    <Button color='info' onClick={this.toggle}>Add ChipSet</Button>
                   
                  
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
                                                <Button color='info' data-id="editButtonId">
                                                    Edit
                                                </Button> {' '}
                                                <Button color='info' data-id="deleteButtonId">
                                                    Delete
                                                </Button>
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
        if (data.length != 0) {
            const chipsetId = Enumerable.from(data)
                .max(s => s.chipSetId);
            this.setState({ chipSetInfo: data, message: '', update: false, maxId: chipsetId + 1 });
        }
        else
            this.setState({ chipSetInfo: data, message: '', maxId: 0, update: false });
        this.setState({ chipSetInfo: data, message: '' });
    }
    
}


