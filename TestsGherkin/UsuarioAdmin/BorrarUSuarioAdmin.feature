Feature: BorrarUsuarioAdmin
	Para borrar un usuario Admin
	Como usuario
	Quiero borrar el usuario

@BorrarUsuario
Scenario: Borrar usuario existente
	Given TEngo un usuario existente
	When Elimino el usuario
	Then Devuelvo el usuario con datos borrados

	@BorrarUsuario
Scenario: Borrar usuario no existente
	Given No existe un usuario admin -1
	When Elimino el usuario
	Then No se puede borrar el usuario
