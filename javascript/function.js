function openform (element) {
	document.getElementById(element).style.display = 'block';
}

function closeform(element) {
	document.getElementById(element).style.display = 'none';
}

function openFileOption()
{
document.getElementById("file1").click();
}

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
	document.getElementById("CurrentPatient").innerHTML = arr[0];
	return
}

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
		str = str.concat(" ");
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

		xmlhttp.open("GET", "php/edit_patient.php?q="+str, true);
		xmlhttp.send();
	}
}