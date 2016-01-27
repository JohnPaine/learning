/**
 * Created by shtefan on 26.01.2016.
 */
function largestOfFour(arrArr) {
    return arrArr.map(function(arr) {
        var largest = arr[0];
        arr.forEach(function(current) {
            if (current > largest)
                largest = current;
        });
        return largest;
    });
}

alert(largestOfFour([[4, 5, 1, 3], [13, 27, 18, 26], [32, 35, 37, 39], [1000, 1001, 857, 1]]));