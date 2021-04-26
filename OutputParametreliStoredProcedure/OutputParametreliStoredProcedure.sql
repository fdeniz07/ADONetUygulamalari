create proc upAddEmployee
@Name nvarchar(50),
@Gender nvarchar(50),
@Salary int,
@DepartmentId int,
@EmployeeId int out
as
Begin
	Insert into tblEmployee values (@Name,@Gender,@Salary,@DepartmentId)
	Select @EmployeeId = SCOPE_IDENTITY()
End


Declare @EmpId int
Execute upAddEmployee 'Alper','Celik','7600','2', @EmpId out
Print 'Employee Id = ' + cast (@EmpId as nvarchar(2))