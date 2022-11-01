/*
 * Person
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
 * Compiles the person details
 * @author Daniel Hayes
 * @version 1.0
 * @since 0.1
 */
public class Person {
    private String name;
    private String gender;
    private Date dob;
    private String phone;
    private String nin;

    
    public Person() {
        name = null;
        gender = null;
        dob = null;
        phone = null;
        nin = null;
    }

    /**
     * Creates a person with the following parameters
     * @param name of the person
     * @param gender of the person
     * @param dob date of birth of the person
     * @param phone number of the person
     * @param nin National Insurance number of the person
     */
    public Person
        (String name, String gender, Date dob, String phone, String nin) {
        this.name = name;
        this.gender = gender;
        this.dob = dob;
        this.phone = phone;
        this.nin = nin;
    }
    
    public Person(Person p) {
        name = p.name;
        gender = p.gender;
        dob = p.dob;
        phone = p.phone;
        nin = p.nin;
    }

    /**
     * Gets the name of the person
     * @return a String of the name
     */
    public String getName() {
        return name;
    }
    
    /**
     * Gets the gender of the person
     * @return a String of the gender
     */
    public String getGender() {
        return gender;
    }

    /**
     * Gets the date of birth of the person
     * @return a Date object of the date of birth
     */
    public Date getDob() {
        return dob;
    }

    /**
     * Gets the phone number of the person
     * @return a String of the phone number
     */
    public String getPhone() {
        return phone;
    }

    /**
     * Gets the national insurance number of the person
     * @return a String of the national insurance number
     */
    public String getNin() {
        return nin;
    }

    /**
     * Sets the name of the person
     * @param name a String containing the name
     */
    public void setName(String name) {
        this.name = name;
    }
    
    /**
     * Sets the gender of the person
     * @param gender a String containing the gender
     */
    public void setGender(String gender) {
        this.gender = gender;
    }

    /**
     * Sets the date of birth of the person
     * @param dob a Date object of the date of birth
     */
    public void setDob(Date dob) {
        this.dob = dob;
    }

    /**
     * Sets the phone number of the person
     * @param phone a String containing the phone number
     */
    public void setPhone(String phone) {
        this.phone = phone;
    }

    /**
     * Sets the national insurance number of the person
     * @param nin a String containing the national insurance number
     */
    public void setNin(String nin) {
        this.nin = nin;
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
        final Person other = (Person) obj;
        if (!Objects.equals(this.name, other.name)) {
            return false;
        }
        if (!Objects.equals(this.phone, other.phone)) {
            return false;
        }
        if (!Objects.equals(this.nin, other.nin)) {
            return false;
        }
        if (!Objects.equals(this.gender, other.gender)) {
            return false;
        }
        return Objects.equals(this.dob, other.dob);
    }

    /**
     * Method to return String of parameters
     * @return String of person components
     */
    @Override
    public String toString() {
        return name + " " + gender + " "
                + dob + " " + phone + " " + nin;
    }
    
}
