class Company
{

    constructor()
    {
        this.departments = {};
        this.employees = [];
        this.employeesInDepartments={};
    }

    addEmployee(username, salary, position, department)
    {
        if (!username || !salary || !position || !department || salary < 0) 
        {
            throw new Error('Invalid input!');
        }

        if (!this.departments.hasOwnProperty(department))
        {
            this.departments[department] = [];
            this.employeesInDepartments[department] =0;;
        }
        this.departments[department].push(salary);

        this.employees.push({
            name: username,
            salary: salary,
            position: position,
            department: department
        });
        this.employeesInDepartments[department]++;
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment()
    {
        for (const dept in this.departments) 
        {
            this.departments[dept] = this.departments[dept].reduce((a, b) => a + b);
            this.departments[dept] /= this.employeesInDepartments[dept];
        }

        let bestDeptName = Object.keys(this.departments)
            .sort((a, b) => this.departments[b] - this.departments[a])[0];

        let employeesInDetp = this.employees
            .filter(x => x.department == bestDeptName)
            .sort((a, b) => 
            {
                if (a.salary === b.salary) 
                {
                    return a.name.localeCompare(b.name)
                }

                return b.salary - a.salary;
            });

        let deptSalary  = 0;

        for (const employee of employeesInDetp) {
            deptSalary+=employee.salary;
        }

        let result = `Best Department is: ${bestDeptName}\n`    
        result+=`Average salary: ${(deptSalary / employeesInDetp.length).toFixed(2)}\n`     
        for (const employee of employeesInDetp) 
        {
            result+=`${employee.name} ${employee.salary} ${employee.position}\n`  
        }

        return result.slice(0,-1);

    }
}

let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

