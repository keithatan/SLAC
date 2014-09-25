package patientInfo;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(name = "patient")
@XmlType(propOrder = { "pathology", "caseHistory", "thresholds" })
public class Patient {

	private String pathology;
	private CaseHistory caseHistory;
	private Thresholds thresholds;

	public String getPathology() {
		return pathology;
	}

	public void setPathology(String pathology) {
		this.pathology = pathology;
	}

	public CaseHistory getCaseHistory() {
		return caseHistory;
	}

	public void setCaseHistory(CaseHistory history) {
		this.caseHistory = history;
	}

	public Thresholds getThresholds() {
		return thresholds;
	}

	public void setThresholds(Thresholds thresholds) {
		this.thresholds = thresholds;
	}

}
