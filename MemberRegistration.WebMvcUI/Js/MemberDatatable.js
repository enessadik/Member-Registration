
$(document).ready(function () {
    $("#tbl1").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },
        "lengthChange": "true",
        //"pageLength": 10,
        "lengthMenu": [[5, 8, 20, 50, - 1], [5, 8, 20, 50, "Hepsi"]],
        "ajax": {
            "url": "/Member/GetJsonList",
            "type": "GET",
            "datatype": "json",
            "cache": false
        },
        "columns": [
            { "data": "Id" },
            { "data": "Name" },
            { "data": "LastName" },
            { "data": "Email" },
            { "data": "RecourseType", "sortable": false },
            { "render": function () { return '<a href="/User/Mail" class="btn btn-success">Onay</a>'; }, "sortable": false },
            { "render": function () { return '<a href="/User/Mail" class="btn btn-danger">Red</a>'; }, "sortable": false },


        ],

        "serverSide": "true",
        "order": [0, "asc"],
        "processing": "true"
        //"language": {
        //    "processing":"yükleniyor... lütfen bekleyiniz"
        //}

    });
});

//Deneme-1

//$(document).ready(function () {
//    $('#tbl1').DataTable({
//        "language": {
//            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
//        },
//        "lengthChange": true,  /*aklıma takılan birşey var mesela ben manuel server side tarafında datatablaki sol üstte 5 10 15 olaylarını elle değilde surda tanımlasam ne farkeder niye ugrasıyorzu kiböyle?*/
//        "lengthMenu": [[5, 10, -1], [5, 10, "All"]],
//        "ajax": {
//            "url": "/Member/GetJsonList",
//            "type": "GET",
//            "datatype": "json",
//            "dataSrc": "MemberForRecourseDtos"

//        },
//        "columns": [
//            { "data": "Id" },
//            { "data": "Name", "searchable": false, "sortable": false },
//            { "data": "LastName" },
//            { "data": "Email" },
//            { "data": "RecourseType" },
//            { "render": function () { return '<a href="/User/Mail" class="btn btn-success">Onay</a>'; } },
//            { "render": function () { return '<a href="/User/Mail" class="btn btn-danger">Red</a>'; } },

//        ]
//    });
//});




/*Deneme-2 Server side*/

//$(document).ready(function () {
//    $("#tbl1").DataTable({
//        "processing": true, // for show progress bar
//        "serverSide": true, // for process server side
//        "filter": true, // this is for disable filter (search box)
//        "orderMulti": false, // for disable multiple column at once
//        "ajax": {
//            "url": "/Member/GetJsonList",
//            "type": "POST",
//            "datatype": "json",
//            "dataSrc": "MemberForRecourseDtos"
//        },
//        "columns": [
//            { "data": "Id" },
//            { "data": "Name", "searchable": false, "sortable": false },
//            { "data": "LastName" },
//            { "data": "Email" },
//            { "data": "RecourseType" },
//            { "render": function () { return '<a href="/User/Mail" class="btn btn-success">Onay</a>'; } },
//            { "render": function () { return '<a href="/User/Mail" class="btn btn-danger">Red</a>'; } },

//        ]
//    });
//});




//Deneme-3

//$(document).ready(function () {

//    BindDataTable();
//})

//var BindDataTable = function (response) {

//    $("#tbl1").DataTable({
//        "language": {
//            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
//        },
//        "bServerSide": true,
//        "bProcessing": true,
//        "sAjaxSource": "/Member/GetJsonList",
//        "fnServerData": function (sSource, aoData, fnCallback) {

//            $.ajax({

//                type: "GET",
//                data: aoData,
//                url: sSource,
//                success: fnCallback
//            })

//        },
//        "aoColumns": [

//            { "mData": "Id" },
//            { "mData": "Name" },
//            { "mData": "LastName" },
//            { "mData": "Email" },
//            { "mData": "RecourseType" },
//            {                                             /*şu alttaki debugger ile başlayan iki yeri modal form ile yapacam o modal formun ismi Mail olacak modal formun içinde de drowpdown ile onay ve red mesajları olacak bunları post ile tetiklicem*/
//                "mData": "Id",
//                "render": function (Id, type, full, meta) {
//                    debugger
//                    return '<a href="/User/Mail" onclick="SendMailUser(' + Id + ')"><b class="btn btn-success">Onay</b></a>'
//                }
//            },

//            {
//                "mData": "Id",
//                "render": function (Id, type, full, meta) {
//                    debugger
//                    return '<a href="/User/Mail" onclick="SendMailUser(' + Id + ')"><b class="btn btn-danger">Red</b></a>'
//                }
//            },


//        ]

//    });
//}