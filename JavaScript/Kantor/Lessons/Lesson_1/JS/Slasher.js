/**
 * Created by shtefan on 28.01.2016.
 */
function slasher(arr, howMany) {
    if (howMany > arr.length || howMany < 0)
        return [];
    return arr.slice(howMany);
}

slasher([1, 2, 3], 2);