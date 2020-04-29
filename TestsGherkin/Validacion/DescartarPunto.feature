Feature: DescartarPunto
	Para descartar un punto
	Como usuario
	Quiero cambiar el estado del punto a descartado

@DescartarPunto
Scenario: Descartar un punto sin descartar
	Given Tengo un punto sin descartar
	When Descarto el punto
	Then El punto es descartado

@DescartarPunto
Scenario: Descartar un punto validado
	Given Tengo un punto ya validado
	When Descarto el punto
	Then No se puede descartar el punto

@DescartarPunto
Scenario: Descartar un punto descartado
	Given Tengo un punto ya descartado
	When Descarto el punto
	Then No se puede descartar el punto