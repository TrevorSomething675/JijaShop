//$(document).ready(function () {
//    var counter = 0;
//$("#incrementButton").click(function () {
//    counter += 1;
//$.ajax({
//    url: 'Products',
//type: 'GET',
//data: { value: counter },
//success: function (result) {
//    $("#counterValue").text(counter);
//            },
//error: function (result) {
//    alert('error');
//            }
//        });
//    });
//});

$(document).ready(function () {
    var headerSearch = $('#searchInHeader');
    var sidebarSearch = $('#searchInSidebar');
    var headerOffset = headerSearch.offset().top;

    $(window).scroll(function () {
        var scrollPos = $(window).scrollTop();

        if (scrollPos >= headerOffset) {
            headerSearch.removeClass('sticky-top');
            headerSearch.addClass('fixed');
            sidebarSearch.removeClass('d-none');
        } else {
            headerSearch.addClass('sticky-top');
            headerSearch.removeClass('fixed');
            sidebarSearch.addClass('d-none');
        }
    });
});