//Preset Hearing values 
//super long and literally just hardcoded text
Normal_Hearing = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "Normal Hearing Preset",
	"R_250" : 10,
	"R_500" : 15,
	"R_1000" : 10,
	"R_2000" : 0,
	"R_4000" : 10,
	"R_8000" : 10,
	"L_250" : 10,
	"L_500" : 10,
	"L_1000" : 10,
	"L_2000" : 10,
	"L_4000" : 10,
	"L_8000" : 10};

Mild_Hearing_Loss_Right = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "Hearing Loss Preset",
	"R_250" : 10,
	"R_500" : 15,
	"R_1000" : 10,
	"R_2000" : 0,
	"R_4000" : 10,
	"R_8000" : 10,
	"L_250" : 10,
	"L_500" : 10,
	"L_1000" : 10,
	"L_2000" : 10,
	"L_4000" : 10,
	"L_8000" : 10};

Mild_Hearing_Loss_Left = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "Left Ear Bone Preset",
	"R_250" : 10,
	"R_500" : 0,
	"R_1000" : 10,
	"R_2000" : 10,
	"R_4000" : 0,
	"R_8000" : 10,
	"L_250" : 20,
	"L_500" : 20,
	"L_1000" : 30,
	"L_2000" : 40,
	"L_4000" : 30,
	"L_8000" : 20};

Mild_Hearing_Loss_Both = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "Right Ear Bone Preset",
	"R_250" : 20,
	"R_500" : 20,
	"R_1000" : 30,
	"R_2000" : 20,
	"R_4000" : 30,
	"R_8000" : 20,
	"L_250" : 20,
	"L_500" : 30,
	"L_1000" : 30,
	"L_2000" : 20,
	"L_4000" : 30,
	"L_8000" : 40};

Severe_Hearing_Loss_Right = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "No High Frequencies Preset",
	"R_250" : 80,
	"R_500" : 80,
	"R_1000" : 90,
	"R_2000" : 70,
	"R_4000" : 80,
	"R_8000" : 85,
	"L_250" : 0,
	"L_500" : 10,
	"L_1000" : 10,
	"L_2000" : 0,
	"L_4000" : 10,
	"L_8000" : 0};

Severe_Hearing_Loss_Left = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "No High Frequencies Preset",
	"R_250" : 0,
	"R_500" : 10,
	"R_1000" : 20,
	"R_2000" : 0,
	"R_4000" : 15,
	"R_8000" : 0,
	"L_250" : 90,
	"L_500" : 80,
	"L_1000" : 70,
	"L_2000" : 80,
	"L_4000" : 80,
	"L_8000" : 85};

Severe_Hearing_Loss_Both = 
	{"first_name" : "Preset", 
	"last_name" : "add name", 
	"description" : "No High Frequencies Preset",
	"R_250" : 90,
	"R_500" : 80,
	"R_1000" : 70,
	"R_2000" : 80,
	"R_4000" : 80,
	"R_8000" : 85,
	"L_250" : 80,
	"L_500" : 80,
	"L_1000" : 90,
	"L_2000" : 70,
	"L_4000" : 80,
	"L_8000" : 80};

Presets = 
{
	"Normal Hearing" :Normal_Hearing,
	"Mild Hearing Loss in Right Ear" :Mild_Hearing_Loss_Right,
	"Mild Hearing Loss in Left Ear" :Mild_Hearing_Loss_Left,
	"Mild Hearing Loss in Both Ears" :Mild_Hearing_Loss_Both,
	"Severe Hearing Loss in Right Ear" :Severe_Hearing_Loss_Right,
	"Severe Hearing Loss in Left Ear" :Severe_Hearing_Loss_Left,
	"Severe Hearing Loss in Both Ears" :Severe_Hearing_Loss_Both,
};
function fillForm(str)
{
	for (key in Presets)
	{
		if (str == key)
		{
			for(sub_key in Presets[key])
			{
				var field = document.getElementsByName(sub_key);
				field[0].value = Presets[key][sub_key];
			}
		}
	}

	if (str != "") 
	{
		document.getElementById("presetNotification").innerHTML = 'Select "Use Form" to modify ' + str + ' values and then press "Submit"';
	}
	else
	{
		document.getElementById("presetNotification").innerHTML = "";
	}
	return
}
