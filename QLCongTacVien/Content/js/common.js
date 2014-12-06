/*
 * Author : Truong Nguyen 
 * Update : 2013/10/21
 */

/*Create buttonUI*/
function jButton(){
	$("input[type=submit], input[type=button], input[type=reset]").button();
}
/*Alert jqueryUI*/
function alertUI(mess){
    $('<div style="padding: 20px 50px; max-width: 500px; word-wrap: break-word;font-size:12px">' + mess + '</div>').dialog({
        draggable: false,
        modal: true,
        resizable: false,
        width: 'auto',
        position:[($(window).width()/2)-(300/2),250],
        title: 'Message',
        minHeight: 75,
        buttons : {OK : function(){$(this).dialog('destroy');}}
    });
}
/*Confirm jqueryUI*/
function confirmUI(dialogText, okFunc, cancelFunc, dialogTitle) {
    $('<div style="padding: 20px; max-width: 500px; word-wrap: break-word;font-size:12px">' + dialogText + '</div>').dialog({
        draggable: false,
        modal: true,
        resizable: false,
        width: 'auto',
        title: dialogTitle || 'Confirm',
        minHeight: 75,
        buttons: {
            OK: function () {
                if (typeof (okFunc) == 'function') { setTimeout(okFunc, 50); }
                $(this).dialog('destroy');
            },
            Cancel: function () {
                if (typeof (cancelFunc) == 'function') { setTimeout(cancelFunc, 50); }
                $(this).dialog('destroy');
            }
        }
    });
}
/*Block all site or by id*/
function blockSite(id,img){
    var loading = (img) ? '<img src="'+img+'">' : '<img src="design/pic/ajax-loader.gif">';
    if(id){
        $('#'+id).block({message : loading});
    } else {
         $.blockUI({message : loading});
    }
}
/*unblock*/
function unblockSite(){
    $.unblockUI();
}