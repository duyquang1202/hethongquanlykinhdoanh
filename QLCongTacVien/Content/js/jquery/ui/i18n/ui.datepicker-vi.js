/* Vietnamese initialisation for the jQuery UI date picker plugin. */
/* Written by Huy Kha (khahuy@gmail.com). */
jQuery(function($){
	$.datepicker.regional['vi'] = {
		closeText: 'Đóng',
		prevText: '&#x3c;Trước',
		nextText: 'Tiếp&#x3e;',
		currentText: 'Hôm nay',
		monthNames: ['Tháng 1 - ','Tháng 2 - ','Tháng 3 - ','Tháng 4 - ','Tháng 5 - ','Tháng 6 - ',
		'Tháng 7 - ','Tháng 8 - ','Tháng 9 - ','Tháng 10 - ','Tháng 11 - ','Tháng 12 - '],
		monthNamesShort: ['Th.1','Th.2','Th.3','Th.4','Th.5','Th.6',
		'Th.7','Th.8','Th.9','Th.10','Th.11','Th.12'],
		dayNames: ['Chủ nhật','Thứ 2','Thứ 3','Thứ 4','Thứ 5','Thứ 6','Thứ 7'],
		dayNamesShort: ['CN','T.2','T.3','T.4','T.6','T.6','T.7'],
		dayNamesMin: ['CN','T.2','T.3','T.4','T.5','T.6','T.7'],
		dateFormat: 'dd/mm/yy', firstDay: 1,
		isRTL: false};
	$.datepicker.setDefaults($.datepicker.regional['vi']);
});