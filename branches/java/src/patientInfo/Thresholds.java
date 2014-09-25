package patientInfo;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(name = "thresholds")
@XmlType(propOrder = { "ac_right", "ac_left", "bc_right", "bc_left",
		"masked_ac_right", "masked_ac_left", "masked_bc_right",
		"masked_bc_left", "no_response_right", "no_response_left",
		"soundfield", "aided", "ucl_right", "ucl_left" })
public class Thresholds {

	private Freq ac_right;
	private Freq ac_left;
	private Freq bc_right;
	private Freq bc_left;
	private Freq masked_ac_right;
	private Freq masked_ac_left;
	private Freq masked_bc_right;
	private Freq masked_bc_left;
	private Freq no_response_right;
	private Freq no_response_left;
	private Freq soundfield;
	private Freq aided;
	private Freq ucl_right;
	private Freq ucl_left;

	public Freq getAc_right() {
		return ac_right;
	}

	public void setAc_right(Freq ac_right) {
		this.ac_right = ac_right;
	}

	public Freq getAc_left() {
		return ac_left;
	}

	public void setAc_left(Freq ac_left) {
		this.ac_left = ac_left;
	}

	public Freq getBc_right() {
		return bc_right;
	}

	public void setBc_right(Freq bc_right) {
		this.bc_right = bc_right;
	}

	public Freq getBc_left() {
		return bc_left;
	}

	public void setBc_left(Freq bc_left) {
		this.bc_left = bc_left;
	}

	public Freq getMasked_ac_right() {
		return masked_ac_right;
	}

	public void setMasked_ac_right(Freq masked_ac_right) {
		this.masked_ac_right = masked_ac_right;
	}

	public Freq getMasked_ac_left() {
		return masked_ac_left;
	}

	public void setMasked_ac_left(Freq masked_ac_left) {
		this.masked_ac_left = masked_ac_left;
	}

	public Freq getMasked_bc_right() {
		return masked_bc_right;
	}

	public void setMasked_bc_right(Freq masked_bc_right) {
		this.masked_bc_right = masked_bc_right;
	}

	public Freq getMasked_bc_left() {
		return masked_bc_left;
	}

	public void setMasked_bc_left(Freq masked_bc_left) {
		this.masked_bc_left = masked_bc_left;
	}

	public Freq getNo_response_right() {
		return no_response_right;
	}

	public void setNo_response_right(Freq no_response_right) {
		this.no_response_right = no_response_right;
	}

	public Freq getNo_response_left() {
		return no_response_left;
	}

	public void setNo_response_left(Freq no_response_left) {
		this.no_response_left = no_response_left;
	}

	public Freq getSoundfield() {
		return soundfield;
	}

	public void setSoundfield(Freq soundfield) {
		this.soundfield = soundfield;
	}

	public Freq getAided() {
		return aided;
	}

	public void setAided(Freq aided) {
		this.aided = aided;
	}

	public Freq getUcl_right() {
		return ucl_right;
	}

	public void setUcl_right(Freq ucl_right) {
		this.ucl_right = ucl_right;
	}

	public Freq getUcl_left() {
		return ucl_left;
	}

	public void setUcl_left(Freq ucl_left) {
		this.ucl_left = ucl_left;
	}

}
