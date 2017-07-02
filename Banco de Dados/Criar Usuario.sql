CREATE TABLESPACE tbsTCC 
LOGGING DATAFILE 'D:\Documentos\Tablespaces Oracle\tbsTCC.dbf'
SIZE 10M AUTOEXTEND ON NEXT 20M EXTENT MANAGEMENT LOCAL;

CREATE USER LAMPIOES identified by 123456
DEFAULT TABLESPACE tbsTCC 
TEMPORARY TABLESPACE temp
QUOTA UNLIMITED ON tbsTCC;

GRANT create session, alter session, create table,
create procedure, create view, create materialized view,
create trigger, create sequence, create any directory,
create type, create synonym TO LAMPIOES;
