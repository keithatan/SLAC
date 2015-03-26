$('input#name-submit').on('click',function(){
	var name = $('input#name').val()
//	alert(name);
	console.log("global ran");
	if($.trim(name) != '' && $.trim(name) != null) {
	//	alert(name);
		$.post('ajax/name.php', {name: name}, function(data) {
			// $('div#name-data').text(data);
			$('#name-data').html(data);
		})

	}

});	