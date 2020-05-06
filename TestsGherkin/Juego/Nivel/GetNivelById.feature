Feature: GetNivelById
	Para buscar un nivel por Id
	Como usuario
	Quiero obtener el nivel con ese nivel

@GetNivelById
Scenario: Obtener nivel por un Id existante
	Given Tengo un nivel con una id específico
	When Busco el nivel pos su id
	Then obtengo este nivel

@GetNivelById
Scenario: Obtener nivel por un Id inexistente
	Given No hay un nivel con Id
	When Busco un nivel por ese nivel
	Then No se puede devolver un nivel