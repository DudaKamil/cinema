function parallax() {
    var scrolled = $(window).scrollTop();
    $('.bg').css('height', (350 - scrolled) + 'px');
}

$(window).scroll(function (e) {
    parallax();
});


//Nadawanie wszystkim thumbnail jednakowej wielkości
function equalHeight(group) {
    tallest = 0;
    group.each(function () {
        thisHeight = $(this).height();
        if (thisHeight > tallest) {
            tallest = thisHeight;
        }
    });
    group.each(function () { $(this).height(tallest); });
}

$(window).load(function () {
    equalHeight($(".thumbnail"));
});