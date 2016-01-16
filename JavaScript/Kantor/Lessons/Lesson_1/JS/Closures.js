/**
 * Created by shtefan on 12.01.2016.
 */
// making counter

function makeCounter() {
    var currentCount = 1;

    // second realization
    function counter() {
        return currentCount++;
    }

    counter.set = function (value) {
        currentCount = value;
    };

    counter.reset = function() {
        currentCount = 1;
    };

    return counter;

    // first realization
    //return {
    //    getNext: function() {
    //        return currentCount++;
    //    },
    //
    //    set: function(value) {
    //        currentCount = value;
    //    },
    //
    //    reset: function() {
    //        currentCount = 1;
    //    }
    //};
}

//var counter = makeCounter();

// first realization test
//alert(counter.getNext());
//alert(counter.getNext());
//
//counter.set(5);
//alert(counter.getNext());
//
//counter.reset();
//alert(counter.getNext());
//alert(counter.getNext());


// second realization test
//alert(counter());
//alert(counter());
//
//counter.set(5);
//alert(counter());
//alert(counter());



function sum(a) {
    return function (b) {
        return a + b;
    }
}

//alert(sum(1)(2));
//alert(sum(5)(-1));


function makeBuffer() {
    var text = '';

    function buffer (newText) {
        if (arguments.length == 0)
            return text;
        text += newText;
    }

    buffer.clear = function () {
        text = '';
    };

    return buffer;
}

//var buff = makeBuffer();
//buff('Closures');
//buff(' are to');
//buff(' use!');
//
//alert(buff());
//
//buff.clear();
//
//buff(0);
//buff(1);
//buff(0);
//buff(+2);
//buff(+3);
//alert(buff());


var users = [{
    name: "Vasya",
    surname: "Petrov",
    age: 20
}, {
    name: "Petya",
    surname: "Ivanov",
    age: 21
}, {
    name: "Masha",
    surname: "Medved",
    age: 17
}];

function byField(field) {
    return function (a, b) {
        return a[field] > b[field] ? 1 : -1;
    }
}

users.sort(byField('name'));
//users.forEach(function(user) {
//   alert(user.name);
//});

users.sort(byField('age'));
//users.forEach(function(user) {
//    alert(user.name);
//});


function filter(array, func) {
    var result = [];

    for (var i = 0; i < array.length; ++i) {
        if (func(array[i]))
            result.push(array[i]);
    }
    return result;
}

function inBetween(a, b) {
    return function (x) {
        return x >= a && x <= b;
    }
}

function inArray(array) {
    return function (x) {
        return array.indexOf(x) != -1;
    }
}

var array = [1,2,3,4,5,6,7,8];

//alert(filter(array, inBetween(3,6)));
//
//alert(filter(array, inArray([1,4,5,7,9,11])));


function makeArmy() {
    var shooters = [];

    /*
    for (var i = 0; i < 10; ++i) {
        // здесь проблема в том, что i - mutable
        // и если мы заполняем массив функциями, которые используют локальную переменную i
        // из внешней области видимости, то при вызове этих функций после заполнения
        // i уже будет иметь другое значение. То есть, так сделать не получится:

        //var shooter = function() { // функция-стрелок
        //    alert( i ); // выводит свой номер
        //};


        // так работать тоже не будет:

        //var shooter = function() {
        //    alert( shooter.i ); // вывести свой номер (не работает!)
        //    // потому что откуда функция возьмёт переменную shooter?
        //    // ..правильно, из внешнего объекта, а там она одна на всех
        //};
        //shooter.i = i;


        // Решение проблемы может быть таким: привязываем переменную непосредственно к функции-стрелку,
        // но обращаемся мы к ней через локальное имя функции, используя Named Function Expression, -
        // тогда имя жёстко привязывается к конкретной функции:

        //var shooter = function me() {
        //    alert(me.i);
        //};
        //shooter.i = i;


        // более продвинутое решение: здесь внутренняя функция function(x) сразу выполняется

        //var shooter = function(x) {
        //    return function () {
        //        alert(x);
        //    }
        //}(i);

        // для "лучшей" читаемости можно заменить x на i и добавить скобки,
        // чтобы читающий код человек понял, что это не var shooter = function, а вызов "на месте"

        var shooter = (function (i) {
           return function () {
               alert (i);
           }
        })(i);

        shooters.push(shooter);
    }
    */

    // более "простой" способ добавления в массив функции с конкретной переменной -
    // выполнить ее на месте, обернув весь цикл во временную функцию

    for (var i = 0; i < 10; ++i) (function (i) {
        // тогда можно сделать так, как было изначально:

        var shooter = function() { // функция-стрелок
            alert( i ); // выводит свой номер
        };
        shooters.push(shooter);
    })(i);

    return shooters;

}

var army = makeArmy();

army[0]();
army[5]();

