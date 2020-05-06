Feature: GetNivel
	Para obtener los niveles
	Como usuario
	Quiero obtener una lista de los niveles disponible

@GetNivel
Scenario: Existen niveles
	Given tengo niveles
	When Obtengo los niveles
	Then Obtengo una lista con los niveles disponible
