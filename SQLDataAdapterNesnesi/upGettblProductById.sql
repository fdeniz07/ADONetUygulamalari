create proc upGettblProductById
(
@ProductId int
)
as
Begin
Select * from tblProduct where Id = @ProductId
End