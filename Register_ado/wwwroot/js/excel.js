        var datatable;
        $(document).ready(function () {
            loadDataTable()
        })
        function loadDataTable() {
            dataTable = $('#tblData').DataTable({
           
                "ajax": {
                    "url": "/Home/GetAll",
                    "type": "POST",
                    "datatype": "json",
                },
                processing: true,
                serverSide: true,
              
              //  order: [[1, 'desc']],
                "columns": [
                    { "data": "name", /*"searchable": false*/ },
                    { "data": "email" },
                    { "data": "hobbies" },
                    { "data": "department", /*"searchable": false */},
                    { "data": "designation", /*"searchable": false, "sortable": false*/ }
                ],

                "language": {
                    "infoFiltered": ""
                },
              
                "dom": 'lBfrtip',
                buttons: [
                    {
                      
                        extend: 'excelHtml5',
                        text: 'Export to Excel',
                        title: 'Export datatable data to Excel',
                        exportOptions: {
                            columns: ':visible'
                        }
                    }]
            })
}
$(function () {
    $('#hobbies1').multiselect({
        template: {
            button: '<button type="button" class="multiselect dropdown-toggle btn btn-primary" data-bs-toggle="dropdown" aria-expanded="false"><span class="multiselect-selected-text" selected ></span></button>',
        },
    });
});                                                     