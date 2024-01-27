import React, { Component } from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export class EditAppointmentModal extends Component {
  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    console.log(this.props);
  }

  handleSubmit(event) {
    event.preventDefault();
    fetch(
      `http://localhost:36468/api/appointment/${event.target.appointmentId.value}`,
      {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          id: event.target.appointmentId.value,
          patientName: event.target.patientName.value,
          date: event.target.date.value,
          email: event.target.email.value,
          doctorName: event.target.doctorName.value,
          roomNo: event.target.roomNo.value,
        }),
      }
    )
      .then((appointment) => appointment.json())
      .then(
        (result) => {
          alert(result);
        },
        (error) => {
          alert("Failed");
        }
      );
  }

  render() {
    return (
      <div className="container">
        <Modal
          {...this.props}
          size="md"
          aria-labelledby="contained-modal-title-vcenter"
          centered
        >
          <Modal.Header clooseButton>
            <Modal.Title
              className="ms-auto modal-title"
              id="contained-modal-title-vcenter"
            >
              Edit Appointment
            </Modal.Title>
            <Button
              variant="danger"
              className="ms-auto btn-exit"
              onClick={this.props.onHide}
            >
              X
            </Button>
          </Modal.Header>
          <Modal.Body>
            <Row>
              <Col sm={6} className="mx-auto">
                <Form onSubmit={this.handleSubmit}>
                  <Form.Group controlId="appointmentId">
                    <Form.Control
                      type="text"
                      name="appointmentId"
                      required
                      disabled
                      defaultValue={this.props.appointmentId}
                      placeholder="Appointment ID"
                    />
                  </Form.Group>

                  <Form.Group controlId="patientName">
                    <Form.Control
                      type="text"
                      name="patientName"
                      required
                      defaultValue={this.props.appointmentPatientName}
                      placeholder="Patient Name"
                    />
                  </Form.Group>

                  <Form.Group controlId="date">
                    <Form.Control
                      type="text"
                      name="date"
                      required
                      defaultValue={this.props.appointmentDate}
                      placeholder="Date"
                    />
                  </Form.Group>

                  <Form.Group controlId="email">
                    <Form.Control
                      type="text"
                      name="email"
                      required
                      defaultValue={this.props.Email}
                      placeholder="Email"
                    />
                  </Form.Group>

                  <Form.Group controlId="doctorName">
                    <Form.Control
                      type="text"
                      name="doctorName"
                      required
                      defaultValue={this.props.DoctorName}
                      placeholder="Doctor name"
                    />
                  </Form.Group>

                  <Form.Group controlId="roomNo">
                    <Form.Control
                      type="text"
                      name="roomNo"
                      required
                      defaultValue={this.props.RoomNo}
                      placeholder="Room Number"
                    />
                  </Form.Group>

                  <Form.Group className="d-flex justify-content-center">
                    <Button
                      variant="primary"
                      className="rounded-5 mt-3 btn-add"
                      type="submit"
                    >
                      Update
                    </Button>
                  </Form.Group>
                </Form>
              </Col>
            </Row>
          </Modal.Body>
        </Modal>
      </div>
    );
  }
}
