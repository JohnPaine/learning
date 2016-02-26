/*
 Code by John Shtefan
 */

function inIframe() {
    try {
        return window.self !== window.top;
    } catch (e) {
        return true;
    }
}

var colors = ['#16a085', '#27ae60', '#2c3e50', '#f39c12', '#e74c3c', '#9b59b6', '#FB6964', '#342224', "#472E32", "#BDBB99", "#77B1A9", "#73A857"];
var currentQuote = 'abc', currentAuthor = 'ICNDb';
function openURL(url) {
    window.open(url, 'Share', 'width=550, height=400, toolbar=0, scrollbars=1 ,location=0 ,statusbar=0,menubar=0, resizable=0');
}
function getQuote(reload) {
    if (typeof reload === "undefined")
        reload = true;
    $.ajax({
        url: 'http://api.icndb.com/jokes/random',
        success: function (response) {
            currentQuote = response['value']['joke'];
            currentQuote = currentQuote.replace(/&quot;/g, '\"');
            if (response['value']['categories'].length > 0)
                currentAuthor = response['value']['categories'][0];
            if (inIframe()) {
                $('#tweet-quote').attr('href', 'https://twitter.com/intent/tweet?hashtags=quotes&related=freecodecamp&text=' +
                    encodeURIComponent('"' + currentQuote + '" ' + currentAuthor));
                $('share-google').attr('href', 'https://plus.google.com/share?url=http://codepen.io/JohnMPaine/full/rxqRxd/');
            }
            $(".quote-text").animate({
                    opacity: 0
                }, 500,
                function () {
                    $(this).animate({
                        opacity: 1
                    }, 500);
                    $('#text').text(currentQuote);
                });

            $(".quote-author").animate({
                    opacity: 0
                }, 500,
                function () {
                    $(this).animate({
                        opacity: 1
                    }, 500);
                    $('#author').html(currentAuthor);
                });

            var color = Math.floor(Math.random() * colors.length);
            $(".button").animate({
                backgroundColor: colors[color]
            }, 1000);
            if (reload)
                window.location.reload();
        }
    });
}

$(document).ready(function () {
    getQuote(false);
    $('#new-quote').on('click', getQuote);
    $('#tweet-quote').on('click', function () {
        if (!inIframe()) {
            openURL('https://twitter.com/intent/tweet?hashtags=quotes&related=freecodecamp&text=' + encodeURIComponent('"' + currentQuote + '" ' + currentAuthor));
        }
    });
    $('#share-google').on('click', function () {
        if (!inIframe()) {
            openURL('https://plus.google.com/share?url=http://codepen.io/JohnMPaine/full/rxqRxd/');
        }
    });
});