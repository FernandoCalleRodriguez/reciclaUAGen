
package reciclaUAGenReciclaUARESTAzure.uiModels.DTO.enumerations;

/**
 * Code autogenerated. Do not modify this file.
 */
public enum Estado
{
	// region - Literals

	Verificado (1)
	,	EnProceso (2)
	,	Descartado (3)
;

	// endregion


	// region - Members and constructor

	private final int rawValue;

	public int getRawValue ()
	{
		return this.rawValue;
	}

	Estado (int rawValue)
	{
		this.rawValue = rawValue;
	}

	// endregion


	// region - Public methods

	public static Estado fromRawValue (int rawValue)
	{
		Estado[] enumValues = Estado.values();

		for (int i = 0; i < enumValues.length; i++)
		{
			if (enumValues[i].Compare(rawValue))
			{
				return enumValues[i];
			}
		}

		return null;
	}

	public boolean Compare (int rawValue)
	{
		return this.rawValue == rawValue;
	}

	// endregion
	
}
