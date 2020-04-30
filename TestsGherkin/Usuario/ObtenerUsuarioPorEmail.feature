Feature: obtenerUsuarioPorEmail
	Para buscar el usuario por el email
	Como usuario
	Quiero obtener el usuario con ese email

@mytag
Scenario: Obtener usuario por email existente
	Given Hay un usuario con email "usuario@ua.es"
	When Busco el usuario por ese email
	Then Devuelvo el ususario

	@mytag
Scenario: Obtener usuario por email inexistente
	Given Hay un usuario con email "usuarioprueba@ua.es"
	When Busco el usuario por ese email
	Then No se puede devolver al suario