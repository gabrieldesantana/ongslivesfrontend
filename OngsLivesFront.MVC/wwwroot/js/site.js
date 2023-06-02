// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(document).ready(function () {
//    $('#tabelaVoluntario').DataTable();
//});


window.addEventListener('DOMContentLoaded', function () {
    var loadingOverlay = document.getElementById('loading-overlay');
    loadingOverlay.style.display = 'none';
});


function formatCPF(cpf) {
    cpf = cpf.replace(/\D/g, '');
    cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
    cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
    return cpf;
}

function formatTelefone(phone) 
{
phone = phone.replace(/\D/g, '');
phone = phone.replace(/(\d{2})(\d)/, '($1) $2');
phone = phone.replace(/(\d{4})(\d)/, '$1-$2');
phone = phone.replace(/(\d{4})-(\d)(\d{4})/, '$1$2-$3');
    return phone;
}

function formatCNPJ(cnpj) {
    cnpj = cnpj.replace(/\D/g, '');
    cnpj = cnpj.replace(/(\d{2})(\d)/, '$1.$2');
    cnpj = cnpj.replace(/(\d{3})(\d)/, '$1.$2');
    cnpj = cnpj.replace(/(\d{3})(\d)/, '$1/$2');
    cnpj = cnpj.replace(/(\d{4})(\d)/, '$1-$2');
    cnpj = cnpj.replace(/(\d{2})(\d{1,2})$/, '$1$2');
    return cnpj;
}
