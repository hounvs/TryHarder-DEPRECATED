/*
 * Bind page address to modal. Source:
 * https://stackoverflow.com/questions/34154370/bootstrap-3-x-how-to-have-url-change-upon-clicking-modal-trigger
 */

$(window.location.hash).modal('show');
$('a[data-toggle="modal"]').click(function () {
    window.location.hash = $(this).attr('href');
});

function revertToOriginalURL() {
    var original = window.location.href.substr(0, window.location.href.indexOf('#'))
    history.replaceState({}, document.title, original);
}

$('.modal').on('hidden.bs.modal', function () {
    revertToOriginalURL();
});