Feature: CreateEdificio
	para crear un Edificio nuevo
	como usuario
	quiero informar su numero y pontuacion

@CreateEdificio
Scenario: Crear un Edificio nuevo
	Given Quiero crear un Edificio nuevo con numero y pontuacion specifica
	When Creo el Edificio 
	Then Se Creo el Edificio
