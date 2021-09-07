import React, { Component } from 'react';
import ReactTable from "react-table";
import REACTDOM from "react-dom";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import './DefaultReactTable.css';
import { PopupForm } from './PopUpForm.js';
import axios from 'axios';

export class TeamOperation extends Component {
    static displayName = TeamOperation.name;

    constructor(props) {
        super(props);
        this.state = {
            data: {
                value1: "",
                value2: "",
                value3: ""
            },
            teamInfo: [], loading: true, modal: false, clicked: false, update: '', teamId: '', Button: 'Delete',
            fade: false, teamValue: '', descriptionValue: '', memberValue: '', value2: '', message: 'Loading....', visible: false
        };

        this.toggle = this.toggle.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    toggle(e) {
        this.setState({ teamValue: '', descriptionValue: '', memberValue: '' });
        this.setState({
            modal: !this.state.modal,
            update: false
        });
        console.log('after setState: ', this.state);
    }

    handleSubmit(event) {

        if (this.state.update == false) {
            var teamName = document.getElementById('txtTeamName').value;
            var description = document.getElementById('txtDescription').value;
            var teamMembers = document.getElementById('txtTeamMembers').value;


            let team = {
                TeamId: 18,
                TeamName: teamName,
                Description: description,
                TeamMembers: teamMembers
            };
            fetch('/api/Team', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(
                    team
                )
            }).then(r => r.json()).then(res => {
                if (res) {
                    this.setState({ message: 'Team Added Successfully' });
                }
            });
        }
        if (this.state.update == true) {
            let team =
            {
                TeamId: this.state.teamId,
                TeamName: document.getElementById('txtTeamName').value,
                Description: document.getElementById('txtDescription').value,
                TeamMembers: document.getElementById('txtTeamMembers').value
            };
            fetch('/api/Team/Update', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(
                    team
                )

            }).then(res => {
                if (res) {
                    this.setState({ message: 'Team details updated successfully' });
                    console.log("updated");
                    //window.location("api/Team");
                }
            });
        }
    }

    componentDidMount() {
        this.populateTeamData();

    }
 
    onRowClick = (state, rowInfo, column, instance) => {
        return {

            onClick: e => {
                const btnId = e.target.dataset.id;
                this.setState({ teamId: rowInfo.row.teamId, teamValue: rowInfo.row.teamName, descriptionValue: rowInfo.row.description, memberValue: rowInfo.row.teamMembers });
                if (btnId == "editButtonId") {
                    this.setState({
                        modal: !this.state.modal,
                        update: true
                    });
                    /* this.setState({ teamId: rowInfo.row.teamId, teamValue: rowInfo.row.teamName, descriptionValue: rowInfo.row.description, memberValue: rowInfo.row.teamMembers });*/
                }
                else if (btnId == "deleteButtonId") {

                    let team =
                    {
                        TeamId: rowInfo.row.teamId,
                        TeamName: rowInfo.row.teamName,
                        Description: rowInfo.row.description,
                        TeamMembers: rowInfo.row.teamMembers
                    };

                    fetch('/api/Team/Delete', {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-type': 'application/json'
                        },
                        body: JSON.stringify(
                            team
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

    static renderForecastsTable(teamInfo) {
        return (
            <div>
                
            </div>
        );
    }
 

    render() {

        //let contents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : FetchData.renderForecastsTable(this.state.teamInfo);

        return (
            <div><br></br>
                <h2 id="tabelLabel" >Manage Team</h2><br></br>
                <div>
                    <Button color='success' onClick={this.toggle}>Add Team</Button>                                    
                    <PopupForm data={this.state} toggle={this.toggle} handleSubmit={this.handleSubmit} />                 
                </div><br></br>
                <p><em>{this.state.message}</em></p>
                <br></br>
                <div>
                    
                    <ReactTable
                        getTdProps={this.onRowClick}
                        expandedRows={true}
                        data={this.state.teamInfo}
                        columns={[
                            {
                                columns: [
                                    {
                                        Header: () => <strong>Team Id</strong>,
                                        accessor: 'teamId',
                                    },
                                    {
                                        Header: () => <strong>Team Name</strong>,
                                        accessor: 'teamName',
                                    },
                                    {
                                        Header: () => <strong>Description</strong>,
                                        accessor: 'description',
                                    },
                                    {
                                        Header: () => <strong>Team  Members</strong>,
                                        accessor: 'teamMembers',
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

    async populateTeamData() {
        const response = await fetch('api/Team');
        const data = await response.json();
        this.setState({ teamInfo: data, message: '' });
    }
}
