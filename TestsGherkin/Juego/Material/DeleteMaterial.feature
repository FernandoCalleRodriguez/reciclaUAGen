Feature: DeleteMaterial
	Para borrar un Material
	Como usuario
	Quiero borrar el Material

@DeleteMaterialExists
Scenario: Borrar Material existente
	Given Hay un Material con un id especifico
	When Elimino El Material
	Then Se borra el Material

	
@DeleteMaterialDoesntExists
Scenario: Borrar Material no existente
	Given No hay un Material con un id especifico
	When  Entento elimino El Material
	Then  no se borra el Material