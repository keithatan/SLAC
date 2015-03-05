var app = {
    stimulus: 'tone',
    transducer: 'phone',
    ch1: {},
    ch2: {}
};


// Changing frequency
var Freq = 125;

// Increasing frequency
function FreqPlus() {
    if (Freq >= 8000) return Freq;

    else if (Freq >= 500 && Freq < 1000) {
        Freq = Freq + 250;
    } else if (Freq >= 1000 && Freq < 2000) {
        Freq = Freq + 500;
    } else if (Freq >= 2000 && Freq < 4000) {
        Freq = Freq + 1000;
    } else if (Freq >= 4000 && Freq < 8000) {
        Freq = Freq + 2000;
    } else {
        Freq = Freq * 2;
    }
    console.log(String(Freq));
    return Freq;
}

// Decreasing frequency
function FreqMinus() {
    if (Freq <= 125) return Freq;

    else if (Freq > 4000 && Freq <= 8000) {
        Freq = Freq - 2000;
    } else if (Freq > 2000 && Freq <= 4000) {
        Freq = Freq - 1000;
    } else if (Freq > 1000 && Freq <= 2000) {
        Freq = Freq - 500;
    } else if (Freq > 500 && Freq <= 1000) {
        Freq = Freq - 250;
    } else {
        Freq = Freq / 2;
    }
    console.log(String(Freq));
    return Freq;
}

// Updates frequency on page
function printHz(id, msg) {
    document.getElementById(id).innerHTML = msg + " Hz";
}

// Updates channel 1 dB level
function update_ch1_dB() {
    app.ch1.dB = this.value;
    document.getElementById('dB1').innerHTML = app.ch1.dB + " dB HL";
}

// Updates channel 2 dB level
function update_ch2_dB() {
    app.ch2.dB = this.value;
    document.getElementById('dB2').innerHTML = app.ch2.dB + " dB HL";
}

// Page timer
var seconds = 0;

function secondPassed() {
    var minutes = Math.round((seconds - 30) / 60);
    var remainingSeconds = seconds % 60;
    if (remainingSeconds < 10) {
        remainingSeconds = "0" + remainingSeconds;
    }
    document.getElementById('countdown').innerHTML = minutes + ":" + remainingSeconds;

    seconds++;
}

// Updates routing on page
function print_routing(id, routing) {
    app.routing = routing;
    document.getElementById(id).innerHTML = "Routing: " + routing;
}

// Updates transducer on page
function print_transducer(id, transducer) {
    app.transducer = transducer;
    
    app.audiogram.switchPlotType();
    
    document.getElementById(id).innerHTML = "Transducer: " + transducer;
}

// Updates stimulus on page
function print_stimulus(id, stimulus) {
    app.stimulus = stimulus;
    document.getElementById(id).innerHTML = "Stimulus: " + stimulus;
}

// Updates dB step on page [DEPRECATED]
function print_step(id, step) {
    app.dB_step = step;
    document.getElementById(id).innerHTML = step + " dB step";
}

// Changes color to red and back
function changeColor(clicked_id){
    var tmp = document.getElementById(clicked_id);
    console.log("Button color changed from: " + tmp.style.backgroundColor);
    if(tmp.style.backgroundColor == 'red'){
        tmp.style.backgroundColor = 'white';
    }else{
        tmp.style.backgroundColor = 'red';
    }
}

// Changes color to blue and back
function changeColorBlue(clicked_id){
    var tmp = document.getElementById(clicked_id);
    console.log("Button color changed from: " + tmp.style.backgroundColor);
    if(tmp.style.backgroundColor == 'CornflowerBlue'){
        tmp.style.backgroundColor = 'white';
    }else{
        tmp.style.backgroundColor = 'CornflowerBlue';
    }
}

// Sleeps for a given time
function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

// Play audio
// Define audio variables
var snd200 = new Audio("sound/200hz.wav");
var snd250 = new Audio("sound/250hz.mp3");
var snd500 = new Audio("sound/500hz.wav");
var snd750 = new Audio("sound/750hz.mp3");
var snd1000 = new Audio("sound/1000hz.wav");
var snd1500 = new Audio("sound/1500hz.mp3");
var snd2000 = new Audio("sound/2000hz.wav");
var snd3000 = new Audio("sound/3000hz.mp3");
var snd4000 = new Audio("sound/4000hz.mp3");
//var snd5000 = new Audio("sound/5000hz.wav"); 
var snd6000 = new Audio("sound/6000hz.mp3");
var snd8000 = new Audio("sound/8000hz.wav");

// Play sound based on what frequency is
function sndplay() {
    if (Freq == 200) snd200.play();
    else if (Freq == 250) snd250.play();
    else if (Freq == 500) snd500.play();
    else if (Freq == 750) snd750.play();
    else if (Freq == 1000) snd1000.play();
    else if (Freq == 1500) snd1500.play();
    else if (Freq == 2000) snd2000.play();
    else if (Freq == 3000) snd3000.play();
    else if (Freq == 4000) snd4000.play();
    else if (Freq == 6000) snd6000.play();
    else if (Freq == 8000) snd8000.play();

}


/*****************************
 * Blinking Text
 ******************************/

// add  counter to blink limited times//
function blinkFont(id) {
    setTimeout(function (id) {
        setblinkFont(id);
    }, 500);
}

function setblinkFont(id) {
    setTimeout(function (id) {
        blinkFont(id);
    }, 500);
}

function blinkColor() {
    document.getElementById("blink2").style.background = "red";
    setTimeout("setblinkColor()", 500);
}

function setblinkColor() {
    document.getElementById("blink2").style.background = "green";
    setTimeout("blinkColor()", 500);
}


/*****************************
 * record unheard data
 ******************************/


//function UserWindow() {
//
//    // URL, name and attributes
//    window.open('User.html','windowNew','width=300, height=300');
//    return true;
//}

//function unheard(dB_left, dB_right){
//    var freq = Freq;
//    console.log("dB left is" + dB_left);
//    console.log("dB left is" + dB_right);
//    console.log("Frequency is" + freq);
////    draw AC, BC accordingly;
//}

// Initialize environment
function windowLoad() {
    
    app.audiogram = new Audiogram().initialize("audiogram", 600);  //pass the id of the HTML DOM Element
    
    var countdownTimer = setInterval('secondPassed()', 1000);
    
    var dB_ch1 = document.getElementById('range1');
    var dB_ch2 = document.getElementById('range2');
    
    dB_ch1.addEventListener('change', update_ch1_dB, false);
    dB_ch1.addEventListener('mousemove', update_ch1_dB, false);
    
    dB_ch2.addEventListener('change', update_ch2_dB, false);
    dB_ch2.addEventListener('mousemove', update_ch2_dB, false);
    
    var snapper = new Snap({
        element: document.getElementById('content'),
        maxPosition: 300,   //left drawer width; must also be modified in the CSS file
        minPosition: -700   //right drawer width; must also be modified in the CSS file
    });

    var counterL = 1;
    var counterR = 1;

    document.getElementById('ol').addEventListener('click', function () {
        if (counterL == 1) {
            snapper.open('left');
            counterL = 0;
        } else {
            snapper.close('left');
            counterL = 1;
        }
    });

    document.getElementById('or').addEventListener('click', function () {
        if (counterR == 1) {
            snapper.open('right');
            counterR = 0;
        } else {
            snapper.close('right');
            counterR = 1;
        }
    }, false);
}

// Begins execution of the app
window.addEventListener("load", windowLoad, false);