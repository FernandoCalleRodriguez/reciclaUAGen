Feature: VerificarEmail
	Para verificar una cuenta
	Como usuario web
	Quiero obtener el usario verficado

@mytag
Scenario: Test verificarEmail
	Given Un usuario 32769
	When Cambio el usuario a verificado
	Then obtengo el usuario verificado
