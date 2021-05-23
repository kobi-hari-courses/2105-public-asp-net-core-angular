var colors = require('colors');

function Calculator(a, b) {
    this.a = a;
    this.b = b;
}

Calculator.prototype.add = function() {
    return this.a + this.b;
}

Calculator.prototype.subtract = function() {
    return this.a - this.b;
}

Calculator.prototype.multiply = function() {
    return this.a * this.b;
}

Calculator.prototype.log = function() {
    var s1 = this.a + ' + ' + this.b + ' = ' + this.add();
    s1 = s1.green;

    var s2 = this.a + ' - ' + this.b + ' = ' + this.subtract();
    s2 = s2.white;

    var s3 = this.a + ' * ' + this.b + ' = ' + this.multiply();
    s3 = s3.rainbow;

    console.log(s1);
    console.log(s2);
    console.log(s3);
}


var c1 = new Calculator(5, 10);
var c2 = new Calculator(4, 3);

c1.log();

setTimeout(function() {
    c2.log();
}, 2000);

