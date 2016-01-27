/**
 * Created by shtefan on 26.01.2016.
 */
function findLongestWord(str) {
    var words = str.split(' ');
    var longest = {index: 0, len: words[0].length};
    for (var i = 1; i < words.length; ++i) {
        if (words[i].length > longest.len) {
            longest.index = i;
            longest.len = words[i].length;
        }
    }
    return longest.len;
}

findLongestWord("The quick brown fox jumped over the lazy dog");