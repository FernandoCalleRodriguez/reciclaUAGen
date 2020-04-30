Feature: BorrarUsuarioAdmin
	Para borrar un usuario Admin
	Como usuario
	Quiero borrar el usuario

@mytag
Scenario: Borrar usuario existente
	Given Hay un usuario admin 32770
	When Elimino el usuario
	Then Devuelvo el usuario con datos borrados

	@mytag
Scenario: Borrar usuario no existente
	Given Hay un usuario admin -1
	When Elimino el usuario
	Then No se puede borrar el usuario
