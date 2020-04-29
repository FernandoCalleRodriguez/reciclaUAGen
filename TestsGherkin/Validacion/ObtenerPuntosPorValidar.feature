Feature: ObtenerPuntosPorValidar
	Para obtener los puntos por validar
	Como usuario
	Quiero obtener una lista de los puntos por validar

@ObtenerPuntosPorValidar
Scenario: Existen puntos por validar
	Given Tengo puntos sin validar
	When Obtengo los puntos por validar
	Then Obtengo una lista con los puntos por validar