import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';


export class EditDepartmentModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch('http://localhost:36468/api/department',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                DepID: event.target.DepID.value,
                DepName: event.target.DepName.value,
            })
        })
        .then(dep=>dep.json())
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
                <Form.Group controlId="DepID">
                        {/* <Form.Label>User ID</Form.Label> */}
                        <Form.Control type="text" name="DepID" required
                        disabled
                        defaultValue={this.props.depid} 
                        placeholder="Department ID"/>
                    </Form.Group>

                    <Form.Group controlId="DepName">
                        <Form.Control type="text" name="DepName" required 
                        defaultValue={this.props.depname}
                        placeholder="Department Name"/>
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