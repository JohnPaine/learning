/**
 * Created by shtefan on 30.01.2016.
 */

// One of the simplest and most widely known ciphers is a Caesar cipher,
// also known as a shift cipher. In a shift cipher the meanings of the letters are shifted by some set amount.

//A common modern use is the ROT13 cipher, where the values of the letters are shifted by 13 places.
// Thus 'A' ↔ 'N', 'B' ↔ 'O' and so on.

//Write a function which takes a ROT13 encoded string as input and returns a decoded string.

//All letters will be uppercase. Do not transform any non-alphabetic character
// (i.e. spaces, punctuation), but do pass them on.
function rot13(str) { // LBH QVQ VG!
    return str.split('').map(function(char) {
        if (!char.match(/[A-Z]/g))
            return char;
        return String.fromCharCode(((char.charCodeAt(0) + 13) % 91) + ((char.charCodeAt(0) + 13) > 90 ? 65 : 0));
    }).join('');
}

// Change the inputs below to test
alert(rot13("SERR PBQR PNZC"));