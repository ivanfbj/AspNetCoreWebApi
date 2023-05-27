DECLARE @fecha_actual DATETIME = GETDATE();
DECLARE @texto_fecha VARCHAR(50);

SET @texto_fecha = REPLACE(REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(23), @fecha_actual, 121), '-', ''), ' ', '_'), ':', 'h'), '.', 'ms');

--Si la tabla existe y tiene registros crea un respaldo de la información y luego elimina la tabla original.
IF EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TblApartamentos')
	BEGIN
		Declare @CantidadRegistros INT = (SELECT COUNT(1) FROM TblApartamentos);
		if @CantidadRegistros > 0
			BEGIN
				DECLARE @query NVARCHAR(MAX);
				SET @query = 'SELECT * INTO ' + QUOTENAME('TblApartamentos_' + @texto_fecha) + ' FROM TblApartamentos';
				EXEC sp_executesql @query;
			END
		DROP TABLE TblApartamentos;
	END
GO
CREATE TABLE TblApartamentos (
    Id				INT IDENTITY(1,1)
						CONSTRAINT PK_TblApartamentos_Id PRIMARY KEY,
    Codigo			VARCHAR(255),
    Urls			VARCHAR(1000),
    Area			VARCHAR(15),
    Habitaciones	INT,
    Garaje			INT,
    Ducha			INT,
    Municipio		VARCHAR(255),
    Barrio			VARCHAR(255),
    Precio			BIGINT,
    Agencia			VARCHAR(255)
);
GO
-- =============================================
-- Author:		Ivanfbj
-- Create date: 20230513
-- Description:	Procedimiento que se utiliza en la API REST para insertar información.
-- =============================================
CREATE OR ALTER PROCEDURE stpr_InsertarApartamento
    @Codigo			VARCHAR(255),
    @Urls			VARCHAR(1000),
    @Area			VARCHAR(15),
    @Habitaciones	INT,
    @Garaje			INT,
    @Ducha			INT,
    @Municipio		VARCHAR(255),
    @Barrio			VARCHAR(255),
    @Precio			BIGINT,
    @Agencia		VARCHAR(255)
AS
BEGIN
	INSERT INTO TblApartamentos
	VALUES (@Codigo,
			@Urls,
			@Area,
			@Habitaciones,
			@Garaje,
			@Ducha,
			@Municipio,
			@Barrio,
			@Precio,
			@Agencia)
END
GO
-- =============================================
-- Author:		Ivanfbj
-- Create date: 20230513
-- Description:	Procedimiento que se utiliza en la API REST para actualizar información.
-- =============================================
CREATE OR ALTER PROCEDURE stpr_ActualizarApartamento
	@Id				INT,
	@Codigo			VARCHAR(255) = NULL,
	@Urls			VARCHAR(1000) = NULL,
	@Area			VARCHAR(15) = NULL,
	@Habitaciones	INT = NULL,
	@Garaje			INT = NULL,
	@Ducha			INT = NULL,
	@Municipio		VARCHAR(255) = NULL,
	@Barrio			VARCHAR(255) = NULL,
	@Precio			BIGINT = NULL,
	@Agencia		VARCHAR(255) = NULL
AS
BEGIN
	UPDATE TblApartamentos
	SET 
		Codigo = COALESCE(@Codigo, Codigo),
		Urls = COALESCE(@Urls, Urls),
		Area = COALESCE(@Area, Area),
		Habitaciones = COALESCE(@Habitaciones, Habitaciones),
		Garaje = COALESCE(@Garaje, Garaje),
		Ducha = COALESCE(@Ducha, Ducha),
		Municipio = COALESCE(@Municipio, Municipio),
		Barrio = COALESCE(@Barrio, Barrio),
		Precio = COALESCE(@Precio, Precio),
		Agencia = COALESCE(@Agencia, Agencia)
	WHERE Id = @Id
END
GO
-- =============================================
-- Author:		Ivanfbj
-- Create date: 20230513
-- Description:	Procedimiento que se utiliza en la API REST para consultar información.
-- =============================================
CREATE OR ALTER PROCEDURE stpr_MostrarApartamentos
AS
BEGIN
	SELECT Id, Codigo, Urls, Area, Habitaciones, Garaje, Ducha, Municipio, Barrio, Precio, Agencia
	FROM TblApartamentos
END
GO
-- =============================================
-- Author:		Ivanfbj
-- Create date: 20230513
-- Description:	Procedimiento que se utiliza en la API REST para Eliminar información.
-- =============================================
CREATE OR ALTER PROCEDURE stpr_EliminarApartamento
	@Id		INT
AS
BEGIN
	DELETE
	FROM TblApartamentos
	WHERE Id = @Id
END