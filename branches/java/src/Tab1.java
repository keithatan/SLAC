import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;

import javax.swing.JButton;
import javax.swing.JPanel;

//import net.miginfocom.swing.MigLayout;
import patientInfo.ImportXml;

public class Tab1 extends JPanel {
	private static final long serialVersionUID = 1L;
	private PatientHistory patient_history;

	public Tab1(ImportXml data, PatientHistory history) {
		patient_history = history;
		JButton button;

		GridBagConstraints c = new GridBagConstraints();
		c.fill = GridBagConstraints.BOTH;
		c.anchor = GridBagConstraints.CENTER;

		GridBagLayout layout = new GridBagLayout();
		setLayout(layout);
		Audiometer audiometer = new Audiometer();
//		audiometer.setLayout(new MigLayout("wrap 10"));
//		audiometer.add(button = new JButton("Button 1"),"width 50:50, gapleft 17");
//		audiometer.add(button = new JButton("Button 2"),"width 50:50, gapleft 33");
//		audiometer.add(button = new JButton("Button 3"),"width 50:50, gapleft 45");
//		audiometer.add(button = new JButton("Button 4"),"width 50:50, gapleft 45");
//		audiometer.add(button = new JButton("Button 5"),"width 50:50, gapleft 120");
//		audiometer.add(button = new JButton("Button 6"),"width 50:50, gapleft 45");
//		audiometer.add(button = new JButton("Button 7"),"width 50:50, gapleft 45");
//		audiometer.add(button = new JButton("Button 8"),"width 50:50");
//		audiometer.add(button = new JButton("Button 9"),"width 50:50");
//		audiometer.add(button = new JButton("Button 10"),"width 50:50");
//		audiometer.add(button = new JButton("Button 11"),"north");
//		audiometer.add(button = new JButton("Button 12"),"west");
//		audiometer.add(button = new JButton("Button 13"),"east");
//		audiometer.add(button = new JButton("Button 14"),"south");
//		audiometer.add(button = new JButton("Button 15"),"north");
//		audiometer.add(button = new JButton("Button 11"),"north");
//		audiometer.add(button = new JButton("Button 11"),"north");
//		audiometer.add(button = new JButton("Button 11"),"north");
//		audiometer.add(button = new JButton("Button 11"),"north");

		
		




		c.fill = GridBagConstraints.BOTH;
		c.weightx = 1;
		c.weighty = 1;
		c.gridx = 0;
		add(audiometer, c);

		c.fill = GridBagConstraints.BOTH;
		c.weightx = 0;
		c.weighty = 1;
		c.gridx = 1;
		add(patient_history, c);

	}
}
