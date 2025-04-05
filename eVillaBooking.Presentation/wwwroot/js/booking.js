$(document).ready(function () 
{
    $('#bookingTable').DataTable({
        "ajax": {
            "url": "Booking/GetAllDetails",
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                console.log("API Response:", json);  // Console me data print karega
                return json.data;  // DataTable ke 
            }
        },
        "columns": [
            { data: "id" },
            { data: "name" },
            { data: "phone" },
            { data: "email" },
            { data: "status" },
            {
                data: "checkInDate",
                render: function (data) {
                    if (data) {
                        let date = new Date(data);
                        let options = { day: '2-digit', month: 'short', year: 'numeric' };
                        return date.toLocaleDateString('en-GB', options).replace(/ /g, '-');
                    }
                    return "";
                }
            },
            { data: "nights" },
            {data: "villas.name"},
            { data: "totalCost" },

            {
                data: "id",
                "render": function (data) {
                    return `<a href="Booking/Details/${data}" class="btn btn-info btn-sm">View</a>`
                }
            }
        ]

    });
});