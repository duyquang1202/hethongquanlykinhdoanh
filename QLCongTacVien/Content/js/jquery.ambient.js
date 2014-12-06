/*
 * Jquery delayKeyup
 * Default time delay 400 ms
 * Example : 
 *          $("#input").delayKeyup(function(){ alert("500 ms passed from the last event keyup."); }, 500);
 *          $("#input").delayKeyup(function(){ alert("400 ms passed from the last event keyup."); });
 */
$.fn.delayKeyup = function(callback, ms){
    var myTime = 0;
    var el = $(this);
    var delay = (ms) ? ms : 400;
    $(this).keyup(function(){                   
        clearTimeout (myTime);
        myTime = setTimeout(function(){
            callback(el)
        }, delay);
    });
    return $(this);
};

/*
 * Jquery display error nearby field
 * Author : Truong Nguyen
 * Example : $("#txtName").displayMessage('Please input name');
 * Notes : no suppor IE8 and earlier, if not have param mess, will remove tag contain error   
 */
$.fn.displayMessage = function(mess,style){
    //remove tag contain error
    ($('#'+this[0].id+'Error').length > 0) ? $('#'+this[0].id+'Error').remove() : null;
    if(mess){
        //caculate position
        var width = parseInt(this.outerWidth(true));
        var height = parseInt(this.outerHeight(true));
        var left = parseInt(this.position().left) + width + 2;
        var top = parseInt(this.position().top) + parseInt(this.css('margin-top')) + parseInt(this.css('padding-top')) -2;
        //not style
        if(typeof style == 'undefined' ){
            var style = {};
        }
        
        //create tag error
        this.after('<div id="'+this[0].id+'Error'+'">'+mess+'</div>');
        $('#'+this[0].id+'Error').css({
            'z-index':'1000',
            'font-size': '12px',
            'border-radius' : '2px',
            'left':left,
            'top':top,
            'max-width' : (style.width) ? style.width : parseInt(this.css('width')) + parseInt(this.css('padding-left')) + parseInt(this.css('padding-right'))+'px',
            'position':(style.position) ? '' : 'absolute',
            'color' : (style.color) ? style.color : '#FF0000',
            'border' : (style.border) ? style.border : '1px solid #AAAAAA',
            'margin' : (style.margin) ? style.margin : '',
            'padding' : (style.padding) ? style.padding : '',
            'background' : (style.background) ? (style.background) : '#FFFFFF',
        });
    }
};

/*
 * Jquery devidePercent method
 * Author : Truong Nguyen
 * Example : $("#divID").devidePercent([5,10]);
 * Notes : 
 * - using tag <div> 
 * - include lib jquery.equalHeight.js
 * - limit style css in layout 
 * Description : 
 * - get width of <div id="divID">, devide percent and equal height for colum in list
 * - style css for layout
 * - <div> first in <div id="divID"> using to head row
 * - required contruct 
 * <div id="divID">
 *      <div>
 *          <div>colum1</div>
 *          <div>colum2</div>
 *          ...
 *      </div>
 *      <div>
 *          <div>colum1</div>
 *          <div>colum2</div>
 *          ...
 *      </div> 
 * </div>
 */
$.fn.devidePercent = function(aPercent){
    //css for wrapper
    $(this).addClass('percent_wrapper');
    //css head
    $(this).children('div:first').addClass('head');
    //css rows
    $(this).children('div:gt(0)').addClass('rows');
    //css region
    $(this).children('div').children('div').each(function(){
        $(this).addClass('regions');
        if($(this).index() == aPercent.length-1){
            $(this).css('border-right','none');
        }
    });
    
    var aWidth = new Array();
    var iTmp = 0;
    //get width wrapper
    var iWrapW = $(this).width();
    //subtraction padding, margin, border
    var aPadd = ['padding-left','padding-right','margin-left','margin-right','border-left-width','border-right-width'];
    $(this).children('div:first').children('div').each(function(){
        for(i=0;i<aPadd.length;i++){
            iWrapW -= !isNaN(parseInt($(this).css(aPadd[i]))) ? parseInt($(this).css(aPadd[i])) : 0;
        }
    });
    //calculate width
    for(i = 0 ; i < aPercent.length-1 ; i++){
        var val = iWrapW/100*aPercent[i];
        aWidth.push(parseInt(val));
        iTmp += parseInt(val);
    }
    //assign end colum
    aWidth.push(parseInt(iWrapW-iTmp-1));
    //add width to Region
    $(this).children('div').children('div .regions').each(function(){
        $(this).css('width',aWidth[$(this).index()]);
    });
    //add height equal
    $(this).children('div:first').children('div').equalHeights();
    $(this).children('div:gt(0)').children('div').equalHeights();
    //wrap label for checkbox
    $(this).find('input:checkbox').each(function(){
        $(this).parent().wrapAll('<label style="cursor: pointer;"></label>');
    });
};

/* Jquery push and check one value to list checked
 * Author : Truong Nguyen
 * Description :
 * - push one value to field #cbList delimiter (,)
 * Example :
 * - $('#cbList').pushCB(fieldChecked);
 */
$.fn.pushCB = function (checkbox){
    if($(checkbox).prop('checked') == true){
        var del = ($(this).val()) ? ',' : '';
        $(this).attr('value',$(this).val()+del+$(checkbox).val());
    } else {
        var arr = $(this).val().split(',');
        arr.splice(arr.indexOf($(checkbox).val()), 1);
        $(this).attr('value',arr.join(','));
    }
};

/* Jquery push all to list checked and check all item
 * Author : Truong Nguyen
 * Description :
 * - push all value of item to field #cbList delimiter (,)
 * - required one field checked and fields item
 * Example : 
 * - $('#cbList').pushAllCB(fieldChecked,nameItem);
 */
$.fn.pushAllCB = function(checkbox,item) {
    var ListID = $(this).prop('id');
    if($(checkbox).prop('checked') == true) {
        var aExist = $(this).val().split(',');
        //check
        $('input[name="'+item+'"]').prop('checked',true);
        //loop check item and push if not exists in list
        $('input[name="'+item+'"]').each(function() {
            if( $.inArray($(this).val(),aExist) == -1 ) {
                $('#'+ListID).pushCB(this);
            }
        });
    } else {
        //remove check
        $('input[name="'+item+'"]').prop('checked',false);
        //remove value in list
        $('input[name="'+item+'"]').each(function(){
            $('#'+ListID).pushCB(this);
        });
    }
};

/*
* Jquery valid field match with reg
* Author : Truong Nguyen
* Params : 
* - reg : regular expression
* - mess : message when invalid or mess default
* - unmatch : will valid unmatch with reg (default match)
* - notnull : field required not null
* Example : $("#FieldId").validField({reg:1,notnull:true,mess:'Please input'}); 
* Notes : aRegDefault is pattern regular create before
*/
$.fn.validField = function(param){
    var aPattern = {
        //accept (number, null)
        0:'This field is required.',
        //accept char
        1:{
            reg : /^[A-Za-z]+$/,
            mess : 'Only accept char'
        },
        //accept date yyyy-mm-dd
        2:{
            reg : /^(^$|(19|20)\d\d[-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01]))$/,
            mess : 'Only accept date format yyyy-mm-dd'
        },
        //accept file .pdf|.txt|.doc|.csv
        3:{
            reg : /^[a-zA-Z0-9-_\.]+\.(pdf|txt|doc|csv)$/,
            mess : 'Only accsept file format pdf|txt|doc|csv' 
        },
        //accept IP adress
        4:{
            reg : /^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})$/,
            mess : 'Only accept IP adress valid'
        },
        //accept char in list
        5:{
            reg : /^[\w]+$/,
            mess : 'Accept char or number or _'
        },
        //accept email adress
        6:{
            reg : /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,6})+$/,
            mess : 'Email adress invalid'
        },
        //not accept char in lists
        7:{
            reg : /[\',\",\`\~\!\@\#\$\%\^\&\*\|\,\\,\<,\>,\+,\/,\;\.]/,
            mess : 'Don\'t accept special char '  
        },
        8:{
            reg : /^((ht|f)tps?:\/\/)[a-z0-9-\.]+\.[a-z]{2,4}\/?([^\s<>\#%\"\,\{\}\\|\\\^`]+)?$/, 
            mess : 'Url invalid'
        }
    };
    //remove message
    $(this).displayMessage();
    var value = $(this).val();
    if($.trim(value) == ''){
        //required not null
        if(param.notnull){
            var message = aPattern[0];
            $(this).displayMessage(message);
            return false;
        }
        return true;
    }
    else{
        if(typeof param.reg != 'undefined'){
            //regular declare or default
            var regular = (param.reg in aPattern) ? aPattern[param.reg].reg : param.reg;
            var result = (param.unmatch) ? !RegExp(regular).test(value) : RegExp(regular).test(value);
            if(result){
                return true;
            }
            //message declare or default
            var message = (typeof param.mess != 'undefined' ) ? param.mess : (param.reg in aPattern) ? aPattern[param.reg].mess  : '' ;
            $(this).displayMessage(message);
        }
        return false;
    }
};