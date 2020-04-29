Feature: CambiarPassword
	Para cambiar la contraseña
	Como usuario web
	Quiero obtener el usuario con la nueva contraseña

@mytag
Scenario: Test obtenerUsuarioPorEmail
	Given Hay un usuario con id 32769
	When Cambiar la contraseña del usuario
	And Obtener el usuario
	Then Devuelvo el usuario
