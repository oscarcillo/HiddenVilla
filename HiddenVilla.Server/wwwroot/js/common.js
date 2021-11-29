window.ShowToastr = (type, message) => {
    if(type === "success"){
        toastr.success(message, "Operation Succesful");
    }
    if(type === "error"){
        toastr.error(message, "Operation Failed");
    }
}

window.ShowSwal = (type, message) => {
    if(type === "success"){
        Swal.fire({
            icon: 'success',
            title: 'Correct',
            text: message
        })
    }
    if(type === "error"){
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: message
        })
    }
}