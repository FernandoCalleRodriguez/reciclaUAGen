Feature: ObtenerTiposAccion
	Para obtener todos los tipos de accion
	Como usuario
	Quiero obtener una lista de los tipos de accion

@ObtenerTiposAccionExistentes
Scenario: Existen tipos de acciones
	Given Tengo tipos de acciones
	When Obtengo los tipos de acciones
	Then Obtengo una lista de los tipos de acciones


