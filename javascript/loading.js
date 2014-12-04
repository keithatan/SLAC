function loadPatient(name) {
	if (name == "pat1") {
		initPat();
		// load patient 1 data from file
		// call function "setPatInfo", sending loaded data
	} else if (name == "pat2") {
		initPat();
		// load patient 2 data from file
		// call function "setPatInfo", sending loaded data
	} else if (name == "pat3") {
		initPat();
		// load patient 3 data from file
		// call function "setPatInfo", sending loaded data
	} else if (name == "pat4") {
		initPat();
		// load patient 4 data from file
		// call function "setPatInfo", sending loaded data
	}
	
	function initPat() {
		document.getElementById("patArea").style.textAlign = "left";
		document.getElementById("patHeader").innerHTML = "";
		document.getElementById("patInfoHider").style.opacity = "1";
	}
	
	function setPatInfo(info) {
		// parse patient info into sections such as "name", "history", etc.
		// adjust the appropriate fields in the audiometer information display based on parsed data
	}
}