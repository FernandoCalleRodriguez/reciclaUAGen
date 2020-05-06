Feature: ObtenerAccionReciclarPorAutor
	Para obtener todas las acciones de reciclaje filtradas por un autor
	Como usuario
	Quiero obtener una lista de todas las acciones de reciclaje filtradas por un autor

@ObtenerAccionesReciclarPorAutor
Scenario: Existen acciones de reciclaje con el autor indicado
	Given Tengo acciones de reciclaje con el autor indicado
	When Obtengo las acciones de reciclaje con el autor 32769
	Then Obtengo la lista de las acciones de reciclaje con el autor indicado

@ObtenerAccionesReciclarPorAutorNoExistente
Scenario: No existen acciones de reciclaje con el autor indicado
	Given No tengo acciones de reciclaje con el autor indicado
	When Obtengo las acciones de reciclaje con el autor 1
	Then No obtengo la lista de las acciones de reciclaje con el autor indicado
