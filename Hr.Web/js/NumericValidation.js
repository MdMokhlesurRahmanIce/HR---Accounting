    
    function CheckInteger(sender,keyCode,allowNegative) {
        if ((keyCode >= 48 && keyCode <= 57) || // 0-9 numbers
            (keyCode >= 37 && keyCode <= 40) || // Left, Up, Right and Down
            keyCode == 8 || // backspaceASKII
            keyCode == 9 || // tabASKII
            keyCode == 16 || // shift
            keyCode == 17 || // control
            keyCode == 35 || // End
            keyCode == 36 || // Home
            keyCode == 46) // deleteASKII
            return true;
        else if ((keyCode == 189 || keyCode == 109) && allowNegative == true) 
        { // dash (-)
            if (sender.value.indexOf('-', 0) > -1)
                return false;
            else
                return true;
        }
        else
            return false;
    };
    
    
    function CheckDecimal(sender, keyCode, numberOfInteger, numberOfFrac, allowNegative) 
    {
        var valueArr;

        if ((keyCode >= 37 && keyCode <= 40) || // Left, Up, Right and Down
            keyCode == 8 || // backspaceASKII
            keyCode == 9 || // tabASKII
            keyCode == 16 || // shift
            keyCode == 17 || // control
            keyCode == 35 || // End
            keyCode == 36 || // Home
            keyCode == 46) // deleteASKII
            return true;
        else if ((keyCode == 189 || keyCode == 109) && allowNegative == true) 
        { // dash (-)
            if (sender.value.indexOf('-', 0) > -1)
                return false;
            else
                return true;
        }

        valueArr = sender.value.split('.');
        
        if (keyCode == 190 || keyCode == 110) 
        { // decimal point (.)
            if (valueArr[0] != null && valueArr[1] == null)
                return true;
            else
                return false;
        }

        if (keyCode >= 48 && keyCode <= 57) 
        { // 0-9 numbers            
            if (valueArr[1] == null) {
                if (valueArr[0].indexOf('-', 0) > -1)
                    numberOfInteger++;

                if (valueArr[0].length < numberOfInteger)
                    return true;
            }
            else {
                if (valueArr[1].length < numberOfFrac)
                    return true;
            }
        }

        return false;
    };
    
    function IsNumeric(strString)    
    {
        //  check for valid numeric strings	    
        var strValidChars = "0123456789.-";
        var strChar;
        var blnResult = true;

        if (strString.length == 0) return false;

        //  test strString consists of valid characters listed above
        for (i = 0; i < strString.length && blnResult == true; i++)
        {
            strChar = strString.charAt(i);
            if (strValidChars.indexOf(strChar) == -1)
            {
                blnResult = false;
            }
        }
        return blnResult;
    }