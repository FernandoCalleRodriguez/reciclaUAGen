Feature: CrearAccionReciclar
	Para crear una accion de reciclaje
	Como usuario  
	Quiero crear una accion de reciclaje

@CrearNuevaAccionReciclaje
Scenario: Crear una nueva accion de reciclaje
	Given Quiero crear una nueva accion de reciclaje
		| cantidad | 
		| 300 | 
	And Logueado con el usuario 32769
	When Creo la accion de reciclaje
	Then Obtengo la accion de reciclaje