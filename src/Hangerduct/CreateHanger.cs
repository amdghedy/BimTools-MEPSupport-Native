using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Hangerduct;

[Transaction(TransactionMode.Manual)]
public class CreateHanger : IExternalCommand
{
	public static Application Application { get; set; }

	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		UIApplication application = commandData.Application;
		UIDocument activeUIDocument = application.ActiveUIDocument;
		Document document = activeUIDocument.Document;
		using MainForm mainForm = new MainForm();
		DialogResult dialogResult = mainForm.ShowDialog();
		if (dialogResult == DialogResult.Cancel)
		{
			return (Result)1;
		}
		double iValue = mainForm.IValue;
		double spaceValue = mainForm.SpaceValue;
		double thicknessInput = mainForm.ThicknessInput;
		double bartypeInput = mainForm.BartypeInput;
		switch (mainForm.SelectedOption)
		{
		case MainForm.Option.Pipe:
		{
			PipeHangerCommand pipeHangerCommand = new PipeHangerCommand(iValue, spaceValue, thicknessInput, bartypeInput);
			return pipeHangerCommand.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.Pipec:
		{
			PipeHangerclevis pipeHangerclevis = new PipeHangerclevis(iValue, spaceValue, thicknessInput, bartypeInput);
			return pipeHangerclevis.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.Pipeb:
		{
			PipeHangerBEND pipeHangerBEND = new PipeHangerBEND(iValue, spaceValue, thicknessInput, bartypeInput);
			return pipeHangerBEND.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.Pipebase:
		{
			HangerBase hangerBase = new HangerBase(iValue, spaceValue);
			return hangerBase.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.Duct:
		{
			DuctHangerCommand ductHangerCommand = new DuctHangerCommand(iValue, spaceValue, thicknessInput, bartypeInput);
			return ductHangerCommand.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.DuctBase:
		{
			ductCommandB ductCommandB2 = new ductCommandB(iValue, spaceValue, thicknessInput, bartypeInput);
			return ductCommandB2.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.DuctR:
		{
			DuctHangerCommandREC ductHangerCommandREC = new DuctHangerCommandREC(iValue, spaceValue, thicknessInput, bartypeInput);
			return ductHangerCommandREC.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.CableTray:
		{
			CableTrayHangerCommand cableTrayHangerCommand = new CableTrayHangerCommand(mainForm.IValue, mainForm.SpaceValue, bartypeInput);
			return cableTrayHangerCommand.Execute(commandData, ref message, elements);
		}
		case MainForm.Option.Cable_TrayREC:
		{
			Cable_TrayREC cable_TrayREC = new Cable_TrayREC(mainForm.IValue, mainForm.SpaceValue, bartypeInput);
			return cable_TrayREC.Execute(commandData, ref message, elements);
		}
		default:
			TaskDialog.Show("Error", "Unsupported element type selected.");
			return (Result)(-1);
		}
	}
}
