Feature: ObtenerAccionReciclar
	Para obtener todas las acciones de reciclaje 
	Como usuario
	Quiero obtener una lista de todas las acciones de reciclaje 

@ObtenerAccionesReciclarExistentes
Scenario: Existen acciones de reciclaje 
	Given Tengo acciones de reciclaje 
	When Obtengo las acciones de reciclaje
	Then Obtengo la lista de las acciones de reciclaje 

@ObtenerAccionesReciclarNoExistentes
Scenario: No existen acciones de reciclaje
	Given No tengo acciones de reciclaje 
	When Obtengo las acciones de reciclaje 
	Then No obtengo la lista de las acciones de reciclaje 
