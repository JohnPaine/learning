/**
 * Created by shtefan on 27.01.2016.
 */
//function chunk(arr, size) {
//    if (size >= arr.length || size <= 0)
//        return [arr];
//    result = [];
//    var i = 0;
//    while(arr.length > i * size + size) {
//        result.push([]);
//        //result[i].push(arr.slice(i * size, i * size + size));
//        for (var j = 0; j < size && arr.length > 0; ++j) {
//            result[i].push(arr.shift());
//        }
//        i++;
//    }
//    return result;
//}

"use strict";

// From freecodecamp
function chunk(arr, size) {

    if (size >= arr.length || size <= 0)
        return [arr];
    var result = [];
    var i = 0;
    while(arr.length > 0) {
        result.push([]);
        for (var j = 0; j < size && arr.length > 0; ++j) {
            result[i].push(arr.shift());
        }
        i++;
    }
    return result;
}

var array1 = chunk(["a", "b", "c", "d"], 2);
var array2 = [["a", "b"], ["c", "d"]];
var equals = (array1.length == array2.length) && array1.every(function(element, index) {
        return (element.length == array2[index].length) && element.every(function(element1, index1) {
                return element1 === array2[index][index1];
            });
    });
alert(equals);

//alert(JSON.stringify(chunk(["a", "b", "c", "d"], 2)) == JSON.stringify([["a", "b"], ["c", "d"]]));
//alert(JSON.stringify(chunk(["a", "b", "c", "d"], 2)));