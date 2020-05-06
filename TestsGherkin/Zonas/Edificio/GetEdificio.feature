Feature: GetEdificios
	Para obtener los Edificio
	Como usuario
	Quiero obtener una lista de los Edificio disponible

@GetEdificios
Scenario: Existen Edificios
	Given tengo Edificios
	When Obtengo los Edificios
	Then Obtengo una lista con los Edificios disponible

