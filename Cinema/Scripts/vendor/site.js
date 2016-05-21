$(document).ready(function() {

  $(window).scroll(function () {  
      console.log($(window).scrollTop())
    if ($(window).scrollTop() > 150) {
        $('.navbar').addClass('navbar-fixed-top');
    }
    if ($(window).scrollTop() < 151) {
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
