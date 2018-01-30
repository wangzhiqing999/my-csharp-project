use master
go


DECLARE
  @FileName AS VARCHAR(100);
BEGIN
  SET @FileName = 'd:\MyMiniTradingSystem_' + Convert(VARCHAR(8), GETDATE(),  112) + '.dat';
  backup database MyMiniTradingSystem to disk=@FileName
END
go

