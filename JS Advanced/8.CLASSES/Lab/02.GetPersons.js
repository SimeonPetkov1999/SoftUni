function getPersons()
{
    class Person
    {
        constructor(firstName, lastName, age, email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
            this.toString;
        }
        toString()
        {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
        }
    }

    let arr = [];
    arr.push(new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'));
    arr.push(new Person('SoftUni'));
    arr.push(new Person('Stephan', 'Johnson', 25,));
    arr.push(new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com'));
    return arr;
}

console.log(getPersons()[0].toString());