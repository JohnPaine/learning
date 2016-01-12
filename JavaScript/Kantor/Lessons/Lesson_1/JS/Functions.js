/**
 * Created by John on 27.12.2015.
 */

"use strict"

//function showMessage(from, text) { // параметры from, text
//
//    from = "** " + from + " **"; // здесь может быть сложный код оформления
//
//    alert(from + ': ' + text);
//}
//
//showMessage('Маша', 'Привет!');
//showMessage('Маша', 'Как дела?');


//function showMessage(from, text) {
//    from = '**' + from + '**'; // меняем локальную переменную from
//    alert( from + ': ' + text );
//}
//
//var from = "Маша";
//
//showMessage(from, "Привет");
//
//alert( from ); // старое значение from без изменений, в функции была изменена копия


// Функцию можно вызвать с любым количеством аргументов.
// Если параметр не передан при вызове — он считается равным undefined.

//function showMessage(from, text) {
//    // Для задания параметров по умолчанию можно или проверить на undefined:
//    //if (text === undefined) {
//    //    text = 'текст не передан';
//    //}
//    // Или можно использовать оператор ||:
//    text = text || 'текст не передан';
//
//    alert( from + ": " + text );
//}
//
//showMessage("Маша", "Привет!"); // Маша: Привет!
//showMessage("Маша"); // Маша: текст не передан

//function sayHi() {
//    alert( "Привет" );
//}
//
//alert( sayHi ); // выведет код функции



// Function Declaration
//function sum1(a, b) {
//    return a + b;
//}
//// Function Expression
//var sum2 = function (a, b) {
//    return a + b;
//};
//sum1 = function (a, b, c) {
//    "use strict";
//    return a + b - c;
//};
//alert(sum1(3, 2, 1));

// Основное отличие между ними: функции, объявленные как Function Declaration,
// создаются интерпретатором до выполнения кода.
// Поэтому их можно вызвать до объявления, например:
//sayHi("Вася"); // Привет, Вася
//
//function sayHi(name) {
//    alert( "Привет, " + name );
//}



// Function Declaration при use strict видны только внутри блока, в котором объявлены.
// Так как код в учебнике выполняется в режиме use strict, то будет ошибка.
//var age = +prompt("Сколько вам лет?", 20);
//
//if (age >= 18) {
//    function sayHi() {
//        alert( 'Прошу вас!' );
//    }
//} else {
//    function sayHi() {
//        alert( 'До 18 нельзя' );
//    }
//}
//
//sayHi();

// А так норм:
//var age = prompt('Сколько вам лет?');
//
//var sayHi = (age >= 18) ?
//    function() { alert('Прошу Вас!');  } :
//    function() { alert('До 18 нельзя'); };
//
//sayHi();



// Анонимусы - Функциональное выражение, которое не записывается в переменную, называют анонимной функцией.
/*
function ask(question, yes, no) {
    if (confirm(question)) yes()
    else no();
}

ask(
    "Вы согласны?",
    function() { alert("Вы согласились."); },
    function() { alert("Вы отменили выполнение."); }
);*/


// создание функции полностью «на лету» из строки
//var sum = new Function('a,b', ' return a+b; ');
//
//var result = sum(1, 2);
//alert( result ); // 3



// Named Function Expressions

//var f = function sayHi(name) {
//    alert( sayHi ); // изнутри функции - видно (выведет код функции)
//};
//
//alert( sayHi ); // снаружи - не видно (ошибка: undefined variable 'sayHi')

//var test = function sayHi(name) {
//    sayHi = "тест"; // попытка перезаписи
//    alert( sayHi ); // function... (перезапись не удалась)
//};
//
//test();

var f = function factorial(n) {
    return n ? n*factorial(n-1) : 1;
};

var g = f;  // скопировали ссылку на функцию-факториал в g
f = null;

alert( g(5) ); // 120, работает!

