function register_valid(element) {
  /*This function will test the registration page for valid responses
  I used AJAX to show the user messages that describe the problem at hand
  The last AJAX call adds the information to the database but also double checks the values
  I was not able to terminate function before 3rd AJAX call for some reason so I had to double check values*/


  /*var x = document.getElementById(element).elements;*/
  var str = '';
  var pattern;
  var temp;

  var x = new Array(document.getElementById("gridRadios1"),
    document.getElementById("gridRadios2"),
    document.getElementById("FirstName"),
    document.getElementById("LastName"),
    document.getElementById("PUID"),
    document.getElementById("Email"),
    document.getElementById("Password"),
    document.getElementById("Passwordconfirm"));

  //check all fields
  for (var i = 7; i >= 2; i--) {
    if (x[i].value == "") {
      alert("Please fill in all fields");
      return false;
    };
  }

  //check passwords to match
  if (x[7].value != x[6].value) {
    alert("Passwords do not match!");
    return false;
  }

  //Check if email exists in database
  str = "CheckEmail ";
  pattern = /.*@purdue.edu/;
  if (pattern.test(x[5].value)) {
    str = str + x[5].value;
  } else {
    document.getElementById("CheckEmail").innerHTML = "Provide a Purdue Email";
    return false;
  }
  /*FIRST AJAX CALL TO CHECK EMAIL*/
  if (window.XMLHttpRequest) {
    xmlhttp = new XMLHttpRequest();
  } else {
    xmlhttp = new ActiveXObject();
  }

  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      /*in registration.html there is a spot under Email to write an error message*/
      document.getElementById("CheckEmail").innerHTML = xmlhttp.responseText;
    }
  }

  xmlhttp.open("GET", "../php/register_validation.php?q=" + str, true);
  xmlhttp.send();

  //Check if PUID is 10 digits
  str = "CheckPUID ";
  pattern = /[0-9]{10}/;
  if (pattern.test(x[4].value)) {
    str = str + x[4].value;
  } else {
    document.getElementById("CheckPUID").innerHTML = "Provide a Valid PUID";
    return false;
  }
  /*SECOND AJAX CALL TO CHECK PUID*/
  if (window.XMLHttpRequest) {
    xmlhttp2 = new XMLHttpRequest();
  } else {
    xmlhttp2 = new ActiveXObject();
  }

  xmlhttp2.onreadystatechange = function() {
    if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
      /*similar to how email error message is displayed*/
      document.getElementById("CheckPUID").innerHTML = xmlhttp2.responseText;
    }
  }

  xmlhttp2.open("GET", "../php/register_validation.php?q=" + str, true);
  xmlhttp2.send();

  register_data = {
    firstname: x[2].value,
    lastname: x[3].value,
    PUID: x[4].value,
    email: x[5].value,
    pass: x[6].value
  };

  if (x[0].checked) {
    register_data.admin = "admin";
  } else if (x[1].checked) {
    register_data.student = "student";
  } else {
    alert("Need to select account type");
    return false;
  }

  $.post("../php/register.php", register_data, function(data) {
    if (data) {
      document.getElementById("SubmitResponse").innerHTML = data;
    }
  });

  return false;
}

/*This function will be used to verify login information and display error message if neccesary
It follows the same format as the registration page for AJAX calls*/
function login(element) {
  var email = document.getElementById("email").value;
  var password = document.getElementById("pwd").value;
  var str = "";

  $.post("./php/login.php", {
    email: email,
    pass: password
  }, function(data) {
    if (data) {
      console.log(data);
      document.getElementById("LoginFail").innerHTML = data;
    } else {
      window.location.href = './simulator.php';
    }
  });

  return false;
}
