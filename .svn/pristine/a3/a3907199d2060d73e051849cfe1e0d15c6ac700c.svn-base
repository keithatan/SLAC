import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.SwingConstants;


public class Create_About_Window extends JFrame {
	private static final long serialVersionUID = 1L;
	
	/* Constructor for Create_About_Window class */
	public Create_About_Window() {
		Create_New_About_Window(new Create_Objects());
	}
	
	public static void Create_New_About_Window(final JFrame frame) {
		EventQueue.invokeLater(new Runnable() {
	        public void run() {
	    		frame.setTitle("About Virtual Masking Lab");
	        	frame.setSize(500, 500);
	        	frame.setVisible(true);
	        }
		});
	}
	
	/* Creates all objects inside of the "About" window */
	public class Create_Objects extends JFrame {
		private static final long serialVersionUID = 1L;

		private JLabel[] about_label = new JLabel[12];
		private JTextArea about_text_area = new JTextArea();
		private JScrollPane about_scroll_pane = new JScrollPane(about_text_area);
		private JButton ok_button = new JButton("Okay");
		
		private JPanel about_panel = new JPanel();
		
		/* Constructor for Create_Objects */
		public Create_Objects(){
			this.setResizable(false);
			this.setAlwaysOnTop(true);
			
			Add_Label();
			Add_TextArea();
			Add_Buttons();
			Add_Panel();
			Add_Listeners();
		}
		
		public void Add_Label() {
			/* Gets the current directory that the application is in - sohn 10/28/13 */
			String current_directory = System.getProperty("user.dir") + "\\About_Title_Label.txt";
			
			/* There are 12 unique lines that are seen in About_Title_Label.txt - sohn 11/7/13 */
			String[] line = new String[12];
			
			try {
				BufferedReader buffered_reader = new BufferedReader(new FileReader(current_directory));
				try {
					for(int i = 0; i < 12; i++) {
						line[i] = buffered_reader.readLine();
					}
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				buffered_reader.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			for(int i = 0; i < 12; i++) {
				/* Add the content found in About_Title_Label.txt - sohn 11/7/13 */
				about_label[i] = new JLabel("<html><p align=center>" + line[i] + "</html>", SwingConstants.CENTER);
				about_label[i].setAlignmentX(CENTER_ALIGNMENT);				
			}
		}
		public void Add_TextArea() {
			/* Gets the current directory that the application is in - sohn 10/28/13 */
			String current_directory = System.getProperty("user.dir") + "\\GNU_General_Public_License.txt";
			
			try {
				/* Use a buffered reader to read in a large text file */
				BufferedReader buffered_reader = new BufferedReader(new FileReader(current_directory));
				try {
					/* Create a string builder that will hold all the text */
					StringBuilder string_builder = new StringBuilder();
					/* Read the first line of the text file */
					String line = buffered_reader.readLine();;
					
		        	while (line != null) {
		        		/* Put the read line into the string builder */
		        		string_builder.append(line);
		        		/* Put a new line into the string builder */
		        		string_builder.append('\n');
		        		/* Store the next line into the variable "line" */
		            	line = buffered_reader.readLine();
		        	}
		        	/* Set the about text field as the string builder */
		        	about_text_area.setText(string_builder.toString());
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				/* Close the buffered reader */
				buffered_reader.close();
			} catch(IOException e) {
				e.printStackTrace();
			}
			/* Set the text area as uneditable */
			about_text_area.setEditable(false);
			about_text_area.setLineWrap(true);
			about_text_area.setWrapStyleWord(true);
		}
		public void Add_Buttons() {
			ok_button.setAlignmentX(CENTER_ALIGNMENT);
		}
		
		public void Add_Panel() {
			/* Add panel to the frame */
			add(about_panel);
			
			/* Add components to the panel */
			for(int i = 0; i < 3; i++) { about_panel.add(about_label[i]); }
			about_panel.add(about_scroll_pane);
			for(int i = 3; i < 12; i++) { about_panel.add(about_label[i]); }
			about_panel.add(ok_button);
			
			/* Set the layout as a box layout for about_panel */
			about_panel.setLayout(new BoxLayout(about_panel, BoxLayout.Y_AXIS));
		}
		
		public void Add_Listeners() {
			ok_button.addActionListener(Button_Listener);
		}
		private ActionListener Button_Listener = new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				setVisible(false);
			}
		};
	}
}