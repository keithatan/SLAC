package patientInfo;

import java.util.ArrayList;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "patientsList")
@XmlAccessorType(XmlAccessType.FIELD)
public class PatientsList {

	private int numberOfPatients;

	@XmlElement(name = "patient")
	private ArrayList<Patient> patients;

	public ArrayList<Patient> getPatients() {
		return patients;
	}

	public void setPatients(ArrayList<Patient> patients) {
		this.patients = patients;
	}

	public int getNumberOfPatients() {
		return numberOfPatients;
	}

	public void setNumberOfPatients(int numberOfPatients) {
		this.numberOfPatients = numberOfPatients;
	}

}
