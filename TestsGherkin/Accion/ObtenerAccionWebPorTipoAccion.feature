Feature: ObtenerAccionWebPorTipoAccion
	Para obtener todas las acciones web filtradas por un tipo de accion
	Como usuario
	Quiero obtener una lista todas las acciones web filtradas por un tipo de accion

@ObtenerAccionesWebConTipoAccion
Scenario: Existen acciones web con el tipo de accion indicado
	Given Tengo acciones web con el tipo de accion
	When Obtengo las acciones web con el tipo de accion
		| tipo        |
		| Tipo Prueba |
	Then Obtengo la lista de las acciones web con el tipo de accion

@ObtenerAccionesWebConTipoAccionNoExistente
Scenario: No existen acciones web con el tipo de accion indicado
	Given No tengo acciones web con el tipo de accion 
	When Obtengo las acciones web con el tipo de accion
		| tipo        |
		| Tipo Prueba |
	Then No obtengo la lista de las acciones web con el tipo de accion
