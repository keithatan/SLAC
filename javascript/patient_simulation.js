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
    "BL_8000",
    "BMR_125",
    "BMR_250",
    "BMR_500",
    "BMR_750",
    "BMR_1000",
    "BMR_1500",
    "BMR_2000",
    "BMR_3000",
    "BMR_4000",
    "BMR_6000",
    "BMR_8000",
    "BML_125",
    "BML_250",
    "BML_500",
    "BML_750",
    "BML_1000",
    "BML_1500",
    "BML_2000",
    "BML_3000",
    "BML_4000",
    "BML_6000",
    "BML_8000"];

function patient(arr)
{
    var R = "R";
    var L = "L";
    var BR = "BR";
    var BL = "BL";	
    var i = 0;
	this.first_name = arr[i++];
	this.last_name = arr[i++];
	this.description = arr[i++];
	this.R_125 = [125, "R", arr[i++]]; 
    this.R_250 = [250, "R", arr[i++]]; 
    this.R_500 = [500, "R", arr[i++]]; 
    this.R_750 = [750, "R", arr[i++]]; 
    this.R_1000 = [1000, "R", arr[i++]]; 
    this.R_1500 = [1500, "R", arr[i++]]; 
    this.R_2000 = [2000, "R", arr[i++]]; 
    this.R_3000 = [3000, "R", arr[i++]]; 
    this.R_4000 = [4000, "R", arr[i++]]; 
    this.R_6000 = [6000, "R", arr[i++]]; 
    this.R_8000 = [8000, "R", arr[i++]]; 
    this.L_125 = [125, "L", arr[i++]]; 
    this.L_250 = [250, "L", arr[i++]]; 
    this.L_500 = [500, "L", arr[i++]]; 
    this.L_750 = [750, "L", arr[i++]]; 
    this.L_1000 = [1000, "L", arr[i++]]; 
    this.L_1500 = [1500, "L", arr[i++]]; 
    this.L_2000 = [2000, "L", arr[i++]]; 
    this.L_3000 = [3000, "L", arr[i++]]; 
    this.L_4000 = [4000, "L", arr[i++]]; 
    this.L_6000 = [6000, "L", arr[i++]]; 
    this.L_8000 = [8000, "L", arr[i++]]; 
    this.BR_125 = [125, "BR", arr[i++]]; 
    this.BR_250 = [250, "BR", arr[i++]]; 
    this.BR_500 = [500, "BR", arr[i++]]; 
    this.BR_750 = [750, "BR", arr[i++]]; 
    this.BR_1000 = [1000, "BR", arr[i++]]; 
    this.BR_1500 = [1500, "BR", arr[i++]]; 
    this.BR_2000 = [2000, "BR", arr[i++]]; 
    this.BR_3000 = [3000, "BR", arr[i++]]; 
    this.BR_4000 = [4000, "BR", arr[i++]]; 
    this.BR_6000 = [6000, "BR", arr[i++]]; 
    this.BR_8000 = [8000, "BR", arr[i++]]; 
    this.BL_125 = [125, "BL", arr[i++]]; 
    this.BL_250 = [250, "BL", arr[i++]]; 
    this.BL_500 = [500, "BL", arr[i++]]; 
    this.BL_750 = [750, "BL", arr[i++]]; 
    this.BL_1000 = [1000, "BL", arr[i++]]; 
    this.BL_1500 = [1500, "BL", arr[i++]]; 
    this.BL_2000 = [2000, "BL", arr[i++]]; 
    this.BL_3000 = [3000, "BL", arr[i++]]; 
    this.BL_4000 = [4000, "BL", arr[i++]]; 
    this.BL_6000 = [6000, "BL", arr[i++]]; 
    this.BL_8000 = [8000, "BL", arr[i++]];
    this.BMR_125 = [125, "BMR", arr[i++]]; 
    this.BMR_250 = [250, "BMR", arr[i++]]; 
    this.BMR_500 = [500, "BMR", arr[i++]]; 
    this.BMR_750 = [750, "BMR", arr[i++]]; 
    this.BMR_1000 = [1000, "BMR", arr[i++]]; 
    this.BMR_1500 = [1500, "BMR", arr[i++]]; 
    this.BMR_2000 = [2000, "BMR", arr[i++]]; 
    this.BMR_3000 = [3000, "BMR", arr[i++]]; 
    this.BMR_4000 = [4000, "BMR", arr[i++]]; 
    this.BMR_6000 = [6000, "BMR", arr[i++]]; 
    this.BMR_8000 = [8000, "BMR", arr[i++]]; 
    this.BML_125 = [125, "BML", arr[i++]]; 
    this.BML_250 = [250, "BML", arr[i++]]; 
    this.BML_500 = [500, "BML", arr[i++]]; 
    this.BML_750 = [750, "BML", arr[i++]]; 
    this.BML_1000 = [1000, "BML", arr[i++]]; 
    this.BML_1500 = [1500, "BML", arr[i++]]; 
    this.BML_2000 = [2000, "BML", arr[i++]]; 
    this.BML_3000 = [3000, "BML", arr[i++]]; 
    this.BML_4000 = [4000, "BML", arr[i++]]; 
    this.BML_6000 = [6000, "BML", arr[i++]]; 
    this.BML_8000 = [8000, "BML", arr[i++]];

    this.list = [ this.R_125,
        this.R_250, 
        this.R_500, 
        this.R_750, 
        this.R_1000, 
        this.R_1500, 
        this.R_2000, 
        this.R_3000, 
        this.R_4000, 
        this.R_6000, 
        this.R_8000, 
        this.L_125, 
        this.L_250, 
        this.L_500, 
        this.L_750, 
        this.L_1000, 
        this.L_1500, 
        this.L_2000, 
        this.L_3000, 
        this.L_4000, 
        this.L_6000, 
        this.L_8000, 
        this.BR_125, 
        this.BR_250, 
        this.BR_500, 
        this.BR_750, 
        this.BR_1000, 
        this.BR_1500, 
        this.BR_2000, 
        this.BR_3000, 
        this.BR_4000, 
        this.BR_6000, 
        this.BR_8000, 
        this.BL_125, 
        this.BL_250, 
        this.BL_500, 
        this.BL_750, 
        this.BL_1000, 
        this.BL_1500, 
        this.BL_2000, 
        this.BL_3000, 
        this.BL_4000, 
        this.BL_6000, 
        this.BL_8000,
        this.BMR_125, 
        this.BMR_250, 
        this.BMR_500, 
        this.BMR_750, 
        this.BMR_1000, 
        this.BMR_1500, 
        this.BMR_2000, 
        this.BMR_3000, 
        this.BMR_4000, 
        this.BMR_6000, 
        this.BMR_8000, 
        this.BML_125, 
        this.BML_250, 
        this.BML_500, 
        this.BML_750, 
        this.BML_1000, 
        this.BML_1500, 
        this.BML_2000, 
        this.BML_3000, 
        this.BML_4000, 
        this.BML_6000, 
        this.BML_8000];
    //add a variation of +5 to each value    
    for(var i = 0; i< this.list.length; i++)
    {
        this.list[i].push(Math.floor((Math.random() * 3) + 1));
        this.list[i].push(0);
    }
}

/*Creating global variables don't reuse these names*/
var PatientObject;
var off = "rgb(255, 255, 255)"; //button is off color code
var on1 = "rgb(255, 0, 0)"; //left panel button is "on" color code
var on2 = "rgb(100, 149, 237)"; // right panel button is "on" color code

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
    string = string.concat(" ");
    string = string.concat(PatientObject.last_name);
    document.getElementById("CurrentPatient").innerHTML = string;
    return
}

function clearPatient()
{
    PatientObject = undefined;
    document.getElementById("CurrentPatient").innerHTML = "No Patient Selected";
    return
}

function simulate()
{
    if (document.getElementById("match").style.backgroundColor == on2) 
        {
            return
        }
    /*Use the actual interface text to get current state*/
    var Stimulus1 = document.getElementById("Stimulus1").innerHTML.replace("Stimulus: ", "");
    var Stimulus2 = document.getElementById("Stimulus2").innerHTML.replace("Stimulus: ", "");
    var Transducer1 = document.getElementById("Transducer1").innerHTML.replace("Transducer: ","");
    var Transducer2 = document.getElementById("Transducer2").innerHTML.replace("Transducer: ","");
    var Routing1 = document.getElementById("Routing1").innerHTML.replace("Routing: ","");
    var Routing2 = document.getElementById("Routing2").innerHTML.replace("Routing: ","");
    var Freq = parseInt(document.getElementById("Freq").innerHTML.replace(" Hz", ""),10);
    var dB1 = parseInt(document.getElementById("dB1").innerHTML.replace(" dB HL", ""),10);
    var dB2 = parseInt(document.getElementById("dB2").innerHTML.replace(" dB HL", ""),10);
    var NB = (document.getElementById("NB").style.backgroundColor == on1);
    var NB2 = (document.getElementById("NB2").style.backgroundColor == on2);

    var Present1 = 0;
    var Present2 = 0;
    /*var off = "rgb(255, 255, 255)";
    var on1 = "rgb(255, 0, 0)";
    var on2 = "rgb(100, 149, 237)";*/
    var key = "";
    var dB = 0;

    document.getElementById("result").innerHTML = "INVALID :("; //Used to show if patient heard the sound


    //check if present button is on
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
    if (PatientObject == undefined) 
    {
        return;
    }
    //Present button must be on in order to play a sound
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
                    key = "BMR";
                    db = dB2;
                }
                else if (Routing2 = "Left" && Routing1 == "Right") 
                {
                    //right ear is masked so check only left ear
                    key = "BML";
                    db = dB2;
                }
            }
            else if(!NB && NB2)
            {
                //bone masking using right panel for masking
                if (Routing1 == "Left" && Routing2 == "Right") 
                {
                    //right ear is masked so check only left ear
                    key = "BML";
                    db = dB1;
                }
                else if (Routing2 = "Left" && Routing1 == "Right") 
                {
                    //left ear is masked so check only right ear
                    key = "BMR";
                    db = dB1;
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
                key = "BR";
                dB = dB1;
            }

            else if (Routing1 == "Left") 
            {
                //check left ear for bone response
                key = "BL";
                dB = dB1;
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
                key = "BR";
                dB = dB2;
            }

            else if (Routing2 == "Left") 
            {
                //check left ear for bone response
                key = "BL";
                dB = dB2;
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
                key="R";
                dB = dB1;
            }

            else if (Routing1 == "Left") 
            {
                //check left ear for phone response
                key = "L";
                dB = dB1;
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
                key = "R";
                dB = dB2;
            }

            else if (Routing2 == "Left") 
            {
                //check left ear for response
                key = "L";
                dB = dB2;
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

    for (var i = 0; i < PatientObject.list.length; i++) 
    {
        if (PatientObject.list[i][1] == key && PatientObject.list[i][0] == Freq) 
        {
            if ((PatientObject.list[i][3] == PatientObject.list[i][4] % 3 + 1) && PatientObject.list[i][2] + 5 <= dB) 
            {
                PatientObject.list[i][4] += 1;
                document.getElementById("result").innerHTML = "VALID!";
            }
            else if (PatientObject.list[i][2] <= dB) 
            {
                PatientObject.list[i][4] += 1;
                document.getElementById("result").innerHTML = "VALID!";
            }
        }
    };
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

/*must press reset before running another test*/
function reset()
{
    document.getElementById("result").innerHTML = "Result Displayed here";
    var temp = document.getElementsByClassName("btn-default");
    for (var i = 0; i < temp.length; i++) {
        temp[i].style.backgroundColor = off;
    };
    return
}