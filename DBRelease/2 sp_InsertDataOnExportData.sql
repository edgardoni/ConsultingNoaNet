
IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_InsertDataOnExportData') 
BEGIN
    DROP PROCEDURE dbo.[sp_InsertDataOnExportData]
END
GO

CREATE PROCEDURE [dbo].[sp_InsertDataOnExportData]
@idDocumentType int,
@idUser int,
@insert varchar(max),
@values varchar(max)


AS

BEGIN
 declare @FechaNueva varchar(10)
 declare @HoraNueva varchar(8)
 declare @tableName varchar(max)
 declare @idVolume varchar(10)
 declare @idLot varchar(10)
 declare @idPage varchar(10) 
 
 set @FechaNueva = (select CONVERT(varchar(10), GETDATE(),103))
 set @HoraNueva = (select CONVERT (varchar(8), GETDATE(),108))
 set @tableName = (select ExportTable from AG_DocumentTypes where IDDocumentType = @idDocumentType)
 set @idVolume = (select top 1 IDVolume from AG_Volumes) 
 set @idLot = (select top 1 IDLot from AG_Lots where IDDocumentType = @idDocumentType order by IDLot desc)
 set @idPage = (select top 1 IDPage from AG_Pages order by IDPage desc)
 
 declare @sql1 nvarchar(max)
 set @sql1 = 'insert into ' + @tableName + ' ([IDVolume], [IDPage], [IDLot], [IndexDate], [IndexTime], [FirstPage], [LastPage], [PageDiff], [FileName],[PageCount], [IDUser],' + @insert + ', [Estado], [FechaOpenFilePdf])
 values (' + @idVolume + ','+ @idPage +', ' + @idLot + ', ''' + @FechaNueva + ''', '''+ @HoraNueva + ''' , 1, 1, 0, 0, 0, ' + @values + ', 0,SYSDATETIME ())' 
 
 declare @idExport int 
 declare @ultimoIDExport nvarchar(max)    
 set @ultimoIDExport = N'@ultimoID int output' 
 declare @sql2 nvarchar(max)
 set @sql2 = @sql1 + ' SELECT @ultimoID = scope_identity()'

 exec sp_executesql @sql2, @ultimoIDExport, @ultimoID = @idExport output;
 select @idExport
END

GO

 
