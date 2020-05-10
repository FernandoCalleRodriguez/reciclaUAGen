Feature: DeletePunto
	Para borrar un Punto
	Como usuario
	Quiero borrar el Punto

@DeletePunto
Scenario: Borrar Punto existente
	Given Hay un Punto con un id especifico
	When Elimino El Punto
	Then Se borra el Punto

	
@DeletePunto
Scenario: Borrar Punto no existente
	Given No hay un Punto con un id especifico
	When  Entento elimino El Punto
	Then  no se borra el Punto
