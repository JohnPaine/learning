/**
 * Created by shtefan on 26.01.2016.
 */
function truncate(str, num) {
    if (str.length <= num)
        return str;
    if (num <= 3)
        var truncated = str.slice(0, num);
    else
        var truncated = str.slice(0, num - 3);
    return truncated + '...';
}

alert(truncate("A-", 1));
alert(truncate("Absolutely Longer", 2));
