Feature: UpdateMaterial
	Para modificiar un Material
	Como usuario
	Quiero cambiar sus informaciónes

@UpdateMaterialExists
Scenario: Modificar Material existente
	Given Existe un Material con id especifico
	When Modifico los datos de este Material
	Then Obtengo el Material con los datos modificados


	@UpdateMaterialDoesntExist
Scenario: Modificar Material no existente
	Given No existe un Material con id -1
	When Entento odifico los datos de este Material
	Then No se puede modificar el Material