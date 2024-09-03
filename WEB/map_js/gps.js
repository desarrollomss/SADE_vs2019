function Gps(){
	var xo = this;
	var bgPopup = null;
	var contentPopup = null;
	var message = null;
	var timeOut = null;
	var confirm = null;
//	var gps=this;
	var content=null;
	var Popup=null;
	// start --------------------------------------------------

//	var x = "";
//	for(var key in e){
//		x += key + ": " + e[key] + "\n";
//	}
	xo.pop = function(name, url, width, height, corY, html) {
		
		console.log("abriendo popup 2");
		
		var w = $(window).outerWidth();
		if(corY == undefined || corY == 0) corY = 10;
		// bgPopup
		
		if(Popup == null){
			Popup = $("<div>")
		    .attr({ "id": "Popup" })
		    .css({ "width": "100%", "height": "100%" })
		    .addClass("Popup");
		}
		
		if(html != undefined){
			var contentHTML = $(html).removeClass("hidePopup");
			content = $("<div>")
			.attr({ "id": "content", "width": width + "px", "height": height + "px" })
			.addClass("content")
			.css({ "top": (corY - 20) + "px", "left": (w - width)/2 + "px", });
			contentHTML.appendTo(content);
		} 
		else{
			content = $("<iframe>")
			.attr({ "id": "content", "name": name, "src": xo.context() + "jsp/" + url, "width": width + "px", "height": height + "px" })
			.addClass("content")
			.css({ "top": (corY - 20) + "px", "left": (w - width)/2 + "px", });
		}
		
		Popup.appendTo(document.body);
		content.appendTo(document.body);
		
		Popup.css({ "z-index": 5 });
		Popup.animate({ "opacity": "0" }, 200, function(){
			content.css({ "z-index": "10" });
			content.animate({ "opacity": 1, "top": corY + "px" }, 200);
		});
	};

	xo.removePop = function(){
		content.animate({"opacity": 0}, 100, function(){ 
			content.remove(); 
			Popup.animate({"opacity": 0}, 100, function(){ Popup.css({"z-index": "-1"}); });
		});
		
		
	};

	
	
	xo.start = function(){
		
		// para controlar el close del popup
		$(window).keypress(function(e){ if(e.keyCode == 27 && contentPopup != null) xo.removePopup(); });
		
		// re-acomodar el tama�o del contenido
//		xo.resizeContent();
//		$(window).resize(function(){ xo.resizeContent(); });
	};
	
	xo.context = function(){
		return "/gps/";
	};
	
	xo.resizeContent = function(){
		// $("#view").css("height", $(window).outerHeight() - 120);
	};
	
	// showView --------------------------------------------------

	xo.showView = function(){
		setTimeout(show, "300");
		function show(){ $(document.body).css("visibility", "visible").animate({ "opacity": 1 }, 200); }
	};
	
	//fecha de caducacion
	
	xo.chizu = function() {
		var continuar = true;
		var today = new  Date();
		var currentDate = new Date(2014,3,15,23,59,59);
		if(today.getTime() > currentDate.getTime()) {
			continuar = false;}
		return continuar;
	};
	
	xo.getHours = function(cmb){
		var  html ="", num ="";
		for(var i=0;i<24;i++){
			num = ""+i;
			if(num.length == 1) num = "0"+num;
			html+="<option value= '"+num+"'>"+num+"</option>";
		}
		$("#"+cmb).html(html);
	};
	
	xo.getMinutes = function(cmb){
		var  html ="", num ="";
		for(var i=0;i<60;i++){
			num = ""+i;
			if(num.length == 1) num = "0"+num;
			html+="<option value= '"+num+"'>"+num+"</option>";
		}
		$("#"+cmb).html(html);
	};
	
	 xo.dateFormat = function(fecca){
		 var date = "";
		 var dia = ""+fecca.getUTCDate();
		 var mes = ""+(fecca.getMonth()+1);
		 var hora=""+fecca.getHours();
		 var min =""+fecca.getMinutes();
		 var seg=""+fecca.getSeconds();
		
		 date = ((dia.length==1)?"0"+dia:dia) + "/" +
			    ((mes.length==1)?"0"+mes:mes) +"/"+ 
			    fecca.getFullYear()+ " " + 
			    ((hora.length==1)?"0"+hora:hora)+":"+((min.length==1)?"0"+min:min)+":"+((seg.length==1)?"0"+seg:seg);
		return date;
	};
	
	
	
	// trim --------------------------------------------------
	
	xo.trim = function(text){
		return text.replace(/^\s+|\s+$/g, "");
	};
	
	// confirm --------------------------------------------------
	
	xo.confirm = function(men, fn, params, corY){
		var w = $(window).outerWidth();
		var h = $(window).outerHeight();
		
		if(corY == undefined) corY = 100;
		confirm = $("<div>").addClass("contentPopup").css({"top": (corY - 20) + "px"});
		
		var bodyConfirm = $("<div>").addClass("contentViewConfirm");
		var label = $("<label>").text("Confirmacion");
		var headConfirm = $("<div>").addClass("titleView");
		label.appendTo(headConfirm);
		
		
		// message of confirm
		var table = $("<table>");
		var tr1 = $("<tr>");
		var td1 = $("<tr>").attr("align", "center").text(men);
		td1.appendTo(tr1);
		
		// buttons
		var buttons = $("<div>").attr("align", "center").css("padding-top", "20px");
		
		var aceptar = $("<input>")
		.attr({"value": "Aceptar", "type": "button", "class": "blue"})
	    .css("margin-right", "4px")
	    .click(function(){
	    	fn(params);
	    	xo.removeConfirm();
	    });
		
		var cancelar = $("<input>")
		               .attr({"value": "Cancelar", "type": "button", "class": "silver"})
		               .click(function(){
		            	   xo.removeConfirm();	
		               });
		
		// appendToando los elementos del confirm
		aceptar.appendTo(buttons);
		cancelar.appendTo(buttons);
		
		tr1.appendTo(table);
		table.appendTo(bodyConfirm);
		buttons.appendTo(bodyConfirm);
		
		if(bgPopup == null){
			bgPopup = $("<div>")
			.attr({"id": "bgPopup"})
			.addClass("bgPopup")
			.css({ "width": w, "height": h });
		}
		
		headConfirm.appendTo(confirm);
		bodyConfirm.appendTo(confirm);
		
		bgPopup.appendTo(document.body);
		confirm.appendTo(document.body);
		confirm.css("left", (w - confirm.outerWidth())/2);
		
		bgPopup.css({"z-index": "5"});
		bgPopup.animate({"opacity": "0.85"}, 200, function(){
			confirm.css({"z-index": "10"});
			confirm.animate({"opacity": 1, "top": corY}, 200);
		});
	};
	
	xo.removeConfirm = function(){
		confirm.animate({"opacity": 0}, 100, function(){ 
			confirm.remove(); 
			bgPopup.animate({"opacity": 0}, 100, function(){ bgPopup.css({"z-index": "-1"}); });
		});
	};
	
	// contextMenu --------------------------------------------------
	
	xo.contextMenu = function(ev, opciones){
		var mouseX = ev.x;
        var MouseY = ev.y;
		
        var row = ev.currentTarget;
        $(row).addClass("rowSelected");
        
        // obteniendo las opciones
        var opcs = "";
        for(var i = 0; i < opciones.length; i++){
	      	// obteniendo los parametros
	      	var params = "";
	      	if(opciones[i].parametros != null){
	      		for(var k = 0; k < opciones[i].parametros.length; k++){
	          		var type = typeof(opciones[i].parametros[k]);
	          		if(type == "string") params += "'" + opciones[i].parametros[k] + "', ";
	          		else if(type == "boolean" || type == "number") params += "" + opciones[i].parametros[k] + ", ";
	          	}
	          	params = params.substring(0, params.lastIndexOf(","));
	      	}
	      	// creando la opcion
	      	opcs += "<div><a class='optContextMenu' onclick=\"" + opciones[i].funcion + "(" + params + "); $('" + ev.currentTarget.id + "').removeClass('rowSelected')\">" + opciones[i].opcion + "</a></div>";
        }
        // creando el bg del contextMenu
        var contextMenu = $("<div>")
        .attr({"id" : "contextMenu", "class" : "contextMenu",})
        .css({"left" : (mouseX - 10), "top" : (MouseY - 10)})
        .mouseleave(function(){ $(row).removeClass("rowSelected"); $(this).remove(); })
        .click(function(e){ $(row).removeClass("rowSelected"); $(this).remove(); })
        .html(opcs);
        
        contextMenu.appendTo(document.body);
	};
	
	// popup --------------------------------------------------
	
	xo.popup = function(name, url, width, height, corY, html) {
		
		console.log("abriendo popup");
		
		var w = $(window).outerWidth();
		if(corY == undefined || corY == 0) corY = 10;
		// bgPopup
		
		if(bgPopup == null){
			bgPopup = $("<div>")
		    .attr({ "id": "bgPopup" })
		    .css({ "width": "100%", "height": "100%","z-index": 3000})
		    .addClass("bgPopup");
		}
		
		if(html != undefined){
			var contentHTML = $(html).removeClass("hidePopup");
			contentPopup = $("<div>")
			.attr({ "id": "contentPopup", "width": width + "px", "height": height + "px" })
			.addClass("contentPopup")
			.css({ "top": (corY - 20) + "px", "left": (w - width)/2 + "px", });
			contentHTML.appendTo(contentPopup);
		} 
		else{
			contentPopup = $("<iframe>")
			.attr({ "id": "contentPopup", "name": name, "src": xo.context() + "jsp/" + url, "width": width + "px", "height": height + "px" })
			.addClass("contentPopup")
			.css({ "top": (corY - 20) + "px", "left": (w - width)/2 + "px", });
		}
		
		bgPopup.appendTo(document.body);
		contentPopup.appendTo(document.body);
		
		bgPopup.css({ "z-index": 3000 });
		bgPopup.animate({ "opacity": "0.85" }, 200, function(){
			contentPopup.css({ "z-index": "4000" });
			contentPopup.animate({ "opacity": 1, "top": corY + "px" }, 200);
		});
	};

	xo.removePopup = function(){
		contentPopup.animate({"opacity": 0}, 100, function(){ 
			contentPopup.remove(); 
			bgPopup.animate({"opacity": 0}, 100, function(){ bgPopup.css({"z-index": "-1"}); });
		});
	};
	
	
	// message --------------------------------------------------
	
	xo.message = function(men, corZ){
		if(message != null) {
			clearTimeout(timeOut);
			$(message).remove();
			message = null;
		}
		
		if(corZ == undefined) corZ = 150;
		var width = $(window).outerWidth();
		
		if(message == null){
			message = $("<div>")
			.attr({ "id": "message", "align": "center" })
			.css({"width": width, "left": "0px", "top": "10px"})
			.click(function(){ xo.hideMessage(); });
		}
		
		var contentMessage = $("<span>")
		.text(men)
		.addClass("contentMessage");
		
		contentMessage.appendTo(message);
		message.appendTo(document.body);
		
		message.css({ "z-index": corZ });
		message.animate({ "opacity": 1 }, 200, function(){
			timeOut = setTimeout(function(){ xo.hideMessage(); }, 3000);
		});
	};

	xo.hideMessage = function(){
		if(message != null){
			message.animate({ "opacity": 0 }, 200, function(){
				message.css({ "z-index": -1 });
			});
		}
	};
	
	// array --------------------------------------------------
	
	xo.getElementList = function(list, ref, field){
		var obj = null;
		if(field == undefined){
			for(var i = 0; i < list.length; i++){
				if(ref == list[i]){
					obj = list[i];
					break;
				}
			};
		} else{
			for(var i = 0; i < list.length; i++){
				if(ref == list[i][field]){
					obj = list[i];
					break;
				}
			};
		}
		return obj;
	};
	
	xo.findElementList = function(list, ref, field){
		var con = false;
		if(field == undefined){
			for(var i = 0; i < list.length; i++){
				if(ref == list[i]){
					con = true;
					break;
				}
			}
		} else{
			for(var i = 0; i < list.length; i++){
				if(ref == list[i][field]){
					con = true;
					break;
				}
			}
		}
		return con;
	};
	
	xo.removeElementList = function(list, ref, field){
		var array = new Array();
		if(field == undefined){
			if(list.length != 0){
				for(var i = 0; i < list.length; i++){
					if(ref != list[i]){
						array.push(list[i]);
					}
				};
			}
		} else{
			array = new Array();
			if(list.length != 0){
				for(var i = 0; i < list.length; i++){
					if(ref != list[i][field]){
						array.push(list[i]);
					}
				};
			}
		}
		return array;
	};

	xo.onlyNumber = function(e){
        tecla = (document.all) ? e.keyCode : e.which;
        //Tecla de retroceso para borrar, siempre la permite
        if (tecla==8) return true;
        // Patron de entrada, en este caso solo acepta letras
        //patron [A-Za-z]/; 
        patron =/[0-9]/; 
        tecla_final = String.fromCharCode(tecla);
        return patron.test(tecla_final); 
        };
        

	xo.onlyLetter = function(e) {
		key = e.keyCode || e.which;
		tecla = String.fromCharCode(key).toLowerCase();
		letras = " �����abcdefghijklmn�opqrstuvwxyz";
		especiales = [ 8, 37, 39, 46 ];

		tecla_especial = false;
		for ( var i in especiales) {
			if (key == especiales[i]) {
				tecla_especial = true;
				break;
			}
		}

		if (letras.indexOf(tecla) == -1 && !tecla_especial) {
			return false;
		}
	};
	
	xo.numbers = function (event){
		if ((event.keyCode < 48) || (event.keyCode > 57)) 
			  event.returnValue = false;
	};
}