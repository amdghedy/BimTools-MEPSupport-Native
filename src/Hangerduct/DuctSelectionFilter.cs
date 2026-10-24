using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI.Selection;

namespace Hangerduct;

public class DuctSelectionFilter : ISelectionFilter
{
	public bool AllowElement(Element elem)
	{
		return elem is Duct;
	}

	public bool AllowReference(Reference reference, XYZ position)
	{
		return false;
	}
}
