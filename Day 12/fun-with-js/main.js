// var o1 = {};

// var a1 = [2, 4, 6];


function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
}

window.firstName = 'Chrome';
window.lastName = 'Google';

var p1 = new Person('John', 'Lennon');
var p2 = new Person('Paul', 'McCartney');
var p3 = new Person('Ringo', 'Starr');

Person.prototype.log = function () {
    console.log(' I am a person, and my name is ' + this.firstName + ' ' + this.lastName);
}

p1.log();
p2.log();

var logFunc = p3.log;
logFunc.call(p3);


// function Kobi(yyy) {
//     this.someRandomProperty = yyy;
// }

// function max(a, b) {
//     if (a > b) return a;
//     return b;
// }

// var k1 = new Kobi(10);
// var k2 = new Kobi(20);
// var k3 = new Object();

// var m = new max(10, 20);

// Kobi(42);

// k1.x = 20;
// k2.x = 40;

// Kobi.prototype.z = 50;

// console.log(k1.z); // 50
// console.log(k2.z); // 50

// console.log(k1.x);  // 20
// console.log(k2.x);  // 40

// Kobi.prototype.sayHello = function() {
//     alert('Hello');
// }