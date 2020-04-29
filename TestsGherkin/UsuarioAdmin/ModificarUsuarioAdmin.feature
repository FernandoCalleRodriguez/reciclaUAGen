Feature: ModificarUsuarioAdmin
	Para modificiar un usuario
	Como usuario
	Quiero cambiar su información

@mytag
Scenario: Add two numbers
	Given Existe un usuario admin 32770
	When Modifico los datos del usuario
	Then Obtengo el usuario con los datos modificados
