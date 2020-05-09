Feature: CrearUsuarioWeb
	Para crear un nuevo usuario web
	Como usuario no autenticado
	Quiero obtener el nuevo usuario

@CrearUsuarioWeb
Scenario: Test crearUsuarioWeb
	Given No existe un usuario
		| nombre | apellidos | email      | pass |
		| usu    | 2         | usu2@ua.es | usu2 |
	When Creo el usuario
	Then Obtengo al nuevo usuario
