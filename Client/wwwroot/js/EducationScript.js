$(document).ready(function () {
    $('#tb_education').DataTable({
        "ajax": {
            url: "https://localhost:44325/api/education",
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
            { "data": "degree" },
            { "data": "gpa" },
            { "data": "university.name"},
            {
                "render": function (data, type, row) {
                    return '<button class="btn btn-warning " data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="BtnAction(\'Update\');return GetById(' + row.id + ')"><i class="fa fa-pen"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ')"><i class="fa fa-trash"></i></button >'

                }
            }
        ]
    })
})

function GetById(id) {
    $.ajax({
        url: "https://localhost:44325/api/education/" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            //console.log(result);
            var obj = result.data;
            $('#Id').val(obj.id);
            $('#Name').val(obj.name);
            $('#Degree').val(obj.degree);
            $('#GPA').val(obj.gpa);
            $('#myModal').modal('show');
            $('#university').val(obj.university_Id);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    })
}

function SelectUniversity() {
    $.ajax({
        url: 'https://localhost:44325/api/university',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var obj = result.data;
            console.log(obj);
            for (var i = 0; i < obj.length; i++) {
                $('#university').append('<option value="' + obj[i].id + '">' + obj[i].name + '</option>');
            }

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Insert() {
    var Education = new Object();
    Education.degree = $('#Degree').val();
    Education.gpa = $('#GPA').val();
    Education.university_Id = $('#university').val();
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44325/api/education',
        data: JSON.stringify(Education),
        contentType: "application/json; charset=utf-8"
    }).then((result) => {
        debugger;
        if (result.status == 200) {
            /*swal("Data input succeed", "Your data has been added", "success");*/
            $('#tb_education').DataTable().ajax.reload();
            Swal.fire(
                'Insert Success',
                '',
                'success'
            )
        } else {
            alert("Data gagal Dimasukan");
        }
    })
}

function Update() {
    var Education = new Object();
    Education.id = $('#Id').val();
    Education.degree = $('#Degree').val();
    Education.gpa = $('#GPA').val();
    Education.university_Id = $('#university').val();
    $.ajax({
        url: 'https://localhost:44325/api/education',
        type: 'PUT',
        data: JSON.stringify(Education),
        contentType: "application/json; charset=utf-8",
    }).then((result) => {
        /*debugger;*/
        if (result.status == 200) {
            $('#tb_education').DataTable().ajax.reload();
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
        url: "https://localhost:44325/api/education/" + id,
        type: "DELETE",
        dataType: "json",
    }).then((result) => {
        /*debugger;*/
        if (result.status == 200) {
            $('#tb_education').DataTable().ajax.reload();
            Swal.fire(
                'Delete Success',
                '',
                'success'
            )
        }
        else {
            alert("Data Gagal Didelete");
        }
    });
}

function ClearAction() {
    $('#Degree').val('Degree');
    $('#GPA').val('');
    $('#university').val('Select University')
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