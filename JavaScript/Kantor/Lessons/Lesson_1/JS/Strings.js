/**
 * Created by John on 28.12.2015.
 */
// Для красивого вызова indexOf применяется побитовый оператор НЕ '~'.
//alert( ~2 ); // -(2+1) = -3
//alert( ~1 ); // -(1+1) = -2
//alert( ~0 ); // -(0+1) = -1
//alert( ~-1 ); // -(-1+1) = 0

// Как видно, ~n — ноль только в случае, когда n == -1.
// То есть, проверка if ( ~str.indexOf(...) ) означает, что результат indexOf отличен от -1, т.е. совпадение есть.
//var str = "Widget";
//if (~str.indexOf("get")) {
//    alert( 'совпадение есть!' );
//}


// Поиск всех вхождений
function findInStr(str, target) {
    var pos = -1;
    while ((pos = str.indexOf(target, pos + 1)) != -1) {
        alert( pos );
    }
}

findInStr("Ослик Иа-Иа посмотрел на виадук", "Иа")