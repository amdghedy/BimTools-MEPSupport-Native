using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;

namespace Hangerduct;

public class PipeDuctCableTraySelectionFilter : ISelectionFilter
{
	public bool AllowElement(Element elem)
	{
		return elem is Pipe || elem is Duct || elem is CableTray;
	}

	public bool AllowReference(Reference reference, XYZ position)
	{
		return false;
	}
}
