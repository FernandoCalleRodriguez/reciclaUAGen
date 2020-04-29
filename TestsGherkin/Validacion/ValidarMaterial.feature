Feature: ValidarMaterial
	Para validar un material
	Como usuario
	Quiero cambiar el estado del material a validado

@ValidarMaterial
Scenario: Validar un material sin validar
	Given Tengo un material sin validar
	When Valido el material
	Then El material es validado

@ValidarMaterial
Scenario: Validar un material validado
	Given Tengo un material validado
	When Valido el material
	Then No se puede validar el material

@ValidarMaterial
Scenario: Validar un material descartado
	Given Tengo un material descartado
	When Valido el material
	Then No se puede validar el material