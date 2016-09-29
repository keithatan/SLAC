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
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">


    <!-- JavaScript Assets -->
    <script src="http://code.jquery.com/jquery-1.12.4.min.js" integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ=" crossorigin="anonymous"></script>


    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <script src="../javascript/accounts.js"></script>


    <!-- MAKES THE MODAL APPEAR ON WINDOW LOAD (OLD DESIGN)-->
    <!--<script type="text/javascript">
      $(window).load(function () {
        $('#choosePatientType').modal('show');
      });
    </script>-->
  </head>
<body>
  <div class="col-md-6 col-md-offset-3">
    <div class="modal-header">

      <h4 class="modal-title">Login Into Your Account</h4>
    </div>
    <div class="modal-body">
      <form role="form" onsubmit="return login('form');">
        <div class="form-group">
          <label for="email">Email:</label>
          <input type="email" class="form-control" id="email" placeholder="Enter email">
        </div>
        <div class="form-group">
          <label for="pwd">Password:</label>
          <input type="password" class="form-control" id="pwd" placeholder="Enter password">
        </div>
        <button type="submit" class="submit">Sign In</button>
        <div id="LoginFail" style="color: red;"></div>
        <br><br><a href="templates/registration.html">Don't have an account? Sign Up!</a>
      </form>
    </div>
    <div class="modal-footer">
      <button type="button" class="submit" data-dismiss="modal">Close</button>
    </div>
  </div>
</body>
