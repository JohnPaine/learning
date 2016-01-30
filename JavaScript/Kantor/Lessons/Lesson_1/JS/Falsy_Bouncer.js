/**
 * Created by shtefan on 30.01.2016.
 */

// Remove all falsy values from an array.

// Falsy values in javascript are false, null, 0, "", undefined, and NaN.
function bouncer(arr) {
    return arr.filter(function(element) {
        return element;
    });
}

bouncer([7, "ate", "", false, 9]);