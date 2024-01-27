import React, { Component } from "react";
import { Table } from "react-bootstrap";

import { Button, ButtonToolbar } from "react-bootstrap";
import { AddDoctorModal } from "./AddDoctorModal";
import { EditDoctorModal } from "./EditDoctorModal";
import Navbar from "./Navbar";

export class Doctor extends Component {
  constructor(props) {
    super(props);
    this.state = { doctorr: [], addModalShow: false, editModalShow: false };
  }

  refreshList() {
    fetch("http://localhost:36468/api/doctor")
      .then((response) => response.json())
      .then((data) => {
        this.setState({ doctorr: data });
      });
  }

  componentDidMount() {
    this.refreshList();
    setInterval(() => {
        this.refreshList();
    }, 30000);
}
// componentDidUpdate() {
//     this.refreshList();
//     setInterval(() => {
//         this.refreshList();
//     }, 20000);
// } 

componentWillUnmount() {
    clearInterval(this.setInterval);
}

  deleteTeams(did) {
    if (window.confirm("Are you sure?")) {
      fetch("http://localhost:36468/api/doctor/" + did, {
        method: "DELETE",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
    }
  }

  render() {
    const {
      doctorr,
      doctorid,
      doctorusername,
      doctorfullname,
      doctoremail,
      doctorpassword,
      doctornrtel,
    } = this.state;
    let addModalClose = () => this.setState({ addModalShow: false });
    let editModalClose = () => this.setState({ editModalShow: false });
    return (
      <div>
      <Navbar />
      <div className="container">
        <br />
        <br />
        <ButtonToolbar>
          <Button
            variant="primary"
            className="rounded-5 btn-add"
            onClick={() => this.setState({ addModalShow: true })}
          >
            + Doctor
          </Button>

          <AddDoctorModal
            show={this.state.addModalShow}
            onHide={addModalClose}
          />
        </ButtonToolbar>

        <Table className="mt-4" striped bordered hover size="sm" id="table-design">
          <thead className="table-head">
            <tr>
              <th>#</th>
              <th>Username</th>
              <th>Full Name</th>
              <th>Email</th>
              <th>Password</th>
              <th>Nr.Tel</th>
              <th>Opportunities</th>
            </tr>
          </thead>
          <tbody>
            {doctorr.map((doctor) => (
              <tr key={doctor.UserId}>
                <td>{doctor.UserId}</td>
                <td>{doctor.Username}</td>
                <td>{doctor.FullName}</td>
                <td>{doctor.Email}</td>
                <td>{doctor.Password}</td>
                <td>{doctor.NrTel}</td>
                <td>
                  <ButtonToolbar className="btn-action">
                    <Button
                      className="mr-2 me-2 button-toolbar"
                      variant="warning"
                      onClick={() =>
                        this.setState({
                          editModalShow: true,
                          doctorid: doctor.UserId,
                          doctorusername: doctor.Username,
                          doctorfullname: doctor.FullName,
                          doctoremail: doctor.Email,
                          doctorpassword: doctor.Password,
                          doctornrtel: doctor.NrTel,
                        })
                      }
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        fill="currentColor"
                        class="bi bi-pencil-square"
                        viewBox="0 0 16 16"
                      >
                        <path
                          d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"
                        />
                        <path
                          fill-rule="evenodd"
                          d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"
                        />
                      </svg>
                    </Button>

                    <Button
                      className="mr-2 button-toolbar"
                      variant="danger"
                      onClick={() => this.deleteTeams(doctor.UserId)}
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        fill="currentColor"
                        class="bi bi-trash3-fill"
                        viewBox="0 0 16 16"
                      >
                        <path
                          d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"
                        />
                      </svg>
                    </Button>

                    <EditDoctorModal
                      show={this.state.editModalShow}
                      onHide={editModalClose}
                      doctorid={doctorid}
                      doctorusername={doctorusername}
                      doctorfullname={doctorfullname}
                      doctoremail={doctoremail}
                      doctorpassword={doctorpassword}
                      doctornrtel={doctornrtel}
                    />
                  </ButtonToolbar>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
      </div>
    );
  }
}

export default Doctor;
