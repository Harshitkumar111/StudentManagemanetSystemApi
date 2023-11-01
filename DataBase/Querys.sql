create database harshitStudent

use harshitStudent
select * from students


create table students(
	id  int IDENTITY(1,1),
	name varchar(255),
	emailid varchar(255),
	phoneNo varchar(255),
	city varchar(255)	
)
create proc xspInsertStudent
@name varchar(255),  
@emailid varchar (255),
@phoneNo nvarchar(255),
@city varchar(255)
as  
begin   
	insert into students values(@name,@emailid,@phoneNo,@city)  
end


insert into students (name,emailid,phoneNo,city) values('harshit','abc@gmial.com',1234567890,'bijnor')
------------------------------------------------------------------------------------------------------------------------
create proc xspgetStudent
as  
begin   
	select * from students
end

-----------------------------------------------------------------------------------------------------------------------------


create proc xspDeleteStudent
@id int
as  
begin   
	delete from students where id = @id
end

----------------------------------------------------------------------------------------------------------------------

create proc xspgetByIdStudent
@id int
as  
begin   
	select * from students where id=@id
end


------------------------------------------------------------------------------------


create proc xspUpdateStudent
@id int,
@name varchar(255),  
@emailid varchar (255),
@phoneNo nvarchar(255),
@city varchar(255)
as  
begin   
	update students set name=@name, emailid =@emailid , phoneNo=@phoneNo , city= @city  where id=@id 
end



