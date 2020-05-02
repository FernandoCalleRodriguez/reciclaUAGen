Feature: ObtenerAccionReciclarPorFecha
	Para obtener todas las acciones de reciclaje filtradas por una fecha
	Como usuario
	Quiero obtener una lista de todas las acciones de reciclaje filtradas por una fecha

@ObtenerAccionesReciclarPorFecha
Scenario: Existen acciones de reciclaje con la fecha indicada
	Given Tengo acciones de reciclaje con la fecha indicada
	When Obtengo las acciones de reciclaje con la fecha 
	| fecha| 
	| hoy | 
	Then Obtengo la lista de las acciones de reciclaje con la fecha indicada

@ObtenerAccionesReciclarPorFechaNoExistente
Scenario: No existen acciones de reciclaje con la fecha indicada
	Given No tengo acciones de reciclaje con la fecha indicada
	When Obtengo las acciones de reciclaje con la fecha 
	| fecha| 
	| hoy | 
	Then No obtengo la lista de las acciones de reciclaje con la fecha indicada
