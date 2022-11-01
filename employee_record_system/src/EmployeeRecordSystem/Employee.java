/*
 * Employee
 * 
 * Version 1.0
 *
 * Created by Daniel Hayes 10/03/2018
 *
 * Creative Commons Fair Use
 */
package EmployeeRecordSystem;

import java.util.Objects;

/**
 * Represents an employee
 * @author Daniel Hayes
 * @version 1.0
 * @since 0.1
 */
public class Employee extends Person {
    private double salary;
    private Date start;
    private String title;

    public Employee() {
        super();
        salary = 0.0;
        start = null;
        title = null;
    }
    /**
     * Creates an employee with the person class and the following parameters
     * @param p The employees personal details
     * @param salary The employees salary
     * @param start The employees start date
     * @param title The employees job title
     */
    public Employee(Person p, double salary, Date start, String title) {
        super(p);
        this.salary = salary;
        this.start = start;
        this.title = title;
    }

    public Employee(String name, String gender, Date dob, String phone,
            String nin, double salary, Date start, String title) {
        super(name, gender, dob, phone, nin);
        this.salary = salary;
        this.start = start;
        this.title = title;
    }
    
    /**
     * Gets the employees salary
     * @return a double of the salary
     */
    public double getSalary() {
        return salary;
    }

    /**
     * Gets the employees start date
     * @return a Date object of the start date
     */
    public Date getStart() {
        return start;
    }

    /**
     * Gets the employees job title
     * @return a string of the job title
     */
    public String getTitle() {
        return title;
    }

    /**
     * Sets the employees salary
     * @param salary a double containing the employees salary
     */
    public void setSalary(double salary) {
        this.salary = salary;
    }

    /**
     * Sets the employees start date
     * @param start A Date object containing the start date
     */
    public void setStart(Date start) {
        this.start = start;
    }

    /**
     * Sets the employee start date
     * @param title A string containing the job title
     */
    public void setTitle(String title) {
        this.title = title;
    }

    /**
     * Method to return hash code 
     * @return hash
     */
    @Override
    public int hashCode() {
        int hash = 3;
        return hash;
    }

    /**
     * Method to compare parameters
     * @param obj of component to compare
     * @return true or false
     */
    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Employee other = (Employee) obj;
        if (Double.doubleToLongBits(this.salary)
                != Double.doubleToLongBits(other.salary)) {
            return false;
        }
        if (!Objects.equals(this.title, other.title)) {
            return false;
        }
        return Objects.equals(this.start, other.start);
    }

    /**
     * Method to return String of parameters
     * @return String of employee components
     */
    @Override
    public String toString() {
        return super.getName() + "," + super.getGender() + "," 
                + super.getDob() + "," + super.getPhone() + "," + super.getNin()
                + "," + salary + "," + start + "," + title;
    }
}