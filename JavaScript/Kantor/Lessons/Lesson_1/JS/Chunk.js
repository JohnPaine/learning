/**
 * Created by shtefan on 27.01.2016.
 */
function chunk(arr, size) {
    if (size >= arr.length || size <= 0)
        return [arr];
    result = [];
    var i = 0;
    while(arr.length > i * size + size) {
        result.push([]);
        //result[i].push(arr.slice(i * size, i * size + size));
        for (var j = 0; j < size && arr.length > 0; ++j) {
            result[i].push(arr.shift());
        }
        i++;
    }
    return result;
}

//alert(chunk(["a", "b", "c", "d"], 2));