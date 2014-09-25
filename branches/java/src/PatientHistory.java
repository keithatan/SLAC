import java.awt.Container;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BorderFactory;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

import patientInfo.ImportXml;

public class PatientHistory extends JPanel implements ActionListener {
	private static final long serialVersionUID = 1L;

	protected static final String hearingDiffString = "HearingDifficulty";
	protected static final String whichEarString = "WhichEar";
	protected static final String betterEarString = "BetterEar";
	protected static final String firstNoticeString = "FirstNotice";
	protected static final String worseString = "Worse";
	protected static final String natureString = "Nature";
	protected static final String earInfectionString = "EarInfection";
	protected static final String whichEarInfectedString = "WhichEarInfected";
	protected static final String familyProblemString = "FamilyProblem";
	protected static final String ifsoString = "IfSo";
	protected static final String noisesInHeadString = "NoisesInHead";
	protected static final String whichEarNoisesString = "WhichEarNoises";
	protected static final String howOftenNoisesString = "HowOftenNoises";
	protected static final String describeNoisesString = "DescribeNoises";
	protected static final String dizzinessString = "Dizzines";
	protected static final String nauseaString = "Nausea";
	protected static final String vomitingString = "Vomiting";
	protected static final String loudNoisesString = "LoudNoises";
	protected static final String describeLoudString = "DescribeLoud";

	protected static final int colLength = 17;

	protected JLabel actionLabel;
	private JTextField hearingDiffTextField = new JTextField(colLength),
					   whichEarTextField = new JTextField(colLength),
					   betterEarTextField = new JTextField(colLength),
					   firstNoticeTextField = new JTextField(colLength),
					   worseTextField = new JTextField(colLength),
					   natureTextField = new JTextField(colLength),
					   earInfectionTextField = new JTextField(colLength),
					   whichEarInfectedTextField = new JTextField(colLength),
					   familyProblemTextField = new JTextField(colLength),
					   ifsoTextField = new JTextField(colLength),
					   noisesInHeadTextField = new JTextField(colLength),
					   whichEarNoisesTextField = new JTextField(colLength),
					   howOftenNoisesTextField = new JTextField(colLength),
					   describeNoisesTextField = new JTextField(colLength),
					   dizzinessTextField = new JTextField(colLength),
					   nauseaTextField = new JTextField(colLength),
					   vomitingTextField = new JTextField(colLength),
					   loudNoisesTextField = new JTextField(colLength),
					   describeLoudTextField = new JTextField(colLength);
	private ImportXml patientData;
	
	public PatientHistory(ImportXml data) {
		patientData = data;
		
		Set_TextFields();

		// Create labels.
		JLabel hearingDiffLabel = new JLabel(hearingDiffString + ": ");
		hearingDiffLabel.setLabelFor(hearingDiffTextField);

		JLabel whichEarLabel = new JLabel(whichEarString + ": ");
		whichEarLabel.setLabelFor(whichEarTextField);

		JLabel betterEarLabel = new JLabel(betterEarString + ": ");
		betterEarLabel.setLabelFor(betterEarTextField);

		JLabel firstNoticeLabel = new JLabel(firstNoticeString + ": ");
		firstNoticeLabel.setLabelFor(firstNoticeTextField);

		JLabel worseLabel = new JLabel(worseString + ": ");
		worseLabel.setLabelFor(worseTextField);

		JLabel natureLabel = new JLabel(natureString + ": ");
		natureLabel.setLabelFor(natureTextField);

		JLabel earInfectionLabel = new JLabel(earInfectionString + ": ");
		earInfectionLabel.setLabelFor(earInfectionTextField);

		JLabel whichEarInfectedLabel = new JLabel(whichEarInfectedString + ": ");
		whichEarInfectedLabel.setLabelFor(whichEarInfectedTextField);

		JLabel familyProblemLabel = new JLabel(familyProblemString + ": ");
		familyProblemLabel.setLabelFor(familyProblemTextField);

		JLabel ifsoLabel = new JLabel(ifsoString + ": ");
		ifsoLabel.setLabelFor(ifsoTextField);

		JLabel noisesInHeadLabel = new JLabel(noisesInHeadString + ": ");
		noisesInHeadLabel.setLabelFor(noisesInHeadTextField);

		JLabel whichEarNoisesLabel = new JLabel(whichEarNoisesString + ": ");
		whichEarNoisesLabel.setLabelFor(whichEarNoisesTextField);

		JLabel howOftenNoisesLabel = new JLabel(howOftenNoisesString + ": ");
		howOftenNoisesLabel.setLabelFor(howOftenNoisesTextField);

		JLabel describeNoisesLabel = new JLabel(describeNoisesString + ": ");
		describeNoisesLabel.setLabelFor(describeNoisesTextField);

		JLabel dizzinessLabel = new JLabel(dizzinessString + ": ");
		dizzinessLabel.setLabelFor(dizzinessTextField);

		JLabel nauseaLabel = new JLabel(nauseaString + ": ");
		nauseaLabel.setLabelFor(nauseaTextField);

		JLabel vomitingLabel = new JLabel(vomitingString + ": ");
		vomitingLabel.setLabelFor(vomitingTextField);

		JLabel loudNoisesLabel = new JLabel(loudNoisesString + ": ");
		loudNoisesLabel.setLabelFor(loudNoisesTextField);

		JLabel describeLoudLabel = new JLabel(describeLoudString + ": ");
		describeLoudLabel.setLabelFor(describeLoudTextField);

		// Create a label to put messages during an action event.
		actionLabel = new JLabel("Type text in a field and press Enter.");
		actionLabel.setBorder(BorderFactory.createEmptyBorder(10, 0, 0, 0));

		// Lay out the text controls and the labels.
		JPanel textControlsPane = new JPanel();
		GridBagLayout gridbag = new GridBagLayout();

		textControlsPane.setLayout(gridbag);

		JLabel[] labels = { hearingDiffLabel, whichEarLabel, betterEarLabel,
				firstNoticeLabel, worseLabel, natureLabel, earInfectionLabel,
				whichEarInfectedLabel, familyProblemLabel, ifsoLabel,
				noisesInHeadLabel, whichEarNoisesLabel, howOftenNoisesLabel,
				describeNoisesLabel, dizzinessLabel, nauseaLabel,
				vomitingLabel, loudNoisesLabel, describeLoudLabel };
		JTextField[] textFields = { hearingDiffTextField, whichEarTextField,
				betterEarTextField, firstNoticeTextField, worseTextField,
				natureTextField, earInfectionTextField,
				whichEarInfectedTextField, familyProblemTextField,
				ifsoTextField, noisesInHeadTextField, whichEarNoisesTextField,
				howOftenNoisesTextField, describeNoisesTextField,
				dizzinessTextField, nauseaTextField, vomitingTextField,
				loudNoisesTextField, describeLoudTextField };
		
		Set_TextFields_NotEditable(textFields);
		
		addLabelTextRows(labels, textFields, gridbag, textControlsPane);

		add(textControlsPane);

	}
	
	public void Set_TextFields() {
		// Set textfields
		hearingDiffTextField.setActionCommand(hearingDiffString);
		hearingDiffTextField.addActionListener(this);

		whichEarTextField.setActionCommand(whichEarString);
		whichEarTextField.addActionListener(this);

		betterEarTextField.setActionCommand(betterEarString);
		betterEarTextField.addActionListener(this);

		firstNoticeTextField.setActionCommand(firstNoticeString);
		firstNoticeTextField.addActionListener(this);

		worseTextField.setActionCommand(worseString);
		worseTextField.addActionListener(this);

		natureTextField.setActionCommand(natureString);
		natureTextField.addActionListener(this);

		earInfectionTextField.setActionCommand(earInfectionString);
		earInfectionTextField.addActionListener(this);

		whichEarInfectedTextField.setActionCommand(whichEarInfectedString);
		whichEarInfectedTextField.addActionListener(this);

		familyProblemTextField.setActionCommand(familyProblemString);
		familyProblemTextField.addActionListener(this);

		ifsoTextField.setActionCommand(ifsoString);
		ifsoTextField.addActionListener(this);

		noisesInHeadTextField.setActionCommand(noisesInHeadString);
		noisesInHeadTextField.addActionListener(this);

		whichEarNoisesTextField.setActionCommand(whichEarNoisesString);
		whichEarNoisesTextField.addActionListener(this);
		
		howOftenNoisesTextField.setActionCommand(howOftenNoisesString);
		howOftenNoisesTextField.addActionListener(this);
		
		describeNoisesTextField.setActionCommand(describeNoisesString);
		describeNoisesTextField.addActionListener(this);

		dizzinessTextField.setActionCommand(dizzinessString);
		dizzinessTextField.addActionListener(this);

		nauseaTextField.setActionCommand(nauseaString);
		nauseaTextField.addActionListener(this);

		vomitingTextField.setActionCommand(vomitingString);
		vomitingTextField.addActionListener(this);
		
		loudNoisesTextField.setActionCommand(loudNoisesString);
		loudNoisesTextField.addActionListener(this);
		
		describeLoudTextField.setActionCommand(describeLoudString);
		describeLoudTextField.addActionListener(this);
	}
	
	public void Set_TextFields_NotEditable(JTextField[] textFields) {
		for(JTextField i : textFields) {
			i.setEditable(false);
		}
	}

	private void addLabelTextRows(JLabel[] labels, JTextField[] textFields,
			GridBagLayout gridbag, Container container) {
		GridBagConstraints c = new GridBagConstraints();
		c.anchor = GridBagConstraints.EAST;
		int numLabels = labels.length;

		for (int i = 0; i < numLabels; i++) {
			c.gridwidth = GridBagConstraints.RELATIVE; // next-to-last
			c.fill = GridBagConstraints.NONE; // reset to default
			c.weightx = 0.0; // reset to default
			container.add(labels[i], c);

			c.gridwidth = GridBagConstraints.REMAINDER; // end row
			c.fill = GridBagConstraints.HORIZONTAL;
			c.weightx = 1.0;
			container.add(textFields[i], c);
		}
	}
	
	public void setPathology(String pathology) {
		for (int i = 0; i < patientData.newList.getNumberOfPatients(); i++) {
			if(pathology.compareTo(patientData.newList.getPatients().get(i).getPathology()) == 0) {				
				hearingDiffTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getHearingDifficulty());
				whichEarTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getWhichEar());
				betterEarTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getBetterEar());
				firstNoticeTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getFirstNotice());
				worseTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getWorse());
				natureTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getNature());
				earInfectionTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getEarInfection());
				familyProblemTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getFamilyProblem());
				noisesInHeadTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getNoisesInHead());
				whichEarNoisesTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getWhichEarNoises());
				howOftenNoisesTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getHowOftenNoises());
				describeNoisesTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getDescribeNoises());
				dizzinessTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getDizziness());
				loudNoisesTextField.setText(patientData.newList.getPatients().get(i).getCaseHistory().getLoudNoises());
				break;
			}
		}
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		// TODO Auto-generated method stub

	}
}
