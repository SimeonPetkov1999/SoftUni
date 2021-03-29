class Person
{
    constructor(firstName,lastName,age,email)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;        
        this.toString;
    }
    toString(){
        return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`      
    }
}

let person = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
console.log(person.toString());
