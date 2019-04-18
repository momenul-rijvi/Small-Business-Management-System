$(document).ready(function () {

    $(".dropdown>a").click(function () {
        if (!$(this).next('.dropdown-content').is(':visible')) {
            $('.dropdown .dropdown-content').slideUp();
            $(this).next('.dropdown-content').slideDown();
        } else {
            $(this).next('.dropdown-content').slideUp();
        }
    });

    $("#ToggleSideNav").on('click', function () {
        $("div.left-sidebar").toggleClass('activeMiniSideNav');
        $("div.left-sidebar").toggleClass('lelt-scroll');
        $(".main-container>.content-box").toggleClass('activeContert-box');
    });


});

