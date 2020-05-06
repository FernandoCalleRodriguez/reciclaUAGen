Feature: DeleteItem
	Para borrar un Item
	Como usuario
	Quiero borrar el Item

@DeleteItemExists
Scenario: Borrar Item existente
	Given Hay un Item con un id especifico
	When Elimino El Item
	Then Se borra el Item

	
@DeleteItemDoesntExists
Scenario: Borrar Item no existente
	Given No hay un Item con un id especifico
	When  Entento elimino El Item
	Then  no se borra el Item