﻿window.ShowToastr = (type, message) => {
    if(type === "success"){
        toastr.success(message, "Operation Succesful");
    }
    if(type === "error"){
        toastr.error(message, "Operation Failed");
    }
}