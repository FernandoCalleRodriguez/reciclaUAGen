Feature: CreatePunto
	para crear un Punto nuevo
	como usuario
	quiero informar su numero y pontuacion

@CreatePunto
Scenario: Crear un Punto nuevo
	Given Quiero crear un Punto nuevo con numero y pontuacion specifica
	When Creo el Punto 
	Then Se Creo el Punto
