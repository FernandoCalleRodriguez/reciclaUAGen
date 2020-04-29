Feature: ObtenerMaterialesPorValidar
	Para obtener los materiales por validar
	Como usuario
	Quiero obtener una lista de los materiales por validar

@ObtenerMaterialesPorValidar
Scenario: Existen materiales por validar
	Given Tengo materiales sin validar
	When Obtengo los materiales por validar
	Then Obtengo una lista con los materiales por validar