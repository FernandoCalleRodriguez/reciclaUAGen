Feature: GetMaterialById
	Para buscar un material por Id
	Como usuario
	Quiero obtener el material con ese id

@GetMaterialById
Scenario: Obtener material por un Id existante
	Given Tengo un material con una id específico
	When Busco el material pos su id
	Then obtengo este material

@GetMaterialByIdDoesntExist
Scenario: Obtener material por un Id inexistente
	Given No hay un material con Id -1
	When Busco un material por ese id
	Then No se puede devolver un material

