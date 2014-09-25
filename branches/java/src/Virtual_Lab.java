import java.awt.Desktop;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.io.File;
import java.io.IOException;

import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JTabbedPane;
import javax.xml.bind.JAXBException;

import patientInfo.ImportXml;

//import TabbedPane.ButtonHandler;

public class Virtual_Lab extends JFrame {
	private static final long serialVersionUID = 7859701997645788087L;

	/* Menu declarations */
	private JMenuBar menuBar;
	private JMenu menuBar_file, menuBar_results, menuBar_help;
	private JMenuItem fileItem_new_patient, fileItem_show_case_history,
			fileItem_speech_audiometry, fileItem_exit,
			resultItem_show_pathology, resultItem_save_results,
			resultItem_clear_all, helpItem_tutorial, helpItem_about;

	/* Get patient data from XML file */
	private ImportXml patientData = null;

	/* Tab declarations */
	private Tab1 jp1;
	private Tab2 jp2;

	/* Patient history declarations */
	private PatientHistory history;

	public Virtual_Lab() {
		CreateMenuBar();

		// import xml files
		try {
			patientData = new ImportXml("createdTest.xml");
		} catch (JAXBException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}

		history = new PatientHistory(patientData);

		// Here we are creating the object
		JTabbedPane jtp = new JTabbedPane();

		// This creates the template on the windowed application that we will be
		// using
		getContentPane().add(jtp);

		jp1 = new Tab1(patientData, history);
		jp2 = new Tab2();

		// This adds the first and second tab to our tabbed pane object and
		// names it
		jtp.addTab("Testing", jp1);
		jtp.addTab("Results", jp2);

		setExtendedState(JFrame.MAXIMIZED_BOTH);
		setMinimumSize(new Dimension(800, 650));
		setVisible(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
	}

	void CreateMenuBar() {
		Menu_EventClick e = new Menu_EventClick();

		menuBar = new JMenuBar();
		menuBar_file = new JMenu("File");
		menuBar_file.setMnemonic(KeyEvent.VK_F);
		menuBar_file.getAccessibleContext().setAccessibleDescription(
				"File menu");
		menuBar.add(menuBar_file);
		/* File Items: New Patient */
		fileItem_new_patient = new JMenuItem("New Patient");
		fileItem_new_patient.setMnemonic(KeyEvent.VK_N);
		fileItem_new_patient.addActionListener(e);
		menuBar_file.add(fileItem_new_patient);
		/* File Items: Show Case History */
		fileItem_show_case_history = new JMenuItem("Show Case History");
		fileItem_show_case_history.setMnemonic(KeyEvent.VK_H);
		fileItem_show_case_history.addActionListener(e);
		menuBar_file.add(fileItem_show_case_history);
		/* File Items: Show Case History */
		fileItem_speech_audiometry = new JMenuItem("Speech Audiometry");
		fileItem_speech_audiometry.setMnemonic(KeyEvent.VK_P);
		fileItem_speech_audiometry.addActionListener(e);
		menuBar_file.add(fileItem_speech_audiometry);
		/* File Items: Seperator */
		menuBar_file.addSeparator();
		// File Items: Exits
		fileItem_exit = new JMenuItem("Exit");
		fileItem_exit.setMnemonic(KeyEvent.VK_E);
		fileItem_exit.addActionListener(e);
		menuBar_file.add(fileItem_exit);

		menuBar_results = new JMenu("Results");
		menuBar_results.setMnemonic(KeyEvent.VK_R);
		menuBar_results.getAccessibleContext().setAccessibleDescription(
				"Result menu");
		menuBar.add(menuBar_results);
		/* Result Items: Show Pathology */
		resultItem_show_pathology = new JMenuItem("Show Pathology");
		resultItem_show_pathology.setMnemonic(KeyEvent.VK_H);
		resultItem_show_pathology.addActionListener(e);
		menuBar_results.add(resultItem_show_pathology);
		/* Result Items: Save Results */
		resultItem_save_results = new JMenuItem("Save Results");
		resultItem_save_results.setMnemonic(KeyEvent.VK_A);
		resultItem_save_results.addActionListener(e);
		menuBar_results.add(resultItem_save_results);
		/* Result Items: Clear All */
		resultItem_clear_all = new JMenuItem("Clear All");
		resultItem_clear_all.setMnemonic(KeyEvent.VK_C);
		resultItem_clear_all.addActionListener(e);
		menuBar_results.add(resultItem_clear_all);

		/* Menu Bar Item: Help */
		menuBar_help = new JMenu("Help");
		menuBar_help.setMnemonic(KeyEvent.VK_H);
		menuBar_help.getAccessibleContext().setAccessibleDescription(
				"Help Menu");
		menuBar.add(menuBar_help);
		/* Help Items: Tutorial */
		helpItem_tutorial = new JMenuItem("Tutorial");
		helpItem_tutorial.setMnemonic(KeyEvent.VK_T);
		helpItem_tutorial.addActionListener(e);
		menuBar_help.add(helpItem_tutorial);
		/* Help Items: Seperator */
		menuBar_help.addSeparator();
		/* Help Items: About */
		helpItem_about = new JMenuItem("About");
		helpItem_about.setMnemonic(KeyEvent.VK_A);
		helpItem_about.addActionListener(e);
		menuBar_help.add(helpItem_about);

		// add menu bar to frame
		setJMenuBar(menuBar);
	}

	public class Menu_EventClick implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			if (e.getSource() == fileItem_new_patient) {
				/* Creates new patient */
				new Create_Pathology_Selector_Window(history, patientData);
			}
			if (e.getSource() == fileItem_show_case_history) {
				/* Brings up case history */

			}
			if (e.getSource() == fileItem_speech_audiometry) {
				// TODO:
			}
			if (e.getSource() == fileItem_exit) {
				// TODO: Exits the application
				System.exit(0);
			}
			if (e.getSource() == resultItem_show_pathology) {
				// TODO:
			}
			if (e.getSource() == resultItem_save_results) {
				// TODO:
			}
			if (e.getSource() == resultItem_clear_all) {
				// TODO:
			}
			if(e.getSource() == helpItem_tutorial) {
				/* Opens a word document that gives the user a tutorial on how to use the program - sohn 11/17/13 */
				helpTutorial_Function();
			}
			if (e.getSource() == helpItem_about) {
				/* Create a new window that will tell user about the project */
				new Create_About_Window();
			}
		}
	}

	public void helpTutorial_Function() {
		/* Gets the filepath */
		String filepath = System.getProperty("user.dir") + "\\Virtual_Masking_Lab_Tutorial.docx";
		Desktop desktop = Desktop.getDesktop();
		
		try {
			File file = new File(filepath);
			desktop.open(file); // opens the file in the filepath
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	class ButtonHandler implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JOptionPane.showMessageDialog(null, "I've been pressed",
					"What happened?", JOptionPane.INFORMATION_MESSAGE);
		}
	}

	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			@Override
			public void run() {
				new Virtual_Lab();
			}
		});
	}

}
