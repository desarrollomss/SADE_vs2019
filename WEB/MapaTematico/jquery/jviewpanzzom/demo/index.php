<?php
$img='';
$img= $_REQUEST['ruta'];
?>

<!doctype html>
<html>
  <head>
    <title>Panzoom for jQuery</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <style type="text/css">
      body { background: #F5FCFF; color: #333666; }
      section { text-align: center; margin: 10px 0; }
      .panzoom-parent { border: 2px solid #333; }
      .panzoom-parent .panzoom { border: 2px dashed #666; }
      .buttons { margin: 15px 15px 15px 15px; }
    </style>
    <script src="../test/libs/jquery.js"></script>
    <script src="../dist/jquery.panzoom.js"></script>
    <script src="../test/libs/jquery.mousewheel.js"></script>
	<script language="Javascript" type="text/javascript">
		//<![CDATA[

		<!-- Begin
		  document.oncontextmenu = function(){return false}
		// End -->
		//]]>
	</script>	
  </head>
  <body>
    <section>
      <div class="buttons">
        <button class="zoom-in">Acercar</button>
        <button class="zoom-out">Alejar</button>
        <input type="range" class="zoom-range">
        <button class="reset">Reinicializar</button>
      </div>
      <div class="parent">
        <div class="panzoom">
          <!--img src="http://blog.millermedeiros.com/wp-content/uploads/2010/04/awesome_tiger.svg" width="600" height="600"-->
		  <img src="<?php echo $img;?>" width="100%" height="100%">
		  
        </div>
      </div>

      <script>
        (function() {
          var $section = $('section').first();
          $section.find('.panzoom').panzoom({
            $zoomIn: $section.find(".zoom-in"),
            $zoomOut: $section.find(".zoom-out"),
            $zoomRange: $section.find(".zoom-range"),
            $reset: $section.find(".reset")
          });
        })();
      </script>
    </section>
    <hr>

  </body>
</html>
