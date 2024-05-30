﻿function confirmDelete(isDeleteClicked) {
    var deleteSpan = 'deleteSpan';
    var confirmDeleteSpan = 'confirmDeleteSpan';

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }

}