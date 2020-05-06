Feature: UpdateItem
	Para modificiar un Item
	Como usuario
	Quiero cambiar sus informaciónes

@UpdateItemExists
Scenario: Modificar Item existente
	Given Existe un Item con id especifico
	When Modifico los datos de este Item
	Then Obtengo el Item con los datos modificados


	@UpdateItemDoesntExist
Scenario: Modificar Item no existente
	Given No existe un Item con id -1
	When Entento odifico los datos de este Item
	Then No se puede modificar el Item