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
	var val = document.getElementById("form-input").value;
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
			}
		}
		var str = val.concat(" all");
		xmlhttp.open("GET", "php/getpatient?q="+str, true);
		xmlhttp.send();
	}

	var arr = string.split(",");
	var i = 0;

	this.first = arr[i++];
	this.last = arr[i++];
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
