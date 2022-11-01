/*Clear existing tables*/
DROP TABLE customers CASCADE CONSTRAINTS;
DROP TABLE quote CASCADE CONSTRAINTS;
DROP TABLE payments CASCADE CONSTRAINTS;
DROP TABLE parts CASCADE CONSTRAINTS;
DROP TABLE line_item CASCADE CONSTRAINTS;


/*Create customers table to hold customer name and address and unique ID*/
/*Cust_ID is foreign key in qoute table*/
CREATE TABLE customers (
    cust_id         VARCHAR2(4)
    , first_name    VARCHAR2(25)
    , surname       VARCHAR2(25)
    , address       VARCHAR2(25)
    , town          VARCHAR2(20)
    , postcode      VARCHAR2(8)
    , email_address VARCHAR2(50)
        CONSTRAINT cus_email_add_U UNIQUE
    , phone_no      VARCHAR2(11)
        CONSTRAINT cus_phone_no_U UNIQUE 
        CONSTRAINT cus_phone_no_NN NOT NULL  
    ) ;
    
/*Index the primary key and alter table to make cust_id the primary key*/    
CREATE UNIQUE INDEX cus_cust_id_pk
ON customers (cust_id);

ALTER TABLE customers
ADD ( 
    CONSTRAINT cus_cust_id_pk
        PRIMARY KEY (cust_id)
    ) ;


/*Create quote table to store quote details*/
/*Quote_ID is foreign key in payments table and forms part of a composite key in the line_item table*/
CREATE TABLE quote (
    quote_id        VARCHAR2(4)
    , cust_id       VARCHAR2(4)
    , quote_date    DATE
        CONSTRAINT quo_quote_date_NN NOT NULL
    , work_loc      VARCHAR2(20)
    , esd           DATE
    , sub_total     NUMBER(10,2)
    , total         NUMBER(10,2)
    ) ;

CREATE UNIQUE INDEX quo_quote_id_PK
ON quote (quote_id);

CREATE INDEX quo_cust_id_FK
ON quote (cust_id);

ALTER TABLE quote
ADD ( 
    CONSTRAINT quo_quote_id_PK
        PRIMARY KEY (quote_id),
    CONSTRAINT check_quote_ID
        CHECK (quote_id BETWEEN 0001 AND 9999),    
    CONSTRAINT quo_cust_id_FK
        FOREIGN KEY (cust_id)
        REFERENCES customers 
        ON DELETE CASCADE
    ) ;


/*Create payments table to track payments made towards a quote*/
CREATE TABLE payments (
    p_date          DATE
    , quote_id      VARCHAR2(4)
    , amount        NUMBER(6,2)
    ) ;

CREATE INDEX pay_pdate_PK
ON payments (p_date);

CREATE INDEX pay_quote_ID_FK
ON payments (quote_id);

ALTER TABLE payments
ADD ( 
    CONSTRAINT pay_pdate_PK
        PRIMARY KEY (p_date),
    CONSTRAINT pay_quote_ID_FK
        FOREIGN KEY (quote_id)
        REFERENCES quote
        ON DELETE CASCADE
    ) ;


/*Create parts table to record details about parts*/
/*ItemCode forms part of a composite key in the line_item table*/
CREATE TABLE parts (
    item_code           VARCHAR2(5)
    , Description       VARCHAR2(40)
    , price_net         NUMBER(8,2)
    , price_gross       NUMBER(8,2)
    ) ;

CREATE UNIQUE INDEX par_item_code_PK
ON parts (item_code);

ALTER TABLE parts
ADD (
    CONSTRAINT par_item_code_PK
        PRIMARY KEY (item_code)
    ) ;


/*Create line_item table to establish relational integrity between the quote and parts tables*/
CREATE TABLE line_item (
    item_code           VARCHAR2(5) 
    , quote_id          VARCHAR2(4) 
    , qty NUMBER(3)
    ) ;

CREATE INDEX line_item_CK
ON line_item (item_code, quote_id);

ALTER TABLE line_item
ADD ( CONSTRAINT line_item_CK
        PRIMARY KEY (item_code, quote_id)
    , CONSTRAINT lin_item_code_FK
        FOREIGN KEY (item_code)
        REFERENCES parts
        ON DELETE CASCADE
    , CONSTRAINT lin_quote_id_FK
        FOREIGN KEY (quote_id)
        REFERENCES quote
        ON DELETE CASCADE
    ) ;


/*Join customer, quote, line item and parts table to create cust_quote_view
providing all the details present on the quote form in the specification*/
COMMIT;


/*Insert data into customers table*/
INSERT INTO customers VALUES
    ( 'BA01'
    , 'Bret'
    , 'Baier'
    , '414 Fox Avenue'
    , 'Stockport'
    , 'SK3 9RU'
    , 'bretbaier@mailmail.com'
    , '07960123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'VA01'
    , 'Tone'
    , 'Vays'
    , '23 Thai Street'
    , 'Manchester'
    , 'M13 9LU'
    , 'tonevays@mailmail.com'
    , '07967123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'SO01'
    , 'Jimmy'
    , 'Song'
    , '11 Riley road'
    , 'Stockport'
    , 'SK3 9QX'
    , 'jimmysong@mailmail.com'
    , '07770123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'BR01'
    , 'Shannon'
    , 'Bream'
    , '31 Fox Avenue'
    , 'Stockport'
    , 'SK3 9RU'
    , 'shannonbream@mailmail.com'
    , '07980123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'WA01'
    , 'Chris'
    , 'Wallace'
    , '11 Town Street'
    , 'Stockport'
    , 'SK2 5AJ'
    , 'chriswallace@mailmail.com'
    , '07870123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'MI01'
    , 'Stephen'
    , 'Miller'
    , '23 Malmo Avenue'
    , 'Manchester'
    , 'M12 8SU'
    , 'stephenmiller@mailmail.com'
    , '07940123456'
    ) ;

INSERT INTO customers VALUES
    ( 'PA01'
    , 'Rand'
    , 'Paul'
    , '32 Mason Street'
    , 'Dukinfield'
    , 'SK16 4TU'
    , 'randpaul@mailmail.com'
    , '07570123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'PA02'
    , 'Ron'
    , 'Paul'
    , '15 Foil Road'
    , 'Hyde'
    , 'SK14 6TH'
    , 'ronpaul@mailmail.com'
    , '07950123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'CL01'
    , 'Geoffry'
    , 'Clap'
    , '72 Salmon Crecent'
    , 'Dukinfield'
    , 'SK16 5AH'
    , 'geoffryclap@mailmail.com'
    , '07979123456'
    ) ;
    
INSERT INTO customers VALUES
    ( 'PI01'
    , 'Josie'
    , 'Piro'
    , '21 Gammon Street'
    , 'Hyde'
    , 'SK14 7MP'
    , 'josiepiro@mailmail.com'
    , '07790123456'
    ) ;
    
    
/* Insert data into quote table */

INSERT INTO quote VALUES
    ( '0001'
    , 'BA01'
    , TO_DATE('21-DEC-2017', 'dd-MON-yyyy')
    , 'Full house'
    , TO_DATE('01-JAN-2018', 'dd-MON-yyyy')
    , 3672.00
    , 4590.00
    ) ;
    
INSERT INTO quote VALUES
    ( '0002'
    , 'VA01'
    , TO_DATE('07-JAN-2018', 'dd-MON-yyyy')
    , 'House rear'
    , TO_DATE('20-JAN-2018', 'dd-MON-yyyy')
    , 2108.00
    , 2635.00
    ) ;
    
INSERT INTO quote VALUES
    ( '0003'
    , 'SO01'
    , TO_DATE('23-JAN-2018', 'dd-MON-yyyy')
    , 'Front door'
    , TO_DATE('23-FEB-2018', 'dd-MON-yyyy')
    , 1020.00
    , 1275.00
    ) ;

INSERT INTO quote VALUES
    ( '0004'
    , 'BR01'
    , TO_DATE('10-JAN-2018', 'dd-MON-yyyy')
    , 'Kitchen'
    , TO_DATE('10-FEB-2018', 'dd-MON-yyyy')
    , 0
    , 0
    ) ;
    
INSERT INTO quote VALUES
    ( '0005'
    , 'WA01'
    , TO_DATE('20-JAN-2018', 'dd-MON-yyyy')
    , 'Lounge'
    , TO_DATE('20-FEB-2018', 'dd-MON-yyyy')
    , 0
    , 0
    ) ;
    

/* Insert data into line_item */
/*
Diasabled integrity constraint to input data, to fix error:

Error report -
ORA-02291: integrity constraint (DJMHAYES.SYS_C007944) violated - parent key not found
*/
ALTER TABLE line_item 
  DISABLE CONSTRAINT line_item_CK;
ALTER TABLE line_item 
  DISABLE CONSTRAINT lin_item_code_FK;
    
INSERT INTO line_item VALUES
    ( 'D0087'
    , '0001'
    , 2
    ) ;
    
INSERT INTO line_item VALUES
    ( 'W830'
    , '0001'
    , 6
    ) ;
    
INSERT INTO line_item VALUES
    ( 'W205'
    , '0001'
    , 2
    ) ;
    
INSERT INTO line_item VALUES
    ( 'DH23'
    , '0001'
    , 2
    ) ;

INSERT INTO line_item VALUES
    ( 'INS1D'
    , '0001'
    , 4
    ) ;
    
INSERT INTO line_item VALUES
    ( 'D0087'
    , '0002'
    , 1
    ) ;
    
INSERT INTO line_item VALUES
    ( 'W830'
    , '0002'
    , 2
    ) ;
    
INSERT INTO line_item VALUES
    ( 'W205'
    , '0002'
    , 3
    ) ;

INSERT INTO line_item VALUES
    ( 'DH23'
    , '0002'
    , 1
    ) ;

INSERT INTO line_item VALUES
    ( 'INS1D'
    , '0002'
    , 2
    ) ;
    
INSERT INTO line_item VALUES
    ( 'D0087'
    , '0003'
    , 1
    ) ;

INSERT INTO line_item VALUES
    ( 'DH23'
    , '0003'
    , 1
    ) ;
    
INSERT INTO line_item VALUES
    ( 'INS1D'
    , '0003'
    , 1
    ) ;
    

/* Insert data into parts table */
INSERT INTO parts VALUES
    ( 'D0087'
    , 'Toughened Door, black, 2 panel'
    , 680.00
    , 850.00
    ) ;

INSERT INTO parts VALUES
    ( 'W830'
    , 'Window, Plain glass, size: 830X1675'
    , 240.00
    , 300.00
    ) ;
    
INSERT INTO parts VALUES
    ( 'W205'
    , 'Window, Plain glass, size: 205X1675'
    , 96.00
    , 120.00
    ) ;
    
INSERT INTO parts VALUES
    ( 'DH23'
    , 'Door Handle, chrome'
    , 20.00
    , 25.00
    ) ;
    
INSERT INTO parts VALUES
    ( 'INS1D'
    , '1 day installation'
    , 320.00
    , 400.00
    ) ;


/* Insert data into payments table */

INSERT INTO payments VALUES
    ( TO_DATE('21-DEC-2017', 'dd-MON-yyyy')
    , '0001'
    , 1500.00
    ) ;
    
INSERT INTO payments VALUES
    ( TO_DATE('01-JAN-2018', 'dd-MON-yyyy')
    , '0001'
    , 3090.00
    ) ;
    
INSERT INTO payments VALUES
    ( TO_DATE('07-JAN-2018', 'dd-MON-yyyy')
    , '0002'
    , 1000.00
    ) ;

INSERT INTO payments VALUES
    ( TO_DATE('14-JAN-2018', 'dd-MON-yyyy')
    , '0002'
    , 1035.00
    ) ;
    
INSERT INTO payments VALUES
    ( TO_DATE('20-JAN-2018', 'dd-MON-yyyy')
    , '0002'
    , 500.00
    ) ;
    
INSERT INTO payments VALUES
    ( TO_DATE('23-JAN-2018', 'dd-MON-yyyy')
    , '0003'
    , 500.00
    ) ;

/* Enable integrity constraints on line_item table */
ALTER TABLE line_item 
  ENABLE CONSTRAINT line_item_CK;
ALTER TABLE line_item 
  ENABLE CONSTRAINT lin_item_code_FK;

COMMIT;

/* Set save point before updates are made */
SAVEPOINT a;

/* A customer may request to have their data removed from the database, this can
be done by deleting what is in the customer and the customer table and will
remove all related data with the on delete cascade statements that I have set*/
DELETE FROM customers
WHERE cust_id = 'BR01';

SAVEPOINT b;

/* After comparing the parts_total to the the total on quote 0001 a discrepancy
was found which needs updating */
UPDATE quote
SET sub_total = 4312, total = 5390
WHERE quote_id = 0001;

/* If the customer was not happy with this change and insists on paying the
the amount original quoted, these changes may need to be rolled back */
ROLLBACK TO b;

COMMIT;

/*
Use DESC function to check details of tables are correcT
*/
DESC customers;

DESC quote;

DESC parts;

DESC line_item;

DESC payments;

/*
Use SELECT statement to confim data has been inserted, updated and deleted
correctly through SQL statements and also the front end interface
*/
SELECT *
FROM customers;

SELECT *
FROM quote;

SELECT *
FROM parts;

SELECT *
FROM line_item;

SELECT *
FROM payments;
