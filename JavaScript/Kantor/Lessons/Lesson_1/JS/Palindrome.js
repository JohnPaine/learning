/**
 * Created by shtefan on 26.01.2016.
 */
function palindrome(str) {
    // Good luck!
    var cleanStr = str.toLowerCase();
    cleanStr = cleanStr.replace(/\s/g, '');
    cleanStr = cleanStr.replace(/\W/g, '');
    cleanStr = cleanStr.replace(/_/g, '');
//            cleanStr = cleanStr.replace(/,/g, '');
//            cleanStr = cleanStr.replace(/\./g, '');
//            cleanStr = cleanStr.replace(/-/g, '');
//            cleanStr = cleanStr.replace(/\//g, '');
//            cleanStr = cleanStr.replace(/\\/g, '');
    alert(cleanStr);
    for (var i = 0; i < Math.floor(cleanStr.length / 2); ++i)
        if (cleanStr[i] != cleanStr[cleanStr.length - i - 1])
            return false;
    return true;
}



//        alert(palindrome("eye"));
//        alert(palindrome("race car"));
//        alert(palindrome("A man, a plan, a canal. Panama"));
alert(palindrome("0_0 (: /-\ :) 0-0"));