/*
 * Date
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
 * Compiles the date in the desired format
 * @author Daniel Hayes
 * @version 1.0
 * @since 0.1
 */
public class Date {
    private int day;
    private String month;
    private int year;

    public Date() {
        day = 0;
        month = null;
        year = 0;
    }
    
    /** 
     * Creates the date components in the specified order
     * @param day of the month
     * @param month of the year
     * @param year since the birth of Christ
     */
    public Date(int day, String month, int year) {
        this.day = day;
        this.month = month;
        this.year = year;
    }
    
    public Date(Date d) {
        day = d.day;
        month = d.month;
        year = d.year;
    }
    
    /** 
     * Gets the day of the date
     * @return An int of the day
     */
    public int getDay() {
        return day;
    }
    
    /** 
     * Gets the month of the Date
     * @return A String of the month
     */
    public String getMonth() {
        return month;
    }

    /**
     * Gets the year of the Date
     * @return An integer of the year
     */
    public int getYear() {
        return year;
    }

    /**
     * Sets the day of the Date
     * @param day An integer containing the day of the Date
     */
    public void setDay(int day) {
        this.day = day;
    }

    /**
     * Sets the month of the Date
     * @param month A String containing the month
     */
    public void setMonth(String month) {
        this.month = month;
    }

    /**
     * Sets the month of the Date
     * @param year An integer containing the year
     */
    public void setYear(int year) {
        this.year = year;
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
        final Date other = (Date) obj;
        if (this.day != other.day) {
            return false;
        }
        if (this.year != other.year) {
            return false;
        }
        return Objects.equals(this.month, other.month);
    }

    /**
     * Method to return String of parameters
     * @return String of Date components
     */
    @Override
    public String toString() {
        return day + "-" + month + "-" + year;
    }
    
}