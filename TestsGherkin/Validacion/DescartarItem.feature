Feature: DescartarItem
	Para descartar un item
	Como usuario
	Quiero cambiar el estado del item a descartado

Scenario: Descartar un item sin descartar
	Given Tengo un item sin descartar
	When Descarto el item
	Then El item es descartado

Scenario: Descartar un item validado
	Given Tengo un item ya validado
	When Descarto el item
	Then No se puede descartar el item

Scenario: Descartar un item descartado
	Given Tengo un item ya descartado
	When Descarto el item
	Then No se puede descartar el item
