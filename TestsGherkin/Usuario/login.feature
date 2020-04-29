Feature: login
	Para realizar el login
	Como usuario
	Quiero comfirma que las credenciales son correstas

@mytag
Scenario: Existe el usuario
	Given Hay un usuario
		| email       | pass  | id    |
		| admin@ua.es | admin | 32768 |
	When Compruebo las credenciales
	Then Obtengo al usuario