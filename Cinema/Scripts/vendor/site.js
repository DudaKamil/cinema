$(document).ready(function() {

  $(window).scroll(function () {  
    if ($(window).scrollTop() > 130) {
        $('.navbar').addClass('navbar-fixed-top');
    }
    if ($(window).scrollTop() < 131) {
        $('.navbar').removeClass('navbar-fixed-top');

    }
  });
});

function parallax() {
    var scrolled = $(window).scrollTop();
    $('.bg').css('height', (150 - scrolled) + 'px');
}

$(window).scroll(function (e) {
    parallax();
});
