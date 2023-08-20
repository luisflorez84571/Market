using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Class Country
	{
		public int Id{get; set;}
		[Display (Name="Pais")]
		[MaxLength(100)]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Name { get; set; } = null;
		
	}
}
