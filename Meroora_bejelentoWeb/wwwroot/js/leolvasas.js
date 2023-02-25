var dataTable



let text = document.getElementById("CC").value.toString();
const myArray = text.split(",");
let oratip = myArray[1];

let text2 = document.getElementById("CCid").value.toString();
const myArray2 = text2.split(",");
let oraid = myArray2[1];

let text3 = document.getElementById("berloid").value;

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



for (i = 0; i < myArray.length-1; i++)
{
    

    let oratip = myArray[i];
    //alert(oratip);
    let oraid = parseInt(myArray2[i]);
    //alert(oraid);

    $(document).ready(function () {
        loadDataTable("#" + oratip, text3, oraid);
        
    });

    //let fogyi = 0;
    
   

}






//$(document).ready(function () {
    
    //loadDataTable("#" + CC.substring(8,14), 2);
    //loadDataTable("#" + "Gazora", 2);
//});

 



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
                "url": "/Admin/Leolvasas/GetAll?Bid=" + berloid + "&Oid=" + oraid
            },

            "columns": [
                { "data": "timeStamp", "width": "10%" },
                { "data": null, "width": "10%", },
                { "data": null, "width": "5%" },
                { "data": null, "width": "5%", },
                { "data": null, "width": "10%" },
                { "data": null, "width": "30%" },
                { "data": null, "width": "8%" },
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
                        if (row.meroOra.atalanyMennyiseg == 0) {
                            let fogyasztas = row.mennyiseg - fogyi;
                            fogyi = row.mennyiseg;

                            if (elso) {
                                elso = false;
                                return ""
                            }
                            else {

                                return fogyasztas + " " + row.meroOra.mertekEgyseg
                            }

                            


                        }
                        else {
                            return ""
                        }
                    }
                },

                // EGYSÉGÁR
                {
                    targets: 3,
                    render: function (data, type, row, meta) {
                        if (row.meroOra.atalanyMennyiseg == 0) {
                            //let fogyasztas = row.mennyiseg - fogyi;
                            //fogyi = row.mennyiseg;
                            if (eelso) {
                                eelso = false;
                                return ""
                            }
                            else {

                                let ertek = row.meroOra.egysegAr
                                var x = Number(ertek).toFixed(0); ertek =
                                    ertek = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " "); // use space as  thousand separator
                                return ertek + " Ft";
                            }
                        }
                        else { return "" }

                    }

                },

                // ÉRTÉK
                {
                    targets: 4,
                    render: function (data, type, row, meta) {
                        if (row.meroOra.atalanyMennyiseg == 0) {
                            let fogyasztas = row.mennyiseg - mmmfogyi;
                            mmmfogyi = row.mennyiseg;
                            let fogyasztasertekhez = row.mennyiseg - fogyiertekhez;
                            fogyiertekhez = row.mennyiseg;

                            if (eeelso) {
                                eeelso = false;
                                return ""
                            }
                            else {
           
                                let ertek = fogyasztas * row.meroOra.egysegAr;
                                var x = Number(ertek).toFixed(0); ertek =
                                    ertek = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " "); // use space as  thousand separator
                                return ertek + " Ft";
                            }
                        }
                        else {
                            let ertek = row.mennyiseg;
                            var x = Number(ertek).toFixed(0); ertek =
                                ertek = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " "); // use space as  thousand separator
                            return ertek + " Ft";
                        }

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

                // Módosítás Gomb
                {
                    targets: 6,
                    render: function (data, type, row, meta) {
                        let mfogyasztas = row.mennyiseg - mmfogyi;
                        mmfogyi = row.mennyiseg;
                        let min = row.mennyiseg - mfogyasztas;
                        if (madd >= row.berlo.leolvKezdonap && madd <= row.berlo.leolvKezdonap + row.berlo.leolvMaxNap && row.timeStamp.slice(0, 4) == mayyyy && row.timeStamp.slice(5, 7) == mamm && row.meroOra.atalanyMennyiseg == 0) {
                            return `
                            <div class="w-100 btn-group" role = "group">
                                <a href="/Admin/Leolvasas/Upsert?id=${row.id + "&Bid=" + berloid + "&Oid=" + oraid + "&Min=" + min}"
                                class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Módosítás</a>
                            </div>`
                            

                        }
                        else {
                            return ""
                        }
                    }

                },


            ]





        },
        
    )

    

    dataTable
        .order([0, 'desc'])
        .draw();

    
   
    



};






