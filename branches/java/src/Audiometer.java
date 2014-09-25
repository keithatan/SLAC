import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.JButton;
import javax.swing.JPanel;

//import net.miginfocom.swing.MigLayout;

public class Audiometer extends JPanel {

	private static final long serialVersionUID = -1426319786241775334L;

	BufferedImage image;
	int newHeight;

	public Audiometer() {
		try {
			image = ImageIO.read(new File("AudioMeter(100).jpg"));
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		JButton button = new JButton("Button 1");
		add(button);
	}

	@Override
	public void paintComponent(Graphics g) {
		super.paintComponent(g);

		newHeight = (getWidth() * image.getHeight()) / image.getWidth();
		g.drawImage(image, 0, 0, getWidth(), newHeight, this);
	}
}
