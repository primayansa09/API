
$(document).ready(function () {
    $('#tb_university').DataTable({
        "ajax":{
            url: "https://localhost:44325/api/University",
            type: "GET",
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            {
                render: function (data, tye, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }   
            },
            { "data": "name" },
            {
                
                "data": "id",
                "render": function (data, type, row) {
                    return '<button class="btn btn-warning " data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="BtnAction(\'Update\');return GetById(' + data + ')"><i class="fa fa-pen"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + data + ')"><i class="fa fa-trash"></i></button >'
                
                }
            }
        ]
    })
})

function Save() {
    var University = new Object();
    University.Name = $("#Name" ).val();
    $.ajax({
        type: "POST",
        url: "https://localhost:44325/api/University/",
        data: JSON.stringify(University),
        contentType: "application/json; charset=utf-8"
    }).then((result) => {
        if (result.status == 200) {
            $('#tb_university').DataTable().ajax.reload();
           /* alert("Data berhasil dimasukan");*/
            Swal.fire(
                'Insert Success',
                '',
                'success'
            )
        } else {
            Swal.fire(
                'Insert Success',
                '',
                'error'
            )
        }
    })
}
function GetById(id) {
    $.ajax({
        url: "https://localhost:44325/api/University/" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            //console.log(result);
            var obj = result.data;
            $('#Id').val(obj.id);
            $('#Name').val(obj.name);
            $('#myModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    })
}

function Update() {
    var University = new Object();
    University.Id = $('#Id').val();
    University.Name = $('#Name').val();
    $.ajax({
        url: 'https://localhost:44325/api/University',
        type: 'PUT',
        data: JSON.stringify(University),
        contentType: "application/json; charset=utf-8",
    }).then((result) => {
        /*debugger;*/
        if (result.status == 200) {
            $('#tb_university').DataTable().ajax.reload();
            Swal.fire(
                'Update Success',
                '',
                'success'
            )
           
        }
        else {
            alert("Data gagal Diperbaharui");
        }
    });
}

function Delete(id) {
    //debugger;
    $.ajax({
        url: "https://localhost:44325/api/University/" + id,
        type: "DELETE",
        dataType: "json",
    }).then((result) => {
        /*debugger;*/
        if (result.status == 200) {
            $('#tb_university').DataTable().ajax.reload();
            Swal.fire(
                'Delete Success',
                '',
                'success'
            )
        }
        else {
            alert("Data gagal Didelete");
        }
    });
}

function ClearActionUniv() {
    $('#Name').val('');
}

function BtnAction(type) {
    var btnSave = 'none';
    var btnUpdate = 'none';
    var message = '';

    switch (type) {
        case 'Insert':
            btnSave = 'block';
            btnUpdate = 'none';
            message = 'Add new university';
            break;
        case 'Update':
            btnSave = 'none';
            btnUpdate = 'block';
            message = 'Update university';
            break;
        default:
            break;
    }

    document.getElementById('Save').style.display = btnSave;
    document.getElementById('Update').style.display = btnUpdate;
}