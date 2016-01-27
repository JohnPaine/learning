/**
 * Created by shtefan on 26.01.2016.
 */
function titleCase(str) {
    return str.split(' ').map(function(item) {
        var letters = item.toLowerCase().split('');
        letters[0] = letters[0].toUpperCase();
        return letters.join('');
    }).join(' ');
}

alert(titleCase("I'm a little tea pot"));