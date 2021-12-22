// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".input").on('input', function () {
    var basicSAlary = document.getElementById('basicSalary').value;
    basicSAlary = parseFloat(basicSAlary);

    var travelAllowance = document.getElementById('travelAllowance').value;
    travelAllowance = parseFloat(travelAllowance);

    var medicalAid = document.getElementById('medicalAid').value;
    medicalAid = parseFloat(medicalAid);

    document.getElementById('grossSalary').value = basicSalary + travellAllowance + medicalAid;
});
