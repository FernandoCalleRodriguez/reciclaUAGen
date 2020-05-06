Feature: UpdateNivel
	Para modificiar un nivel
	Como usuario
	Quiero cambiar sus informaciónes

@UpdateNivelExists
Scenario: Modificar nivel existente
	Given Existe un nivel con id especifico
	When Modifico los datos de este nivel
	Then Obtengo el nivel con los datos modificados


	@UpdateNivelDoesntExist
Scenario: Modificar nivel no existente
	Given No existe un nivel con id -1
	When Modifico los datos de este nivel
	Then No se puede modificar el nivel