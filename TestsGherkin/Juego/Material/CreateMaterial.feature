Feature: CreateMaterial
	para crear un material nuevo
	como usuario
	quiero informar sus informaciones

@CreateMaterial
Scenario: Crear un material nuevo
	Given Quiero crear un material nuevo con informaciones specificas
	When Creo el material 
	Then Se Creo el material
