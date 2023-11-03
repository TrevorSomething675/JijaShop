$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        margin: 20,
        responsive: {
            0: {
                items: 1
            },

            600: {
                items: 3
            },

            1000: {
                items: 5
            }
        }
    });
});

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