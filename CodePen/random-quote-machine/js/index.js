/*
 Code by Gabriel Nunes
 */

function inIframe() {
    try {
        return window.self !== window.top;
    } catch (e) {
        return true;
    }
}

var colors = ['#16a085', '#27ae60', '#2c3e50', '#f39c12', '#e74c3c', '#9b59b6', '#FB6964', '#342224', "#472E32", "#BDBB99", "#77B1A9", "#73A857"];
var currentQuote = 'abc', currentAuthor = 'Chuck Norris';
function openURL(url) {
    window.open(url, 'Share', 'width=550, height=400, toolbar=0, scrollbars=1 ,location=0 ,statusbar=0,menubar=0, resizable=0');
}
function getQuote() {
    getImage();
    $.ajax({
        url: 'http://api.icndb.com/jokes/random',
        success: function (response) {
            currentQuote = response['value']['joke'];
            if (response['value']['categories'].length > 0)
                currentAuthor = response['value']['categories'][0];
            if (inIframe()) {
                $('#tweet-quote').attr('href', 'https://twitter.com/intent/tweet?hashtags=quotes&related=freecodecamp&text=' +
                    encodeURIComponent('"' + currentQuote + '" ' + currentAuthor));
                $('#tumblr-quote').attr('href', 'https://www.tumblr.com/widgets/share/tool?posttype=quote&tags=quotes,freecodecamp&caption=' +
                    encodeURIComponent(currentAuthor) + '&content=' + encodeURIComponent(currentQuote));
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
            $("html body").animate({
                backgroundColor: colors[color],
                color: colors[color]
            }, 1000);
            $(".button").animate({
                backgroundColor: colors[color]
            }, 1000);
        }
    });
}

function getImage() {
    var startAt = Math.floor(Math.random() * 100) % 10;
    $.ajax({
        url: 'https://www.googleapis.com/customsearch/v1?q=chuck+norris&cx=011807910143321447018:kzzgrfnwg_m&imgSize=large&imgType=photo&searchType=image&start=' + startAt + '&key=AIzaSyBwQ1PtGJNUPFI-v16HJ6pvPsbvxtbJAIc',
        success: function (response) {
            console.log(response);

            $('#theImg').remove();
            $('.quote-image').prepend('<img id="theImg" src="' + response["items"][0]["link"] + '" />')
        }
    });
}
$(document).ready(function () {
    getQuote();
    $('#new-quote').on('click', getQuote);
    $('#tweet-quote').on('click', function () {
        if (!inIframe()) {
            openURL('https://twitter.com/intent/tweet?hashtags=quotes&related=freecodecamp&text=' + encodeURIComponent('"' + currentQuote + '" ' + currentAuthor));
        }
    });
    $('#tumblr-quote').on('click', function () {
        if (!inIframe()) {
            openURL('https://www.tumblr.com/widgets/share/tool?posttype=quote&tags=quotes,freecodecamp&caption=' + encodeURIComponent(currentAuthor) + '&content=' + encodeURIComponent(currentQuote));
        }
    });
});