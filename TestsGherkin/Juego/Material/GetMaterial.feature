Feature: GetMaterial
	Para obtener los materiales
	Como usuario
	Quiero obtener una lista de los materiales disponible

@GetMaterial
Scenario: Existen materiales
	Given tengo materiales
	When Obtengo los materiales
	Then Obtengo una lista con los materiales disponible


