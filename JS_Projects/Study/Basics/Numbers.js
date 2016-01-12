/**
 * Created by shtefan on 28.12.2015.
 */
//alert( 12.34.toFixed(1) ); // 12.3
//alert(12.toFixed(1)); // ошибка!
//alert( 12..toFixed(1) ); // 12.0
//alert( 3e-5 ); // 0.00003  <-- 5 нулей, включая начальный ноль
//alert( 1 / 0 ); // Infinity
//alert( 12345 / 0 ); // Infinity
//alert( Infinity > 1234567890 ); // true
//alert( Infinity + 5 == Infinity ); // true
//alert( 1e500 ); // Infinity
//alert( 0 / 0 ); // NaN


//var n = 0 / 0;
//alert( isNaN(n) ); // true
//alert( isNaN("12") ); // false, строка преобразовалась к обычному числу 12
// Забавный способ проверки на NaN
//if (n !== n)
//    alert( 'n = NaN!' );

//alert( isFinite(1) ); // true
//alert( isFinite(Infinity) ); // false
//alert( isFinite(NaN) ); // false

//alert( +"  -12" ); // -12
//alert( +" \n34  \n" ); // 34, перевод строки \n является пробельным символом
//alert( +"" ); // 0, пустая строка становится нулем
//alert( +"1 2" ); // NaN, пробел посередине числа - ошибка
//alert( '12.34' / "-2" ); // -6.17

alert( parseInt('12px') ); // 12

// При возникновении ошибки возвращается число, которое получилось.
// Функция parseInt читает из строки целое число, а parseFloat — дробное.
alert( parseInt('12px') ); // 12, ошибка на символе 'p'
alert( parseFloat('12.3.4') ) ;// 12.3, ошибка на второй точке
alert( parseInt('a123') ); // NaN
alert( parseInt('FF', 16) ); // 255