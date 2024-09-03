var mapa;	//objeto mapa global
var markers=[]; //array de markers
var infoGlobal = null; //variable global del info windows
var geocoder;

var intEmpId = 0;
var intTipUnidad = 0;
var nroRadio = 0;

//probando

//	function initMap(){
//		// 		var map = new google.maps.Map(document.getElementById("map"), {
//		geocoder = new google.maps.Geocoder();
//		mapa= new google.maps.Map(document.getElementById("googleMap"), {
//			zoom : 12,
//			center : new google.maps.LatLng(-12.038985, -77.040939),
//			mapTypeId : google.maps.MapTypeId.ROADMAP
//		});
//		if(s_vchRolDesc =="ADMINISTRADOR"){
//			isAdm = true;
//			intEmpId = intTipUnidad = 0;
//			cargarCmbEmpresa();
//			cargarCmbTipoUnidad();
//		} else{
//			isAdm = false;
//			intEmpId = s_intEmpId;
//			cargarCmbTipoUnidad();
//		}
//		
//
//		google.maps.event.addListener(mapa,'tilt_changed',function(){
//			mostrarUnidades();
//		});
//		
//	 setInterval(function(){
//		 	if(xo.chizu()){
//		 		mostrarUnidades();
//		 	} else {
//		 		var f = document.getElementById('FormCS');
//		 		f.out.value = "timeOut";
//		 		f.submit();
//		 	}	}, 10000);
//	 
//	}

//	function 
	
	function cargarCmbTipoUnidad(){
		$.ajax({
			url:"cmbTipoUnidad.htm",
			type:'POST',
			dataType:'json',
			success: function(json){
				var ar = json;
				var items = "";
				items = "<option value ='0'>Seleccione Tipo Unidad</option>";
				for(var i=0;i <ar.length;i++){
					items += "<option value= '"+ar[i].intTipUnidad+"'>"+ar[i].vchTipUnDesc+"</option>";
				}
				$("#cmbTipoUnidad").html(items);
			}
		});
	}
	
	function cargarCmbEmpresa(){
		$.ajax({
			url:"cmbEmpresaItem.htm",
			type:'POST',
			dataType:'json',
			success: function(json){
				var ar = json;
				var items = "";
				items = "<option value ='0'>Seleccione Empresa</option>";
				for(var i=0;i <ar.length;i++){
					items += "<option value= '"+ar[i].intEmpId+"'>"+ar[i].vchEmpNombre+"</option>";
				}
				$("#cmbEmpresa").html(items);
			}
		});
	}
	
	
	
	function mostrarUnidades(){
		$("#UnidadesCont").html("");
		$.ajax({
			//los parametros de datas son provisionales
			url:"getPositions.htm",
			data:{adm:isAdm,
				  vchEmpSeg: s_vchEmpSeg,
				  vchUsuCod: s_vchUsuCod,
				  intEmpId:intEmpId,
				  intTipUnidad:intTipUnidad,
				  nroRadio:$("#txtNroRadio").val()},
			type:'POST',
			dataType:'json',
			success: function(json){
				var posicion =json;
				var div ="";
				for(var  i = 0; i < posicion.length; i++){
					var pos = posicion[i];
					div +="<div id="+i+" class='unid' data-dropdown='#dropdown-3' data-vertical-offset='13' data-horizontal-offset='5'  onclick='ctxOpc("+JSON.stringify(pos)+")' >";
					div+='<img src="./img/estado/'+pos.vchNomImg+'"/>';
					div+=" "+pos.intIssi+"-"+((pos.vchUniDesc.length <= 20) ? pos.vchUniDesc: (pos.vchUniDesc).substring(0,20))+"</div>";
				}
				$("#UnidadesCont").html(div);
				
//				 while(markers.length){
//			            markers.pop().setMap(null);
//			        }
//				 mostrarPosiciones();				
			}
		});
	}
	 function ctxOpc(pos){
		 $("#idUni").val(pos.intIssi);
		 $("#descUni").val(pos.vchUniDesc);
		 
		 //opcion uno
		  $('#dropdown-3 #aUbUni').click(function(e) { 
				e.preventDefault(); 
				ubicarUnidad(pos);
			});
		  //opcion dos 
		  
		  $('#dropdown-3 #aHistuni').click(function(e){
			//  $(this).attr('href','seguridad.htm?accion=mostrarHistorial&cod='+pos.intIssi+"&desc="+pos.vchUniDesc);
			  var f = document.getElementById('FormMH');
			  window.open('', 'FormMH_W');
			  f.submit();
		  });
		  
	 }
	 
	 function ubicarUnidad(pos) {		 
		 g_map.setCenter(new OpenLayers.LonLat(pos.decPosLat, pos.decPosLon).transform(
			        new OpenLayers.Projection("EPSG:4326"),
			        g_map.getProjectionObject()
			    ), 18);
	}
	

	function mostrarPosiciones(){
		$.ajax({
			//los parametros de datas son provisionales
			url:"getPositions.htm",
			data:{adm:isAdm,
				  vchEmpSeg: s_vchEmpSeg,
				  vchUsuCod: s_vchUsuCod,
				  intEmpId:intEmpId,
				  intTipUnidad:'',//intTipUnidad,
				  nroRadio:''//$("#txtNroRadio").val()
				  },
			type:'POST',
			dataType:'json',
			success: function(json){
				var ar =json;
				//console.log(json)
				for(var  i = 0; i < ar.length; i++){
						//crearPosicion(ar[i]);
				  }
				
			}
		});
	}
	
	
	function crearPosicion(pos){
		var latlng = new google.maps.LatLng(parseFloat(pos.decPosLon),parseFloat(pos.decPosLat));
		var img = pos.vchNomImgTip.substring(0, pos.vchNomImgTip.lastIndexOf("."));
		 img+= pos.vchColorEst + ".png";
		var marker = new google.maps.Marker({
			position:latlng,
			icon: './img/unidad/'+img,
			distanceScaling :true,
			title : pos.vchUniCodigo,
			code: pos.intIssi
		});
		markers.push(marker);
		marker.setMap(mapa);
		
		var infowindow = getInfoWindow(pos);
		
		google.maps.event.addListener(marker,'click',function(){
			  if( infoGlobal )
			    {
				  infoGlobal.close();
			        }
			  infoGlobal = infowindow;
			infowindow.open(mapa,marker);
			mapa.setCenter(latlng);
			mapa.setZoom(16);
		});
		
	}
	
	
	function getInfoWindow(pos){
		var infowindow = new google.maps.InfoWindow({
			content :' <style type="text/css">\
				    	.infoUni{\
							border-top-left-radius: 10px;\
							border-top-right-radius: 10px;\
							border-style:solid;\
							border-color :'+pos.vchCodColor+';\
							margin: 5px;\
								}\
						.infoUni .title{\
							text-align: center;\
							font-weight:bold;\
							padding-left 5px;\
							background-color: '+pos.vchCodColor+';\
							color: #fff;\
							}\
						.infoUni table tr #desc{\
							color: '+pos.vchCodColor+';\
						}\
					</style>\
				<div class="infoUni">\
				   <div class="title">'+pos.vchUniDesc+'</div>\
						<table border="0">\
							<tr>\
							 <td id="desc">ID: </td>\
							 <td>'+pos.intIssi+'</td>\
							</tr>\
							<tr>\
							 <td id="desc">Tipo: </td>\
							 <td >'+pos.vchTipUnDesc+'</td>\
							</tr>\
							<tr>\
							 <td id="desc">Fecha: </td>\
							 <td>'+ xo.dateFormat(new Date(pos.datPosFreg))+'</td>\
							</tr>\
							<tr>\
							 <td id="desc">Velocidad: </td>\
							 <td >'+pos.decPosVel+'</td>\
							</tr>\
							<tr>\
							 	<td id="desc">Direccion: </td>\
							 	<td>'+pos.vchCarCod+'</td>\
							</tr>\
							 <tr>\
							 <td id="desc">Estado: </td>\
							 <td>'+pos.vchEstDesc+'</td>\
							 </tr>\
						</table>\
				</div>'
		});
		return infowindow;
	}
	
	
	function isNumberKey(evt) {
       var charCode = (evt.which) ? evt.which : event.keyCode;
       if (charCode > 31 && (charCode < 48 || charCode > 57))
          return false;
      if(charCode == 13){
    	 mostrarUnidades();
      }
       return true;
    }
	
	


	
	
	
	
	
