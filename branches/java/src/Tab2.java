import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;

import javax.swing.JButton;
import javax.swing.JPanel;

public class Tab2 extends JPanel {
	private static final long serialVersionUID = 1L;

	public Tab2() {
		JButton button;
		JButton button2;

		GridBagConstraints c = new GridBagConstraints();

		GridBagLayout layout = new GridBagLayout();
		setLayout(layout);

		button = new JButton("Audiograph Results");
		c.fill = GridBagConstraints.BOTH;
		c.weightx = .8;
		c.weighty = 1;
		c.gridx = 1;
		c.gridy = 0;
		add(button, c);

		button2 = new JButton("Audiometer Results");
		c.fill = GridBagConstraints.BOTH;
		c.weightx = .3;
		c.weighty = .5;
		c.gridx = 0;
		c.gridy = 0;
		add(button2, c);

	}

}