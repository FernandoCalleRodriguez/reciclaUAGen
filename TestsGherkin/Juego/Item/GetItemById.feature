Feature: GetItemById
	Para buscar un Item por Id
	Como usuario
	Quiero obtener el Item con ese id

@GetItemById
Scenario: Obtener Item por un Id existante
	Given Tengo un Item con una id específico
	When Busco el Item pos su id
	Then obtengo este Item

@GetItemByIdDoesntExist
Scenario: Obtener Item por un Id inexistente
	Given No hay un Item con Id -1
	When Busco un Item por ese id
	Then No se puede devolver un Item
