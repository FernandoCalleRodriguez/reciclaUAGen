Feature: PuntoPorContenedor
	Para buscar un punto por contenedor
	Como usuario
	Quiero obtener el punto de ese contenedor


@PuntoPorContenedor
Scenario: Obtener punto por un contenedor existente
	Given Hay un punto de una contenedor especifica
	When Busco el punto por ese contenedor
	Then Devuelvo el punto

@PuntoPorContenedor
Scenario: Obtener punto por contenedor inexistente
	Given No Hay un punto de un contenedor especifica
	When Busco el punto por este contenedor
	Then No se puede devolver el punto