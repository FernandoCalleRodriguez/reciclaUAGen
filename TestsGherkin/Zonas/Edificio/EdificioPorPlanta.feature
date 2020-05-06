Feature: EdificioPorPlanta
	Para buscar un edificio por una planta
	Como usuario
	Quiero obtener el edificio de ese planta


@EdificioPorPlanta
Scenario: Obtener edificio por una planta existente
	Given Hay un edificio de una planta especifica
	When Busco el edificio por ese planta
	Then Devuelvo el edifico

@EdificioPorPlanta
Scenario: Obtener edificio por planta inexistente
	Given No Hay un edificio de una planta especifica
	When Busco el edificio por este planta
	Then No se puede devolver el edificio