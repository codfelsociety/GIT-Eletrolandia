CREATE TABLESPACE tbsOscar
LOGGING DATAFILE 'D:\Desktop\Coisas\tbsOscar.dbf'
SIZE 10M AUTOEXTEND ON NEXT 20M EXTENT MANAGEMENT LOCAL;

CREATE USER ADMINO identified by 123456
DEFAULT TABLESPACE tbsOscar
TEMPORARY TABLESPACE temp
QUOTA UNLIMITED ON tbsOscar;

GRANT create session, alter session, create table,
create procedure, create view, create materialized view,
create trigger, create sequence, create any directory,
create type, create synonym TO ADMINO;
