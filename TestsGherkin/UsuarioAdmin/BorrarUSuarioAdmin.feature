Feature: BorrarUsuarioAdmin
	Para borrar un usuario Admin
	Como usuario
	Quiero borrar el usuario

@mytag
Scenario: Test borrarUsuarioAdmin
	Given Hay un usuario admin 32770
	When Elimino el usuario
	Then Devuelvo el usuario con datos borrados
