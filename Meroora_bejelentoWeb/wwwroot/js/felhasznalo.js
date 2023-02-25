var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url":"/Admin/Felhasznalo/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "telefon", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/felhasznalo/Upsert?id=${data}"
                            class="btn btn-primary mx-2"> <i class="bg-info bi-pencil-square"></i>Módosítás</a>
                            <a onClick=Delete('/Admin/felhasznalo/Delete/${data}')
                            class="btn btn-danger mx-2"> <i class="bi-trash-fill"></i>Törlés</a>
                        </div>
                    `
                },
                "width": "15%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Biztos törölni szeretné?',
        text: "Nem lehet visszaállítani törlés után!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Igen Törlöm!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}