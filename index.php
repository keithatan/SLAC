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
    
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="images/apple-touch-icon-57-precomposed.png">
    <link rel="shortcut icon" href="images/favicon.png">
    
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