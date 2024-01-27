import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';


export class EditRoleModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch('http://localhost:36468/api/roles',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                RoleID: event.target.RoleID.value,
                Role: event.target.Role.value,
            })
        })
        .then(role=>role.json())
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
            Edit Department
        </Modal.Title>
        <Button variant="danger" className='ms-auto btn-exit' onClick={this.props.onHide}>X</Button>

    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6} className="mx-auto">
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="RoleID">
                        {/* <Form.Label>User ID</Form.Label> */}
                        <Form.Control type="text" name="RoleID" required
                        disabled
                        defaultValue={this.props.roleid} 
                        placeholder="Role ID"/>
                    </Form.Group>

                    <Form.Group controlId="Role">
                        <Form.Control type="text" name="Role" required 
                        defaultValue={this.props.rolename}
                        placeholder="Role"/>
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