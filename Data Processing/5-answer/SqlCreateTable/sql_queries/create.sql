 CREATE TABLE position (
    id    INTEGER   PRIMARY KEY
                    NOT NULL
                    UNIQUE,
    title CHAR (50) NOT NULL
                    UNIQUE
);

 
----------------------------------------
CREATE TABLE contact_type (
    id    INTEGER   PRIMARY KEY
                    NOT NULL
                    UNIQUE,
    title CHAR (25) NOT NULL
                    UNIQUE
);
-----------------------------------------
CREATE TABLE gender (
    id    INTEGER   PRIMARY KEY
                    NOT NULL
                    UNIQUE,
    title CHAR (10) NOT NULL
                    UNIQUE
);
--------------------------------------------
CREATE TABLE work_status (
    id    INTEGER   PRIMARY KEY
                    NOT NULL
                    UNIQUE,
    title CHAR (25) NOT NULL
                    UNIQUE
);
------------------------------------------
CREATE TABLE project_status (
    id    INTEGER   PRIMARY KEY
                    NOT NULL
                    UNIQUE,
    title CHAR (25) NOT NULL
                    UNIQUE
);
------------------------------------------
CREATE TABLE person (
    id         INTEGER   PRIMARY KEY
                         NOT NULL
                         UNIQUE,
    name       CHAR (50) NOT NULL,
    surname    CHAR (50) NOT NULL,
    birth_date DATE      NOT NULL,
    gender     INTEGER   REFERENCES gender (id) 
                         NOT NULL
);
-------------------------------------------
CREATE TABLE person_contact (
    id         INTEGER   PRIMARY KEY
                         NOT NULL
                         UNIQUE,
    contact_type_id      INTEGER NOT NULL REFERENCES contact_type(id),
    contact_value    CHAR (50) NOT NULL,
    
    person_id      INTEGER NOT NULL REFERENCES person(id)
);
--------------------------------------------
CREATE TABLE project (
    id         INTEGER   PRIMARY KEY
                         NOT NULL
                         UNIQUE,
    name       CHAR (50) NOT NULL,
    date_of_creation DATE      NOT NULL,
    status     INTEGER   REFERENCES project_status (id) 
                         NOT NULL,
     date_of_closure DATE      NOT NULL
);
-----------------------------------------------
CREATE TABLE employee (
    id         INTEGER   PRIMARY KEY
                         NOT NULL
                         UNIQUE,
    person_id     INTEGER   REFERENCES person (id) 
                         NOT NULL,
    work_status     INTEGER   REFERENCES work_status (id) 
                         NOT NULL
     
);
--------------------------------------------------
CREATE TABLE project_status_archive (
    project_id     INTEGER   REFERENCES project (id) 
                         NOT NULL,
    status_id     INTEGER   REFERENCES project_status (id) 
                         NOT NULL,
    date_of_setting DATE      NOT NULL,
    employee_setter_id     INTEGER   REFERENCES employee (id) 
                         NOT NULL
);
----------------------------------------------------
CREATE TABLE employee_tasks (
    employee_id     INTEGER   REFERENCES employee (id) 
                         NOT NULL,
    project_id     INTEGER   REFERENCES project (id) 
                         NOT NULL,
    description CHAR (50) NOT NULL,
    start_time DATE      NOT NULL,
    deadline DATE      NOT NULL
);
-----------------------------------------------------
CREATE TABLE project_position (
    employee_id     INTEGER   REFERENCES employee (id) 
                         NOT NULL,
    project_id     INTEGER   REFERENCES project (id) 
                         NOT NULL,
    position_id     INTEGER   REFERENCES position (id) 
                         NOT NULL
);
