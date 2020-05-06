Feature: GetItems
	Para obtener los Item
	Como usuario
	Quiero obtener una lista de los Item disponible

@GetItems
Scenario: Existen Items
	Given tengo Items
	When Obtengo los Items
	Then Obtengo una lista con los Items disponible


