var dataTable

let berloid = document.getElementById("berloid").value;
let oraid = document.getElementById("oraid").value;

//let ma = Date.parse(document.getElementById("today").value);
let ma = new Date().toISOString().slice(0, 10);

let mayyyy = ma.slice(0, 4);
let mamm = ma.slice(5, 7);
let madd = ma.slice(8, 10);

let fogyi = 0;
let fogyiertekhez = 0;
let mfogyi = 0;
let mmfogyi = 0;
let mmmfogyi = 0;

let eelso = true;
let eeelso = true;
    
    $(document).ready(function () {
        // loadDataTable("#" + oratip, text3, oraid);
        loadDataTable("#JSTabla", berloid, oraid);

    });





function loadDataTable(tablanev, berloid, oraid) {
    let elso = true;
    let eelso = true;
    let eeelso = true;

    dataTable = $(tablanev).DataTable(
        {
            "language":
            {
                lengthMenu: '_MENU_ rekord oldalaként',
                zeroRecords: 'Nincs találat',
                info: 'Oldalak _PAGE_ -tól _PAGES_ -ig',
                infoEmpty: 'Nincs elérhető adat',
                "paginate": {
                    "first": "Első",
                    "last": "Utolsó",
                    "next": "Következő",
                    "previous": "Elöző"

                },
                search: "Keresés:",
            },
            "ajax": {
                "url": "/Admin/Leolvasas/GetAll2?Bid=" + berloid + "&Oid=" + oraid
            },

            "columns": [
                { "data": "timeStamp", "width": "10%" },
                { "data": null, "width": "10%", },
                { "data": null, "width": "5%" },
                { "data": null, "width": "5%", },
                { "data": null, "width": "10%" },
                { "data": null, "width": "30%" },
                //{ "data": null, "width": "8%" },
            ],


            columnDefs: [
                // IDŐPONT
                {
                    targets: 0,
                    render: DataTable.render.datetime('yyyy.MM.dd'),
                },

                // LEOLVASAS
                {
                    targets: 1,
                    render: function (data, type, row, meta) {
                        if (row.meroOra.atalanyMennyiseg == 0) {
                            return row.mennyiseg + " " + row.meroOra.mertekEgyseg;
                        }
                        else { return "" }
                    }
                },

                // FOGYASZTÁS
                {
                    targets: 2,
                    render: function (data, type, row, meta) {
                        if (row.meroOra.atalanyMennyiseg == 0 && row.fogyasztas>0) {
                            return row.fogyasztas + " " + row.meroOra.mertekEgyseg;
                        }
                        else { return "" }
                    }
                },

                // EGYSEGAR
                {
                    targets: 3,
                    render: function (data, type, row, meta) {
                        if (row.meroOra.atalanyMennyiseg == 0 && row.fogyasztas > 0) {
                            let ertek = row.egysegAr
                            var x = Number(ertek).toFixed(0); ertek =
                            ertek = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " "); // use space as  thousand separator
                            return ertek + " Ft/"+ row.meroOra.mertekEgyseg;;
                        }
                        else { return "" }
                    }
                },

                // ÉRTÉK
                {
                    targets: 4,
                    render: function (data, type, row, meta) {
                        if (row.meroOra.atalanyMennyiseg == 0 && row.fogyasztas > 0) {
                            let ertek = row.egysegAr * row.fogyasztas
                            var x = Number(ertek).toFixed(0); ertek =
                                ertek = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " "); // use space as  thousand separator
                            return ertek + " Ft/";
                        }
                        else { return "" }
                    }
                },


                // IMAGEURL
                {
                    targets: 5,
                    render: function (url, type, row, meta) {
                        if (row.imageUrl != null) {
                            return '<img src="' + row.imageUrl + '" width=50% />';
                        }
                        else { return '' }


                    }
                },




                





            ]





        },

    )



    dataTable
        .order([0, 'desc'])
        .draw();







};






