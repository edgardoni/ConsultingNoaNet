

IF NOT EXISTS (
	SELECT TABLE_NAME,COLUMN_NAME , DATA_TYPE 
				FROM INFORMATION_SCHEMA.COLUMNS
				where TABLE_NAME = 'AG_DigitalSign' 
				AND COLUMN_NAME = 'idCertificado'
				AND DATA_TYPE = 'nvarchar')
BEGIN

ALTER TABLE dbo.AG_DigitalSign alter column idCertificado nvarchar(100) 

END
GO

