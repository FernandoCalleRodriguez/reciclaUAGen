Feature: DescartarMaterial
	Para descartar un material
	Como usuario
	Quiero cambiar el estado del material a descartado

@DescartarMaterial
Scenario: Descartar un material sin descartar
	Given Tengo un material sin descartar
	When Descarto el material
	Then El material es descartado

@DescartarMaterial
Scenario: Descartar un material validado
	Given Tengo un material ya validado
	When Descarto el material
	Then No se puede descartar el material

@DescartarMaterial
Scenario: Descartar un material descartado
	Given Tengo un material ya descartado
	When Descarto el material
	Then No se puede descartar el material