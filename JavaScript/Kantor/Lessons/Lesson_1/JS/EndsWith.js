/**
 * Created by shtefan on 26.01.2016.
 */
function end(str, target) {
    var subStr = str.substr(str.length - target.length);
    return subStr == target;
}

alert(end("Bastian", "n"));