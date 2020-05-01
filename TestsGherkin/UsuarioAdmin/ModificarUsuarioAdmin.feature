Feature: ModificarUsuarioAdmin
	Para modificiar un usuario
	Como usuario
	Quiero cambiar su información

@ModificarUsuario
Scenario: Modificar usuario existente
	Given Existe un usuario
	When Modifico los datos del usuario
	Then Obtengo el usuario con los datos modificados

	@ModificarUsuario
Scenario: Modificar usuario no existente
	Given No existe el usuario -1
	When Modifico los datos del usuario
	Then No se puede modificar el usuario
