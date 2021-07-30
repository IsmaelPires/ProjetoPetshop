$(".voltar-pet").click(function () {
    window.location.href = "/Home/Index";
});

$(".novo-pet").click(function () {
    window.location.href = "/Pet/Cadastro";
});

$(".btn-salvar-pet").click(function () {
    salvar();
});

$("#btn-cancelar-pet").click(function () {
    window.location.href = "/Pet/Index";
});

function salvar() {
    var nomePet = $("#input-nome-pet").val();
    var nomeDono = $("#input-nome-dono").val();
    var endereco = $("#input-endereco-dono").val();
    var telefone = $("#input-telefone-dono").val();
    var estadoSaude = $("#input-estado-saude").val();
    var motivoInternacao = $("#input-estado-saude").val();

    var data = {
        Nome: nomePet,
        NomeDono: nomeDono,
        EnderecoDono: endereco,
        TelefoneDono: telefone,
        EstadoSaude: estadoSaude,
        MotivoInternacao: motivoInternacao
    };

    validaForm(data);

    var url = "/Pet/Salvar"

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: url,
        data: data
    });
}

function validaForm(data) {
    if (data.Nome == '' || data.Nome == undefined) {
        alert('Nome do Pet é obrigatório!');
        return;
    }

    if (data.NomeDono == '' || data.NomeDono == undefined) {
        alert('Nome do dono é obrigatório!');
        return;
    }

    if (data.EnderecoDono == '' || data.EnderecoDono == undefined) {
        alert('Endereço do dono é obrigatório!');
        return;
    }

    if (data.TelefoneDono == '' || data.TelefoneDono == undefined) {
        alert('Telefone do dono é obrigatório!');
        return;
    }

    if (data.EstadoSaude == '' || data.EstadoSaude == undefined) {
        alert('Estado de saúde do Pet é obrigatório!');
        return;
    }

    if (data.MotivoInternacao == '' || data.MotivoInternacao == undefined) {
        alert('Motivo da internação é obrigatório!');
        return;
    }
}

function sucessoSalvar() {
    alert("Sucesso ao salvar os dados!");
}

function erroSalvar() {
    alert("Erro ao salvar os dados!");
}