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

function sleep(milliseconds) {
  var start = new Date().getTime();
  for (var i = 0; i < 1e7; i++) {
    if ((new Date().getTime() - start) > milliseconds){
      break;
    }
  }
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

//print current patient
function currentPatient(arr){
    PatientObject = new patient(arr);
    var string = "";
    string = PatientObject.first_name.concat(string);
    string = string.concat(PatientObject.last_name);
    document.getElementById("CurrentPatient").innerHTML = string;
    return
}

function simulate()
{
    var Stimulus1 = document.getElementById("Stimulus1").innerHTML.replace("Stimulus: ", "");
    var Stimulus2 = document.getElementById("Stimulus2").innerHTML.replace("Stimulus: ", "");
    var Transducer1 = document.getElementById("Transducer1").innerHTML.replace("Transducer: ","");
    var Transducer2 = document.getElementById("Transducer2").innerHTML.replace("Transducer: ","");
    var Routing1 = document.getElementById("Routing1").innerHTML.replace("Routing: ","");
    var Routing2 = document.getElementById("Routing2").innerHTML.replace("Routing: ","");
    var Freq = document.getElementById("Freq").innerHTML.replace(" Hz", "");
    var NB = (document.getElementById("NB").style.backgroundColor == on1);
    var NB2 = (document.getElementById("NB2").style.backgroundColor == on2);

    var Present1 = 0;
    var Present2 = 0;
    var off = "rgb(255, 255, 255)";
    var on1 = "rgb(255, 0, 0)";
    var on2 = "rgb(100, 149, 237)";

    document.getElementById("result").innerHTML = "INVALID :(";

    if (document.getElementById("Present1").style.backgroundColor == on1) 
    {
        Present1 = 1;
    }
    if (document.getElementById("Present2").style.backgroundColor == on2) 
    {
        Present2 = 1;
    }
    if (!Present1 && !Present2) 
    {
        return;
    }

    if (Present1 && Present2) 
    {
        if (Transducer1 == "Bone" && Transducer2 == "Bone") 
        {
            if (NB && !NB2 && Routing1 != Routing2) 
            {
                //Bone masking using left panel for masking
                if (Routing1 == "Left" && Routing2 == "Right") 
                {
                    //left ear is masked so check only right ear
                }
                else if (Routing2 = "Left" && Routing1 == "Right") 
                {
                    //right ear is masked so check only left ear
                }
            }
            else if(!NB && NB2)
            {
                //bone masking using right panel for masking
                if (Routing1 == "Left" && Routing2 == "Right") 
                {
                    //right ear is masked so check only left ear
                }
                else if (Routing2 = "Left" && Routing1 == "Right") 
                {
                    //left ear is masked so check only right ear
                }
            }
        }
        else
        {
            //invalid operation
            return;
        }
    }
    else
    {
        if (Transducer1 == "Bone" && Present1) 
        {
            if (Routing1 == "Right") 
            {
                //check right ear for bone response
            }

            else if (Routing1 == "Left") 
            {
                //check left ear for bone response
            }
            else
            {
                //invalid operation
                return;
            }
        }
        else if (Transducer2 == "Bone" && Present2) 
        {
            if (Routing2 == "Right") 
            {
                //check right ear for bone response
            }

            else if (Routing2 == "Left") 
            {
                //check left ear for bone response
            }
            else
            {
                //invalid operation
                return;
            }
        }
        else if (Transducer1 == "Phone" && Present1) 
        {
            if (Routing1 == "Right") 
            {
                //check right ear for phone response
            }

            else if (Routing1 == "Left") 
            {
                //check left ear for phone response
            }
            else
            {
                //invalid operation
                return;
            }
        }
        else if (Transducer2 == "Phone" && Present2) 
        {
            if (Routing2 == "Right") 
            {
                //check right ear for phone response
            }

            else if (Routing2 == "Left") 
            {
                //check left ear for response
            }
            else
            {
                //invalid operation
                return;
            }
        }
        else
        {
            return;
        }
    }
    document.getElementById("result").innerHTML = "VALID!";
/*    sleep(8000);
    if (Present1)
    {
        document.getElementById("Present1").style.backgroundColor = off;
    }
    if (Present2) 
    {
        document.getElementById("Present2").style.backgroundColor = off;
    }*/

}