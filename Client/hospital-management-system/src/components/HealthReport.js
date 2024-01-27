import React from 'react';
import jsPDF from 'jspdf';
import Navbar from './Navbar';

class HealthReport extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            patientName: '',
            address: '',
            email: '',
            department: '',
            doctorName: '',
            results: '',
        };
    }

    refreshList() {
        fetch('http://localhost:36468/api/department')
            .then(response => response.json())
            .then(data => {
                this.setState({ depp: data });
            });
    }

    createReport() {
        const {
            patientName,
            address,
            email,
            department,
            doctorName,
            results,
        } = this.state;

        const doc = new jsPDF();

        doc.setFont('helvetica', 'bold');
        doc.setFontSize(24);
        doc.text('Health Report', 105, 20, { align: 'center' });

        doc.setFont('helvetica', 'normal');
        doc.setFontSize(12);
        doc.text(`Raport Mjekësor për Pacientin ${patientName}`, 20, 40);

        doc.setFontSize(12);
        doc.text(`Emri dhe Mbiemri: ${patientName}`, 20, 50);
        doc.text(`Adresa: ${address}`, 20, 60);
        doc.text(`Email: ${email}`, 20, 70);

        doc.setFontSize(14);
        doc.setFont('helvetica', 'bold');
        doc.text('Përshkrimi i Diagnozave të Fundit', 20, 90);

        doc.setFontSize(12);
        doc.setFont('helvetica', 'normal');
        doc.text(`Pacienti ${patientName} ka kryer disa diagnozime të rëndësishme në fund të trajtimit të tij/të saj. Rezultatet e këtyre diagnozimeve dhe trajtimit janë si vijon:`, 20, 100);
        doc.text(`Departamenti: ${department}`, 20, 110);
        doc.text(`Doktori/Doktoresha: ${doctorName}`, 20, 120);
        doc.text(`Rezultatet: ${results}`, 20, 130);

        doc.setFontSize(12);
        doc.text(`Ky raport është përgatitur në bazë të informacioneve të dhëna nga pacienti dhe ndjekja mjekësore që është kryer në Spitalin Rajonal të Pejës. Ju lutemi, konsultohuni me mjekun tuaj për interpretim të saktë dhe udhëzime të tjera të nevojshme në lidhje me rezultatet dhe trajtimin e përcaktuar.`, 20, 150);

        doc.setFontSize(14);
        doc.setFont('helvetica', 'bold');
        doc.text(`Të nënshkruar,`, 20, 180);
        doc.setFontSize(12);
        doc.setFont('helvetica', 'normal');
        doc.text(`Emri dhe Mbiemri i Doktorit/Doktoreshës`, 20, 190);
        doc.text(`Departamenti: ${department}`, 20, 200);

        const pdfContent = doc.output('datauristring');
        this.setState({ report: pdfContent });
    }

    printReport() {
        const { report } = this.state;
        if (report) {
            const printWindow = window.open('', '_blank');
            printWindow.document.open();
            printWindow.document.write(`
        <html>
          <head>
            <title>Health Report</title>
          </head>
          <body>
            <embed width="70%" height="100%" src="${report}" type="application/pdf">
          </body>
        </html>
      `);
            printWindow.document.close();
            // printWindow.print();
        }
    }

    render() {
        return (
            <div>
                <Navbar />
                <div className="container">
                    <br />
                    <div className="row d-flex justify-content-center align-items-center" id="log">
                        <form onSubmit={(e) => e.preventDefault()} className="col-12 d-flex flex-column justify-content-center align-items-center login report">

                            <h2></h2>
                            <h3 className="text-center login-title text-capitalize">Health report</h3>
                            <input type="text" className="form-control" id="patientName" value={this.state.patientName} onChange={(event) => this.setState({ patientName: event.target.value })} placeholder='Name and Surname*' required />
                            <input type="text" className="form-control" id="address" value={this.state.address} onChange={(event) => this.setState({ address: event.target.value })} placeholder='Address*' required />
                            <input type="email" className="form-control" id="email" value={this.state.email} onChange={(event) => this.setState({ email: event.target.value })} placeholder='Email*' required />
                            <input type="text" className="form-control" id="department" value={this.state.department} onChange={(event) => this.setState({ department: event.target.value })} placeholder='Department*' required />
                            <input type="text" className="form-control" id="doctorName" value={this.state.doctorName} onChange={(event) => this.setState({ doctorName: event.target.value })} placeholder='Doctor*' required />
                            <textarea className="form-control" id="results" rows="5" value={this.state.results} onChange={(event) => this.setState({ results: event.target.value })} placeholder='Result/Diagnose*' required />

                            <button type='submit' className="btn btn-login" onClick={() => this.createReport()}>Submit</button>

                            {this.state.report && (
                                <button type='submit' className="btn btn-login btn-login-2" onClick={() => this.printReport()}>Print</button>
                            )}
                        </form>
                    </div>
                    <span className="footer-copyright-login">&copy; HMS</span>
                </div>
            </div>
        );
    }
}

export default HealthReport;
