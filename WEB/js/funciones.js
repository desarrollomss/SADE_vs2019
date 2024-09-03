function jsDecimal(e, tipoDecimal) {

    var evt = (e) ? e : window.event;
    var key = (evt.keyCode) ? evt.keyCode : evt.which;
    if (key != null) {
        key = parseInt(key, 10);
        if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
            //Aca tenemos que reemplazar "Decimal" por "NoDecimal" si queremos que no se permitan decimales
            //if (!jsIsUserFriendlyChar(key, "NoDecimals")) {
            if (!jsIsUserFriendlyChar(key, tipoDecimal)) {
                return false;
            }
        }
        else {
            if (evt.shiftKey) {
                return false;
            }
        }
    }
    return true;
}

function jsIsUserFriendlyChar(val, step) {
    // Backspace, Tab, Enter, Insert, y Delete
    if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
        return true;
    }
    // Ctrl, Alt, CapsLock, Home, End, y flechas
    if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
        return true;
    }
    if (step == "Decimal") {
        if (val == 190 || val == 110) {  //Check dot key code should be allowed
            return true;
        }
    }
    // The rest
    return false;
}


function formatTelephoneNumber(elementRef) {
    //var phoneNumber = elementRef.value.replace(/[^\d]*/g, '');
    var phoneNumber = elementRef.value;

    // Format to "(000) 000-0000"...
    if (phoneNumber.length >= 5) {
        if (phoneNumber.substr(4, 1) == '-') {
        } else {
            var formattedPhoneNumber = new String('');

            //formattedPhoneNumber = '(' + phoneNumber.substr(0, 3) + ') ';
            formattedPhoneNumber += phoneNumber.substr(0, 4);
            formattedPhoneNumber += '-';
            formattedPhoneNumber += phoneNumber.substr(4, 8);

            phoneNumber = formattedPhoneNumber;

            elementRef.value = phoneNumber;
        }
    }
    else {
        //alert('A telephone number consists of 10 characters.');
        //elementRef.fofus();
        //elementRef.select();
    }

    //elementRef.value = phoneNumber;
}

function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}