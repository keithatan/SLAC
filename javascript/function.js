//array on column names
var array = [ "first_name", "last_name", "description",
    "R_125",
    "R_250",
    "R_500",
    "R_750",
    "R_1000",
    "R_1500",
    "R_2000",
    "R_3000",
    "R_4000",
    "R_6000",
    "R_8000",
    "L_125",
    "L_250",
    "L_500",
    "L_750",
    "L_1000",
    "L_1500",
    "L_2000",
    "L_3000",
    "L_4000",
    "L_6000",
    "L_8000",
    "BR_125",
    "BR_250",
    "BR_500",
    "BR_750",
    "BR_1000",
    "BR_1500",
    "BR_2000",
    "BR_3000",
    "BR_4000",
    "BR_6000",
    "BR_8000",
    "BL_125",
    "BL_250",
    "BL_500",
    "BL_750",
    "BL_1000",
    "BL_1500",
    "BL_2000",
    "BL_3000",
    "BL_4000",
    "BL_6000",
    "BL_8000"];

function patient(arr)
{
	var i = 0;
	this.first_name = arr[i++];
	this.last_name = arr[i++];
	this.description = arr[i++];
	this.R_125 = arr[i++]; 
    this.R_250 = arr[i++]; 
    this.R_500 = arr[i++]; 
    this.R_750 = arr[i++]; 
    this.R_1000 = arr[i++]; 
    this.R_1500 = arr[i++]; 
    this.R_2000 = arr[i++]; 
    this.R_3000 = arr[i++]; 
    this.R_4000 = arr[i++]; 
    this.R_6000 = arr[i++]; 
    this.R_8000 = arr[i++]; 
    this.L_125 = arr[i++]; 
    this.L_250 = arr[i++]; 
    this.L_500 = arr[i++]; 
    this.L_750 = arr[i++]; 
    this.L_1000 = arr[i++]; 
    this.L_1500 = arr[i++]; 
    this.L_2000 = arr[i++]; 
    this.L_3000 = arr[i++]; 
    this.L_4000 = arr[i++]; 
    this.L_6000 = arr[i++]; 
    this.L_8000 = arr[i++]; 
    this.BR_125 = arr[i++]; 
    this.BR_250 = arr[i++]; 
    this.BR_500 = arr[i++]; 
    this.BR_750 = arr[i++]; 
    this.BR_1000 = arr[i++]; 
    this.BR_1500 = arr[i++]; 
    this.BR_2000 = arr[i++]; 
    this.BR_3000 = arr[i++]; 
    this.BR_4000 = arr[i++]; 
    this.BR_6000 = arr[i++]; 
    this.BR_8000 = arr[i++]; 
    this.BL_125 = arr[i++]; 
    this.BL_250 = arr[i++]; 
    this.BL_500 = arr[i++]; 
    this.BL_750 = arr[i++]; 
    this.BL_1000 = arr[i++]; 
    this.BL_1500 = arr[i++]; 
    this.BL_2000 = arr[i++]; 
    this.BL_3000 = arr[i++]; 
    this.BL_4000 = arr[i++]; 
    this.BL_6000 = arr[i++]; 
    this.BL_8000 = arr[i++]; 
}

var PatientObject;
//used for pop up forms
function openform (element) {
	document.getElementById(element).style.display = 'block';
}

function closeform(element) {
	document.getElementById(element).style.display = 'none';
}

//this is for load from a file
function openFileOption()
{
document.getElementById("file1").click();
}

//this is to check a form for valid inputs
function checkForm(element)
{
	var x = document.getElementById(element).elements;
	for (var i = x.length - 1; i >= 0; i--) 
	{
		if (x[i].value == "") {
			alert("Please fill in all fields");
			return
		};
	}

	document.getElementById(element).submit();
	return
}


//these functions will load the patient data to test on
function loadPatient()
{
	var string = "";
	var val =document.getElementById("forminput").value;
	if (val == "") {
		document.getElementById("selectPatient").innerHTML = "Please Select Patient";
		return
	}
	else {
		if (window.XMLHttpRequest) {
			xmlhttp = new XMLHttpRequest();
		}
		else{
			xmlhttp = new ActiveXObject();
		}

		xmlhttp.onreadystatechange = function() {
			if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
				string = xmlhttp.responseText;
				var arr = string.split(",");
				document.getElementById("Popup_2").style.display = 'none';
				currentPatient(arr);
			}
		}
		var str = val.concat(" all");
		xmlhttp.open("GET", "php/getpatient.php?q="+str, true);
		xmlhttp.send();
	}

	return
}

function currentPatient(arr){
	PatientObject = new patient(arr);
	for (var i = 0; i< arr.length; i++)
	{
		document.getElementById("CurrentPatient").innerHTML = PatientObject.last_name;
	}
	return
}

//used for showing patient in form for selection
function showPatient(str)
{
	if (str == "") {
		document.getElementById("selectPatient").innerHTML = " ";
		return
	}
	else{
		if (window.XMLHttpRequest) {
			xmlhttp = new XMLHttpRequest();
		}
		else{
			xmlhttp = new ActiveXObject();
		}

		xmlhttp.onreadystatechange = function() {
			if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
				document.getElementById("selectPatient").innerHTML = xmlhttp.responseText;
				document.getElementById("hidden-button").style.display = "block";
			}
			else {
				document.getElementById("hidden-button").style.display = "none";
			}
		}

		xmlhttp.open("GET", "php/getpatient.php?q="+str, true);
		xmlhttp.send();
	}
}

// not used as of now
function showEditPatient(str)
{
	if (str == "") {
		document.getElementById("editPatient").innerHTML = " ";
		return
	}
	else{
		if (window.XMLHttpRequest) {
			xmlhttp = new XMLHttpRequest();
		}
		else{
			xmlhttp = new ActiveXObject();
		}

		xmlhttp.onreadystatechange = function() {
			if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
				document.getElementById("editPatient").innerHTML = xmlhttp.responseText;
				document.getElementById("hidden-button_2").style.display = "block";
			}
			else {
				document.getElementById("hidden-button_2").style.display = "none";
			}
		}

		xmlhttp.open("GET", "php/getpatient.php?q="+str, true);
		xmlhttp.send();
	}
}

//edit the patient values already in the database
function editPatient()
{
	var column = document.getElementById("forminput_2").value;
	if (column == ""){
		alert("Please Select A Value to edit");
		return;
	}
	else {
		var val = document.getElementById("editvalue").value;
		var id = document.getElementById("forminput_3").value;

		var str = "";
		str = id.concat(" ");
		str = str.concat(column);
		str = str.concat(" ");
		str = str.concat(val);

		if (window.XMLHttpRequest) {
				xmlhttp = new XMLHttpRequest();
			}
			else{
				xmlhttp = new ActiveXObject();
			}

			xmlhttp.onreadystatechange = function(){
				if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
					document.getElementById("temp").innerHTML = xmlhttp.responseText;
				}
			}

		xmlhttp.open("GET", "php/getpatient.php?q="+str, true);
		xmlhttp.send();
	}
}