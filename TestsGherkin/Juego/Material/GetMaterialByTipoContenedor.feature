Feature: GetMaterialByTipoContenedor
		Para buscar un material por TipoContenedor
		Como usuario
		Quiero obtener una lista de materiales de ese TipoContenedor

@GetMaterialByTipoContenedor
Scenario: Obtener materiales por un TipoContenedor existante
	Given Tengo materiales de un TipoContenedor específico
	When Busco esos material por su TipoContenedor
	Then obtengo una lista de materiales de este TipoContenedor

@GetMaterialByTipoContenedorDoesntExist
Scenario: Obtener materiales por un TipoContenedor inexistente
	Given No hay un material de tipo Cristal
	When Busco un material por ese tipo
	Then Obtengo una lista vacia

