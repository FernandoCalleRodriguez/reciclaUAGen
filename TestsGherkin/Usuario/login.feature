Feature: login
	Para realizar el login
	Como usuario
	Quiero comfirma que las credenciales son correstas

@Login
Scenario: Existe el usuario
	Given Hay un usuario
		| email         | pass       |
		| usuario@ua.es | contrasena |
	When Compruebo las credenciales
	Then Devuelvo el usuario

@Login
Scenario: No existe el usuario
	Given Hay un usuario
		| email         | pass  |
		| usuarioprueba@ua.es | contrasena |
	When Compruebo las credenciales
	Then No existe el usuario