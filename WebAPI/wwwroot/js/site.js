

function getDataSet() {
    $(document).ready(function () {
        var dataTable = $('#dataTable');

        $.ajax({
            type: 'GET',
            url: 'https://localhost:5001/api/1.0/Admin/DataSetInfo',
            dataType: 'json',
            success: function (data) {
                dataTable.empty();
                $.each(data, function (index, val) {
                    var Title = val.title;
                    var Text = val.text;
                    var Subject = val.subject;
                    var Date = val.date;
                    var Validation = val.validation;
                    dataTable.append('<tr> <th scope="row">' + Title + '</td>' + '<td> ' + Text + '</td >' + '<td> ' + Subject + '</td >' + '<td> ' + Date + '</td >' + '<td> ' + Validation + '</td > </tr>');
                });
            }
        });
    });
}

const selectElement = document.querySelector('#select_data_news');

selectElement.addEventListener('change', (event) => {
    $(document).ready(function () {
        var dataTable = $('#dataTable');
        dataTable.empty();

        if (event.target.value != 'All') {
            $.ajax({
                type: 'GET',
                url: `https://localhost:5001/api/1.0/Admin/TrueInfo?validation=${event.target.value}`,
                dataType: 'json',
                success: function (data) {
                    dataTable.empty();
                    $.each(data, function (index, val) {
                        var Title = val.title;
                        var Text = val.text;
                        var Subject = val.subject;
                        var Date = val.date;
                        var Validation = val.validation;
                        dataTable.append('<tr> <th scope="row">' + Title + '</td>' + '<td> ' + Text + '</td >' + '<td> ' + Subject + '</td >' + '<td> ' + Date + '</td >' + '<td> ' + Validation + '</td > </tr>');
                    });
                }
            });
        } else {
            getDataSet();
        }
    });
});


//function getLinkResult() {
//    $(document).ready(function () {
//        var dataTable = $('#dataTable');

//        $.ajax({
//            type: 'POST',
//            url: 'https://localhost:5001/api/1.0/Admin/DataSetInfo',
//            dataType: 'json',
//            success: function (data) {
//                dataTable.empty();
//                $.each(data, function (index, val) {
//                    var Id = val.id;
//                    var Title = val.title;
//                    var Text = val.text;
//                    var Subject = val.subject;
//                    var Date = val.date;
//                    var Validation = val.validation;
//                    dataTable.append('<tr> <th scope="row">' + Id + '</th> <td>' + Title + '</td>' + '<td> ' + Text + '</td >' + '<td> ' + Subject + '</td >' + '<td> ' + Date + '</td >' + '<td> ' + Validation + '</td > </tr>');
//                });
//            }
//        });
//    });
//}