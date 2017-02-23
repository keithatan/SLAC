<?php
  session_start();
  session_regenerate_id();
  if(!isset($_SESSION['user']))      // if there is no valid session
  {
      header("Location: /index.php");
  }
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>SLAC Virtual Lab</title>

    <meta name="description" content="">
    <meta name="author" content="">

    <meta http-equiv="x-ua-compatible" content="IE=edge">

    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">

    <!-- favicon -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="images/apple-touch-icon-57-precomposed.png">
    <link href="data:image/x-icon;base64,AAABAAEAEBAAAAAAAABoBQAAFgAAACgAAAAQAAAAIAAAAAEACAAAAAAAAAEAAAAAAAAAAAAAAAEAAAAAAAAAAAAAkJvGANnZ2QDAyf8APUFWADY2NgCLlL8AOj9TAFZadQDp7v8ABAQEADg4OAC8xf8AvcX/AMTP/wBTU1MAu7u7AB0gKgCioqIAGBgYAMfS/wDT3P8ARUVFANnf8gCUlJQACQkMAAUHCQATExMAe3t7ABsgKADs7OwAvsf/AGJiYgCcpdYAW1tbAGRkZAAZGyMACAgMAHN3nADV3v8AmpqaAL3G/wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABIEJBsAAAAAAAAAAAAAAAApKSkpFgAAAAAAAAAAABwfDikpAAAAAAAAAAAAAAAFKQAAKSMDAAAAAAAAAAAAACEpByYlIgMAAAAAAAAAAAApFykpKRkCKQAAAAAAAAAAKQApKSkAACkAAAAAAAAAAAAAKAspGQApAAAAAAAAAAARKQgEAAApKQAAAAAAAAAVHSkAAAANBCkAAAAAAAAQAAApACkAKQAnBQAAAAAAAAABBgAAFAwAAAAAAAAAAAAPHgApKSkADAAAAAAAAAAAAAAJGgAADAoAAAAAAAAAAAAAIAAAGBMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPD/AADgfwAAwX8AAMQ/AADgHwAA4A8AAOBPAAD4TwAA4I8AAMMPAAChDwAAxi8AAMAfAADgPwAA8H8AAP//AAA=" rel="icon" type="image/x-icon" />
    <link href="https://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
    <!-- Style Sheets -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link href="css/main.css" rel="stylesheet">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Merriweather:400,300,300italic,400italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css">

    <!-- JavaScript Assets -->
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"
            integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ="
            crossorigin="anonymous"></script>
    <script src="./js/Tone.js"></script>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="js/raphael.min.js"></script>
    <script src="js/snap.min.js"></script>
    <script src="javascript/main.js"></script>
    <script src="javascript/panel.js"></script>
    <script src="javascript/audiogram.js"></script>
    <script src="javascript/patient_tab.js"></script>
    <script src="javascript/patient_simulation.js"></script>
    <script src="javascript/preset_patients.js"></script>
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <!-- MAKES THE MODAL APPEAR ON WINDOW LOAD (OLD DESIGN)-->
    <!--<script type="text/javascript">
      $(window).load(function () {
        $('#choosePatientType').modal('show');
      });
    </script>-->
  </head>

  <!-- Connect to database -->

  <?php
    include 'php/connection.php';
  ?>

  <body>

    <!-- report findings modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="false">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h3 class="modal-title" id="myModalLabel">Student Findings</h3>
          </div>
          <div class="modal-body">
            <div class="container">
            <form class="form-inline" action="demo_form.asp" method="get" role="form">
              <div class="form-group">
              <h4>Patient name</h4>
              First name: <input type="text" name="PatientFirstName" value=""><br>
              Last name:  <input type="text" name="PatientLastName" value=""><br>
              </div>
              <div class="form-group">
              <h4>Patient info</h4>
              <textarea rows="2" cols="30" placeholder="optional patient description"></textarea> <br>
              </div>
              <hr>
              <h4>Type of hearing loss</h4>
              <input type="checkbox" name="hearing-loss-type" value="Conductive"> Patient has conductive hearing loss<br>
              <input type="checkbox" name="hearing-loss-type" value="Sensorineural"> Patient has sensorineural hearing loss<br>
              <input type="checkbox" name="hearing-loss-type" value="Mixed"> Patient has mixed hearing loss<br>
              <input type="checkbox" name="hearing-loss-type" value="Indeterminate"> Patient has indeterminate hearing loss<br>
              <hr>
              <h4>Notes for professer</h4>
              <textarea rows="4" cols="50" placeholder="optional notes for professor"></textarea> <br>
              <div class="form-group">
              <h4>Your name</h4>
              First name: <input type="text" name="StudentFirstName" value=""><br>
              Last name:  <input type="text" name="StudentLastName" value=""><br>
              </div>
              <div class="form-group">
              <h4>Your class</h4>
              Course: <input type="text" name="StudentCourse" value=""><br>
              Section: <input type="text" name="StudentSection" value="" placeholder="if applicable"><br>
              </div>
              <!--<input type="submit" value="Submit">-->
            </form>
            </div>
          </div>
          <div class="modal-footer">
            <!--<button type="button" class="submit" data-dismiss="modal">Report</button>-->
            <input type="submit" value="Report" class="submit" onclick='reportFindings("myModal");'>
            <script type="text/javascript">
            //the purpose of this function is to export the graph without exporting "Choose symbols section"
            function reportFindings(divName) {
              if (confirm("You will not be able to edit the response after reporting, is that okay?") == true) {
                //----------------------------------------------//
                //-------pass all data to database here---------//
                //----------------------------------------------//

                location.reload(); //reload page
              } else {
                  return false;
              }
            }
            </script>
            <!--<input type="submit" id="submit" value="Report">-->
          </div>
        </div>
      </div>
    </div>

    <!-- draggable modal for viewing plot for reference -->
    <script>$("#myModal").draggable({ handle: ".modal-header" });</script>

    <!--left snap-->
    <?php include("templates/patients.html"); ?>

    <!--right snap-->
    <?php include("templates/plotting.html"); ?>

    <!--main interface-->
    <?php include("templates/main_interface.html"); ?>

  </body>
</html>
