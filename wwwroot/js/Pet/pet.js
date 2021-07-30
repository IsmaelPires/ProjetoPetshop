$(".voltar-pet").click(function () {
    window.location.href = "/Home/Index";
});

$(".novo-pet").click(function () {
    window.location.href = "/Pet/Cadastro";
});

$(".btn-salvar-cadastro-pet").click(function () {
    salvarPet();
});

$(".btn-cancelar-cadastro-pet").click(function () {
    $.ajax({
        type: "GET",
        url: "/Pet/Index"
    });
});

$(".btn-excluir-pet").click(function () {
    var id = $(this).data("id");
    var url = "/Pet/Excluir";

    var data = {
        Id: id
    }

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: url,
        data: data,
        success: function (data) {
            exibeToast("Dados excluídos com sucesso!", "success", "fa fa-check-o", function () {
                location.reload(true);
            });
        },
        error: function (data) {
            exibeToast("Erro ao excluir!", "error", "fa fa-close");
        }
    });
});

function salvarPet() {
    var nomePet = $("#input-nome-pet").val();
    var nomeDono = $("#input-nome-dono").val();
    var enderecoDono = $("#input-endereco-dono-pet").val();
    var telefone = $("#input-telefone-dono").val();
    var estadoSaude = $("#input-estado-saude").val();
    var motivoInternacao = $("#input-motivo-internacao").val();

    var data = {
        Nome: nomePet,
        NomeDono: nomeDono,
        EnderecoDono: enderecoDono,
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
        data: data,
        success: function (data) {
            exibeToast("Dados salvos com sucesso!", "success", "fa fa-check-o");
        },
        error: function (data) {
            exibeToast("Erro ao salvar!", "error", "fa fa-close");
        }
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

function exibeToast(mensagem, status, icon) {
    $.notify({
        icon: icon,
        message: mensagem
    }, {
        // settings
        type: status,

    });
}