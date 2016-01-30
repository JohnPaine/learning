/**
 * Created by shtefan on 30.01.2016.
 */
function mutation(arr) {
    return arr[1].split('').every(function(char) {
        return arr[0].toLocaleLowerCase().indexOf(char.toLowerCase()) != -1;
    });
}

//mutation(["hello", "hey"]);