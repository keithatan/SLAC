import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BoxLayout;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JRadioButton;

import patientInfo.ImportXml;

public class Create_Pathology_Selector_Window extends JFrame {
	private static final long serialVersionUID = 1L;
	private String pathology_selected;
	private PatientHistory patient_history;

	public Create_Pathology_Selector_Window(PatientHistory history, ImportXml patientData) {
		Create_New_Patient_Window(new Create_Objects(patientData));
		patient_history = history;
	}
	
	public static void Create_New_Patient_Window(final JFrame frame) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				frame.pack();
				frame.setVisible(true);
			}
		});
	}

	public class Create_Objects extends JFrame {
		private static final long serialVersionUID = 1L;
		/* Creates a group for radiobuttons */
		private ButtonGroup radioButton_group = new ButtonGroup();
		/* Create list of radiobuttons */
		private JRadioButton radioButton_random = new JRadioButton();
		private JRadioButton[] radioButton_list;
		/* Creates a button */
		private JButton ok_button = new JButton("Ok");
		/* Create panel for radio buttons */
		private JPanel radioButton_panel = new JPanel();
		/* Create a panel for ok button */
		private JPanel ok_panel = new JPanel();
		/* Create a temp ImportXml object */
		private ImportXml patientData;

		
		/* Create constructor for Create_Objects */
		public Create_Objects(ImportXml data) {
			patientData = data;
			
			this.setResizable(false);
			this.setAlwaysOnTop(true);
						
			Add_RadioButtons();
			Create_RadioButtons_Group();
			
			Add_Buttons();
			
			Add_Components_Panel();
		}
		
		/* Create RadioButtons */
		public void Add_RadioButtons() {
			radioButton_random.setText("Random");
			radioButton_random.addActionListener(radioButton_Listener);
			
			radioButton_list = new JRadioButton[patientData.newList.getNumberOfPatients()];
			
			for(int i = 0; i < patientData.newList.getNumberOfPatients(); i++) {
				radioButton_list[i] = new JRadioButton();
				radioButton_list[i].setText(patientData.newList.getPatients().get(i).getPathology());
				radioButton_list[i].addActionListener(radioButton_Listener);
			}
		}
		
		/* Create Radio Button Group */
		public void Create_RadioButtons_Group() {
			radioButton_group.add(radioButton_random);
			for(int i = 0; i < patientData.newList.getNumberOfPatients(); i++) {
				radioButton_group.add(radioButton_list[i]);
			}
		}
		
		/* Create Ok Button */
		public void Add_Buttons() {
			ok_button.addActionListener(okButton_Listener);
		}

		/* Create a panel and add to box layout */
		public void Add_Components_Panel() {
			/* Set the layout to radioButton_panel */
			radioButton_panel.setLayout(new BoxLayout(radioButton_panel, BoxLayout.PAGE_AXIS));
			/* Add components to radioButton_panel */
			radioButton_panel.add(radioButton_random);
			radioButton_random.setAlignmentX(LEFT_ALIGNMENT);
			for(int i = 0; i < patientData.newList.getNumberOfPatients(); i++) {
				radioButton_panel.add(radioButton_list[i]);
				radioButton_list[i].setAlignmentX(LEFT_ALIGNMENT);
			}
			
			/* Set the layout of the ok_panel */
			ok_panel.setLayout(new BoxLayout(ok_panel, BoxLayout.PAGE_AXIS));
			/* Add components to ok_panel */
			ok_panel.add(ok_button);
			ok_button.setAlignmentX(CENTER_ALIGNMENT);

			/* Put the radioButton_panel and the ok_panel together with a container */
			Container content_pane = getContentPane();
			content_pane.add(radioButton_panel, BorderLayout.CENTER);
			content_pane.add(ok_panel, BorderLayout.PAGE_END);
		}
		
		/* Create listener for ok button */
		private ActionListener okButton_Listener = new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				patient_history.setPathology(pathology_selected);
				setVisible(false);
			}
		};

		/* Create listener for radiobuttons */
		private ActionListener radioButton_Listener = new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				for(int i = 0; i < patientData.newList.getNumberOfPatients(); i++) {
					if(e.getSource() == radioButton_list[i]) {
						pathology_selected = patientData.newList.getPatients().get(i).getPathology();
					}
				}
				if(e.getSource() == radioButton_random) {
					pathology_selected = patientData.newList.getPatients().get(0).getPathology();
				}
			}
		};
	}
}