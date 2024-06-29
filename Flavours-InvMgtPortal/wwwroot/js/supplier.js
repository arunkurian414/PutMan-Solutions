
$(function () {
    $("#businessName").trigger("focus");
    setSupplierInfoSaveButtonValue();
});

function setSupplierInfoSaveButtonValue() {
    $('.nav-tabs a').on('shown.bs.tab', function (e) {
        //var clickedOn = e.target.id;

        $('#cardTitle').text(e.target.name);
        if (e.target.id == 'companyInfoNavLink') {
            //alert($(this).attr('id'));
            $('#saveSupplierDetails').html('Save Profile');
        }
        else if (e.target.id == 'companyAddressNavLink') {
            $('#saveSupplierDetails').html('Save Address');
        } else if (e.target.id == 'companyContactNavLink') {
            $('#saveSupplierDetails').html('Save Contact');
        } else if (e.target.id == 'companyProductsNavLink') {
            $('#saveSupplierDetails').html('Save Product');
        }
    });
}