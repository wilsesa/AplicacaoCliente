var datatable;

$(document).ready(function () {
    loadDataTable();
    var id = document.getElementById("clienteId");
    if (id.value > 0) {
        $('#myModal').modal('show');
    }
});

function limpar() {
    var clienteId = document.getElementById("clienteId");
    var clienteNomes = document.getElementById("clienteNomes");
    var clienteSobrenomes = document.getElementById("clienteSobrenomes");
    var clienteEndereco = document.getElementById("clienteEndereco");
    var clienteTelefone = document.getElementById("clienteTelefone");
    var clienteEstado = document.getElementById("clienteEstado");

    clienteId.value = 0;
    clienteNomes.value = "";
    clienteSobrenomes.value = "";
    clienteEndereco.value = "";
    clienteTelefone.value = "";
    clienteEstado.value = true;
}


function loadDataTable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Cliente/ObtenerTodos"
        },
        "columns": [
            { "data": "nomes", "width": "15%" },
            { "data": "sobrenomes", "width": "20%" },
            { "data": "endereco", "width": "20%" },
            { "data": "telefone", "width": "20%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "activo";
                    }
                    else {
                        return "Inativo";
                    }
                }, "width" : "10%",
            },
            {
                "data": "id",
                "render": function(data) {
                    return `
                        <div>
                            <a href="/Cliente/Create/${data}" class="btn btn-success text-white" style="cursor:pointer;">
                            Edit    
                            </a>
                        </div>
                            `;
                }, "width": "10%"
            }
        ]
    });
}