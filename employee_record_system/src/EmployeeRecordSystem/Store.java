/*
 * Store
 * 
 * Version 1.0
 *
 * Created by Daniel Hayes 10/03/2018
 *
 * Creative Commons Fair Use
 */
package EmployeeRecordSystem;

/** 
 * Stores an array of employees
 * @author Daniel Hayes
 * @version 1.0
 * @since 0.1
 */
public class Store {
    private Employee[] employees;
    private int size;
    private int index;
    
    /**
     * Creates a store and sets the size
     * @param size an integer with the number of objects in the array
     */
    public Store(int size) {
        index = 0;
        this.size = size;
        employees = new Employee[this.size];
    }
    
    /**
     * A method to add an employee to the Store
     * @param s an Employee object
     */
    public void addEmployee(Employee s) {
        if(index<=size-1) {
            employees[index++] = s;
            System.out.println("Record Added!");
        } else {
            System.out.println("The group is full!");
        }
    }
    
    /**
     * A method to print all objects in the store to the console
     */
    public void showAllRecords() {
        for(int i=0; i<index; i++) {
            System.out.println(employees[i].toString());
        }
    }
    
    /**
     * A method to show all records as a string
     * @return A String array of employee details
     */
    public String[] showAllRecordsAsString() {
        String record[] = new String[index];
        for(int i=0; i<index; i++) {
            record[i] = employees[i].toString();
        }
        return record;
    }
    
    /**
     * A method to return a specific employee
     * @return an Employee of object of the specified employee
     */
    public Employee[] employeeRecord() {
        return employees;
    }
    
    /**
     * Gets the number of records added to the array
     * @return an integer of the index
     */
    public int getIndex() {
        return index;
    }
    
    /**
     * A method to remove an employee from the list
     * @param name a String of the employee name
     */
    public void removeEmployee(String name) {
        boolean recordFound = false;
        for(int i=0; i<index; i++) {
            if(employees[i].getName().equalsIgnoreCase(name)) {
                Employee temp = employees[i];
                employees[i] = employees[i+1];
                employees[i+1] = temp;
                recordFound = true;
            }
        }
        if (recordFound == false) {
            System.out.println("Record Not Found!");
        }else {
            System.out.println("Record Deleted!");
            employees[index-1] = null;
            index--;
        }
    }
    
    /**
     * A method to return the details of an employee from the array as a String
     * @param name a String containing the name of the employee required
     * @return a String of the details of the employee
     */
    public String searchEmployee(String name) {
        String s = "";
        for(int i=0; i<index;i++) {
            if(employees[i].getName().equalsIgnoreCase(name)) {
                s=employees[i].toString();
            }
        }
        return s;
    }
    
    /**
     * A method to return an employee of a specific index
     * @param index an integer of the specified index
     * @return an Employee object from the array
     */
    public Employee getEmployee(int index) {
        return employees[index];
    }
    
    /**
     * A method to show the position of a specified employee in the array
     * @param name a String containing the employee name
     * @return an integer of the position in the array
     */
    public int currentRecordPosition(String name) {
        int s = 0;
        for(int i=0; i<index;i++) {
            if(employees[i].getName().equalsIgnoreCase(name)) {
                s = i;
            }
        }
        return s;
    }
}