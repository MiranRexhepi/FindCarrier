import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';


export class EditNurseModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch('http://localhost:36468/api/nurse',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                UserId: event.target.UserId.value,
                Username: event.target.Username.value,
                FullName: event.target.FullName.value,
                Email: event.target.Email.value,
                Password: event.target.Password.value,
                NrTel: event.target.NrTel.value

            })
        })
        .then(nurse=>nurse.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })
    }

      
    render(){
        return (
            <div className="container">

<Modal
{...this.props}
size="md"
aria-labelledby="contained-modal-title-vcenter"
centered
>
    <Modal.Header clooseButton>
        <Modal.Title className='ms-auto modal-title' id="contained-modal-title-vcenter">
            Edit Nurse
        </Modal.Title>
        <Button variant="danger" className='ms-auto btn-exit' onClick={this.props.onHide}>X</Button>

    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6} className="mx-auto">
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="UserId">
                        {/* <Form.Label>User ID</Form.Label> */}
                        <Form.Control type="text" name="UserId" required
                        disabled
                        defaultValue={this.props.nurseid} 
                        placeholder="User ID"/>
                    </Form.Group>
                    <Form.Group controlId="Username">
                        {/* <Form.Label>FullName</Form.Label> */}
                        <Form.Control type="text" name="Username" required 
                        defaultValue={this.props.nuseusername}
                        placeholder="Username"/>
                    </Form.Group>

                    <Form.Group controlId="FullName">
                        {/* <Form.Label>FullName</Form.Label> */}
                        <Form.Control type="text" name="FullName" required 
                        defaultValue={this.props.nursefullname}
                        placeholder="Full Name"/>
                    </Form.Group>

                    <Form.Group controlId="Email">
                        {/* <Form.Label>Email</Form.Label> */}
                        <Form.Control type="text" name="Email" required 
                        defaultValue={this.props.nurseemail}
                        placeholder="Email"/>
                    </Form.Group>

                    
                    <Form.Group controlId="Password">
                        {/* <Form.Label>Password</Form.Label> */}
                        <Form.Control type="text" name="Password" required 
                        defaultValue={this.props.nursepassword}
                        placeholder="Password"/>
                    </Form.Group>

                    <Form.Group controlId="NrTel">
                        {/* <Form.Label>Nr Tel</Form.Label> */}
                        <Form.Control type="text" name="NrTel" required 
                        defaultValue={this.props.nursenrtel}
                        placeholder="Nr Tel"/>
                    </Form.Group>

                    <Form.Group className='d-flex justify-content-center'>
                        <Button variant="primary" className='rounded-5 mt-3 btn-add' type="submit">
                            Update
                        </Button>
                    </Form.Group>
                </Form>
            </Col>
        </Row>
    </Modal.Body>
 
</Modal>

            </div>
        )
    }

}