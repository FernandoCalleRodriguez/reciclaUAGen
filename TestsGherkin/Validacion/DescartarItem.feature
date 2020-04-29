Feature: DescartarItem
	Para descartar un item
	Como usuario
	Quiero cambiar el estado del item a descartado

@DescartarItem
Scenario: Descartar un item sin descartar
	Given Tengo un item sin descartar
	When Descarto el item
	Then El item es descartado

@DescartarItem
Scenario: Descartar un item validado
	Given Tengo un item ya validado
	When Descarto el item
	Then No se puede descartar el item

@DescartarItem
Scenario: Descartar un item descartado
	Given Tengo un item ya descartado
	When Descarto el item
	Then No se puede descartar el item