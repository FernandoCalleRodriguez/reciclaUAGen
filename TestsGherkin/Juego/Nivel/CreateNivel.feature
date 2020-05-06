Feature: CreateNivel
	para crear un nivel nuevo
	como usuario
	quiero informar su numero y pontuacion

@CreateNivel
Scenario: Crear un nivel nuevo
	Given Quiero crear un nivel nuevo con numero y pontuacion specifica
	When Creo el nivel 
	Then Se Creo el nivel
