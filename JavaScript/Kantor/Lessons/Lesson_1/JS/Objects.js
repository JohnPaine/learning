/**
 * Created by John on 03.01.2016.
 */
var Pencil = {};
Pencil.color = "Red";
Pencil.strength = 4;

Matches = {};
Matches.count = 7;

var Person = {};
Person.age = 15;
Person.name = "Jake";
Person.privateObjects = [Pencil, Matches, ["Gum", "Coin"]];

// guarantees reliable knowledge of property existence
if ("age" in Person)
    alert(Person.age);
// if property exists and == undefined, we'll not know it
if (Person.name != undefined)
    alert(Person["name"]);
if ("privateObjects" in Person)
    alert(Person.privateObjects);

// access to property via string is useful when prop name may contain spaces:
Person["Some long property name with spaces"] = "Some prop value";
if ("Some long property name with spaces" in Person)
    alert(Person["Some long property name with spaces"]);

// literal initialization
var user = {
    name: "Таня",
    age: 25,
    size: {
        top: 90,
        middle: 60,
        bottom: 90
    }
};
alert(user.name); // "Таня"
alert(user.size.top); // 90