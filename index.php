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
    <link href="bower_components/bootstrap-switch/dist/css/bootstrap2/bootstrap-switch.css" rel="stylesheet">
    <link href="bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="css/main.css" rel="stylesheet">
    
    <!-- JavaScript Assets -->
    <!--<script src="bower_components/jquery/dist/jquery.min.js"></script>-->
    
    <script src="http://code.jquery.com/jquery-1.11.2.min.js"></script>
    
    
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="bower_components/raphael/raphael-min.js"></script>
    <script src="bower_components/snap/snap.min.js"></script>
    <script src="javascript/main.js"></script>
    <script src="javascript/panel.js"></script>
    <script src="javascript/audiogram.js"></script>
    <script src="javascript/ajax.js"></script>
    <script src="javascript/function.js"></script>
    <script src="javascript/patient_simulation.js"></script>
    <script src="javascript/preset_patients.js"></script>
    <script src="https://code.jquery.com/jquery-1.11.3.js"></script>
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

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
    <!-- Popup for test type selection (OLD DESIGN) -->
    <!-- <div class="modal fade" id="choosePatientType" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
              <span aria-hidden="true">&times;</span>
              <span class="sr-only">
                Close
              </span>
            </button>
            &nbsp
          </div>
          <div class="modal-body">
            <button type="button" class="btn btn-primary patientOptionPractice" data-toggle="btn" aria-pressed="false" autocomplete="false">
              Practice Test
            </button>
            Name: <input type = "text" id = "name">
            <input type ="submit" id ="name-submit" value ="Get Patient Info.">
            
            <button type="button" class="btn btn-primary patientOptionReal" data-toggle="btn" aria-pressed="false" autocomplete="false">
              Real Test
            </button>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">
              Close
            </button>
          </div>
        </div>
      </div>
    </div> -->

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
            <input type="submit" id="submit" value="Report">
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
  <!-- Global reference (variables shared between .js files)-->
  <script src="js/global.js"></script>
</html>