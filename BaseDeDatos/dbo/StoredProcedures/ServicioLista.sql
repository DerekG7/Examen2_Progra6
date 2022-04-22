CREATE PROCEDURE [dbo].[ServicioLista]
AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	IdServicio,
	NombreServicio,
	PlazoEntrega,
	CostoServicio,
	Estado,
	CuentaContable
		 
	FROM
	    dbo.Servicio

END