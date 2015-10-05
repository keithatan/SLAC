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
