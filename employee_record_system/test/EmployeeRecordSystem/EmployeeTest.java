/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package EmployeeRecordSystem;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Daniel Hayes
 */
public class EmployeeTest {
    
    public EmployeeTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of setSalary method, of class Employee.
     */
    @Test
    public void testSetSalary() {
        System.out.println("setSalary");
        Double salary = 20000.00;
        Employee instance = new Employee();
        instance.setSalary(salary);
        Double expResult = 20000.00;
        Double result = instance.getSalary();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of setStart method, of class Employee.
     */
    @Test
    public void testSetStart() {
        System.out.println("setDate");
        Date start = new Date(25, "Decemeber", 0);
        Employee instance = new Employee();
        instance.setStart(start);
        Date expResult = new Date(25, "Decemeber", 0);
        Date result = instance.getStart();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of setTitle method, of class Employee.
     */
    @Test
    public void testSetTitle() {
        System.out.println("setTitle");
        String title = "Delivery Driver";
        Employee instance = new Employee();
        instance.setTitle(title);
        String expResult="Delivery Driver";
        String result = instance.getTitle();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of getSalary method, of class Employee.
     */
    @Test
    public void testGetSalary() {
        System.out.println("getSalary");
        Employee instance = new Employee();
        Double expResult = 20000.00;
        instance.setSalary(20000.00);
        Double result = instance.getSalary();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of getStart method, of class Employee.
     */
    @Test
    public void testGetStart() {
        System.out.println("getStart");
        Employee instance = new Employee();
        instance.setStart(new Date(25, "December", 0));
        Date expResult = new Date(25, "December", 0);
        Date result = instance.getStart();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of getTitle method, of class Employee.
     */
    @Test
    public void testGetTitle() {
        System.out.println("getTitle");
        Employee instance = new Employee();
        instance.setTitle("Delivery Driver");
        String expResult = "Delivery Driver";
        String result = instance.getTitle();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of equals method, of class Employee.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        Object obj = null;
        Employee instance = new Employee();
        boolean expResult = false;
        boolean result = instance.equals(obj);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of toString method, of class Employee.
     */
    @Test
    public void testToString() {
        System.out.println("toString");
        Employee instance = new Employee();
        instance.setSalary(20000.00);
        instance.setStart(new Date(25, "December", 0));
        instance.setTitle("Delivery Driver");
        String expResult = "null,null,null,null,null,20000.0,25-December-0,Delivery Driver";
        String result = instance.toString();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }
    
}