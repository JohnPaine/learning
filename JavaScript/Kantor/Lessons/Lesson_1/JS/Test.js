/**
 * Created by shtefan on 28.12.2015.
 */

describe("pow", function () {

    describe("Возводит x в степень n", function () {
        //before(function() { alert("Начало тестов"); });
        //after(function() { alert("Конец тестов"); });
        //
        //beforeEach(function() { alert("Вход в тест"); });
        //afterEach(function() { alert("Выход из теста"); });

        function makeTest(x, y) {
            var expected = Math.pow(x, y);
            it("При возведении " + x + " в степень " + y + " ожидаемый результат: " + expected, function () {
                assert.equal(pow(x, y), expected);
            });
        }

        for (var x = 0; x <= 11; ++x) {
            for (var y = 0; y <= 11; ++y) {
                makeTest(x, y);
            }
        }
        it("при возведении в отрицательную степень результат NaN", function() {
            assert(isNaN(pow(2, -1)), "pow(2, -1) не NaN");
        });

        it("при возведении в дробную степень результат NaN", function() {
            assert(isNaN(pow(2, 1.5)), "pow(2, 1.5) не NaN");
        });
        it("ноль в нулевой степени даёт NaN", function() {
            assert(isNaN(pow(0, 0)), "0 в степени 0 не NaN");
        });
    });

});