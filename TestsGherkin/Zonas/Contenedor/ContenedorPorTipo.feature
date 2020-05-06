Feature: ContenedorPorTipo
	Para buscar un contenedor por un tipo
	Como usuario
	Quiero obtener una lista de contenedores de este tipo


@ContenedorPorTipo
Scenario: Obtener edificios por un tipo existente
	Given Hay  edificios de un tipo especifica
	When Busco el edificios por ese tipo
	Then Devuelvo la lista de edificos

@ContenedorPorTipo
Scenario: Obtener edificios por tipo inexistente
	Given No Hay edificios de una planta especifica
	When Busco edificios por este tipo
	Then No se puede devolver los edificio