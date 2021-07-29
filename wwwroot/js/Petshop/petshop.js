$(".voltar-petshop").click(function () {
    window.location.href = "/Home/Index";
});

$(".novo-petshop").click(function () {
    window.location.href = "/Petshop/Cadastro";
});

$(".btn-salvar-petshop").click(function () {
    salvar();
});

$("#btn-cancelar-petshop").click(function () {
    window.location.href = "/Petshop/Index";
});

function salvar() {
    var nome = $("#input-nome-petshop").val();
    var endereco = $("#input-endereco-petshop").val();
    var vagas = $("#input-qtd-vagas").val();

    var data = {
        Nome: nome,
        Endereco: endereco,
        Vagas: vagas
    };

    var url = "/Petshop/Salvar"

    $.ajax({
        type: "POST",
        dataType: 'JSON',
        url: url,
        data: data,
        success: sucessoSalvar(),
        error: erroSalvar()
    });
}

function sucessoSalvar() {
    alert("Sucesso ao salvar os dados!");
}

function erroSalvar() {
    alert("Erro ao salvar os dados!");
}