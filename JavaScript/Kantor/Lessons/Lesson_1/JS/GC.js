/**
 * Created by shtefan on 13.01.2016.
 */

var value = "Surprise!";

function f() {
    var value = Math.random();

    function g() {
        //value = Math.random();
        debugger;
    }

    return g;
}

var g = f();
g();