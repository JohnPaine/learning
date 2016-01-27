/**
 * Created by shtefan on 26.01.2016.
 */
function repeat(str, num) {
    var newStr = '';
    for (var i = 0; i < num ; ++i)
        newStr += str;
    return newStr;
}

alert(repeat("abc", 3));