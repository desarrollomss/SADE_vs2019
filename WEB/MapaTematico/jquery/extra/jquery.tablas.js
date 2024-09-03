jQuery.fn.tablas = function(){
    this.each( function(){
		var $this = jQuery(this).attr('id');
		jQuery('#'+$this).addClass('tblListado');
		//alert($this);
		jQuery('#'+$this+' tr th').addClass('thListado');
		jQuery('#'+$this+' tr th').filter(function(index){ return jQuery(this).attr('colspan') > 1;	}).addClass('thListadoColSpan');
		jQuery('#'+$this+' tr td').eq(0).addClass('tdListado');
		jQuery('#'+$this+' tr td').eq(0).children('div').addClass('divListado');
		
		var $divSelectorID = 'div' + jQuery(this).attr('id');
		var $newSelector = jQuery('<div id="' + $divSelectorID + '" class="divCabeceraListado">').append(jQuery(this).clone()).remove().html();
		
		jQuery(this).replaceWith($newSelector);
    });
}