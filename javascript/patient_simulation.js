//array on column names
//HANDLES ALL PATIENT SIMULATIONS SHOULD BE WORKING FINE ACCORDING TO ROBERTA
var fullPatientInfo = {};
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

/*CREATES A PATIENT OBJECT IN WHICH EACH VALUE ASIDE FROM FIRST THREE CONTAIN THE FOLLOWING FORMAT:
[FREQ, LEFT OR RIGHT, HEARING THRESHOLD]*/
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
var on1 = "rgb(186, 85, 211)"; //left panel button is "on" color code
var on2 = "rgb(186, 85, 211)"; // right panel button is "on" color code

/*THIS FUNCTION IS NOT USED*/
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
                combinedResult = JSON.parse(xmlhttp.responseText);
                fullPatientInfo = (combinedResult.objectResult);
                var arr = combinedResult.stringResult.split(",");
                document.getElementById("Popup_2").style.display = 'none';
                currentPatient(arr);
            }
        }
        var str = val.concat(" all");
        xmlhttp.open("GET", "./php/getpatient.php?q="+str, true);
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
/*ALL SIMULATION TAKES PLACE HERE*/

function matchWithDatabase(frequency, leftDb, rightDb) {
    var leftFreq = fullPatientInfo['L_'+frequency];
    var rightFreq = fullPatientInfo['R_'+frequency];
    if(leftDb >= parseInt(leftFreq) && rightDb >= parseInt(rightFreq)) {
        // show green;
        document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
    } else {
        // show red
        document.getElementById("result").innerHTML = '<img src="images/redlight.png" height="40px" />';
    }
}

function matchWithDatabase2(tone, dB, side) 
{
    if (side == 0) 
    {
        var leftFreq = fullPatientInfo['L_'+ tone];
        if (dB >= parseInt(leftFreq)) 
        {
            document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
        }
        else
        {
            document.getElementById("result").innerHTML = '<img src="images/redlight.png" height="40px" />';
        }
 
    }
    else if (side == 1)
    {
        var rightFreq = fullPatientInfo['R_' + tone];
        if (dB >= parseInt(rightFreq)) 
        {
            document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
        }
        else
        {
            document.getElementById("result").innerHTML = '<img src="images/redlight.png" height="40px" />';
        }

    }
    else
    {
        document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
    }
}

function presentLeft(clicked_id) 
{
    var dBLeft = document.getElementById('range1').value;
    var Freq = parseInt(document.getElementById("Freq").innerHTML.replace(" Hz", ""),10);
    var vol1 = dBLeft*0.1;
    var tone = new Tone.Frequency(Freq);
    var merge = new Tone.Merge().toMaster();
    var leftEar = new Tone.Oscillator(tone, "sine");
    
    leftEar.connect(merge.left);
    leftEar.start().stop("+1");

    Tone.Master.volume.value = vol1;

    changeButtonColor(clicked_id);
    matchWithDatabase2(Freq, dBLeft, 0);
}

function presentRight(clicked_id) 
{
    var dB2 = parseInt(document.getElementById("dB2").innerHTML.replace(" dB HL", ""),10);
    var Freq = parseInt(document.getElementById("Freq").innerHTML.replace(" Hz", ""),10);
    var vol2 = dBRight*0.1;
    var tone = new Tone.Frequency(Freq);
    var merge = new Tone.Merge().toMaster();
    var rightEar = new Tone.Oscillator(tone, "sine");

    rightEar.connect(merge.right);
    rightEar.start().stop("+1");

    Tone.Master.volume.value = vol2;

    changeButtonColor(clicked_id);
    matchWithDatabase2(Freq, dB2, 1);
}

function simulate()
{
    if (document.getElementById("match").style.backgroundColor == on2)
        {
            return
        }

    /*************************8PLEASE READ THIS FALL2016****************************/
    /*
        I originally used the html text to determine what buttons were pressed (pretty stupid idea)
        Now I use the actual button itself so please check that I use them correctly
        In order to debug this section you will need to have taken a hearing test and understand what each button does
    */


    /*Use the actual interface text to get current state <----- DEPRECATED!!!!!!!! */
    /*var Stimulus1 = document.getElementById("Stimulus1").innerHTML.replace("Stimulus: ", "");
    var Stimulus2 = document.getElementById("Stimulus2").innerHTML.replace("Stimulus: ", "");
    var Transducer1 = document.getElementById("Transducer1").innerHTML.replace("Transducer: ","");
    var Transducer2 = document.getElementById("Transducer2").innerHTML.replace("Transducer: ","");
    var Routing1 = document.getElementById("Routing1").innerHTML.replace("Routing: ","");
    var Routing2 = document.getElementById("Routing2").innerHTML.replace("Routing: ","");*/
    var Freq = parseInt(document.getElementById("Freq").innerHTML.replace(" Hz", ""),10);
    var dB1 = parseInt(document.getElementById("dB1").innerHTML.replace(" dB HL", ""),10);
    var dB2 = parseInt(document.getElementById("dB2").innerHTML.replace(" dB HL", ""),10);
    var NB = (document.getElementById("NB").style.backgroundColor == on1);
    var NB2 = (document.getElementById("NB2").style.backgroundColor == on2);
    var Tone1 = (document.getElementById("Tone").style.backgroundColor == on1);
    var Tone2 = (document.getElementById("Tone2").style.backgroundColor == on2);

    /**matchWithDatabase(Freq, dB1, dB2);*/

    var Present1 = 0;
    var Present2 = 0;
    var Transducer1 = 0;
    var Transducer2 = 0;
    var Routing1 = 0;
    var Routing2 = 0;

    var key = "";
    var dB = 0;

    var masking = 0; //signal masking test
    var mask_dB = 0;
    var bone_dB = 0;
    var mask_key = "";
    var bone_key = "";
    var threshold_min = 0; //Required for OE (effect) specific to 250hz, 500hz, and 1000hz
    var threshold_max = 40; //Based on ineraural atten something
    var actual_mask_dB = 140;

    //document.getElementById("result").innerHTML = "INVALID :("; //Used to show if patient heard the sound
    


    //check value of transducer1
    if (document.getElementById("Phone").style.backgroundColor == on1)
    {
        Transducer1 = "Phone";
    }
    else if (document.getElementById("Bone").style.backgroundColor == on1)
    {
        Transducer1 = "Bone";
    }
    else
    {
        Transducer1 = "None";
    }

    //Check value of transducer2
    if (document.getElementById("Phone2").style.backgroundColor == on2)
    {
        Transducer2 = "Phone";
    }
    else if (document.getElementById("Bone2").style.backgroundColor == on2)
    {
        Transducer2 = "Bone";
    }
    else
    {
        Transducer2 = "None";
    }

    //check value of routing1
    if (document.getElementById("Left").style.backgroundColor == on1)
    {
        Routing1 = "Left";
    }
    else if (document.getElementById("Right").style.backgroundColor == on1)
    {
        Routing1 = "Right";
    }
    else
    {
        Routing1 = "None";
    }

    //check value of routing2
    if (document.getElementById("Left2").style.backgroundColor == on2)
    {
        Routing2 = "Left";
    }
    else if (document.getElementById("Right2").style.backgroundColor == on2)
    {
        Routing2 = "Right";
    }
    else
    {
        Routing2 = "None";
    }

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
    if (Present1 && Present2 && Tone1 && Tone2)
    {
        if (Transducer1 == "Bone" && Transducer2 == "Phone")
        {
            if (!NB && NB2 && Routing1 != Routing2)
            {
                if (Routing1 == "Left" && Routing2 == "Right")
                {
                    //Right ear will be masked
                    masking = 1;
                    mask_dB = dB2;
                    bone_dB = dB1;
                    mask_key = "BR";
                    bone_key = "BML";

                }
                else if (Routing1 == "Right" && Routing2 == "Left")
                {
                    //Left ear will be masked
                    masking = 1;
                    mask_dB = dB1;
                    bone_dB = dB2;
                    mask_key = "BL";
                    bone_key = "BMR";
                }
            }
            else
            {
                return
            }
        }

        else if (Transducer1 == "Phone" && Transducer2 == "Bone")
        {
            if (NB && !NB2 && Routing1 != Routing2)
            {
                if (Routing1 == "Left" && Routing2 == "Right")
                {
                    //Left ear will be masked
                    masking = 1;
                    mask_dB = dB1;
                    bone_dB = dB2;
                    mask_key = "BL";
                    bone_key = "BMR";
                }
                else if (Routing1 == "Right" && Routing2 == "Left")
                {
                    //Right ear will be masked
                    masking = 1;
                    mask_dB = dB2;
                    bone_dB = dB1;
                    mask_key = "BR";
                    bone_key = "BML";
                }
            }
            else
            {
                return
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
        if (Transducer1 == "Bone" && Present1 && Tone1)
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
        else if (Transducer2 == "Bone" && Present2 && Tone2)
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
        else if (Transducer1 == "Phone" && Present1 && Tone1)
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
        else if (Transducer2 == "Phone" && Present2 && Tone2)
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


    /*Some crazy bone masking algorithm that was described by Grad student in audiology department*/
    if (masking)
    {
        if (Freq == "250")
        {
            threshold_min = 20;
        }
        else if (Freq == "500")
        {
            threshold_min = 15;
        }
        else if (Freq == "500")
        {
            threshold_min = 10;
        }

        for(var i = 0; i < PatientObject.list.length; i++)
        {
            if (PatientObject.list[i][0] == Freq)
            {
                if (PatientObject.list[i][1] == mask_key)
                {
                    threshold_min = threshold_min + PatientObject.list[i][2];
                    fake_mask_dB = PatientObject.list[i][2];
                }
                else if (PatientObject.list[i][1] == bone_key)
                {
                    threshold_max = threshold_max + PatientObject.list[i][2];
                    actual_mask_dB = PatientObject.list[i][2];
                }
            }

            if (mask_dB >= threshold_min && mask_dB <= threshold_max && bone_dB >= actual_mask_dB)
            {
                document.getElementById("result").innerHTML = '<img src="../images/greenlight.png" height="40px" />';
            }
            else if (mask_dB < threshold_min && (bone_dB >= fake_mask_dB || bone_dB >= actual_mask_dB))
            {
                document.getElementById("result").innerHTML = '<img src="../images/greenlight.png" height="40px" />';
            }
            else
            {
                return;
            }
        }
    }
    else
    {
        for (var i = 0; i < PatientObject.list.length; i++)
        {
            if (PatientObject.list[i][1] == key && PatientObject.list[i][0] == Freq)
            {
                if ((PatientObject.list[i][3] == PatientObject.list[i][4] % 3 + 1) && PatientObject.list[i][2] + 5 <= dB)
                {
                    PatientObject.list[i][4] += 1;
                    document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
                }
                else if (PatientObject.list[i][2] <= dB)
                {
                    PatientObject.list[i][4] += 1;
                    document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
                }
            }
        }
    }
}

/*must press reset before running another test*/
function reset(button)
{
    var tmp = document.getElementById(button);
    if (tmp.style.backgroundColor == blueButtonColor) {
        tmp.style.backgroundColor = defaultButtonColor;
        tmp.style.borderColor = defaultButtonColor;
        tmp.style.color = "black";
    }
    else if (tmp.style.backgroundColor == redButtonColor) {
        tmp.style.backgroundColor = defaultButtonColor;
        tmp.style.borderColor = defaultButtonColor;
        tmp.style.color = "black";
    }

    document.getElementById("result").innerHTML = "";
    var match = document.getElementById("match");
    var Present1 = document.getElementById("Present1");
    var Present2 = document.getElementById("Present2");
    match.style.backgroundColor = off;
    Present2.style.backgroundColor = off;
    Present1.style.backgroundColor = off;

    return
}

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

/*CREATES A PATIENT OBJECT IN WHICH EACH VALUE ASIDE FROM FIRST THREE CONTAIN THE FOLLOWING FORMAT:
[FREQ, LEFT OR RIGHT, HEARING THRESHOLD]*/
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
var on1 = "rgb(186, 85, 211)"; //left panel button is "on" color code
var on2 = "rgb(186, 85, 211)"; // right panel button is "on" color code

/*THIS FUNCTION IS NOT USED*/
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
                combinedResult = JSON.parse(xmlhttp.responseText);
                fullPatientInfo = (combinedResult.objectResult);
                var arr = combinedResult.stringResult.split(",");
                document.getElementById("Popup_2").style.display = 'none';
                currentPatient(arr);
            }
        }
        var str = val.concat(" all");
        xmlhttp.open("GET", "./php/getpatient.php?q="+str, true);
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
/*ALL SIMULATION TAKES PLACE HERE*/

function matchWithDatabase(frequency, leftDb, rightDb) {
    var leftFreq = fullPatientInfo['L_'+frequency]
    var rightFreq = fullPatientInfo['R_'+frequency]
    if(leftDb >= parseInt(leftFreq) && rightDb >= parseInt(rightFreq)) {
        // show green;
        document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
    } else {
        // show red
        document.getElementById("result").innerHTML = '<img src="images/redlight.png" height="40px" />';
    }
}

function simulate()
{
    if (document.getElementById("match").style.backgroundColor == on2)
        {
            return
        }

    /*************************8PLEASE READ THIS FALL2016****************************/
    /*
        I originally used the html text to determine what buttons were pressed (pretty stupid idea)
        Now I use the actual button itself so please check that I use them correctly
        In order to debug this section you will need to have taken a hearing test and understand what each button does
    */


    /*Use the actual interface text to get current state <----- DEPRECATED!!!!!!!! */
    /*var Stimulus1 = document.getElementById("Stimulus1").innerHTML.replace("Stimulus: ", "");
    var Stimulus2 = document.getElementById("Stimulus2").innerHTML.replace("Stimulus: ", "");
    var Transducer1 = document.getElementById("Transducer1").innerHTML.replace("Transducer: ","");
    var Transducer2 = document.getElementById("Transducer2").innerHTML.replace("Transducer: ","");
    var Routing1 = document.getElementById("Routing1").innerHTML.replace("Routing: ","");
    var Routing2 = document.getElementById("Routing2").innerHTML.replace("Routing: ","");*/
    var Freq = parseInt(document.getElementById("Freq").innerHTML.replace(" Hz", ""),10);
    var dB1 = parseInt(document.getElementById("dB1").innerHTML.replace(" dB HL", ""),10);
    var dB2 = parseInt(document.getElementById("dB2").innerHTML.replace(" dB HL", ""),10);
    var NB = (document.getElementById("NB").style.backgroundColor == on1);
    var NB2 = (document.getElementById("NB2").style.backgroundColor == on2);
    var Tone1 = (document.getElementById("Tone").style.backgroundColor == on1);
    var Tone2 = (document.getElementById("Tone2").style.backgroundColor == on2);

    matchWithDatabase(Freq, dB1, dB2);

    var Present1 = 0;
    var Present2 = 0;
    var Transducer1 = 0;
    var Transducer2 = 0;
    var Routing1 = 0;
    var Routing2 = 0;

    var key = "";
    var dB = 0;

    var masking = 0; //signal masking test
    var mask_dB = 0;
    var bone_dB = 0;
    var mask_key = "";
    var bone_key = "";
    var threshold_min = 0; //Required for OE (effect) specific to 250hz, 500hz, and 1000hz
    var threshold_max = 40; //Based on ineraural atten something
    var actual_mask_dB = 140;

    //document.getElementById("result").innerHTML = "INVALID :("; //Used to show if patient heard the sound
    


    //check value of transducer1
    if (document.getElementById("Phone").style.backgroundColor == on1)
    {
        Transducer1 = "Phone";
    }
    else if (document.getElementById("Bone").style.backgroundColor == on1)
    {
        Transducer1 = "Bone";
    }
    else
    {
        Transducer1 = "None";
    }

    //Check value of transducer2
    if (document.getElementById("Phone2").style.backgroundColor == on2)
    {
        Transducer2 = "Phone";
    }
    else if (document.getElementById("Bone2").style.backgroundColor == on2)
    {
        Transducer2 = "Bone";
    }
    else
    {
        Transducer2 = "None";
    }

    //check value of routing1
    if (document.getElementById("Left").style.backgroundColor == on1)
    {
        Routing1 = "Left";
    }
    else if (document.getElementById("Right").style.backgroundColor == on1)
    {
        Routing1 = "Right";
    }
    else
    {
        Routing1 = "None";
    }

    //check value of routing2
    if (document.getElementById("Left2").style.backgroundColor == on2)
    {
        Routing2 = "Left";
    }
    else if (document.getElementById("Right2").style.backgroundColor == on2)
    {
        Routing2 = "Right";
    }
    else
    {
        Routing2 = "None";
    }

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
    if (Present1 && Present2 && Tone1 && Tone2)
    {
        if (Transducer1 == "Bone" && Transducer2 == "Phone")
        {
            if (!NB && NB2 && Routing1 != Routing2)
            {
                if (Routing1 == "Left" && Routing2 == "Right")
                {
                    //Right ear will be masked
                    masking = 1;
                    mask_dB = dB2;
                    bone_dB = dB1;
                    mask_key = "BR";
                    bone_key = "BML";

                }
                else if (Routing1 == "Right" && Routing2 == "Left")
                {
                    //Left ear will be masked
                    masking = 1;
                    mask_dB = dB1;
                    bone_dB = dB2;
                    mask_key = "BL";
                    bone_key = "BMR";
                }
            }
            else
            {
                return
            }
        }

        else if (Transducer1 == "Phone" && Transducer2 == "Bone")
        {
            if (NB && !NB2 && Routing1 != Routing2)
            {
                if (Routing1 == "Left" && Routing2 == "Right")
                {
                    //Left ear will be masked
                    masking = 1;
                    mask_dB = dB1;
                    bone_dB = dB2;
                    mask_key = "BL";
                    bone_key = "BMR";
                }
                else if (Routing1 == "Right" && Routing2 == "Left")
                {
                    //Right ear will be masked
                    masking = 1;
                    mask_dB = dB2;
                    bone_dB = dB1;
                    mask_key = "BR";
                    bone_key = "BML";
                }
            }
            else
            {
                return
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
        if (Transducer1 == "Bone" && Present1 && Tone1)
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
        else if (Transducer2 == "Bone" && Present2 && Tone2)
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
        else if (Transducer1 == "Phone" && Present1 && Tone1)
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
        else if (Transducer2 == "Phone" && Present2 && Tone2)
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


    /*Some crazy bone masking algorithm that was described by Grad student in audiology department*/
    if (masking)
    {
        if (Freq == "250")
        {
            threshold_min = 20;
        }
        else if (Freq == "500")
        {
            threshold_min = 15;
        }
        else if (Freq == "500")
        {
            threshold_min = 10;
        }

        for(var i = 0; i < PatientObject.list.length; i++)
        {
            if (PatientObject.list[i][0] == Freq)
            {
                if (PatientObject.list[i][1] == mask_key)
                {
                    threshold_min = threshold_min + PatientObject.list[i][2];
                    fake_mask_dB = PatientObject.list[i][2];
                }
                else if (PatientObject.list[i][1] == bone_key)
                {
                    threshold_max = threshold_max + PatientObject.list[i][2];
                    actual_mask_dB = PatientObject.list[i][2];
                }
            }

            if (mask_dB >= threshold_min && mask_dB <= threshold_max && bone_dB >= actual_mask_dB)
            {
                document.getElementById("result").innerHTML = '<img src="../images/greenlight.png" height="40px" />';
            }
            else if (mask_dB < threshold_min && (bone_dB >= fake_mask_dB || bone_dB >= actual_mask_dB))
            {
                document.getElementById("result").innerHTML = '<img src="../images/greenlight.png" height="40px" />';
            }
            else
            {
                return;
            }
        }
    }
    else
    {
        for (var i = 0; i < PatientObject.list.length; i++)
        {
            if (PatientObject.list[i][1] == key && PatientObject.list[i][0] == Freq)
            {
                if ((PatientObject.list[i][3] == PatientObject.list[i][4] % 3 + 1) && PatientObject.list[i][2] + 5 <= dB)
                {
                    PatientObject.list[i][4] += 1;
                    document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
                }
                else if (PatientObject.list[i][2] <= dB)
                {
                    PatientObject.list[i][4] += 1;
                    document.getElementById("result").innerHTML = '<img src="images/greenlight.png" height="40px" />';
                }
            }
        }
    }
}

/*must press reset before running another test*/
function reset(button)
{
    var tmp = document.getElementById(button);
    if (tmp.style.backgroundColor == blueButtonColor) {
        tmp.style.backgroundColor = defaultButtonColor;
        tmp.style.borderColor = defaultButtonColor;
        tmp.style.color = "black";
    }
    else if (tmp.style.backgroundColor == redButtonColor) {
        tmp.style.backgroundColor = defaultButtonColor;
        tmp.style.borderColor = defaultButtonColor;
        tmp.style.color = "black";
    }

    document.getElementById("result").innerHTML = "";
    var match = document.getElementById("match");
    var Present1 = document.getElementById("Present1");
    var Present2 = document.getElementById("Present2");
    match.style.backgroundColor = off;
    Present2.style.backgroundColor = off;
    Present1.style.backgroundColor = off;

    return
}
