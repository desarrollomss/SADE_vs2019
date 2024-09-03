jQuery.fn.extend({
	boton_disabled: function() {
		return this.each(function(){
			if( $("#"+$(this).attr("id")).attr("disabled") == false ){
			  	$("#"+$(this).attr("id")).attr("disabled", "diabled");
				$("#"+$(this).attr("id")+" table img").attr("src", ($("#"+$(this).attr("id")+" table img").attr("src")).substring(0, ($("#"+$(this).attr("id")+" table img").attr("src")).length-4) + "_disabled.gif");
			}
		});
	},


	boton_enabled: function () {
		return this.each(function(){
			if( $("#"+$(this).attr("id")).attr("disabled") == true ){
			  	$("#"+$(this).attr("id")).removeAttr("disabled");
				$("#"+$(this).attr("id")+" table img").attr("src", ($("#"+$(this).attr("id")+" table img").attr("src")).substring(0, ($("#"+$(this).attr("id")+" table img").attr("src")).length-13) + ".gif");
			}
		});
	}
});