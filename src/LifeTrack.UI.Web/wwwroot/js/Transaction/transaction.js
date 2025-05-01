// Evento de submissão do formulário via AJAX
$('#transactionForm').submit(function (e) {
    e.preventDefault(); // Evita o comportamento padrão de envio do formulário

    let data = {
        description: $('#Description').val(),
        amount: parseFloat($('#Amount').val().replace(",", ".")),
        transactionDate: $('#TransactionDate').val(),
        categoryId: $('#categoryDropdown').val(),
        statusId: 1 // Ajuste conforme necessário
    };

    console.log(data);

    $.ajax({
        url: '/Transaction/Insert',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (response) {
            Swal.fire({
                title: "Sucesso",
                text: response.message,
                icon: "success"
            }).then(() => {
                location.reload(); // recarrega a página após o usuário fechar o alert
            });
        },
        error: function (xhr, status, error) {
            Swal.fire("Erro", "Falha ao cadastrar transação: " + error, "error");
        }
    });
});