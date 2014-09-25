package patientInfo;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;

public class ImportXml {

	public PatientsList newList;

	public ImportXml(String filename) throws JAXBException {

		//sampleDataToXml("createdTest.xml");

		JAXBContext context = JAXBContext.newInstance(PatientsList.class);
		Unmarshaller um = context.createUnmarshaller();

		newList = new PatientsList();

		try {
			newList = (PatientsList) um.unmarshal(new FileReader(filename));
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}

	private void sampleDataToXml(String file) throws JAXBException {
		// PATIENT 1

		// create case history
		CaseHistory caseHistory = new CaseHistory();
		caseHistory.setHearingDifficulty("Yes");
		caseHistory.setWhichEar("Left");
		caseHistory.setBetterEar("Right");
		caseHistory.setFirstNotice("1 - 2 years ago");
		caseHistory.setWorse("Yes");
		caseHistory.setNature("Gradual");
		caseHistory.setEarInfection("No");
		caseHistory.setWhichEarInfected("");
		caseHistory.setFamilyProblem("No");
		caseHistory.setIfSo("");
		caseHistory.setNoisesInHead("Yes");
		caseHistory.setWhichEarNoises("Left");
		caseHistory.setHowOftenNoises("Frequently");
		caseHistory.setDescribeNoises("High-pitched ringing");
		caseHistory.setDizziness("No");
		caseHistory.setNausea("");
		caseHistory.setVomiting("");
		caseHistory.setLoudNoises("No");
		caseHistory.setDescribeLoud("");

		// create patient
		Patient patient = new Patient();
		patient.setPathology("Acoustic Tumor");
		patient.setCaseHistory(caseHistory);

		Thresholds thresholds = new Thresholds();

		Freq ac_right = new Freq(5, 10, 12, 15, 15, 15);
		Freq ac_left = new Freq(15, 15, 20, 25, 50, 60);
		Freq bc_right = new Freq(5, 10, 12, 15, 15, 0);
		Freq bc_left = new Freq(10, 12, 20, 20, 40, 0);
		Freq masked_ac_right = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_ac_left = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_bc_right = new Freq(0, 0, 0, 0, 15, 0);
		Freq masked_bc_left = new Freq(0, 0, 0, 0, 50, 0);
		Freq no_response_right = new Freq(0, 0, 0, 0, 0, 0);
		Freq no_response_left = new Freq(0, 0, 0, 0, 0, 0);
		Freq soundfield = new Freq(0, 0, 0, 0, 0, 0);
		Freq aided = new Freq(0, 0, 0, 0, 0, 0);
		Freq ucl_right = new Freq(0, 0, 0, 0, 0, 0);
		Freq ucl_left = new Freq(0, 0, 0, 0, 0, 0);

		thresholds.setAc_right(ac_right);
		thresholds.setAc_left(ac_left);
		thresholds.setBc_right(bc_right);
		thresholds.setBc_left(bc_left);
		thresholds.setMasked_ac_right(masked_ac_right);
		thresholds.setMasked_ac_left(masked_ac_left);
		thresholds.setMasked_bc_right(masked_bc_right);
		thresholds.setMasked_bc_left(masked_bc_left);
		thresholds.setNo_response_right(no_response_right);
		thresholds.setNo_response_left(no_response_left);
		thresholds.setSoundfield(soundfield);
		thresholds.setAided(aided);
		thresholds.setUcl_right(ucl_right);
		thresholds.setUcl_left(ucl_left);

		patient.setThresholds(thresholds);

		// PATIENT 2

		// create case history
		CaseHistory caseHistory2 = new CaseHistory();
		caseHistory2.setHearingDifficulty("Yes");
		caseHistory2.setWhichEar("Left");
		caseHistory2.setBetterEar("Right");
		caseHistory2.setFirstNotice("After getting hit with a softball");
		caseHistory2.setWorse("No");
		caseHistory2.setNature("Sudden onset");
		caseHistory2.setEarInfection("No");
		caseHistory2.setWhichEarInfected("");
		caseHistory2.setFamilyProblem("No");
		caseHistory2.setIfSo("");
		caseHistory2.setNoisesInHead("No");
		caseHistory2.setWhichEarNoises("");
		caseHistory2.setHowOftenNoises("");
		caseHistory2.setDescribeNoises("");
		caseHistory2.setDizziness("Yes");
		caseHistory2.setNausea("No");
		caseHistory2.setVomiting("No");
		caseHistory2.setLoudNoises("No");
		caseHistory2.setDescribeLoud("");

		// create patient
		Patient patient2 = new Patient();
		patient2.setPathology("Ossicular Discontinuity");
		patient2.setCaseHistory(caseHistory2);

		Thresholds thresholds2 = new Thresholds();

		Freq ac_right2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq ac_left2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq bc_right2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq bc_left2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_ac_right2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_ac_left2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_bc_right2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_bc_left2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq no_response_right2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq no_response_left2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq soundfield2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq aided2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq ucl_right2 = new Freq(0, 0, 0, 0, 0, 0);
		Freq ucl_left2 = new Freq(0, 0, 0, 0, 0, 0);

		thresholds2.setAc_right(ac_right2);
		thresholds2.setAc_left(ac_left2);
		thresholds2.setBc_right(bc_right2);
		thresholds2.setBc_left(bc_left2);
		thresholds2.setMasked_ac_right(masked_ac_right2);
		thresholds2.setMasked_ac_left(masked_ac_left2);
		thresholds2.setMasked_bc_right(masked_bc_right2);
		thresholds2.setMasked_bc_left(masked_bc_left2);
		thresholds2.setNo_response_right(no_response_right2);
		thresholds2.setNo_response_left(no_response_left2);
		thresholds2.setSoundfield(soundfield2);
		thresholds2.setAided(aided2);
		thresholds2.setUcl_right(ucl_right2);
		thresholds2.setUcl_left(ucl_left2);

		patient2.setThresholds(thresholds2);
		
		// PATIENT 3

		// create case history
		CaseHistory caseHistory3 = new CaseHistory();
		caseHistory3.setHearingDifficulty("Yes");
		caseHistory3.setWhichEar("Left");
		caseHistory3.setBetterEar("Right");
		caseHistory3.setFirstNotice("2 weeks ago");
		caseHistory3.setWorse("No");
		caseHistory3.setNature("Sudden");
		caseHistory3.setEarInfection("No");
		caseHistory3.setWhichEarInfected("");
		caseHistory3.setFamilyProblem("No");
		caseHistory3.setIfSo("");
		caseHistory3.setNoisesInHead("Yes");
		caseHistory3.setWhichEarNoises("Left");
		caseHistory3.setHowOftenNoises("Often");
		caseHistory3.setDescribeNoises("Ringing");
		caseHistory3.setDizziness("No");
		caseHistory3.setNausea("");
		caseHistory3.setVomiting("No");
		caseHistory3.setLoudNoises("No");
		caseHistory3.setDescribeLoud("");

		// create patient
		Patient patient3 = new Patient();
		patient3.setPathology("Sudden Onset");
		patient3.setCaseHistory(caseHistory3);

		Thresholds thresholds3 = new Thresholds();

		Freq ac_right3 = new Freq(20, 20, 25, 30, 30, 50);
		Freq ac_left3 = new Freq(70, 80, 90, 90, 95, 105);
		Freq bc_right3 = new Freq(20, 15, 15, 15, 15, 0);
		Freq bc_left3 = new Freq(50, 50, 65, 70, 70, 0);
		Freq masked_ac_right3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_ac_left3 = new Freq(70, 80, 90, 90, 95, 105);
		Freq masked_bc_right3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq masked_bc_left3 = new Freq(70, 80, 90, 90, 95, 0);
		Freq no_response_right3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq no_response_left3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq soundfield3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq aided3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq ucl_right3 = new Freq(0, 0, 0, 0, 0, 0);
		Freq ucl_left3 = new Freq(0, 0, 0, 0, 0, 0);

		thresholds3.setAc_right(ac_right3);
		thresholds3.setAc_left(ac_left3);
		thresholds3.setBc_right(bc_right3);
		thresholds3.setBc_left(bc_left3);
		thresholds3.setMasked_ac_right(masked_ac_right3);
		thresholds3.setMasked_ac_left(masked_ac_left3);
		thresholds3.setMasked_bc_right(masked_bc_right3);
		thresholds3.setMasked_bc_left(masked_bc_left3);
		thresholds3.setNo_response_right(no_response_right3);
		thresholds3.setNo_response_left(no_response_left3);
		thresholds3.setSoundfield(soundfield3);
		thresholds3.setAided(aided3);
		thresholds3.setUcl_right(ucl_right3);
		thresholds3.setUcl_left(ucl_left3);

		patient3.setThresholds(thresholds3);

		ArrayList<Patient> patients = new ArrayList<Patient>();
		patients.add(patient);
		patients.add(patient2);
		patients.add(patient3);

		// create patinetsList
		PatientsList patientsList = new PatientsList();

		patientsList.setPatients(patients);
		patientsList.setNumberOfPatients(patients.size());

		// create JAXB context and instantiate marshaller
		JAXBContext context = JAXBContext.newInstance(PatientsList.class);
		Marshaller m = context.createMarshaller();
		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);

		// Write to System.out
		m.marshal(patientsList, System.out);

		// Write to File
		m.marshal(patientsList, new File(file));
	}

}
