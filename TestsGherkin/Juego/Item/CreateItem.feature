Feature: CreateItem
	para crear un Item nuevo
	como usuario
	quiero informar su numero y pontuacion

@CreateItem
Scenario: Crear un Item nuevo
	Given Quiero crear un Item nuevo con numero y pontuacion specifica
	When Creo el Item 
	Then Se Creo el Item