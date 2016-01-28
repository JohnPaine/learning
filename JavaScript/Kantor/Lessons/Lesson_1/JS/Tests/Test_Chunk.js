/**
 * Created by shtefan on 27.01.2016.
 */

describe("chunk", function () {

    describe("splits an array (first argument) into groups " +
        "the length of size (second argument) " +
        "and returns them as a multidimensional array", function () {
        //before(function() { alert("Начало тестов"); });
        //after(function() { alert("Конец тестов"); });
        //
        //beforeEach(function() { alert("Вход в тест"); });
        //afterEach(function() { alert("Выход из теста"); });

        //function makeTest(x, y) {
        //    var expected = Math.pow(x, y);
        //    it("При возведении " + x + " в степень " + y + " ожидаемый результат: " + expected, function () {
        //        assert.equal(pow(x, y), expected);
        //    });
        //}
        //
        //for (var x = 0; x <= 11; ++x) {
        //    for (var y = 0; y <= 11; ++y) {
        //        makeTest(x, y);
        //    }
        //}
        it('chunk(["a", "b", "c", "d"], 2) should return [["a", "b"], ["c", "d"]]', function() {
            alert(chunk(["a", "b", "c", "d"], 2));
            assert(chunk(["a", "b", "c", "d"], 2) == [["a", "b"], ["c", "d"]], 'chunk(["a", "b", "c", "d"], 2) != [["a", "b"], ["c", "d"]]');
        });
        it('chunk([0, 1, 2, 3, 4, 5], 3) should return [[0, 1, 2], [3, 4, 5]]', function() {
            alert(chunk([0, 1, 2, 3, 4, 5], 3));
            assert(chunk([0, 1, 2, 3, 4, 5], 3) == [[0, 1, 2], [3, 4, 5]], 'chunk([0, 1, 2, 3, 4, 5], 3) != [[0, 1, 2], [3, 4, 5]]');
        });
        it('chunk([0, 1, 2, 3, 4, 5], 2) should return [[0, 1], [2, 3], [4, 5]]', function() {
            assert(chunk([0, 1, 2, 3, 4, 5], 2) == [[0, 1], [2, 3], [4, 5]], 'chunk([0, 1, 2, 3, 4, 5], 2) != [[0, 1], [2, 3], [4, 5]]');
        });
        it('chunk([0, 1, 2, 3, 4, 5], 4) should return [[0, 1, 2, 3], [4, 5]]', function() {
            assert(chunk([0, 1, 2, 3, 4, 5], 4) == [[0, 1, 2, 3], [4, 5]], 'chunk([0, 1, 2, 3, 4, 5], 4) != [[0, 1, 2, 3], [4, 5]]');
        });
        it('chunk([0, 1, 2, 3, 4, 5, 6], 3) should return [[0, 1, 2], [3, 4, 5], [6]]', function() {
            assert(chunk([0, 1, 2, 3, 4, 5, 6], 3) == [[0, 1, 2], [3, 4, 5], [6]], 'chunk([0, 1, 2, 3, 4, 5, 6], 3) != [[0, 1, 2], [3, 4, 5], [6]]');
        });
        it('chunk([0, 1, 2, 3, 4, 5, 6, 7, 8], 4) should return [[0, 1, 2, 3], [4, 5, 6, 7], [8]]', function() {
            assert(chunk([0, 1, 2, 3, 4, 5, 6, 7, 8], 4) == [[0, 1, 2, 3], [4, 5, 6, 7], [8]], 'chunk([0, 1, 2, 3, 4, 5, 6, 7, 8], 4) != [[0, 1, 2, 3], [4, 5, 6, 7], [8]]');
        });
    });

});