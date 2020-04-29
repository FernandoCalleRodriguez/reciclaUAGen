Feature: ObtenerItemsPorValidar
	Para obtener los items por validar
	Como usuario
	Quiero obtener una lista de los items por validar

@ObtenerItemsPorValidar
Scenario: Existen items por validar
	Given Tengo items sin validar
	When Obtengo los items por validar
	Then Obtengo una lista con los items por validar