(function() {
	var menuButton = document.querySelector('.menu'),
		menu = document.querySelector('#menu')

	menuButton.addEventListener('click', function() {
		if (menu.className.indexOf('active') > -1) {
			menu.className = menu.className.replace(' active', '');
		} else {
			menu.className = menu.className + ' active';
		}
		
	});
})();