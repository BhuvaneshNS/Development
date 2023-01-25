--create procedure sp_createNewUser(
--	@name nvarchar(50),
--	@gender nvarchar(50),
--	@city nvarchar(50),
--	@phone int,
--	@mailId nvarchar(50),
--	@password nvarchar(50),
--	@status int output
--)
--as 
--begin
--	insert into Users(Name,Gender,City,Phone,MailId,Password,Active) values(@name,@gender,@city,@phone,@mailId,@password, 1);
--	set @status=1;
--end;

--declare @status int;
--exec sp_createNewUser 'Bhu','Male','Coorg',123455,'bns@mail.com','1234', @status output; 
--select @status;

--create procedure sp_AuthenticateLogin(
--	@mailId nvarchar(50),
--	@password nvarchar(50),
--	@status int output
--)
--as
--begin
--	begin try
--		select * 
--		from Users
--		where MailId=@mailId and password=@password;

--		if(@@ROWCOUNT>0)
--		begin
--			set @status=1;
--		end
--	end try
--	begin catch
--	set @status=0;
--	end catch
--end;

--declare @status int;
--exec sp_AuthenticateLogin 'bns@mail.com','1234', @status output; 
--select @status;


alter procedure spCheckMailIdExist
(
	@mailId varchar(50)
)
as 
begin
		select * from Users where @mailId=MailId;
end;

spCheckMailIdExist 'bns@mail.com';