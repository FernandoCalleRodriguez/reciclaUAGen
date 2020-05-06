Feature: CreateContenedor
	para crear un Contenedor nuevo
	como usuario
	quiero informar su numero y pontuacion

@CreateContenedor
Scenario: Crear un Contenedor nuevo
	Given Quiero crear un Contenedor nuevo con numero y pontuacion specifica
	When Creo el Contenedor 
	Then Se Creo el Contenedor
