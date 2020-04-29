Feature: CambiarPassword
	Para cambiar la contraseña
	Como usuario web
	Quiero obtener el usuario con la nueva contraseña

@mytag
Scenario: Test cambiarPassword
	Given Hay un usuario con id 32769
	When Cambiar la contraseña del usuario
	And Obtener el usuario
	Then obtengo el usuario con la nueva contrasena
