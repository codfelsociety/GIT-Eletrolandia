CREATE TABLESPACE tbsEletrolandia 
LOGGING DATAFILE 'COLE O LOCAL AQUI\tbsEletrolandia.dbf'
SIZE 10M AUTOEXTEND ON NEXT 20M EXTENT MANAGEMENT LOCAL;

CREATE USER ADM identified by 123456
DEFAULT TABLESPACE tbsEletrolandia
TEMPORARY TABLESPACE temp
QUOTA UNLIMITED ON tbsEletrolandia;

GRANT create session, alter session, create table,
create procedure, create view, create materialized view,
create trigger, create sequence, create any directory,
create type, create synonym TO ADM;
