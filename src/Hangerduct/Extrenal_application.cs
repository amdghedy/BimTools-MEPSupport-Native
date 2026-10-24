using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace Hangerduct;

/// <summary>
/// External application entry. Registers Hanger Generator under Revit tab "BIM TOOLS" / panel "MEP Tools".
/// Behaviour of the command itself is unchanged from the source project.
/// </summary>
internal class Extrenal_application : IExternalApplication
{
	private const string TabName = "BIM TOOLS";
	private const string PanelName = "MEP Tools";
	private const string ButtonName = "HAN_But";
	private const string ButtonText = "Hanger Generator";
	private const string ButtonClass = "Hangerduct.CreateHanger";
	private const string ButtonToolTip = "Create Hangers for Ducts & Pipes and Cabletrays";
	private const string EmbeddedIcon = "Hangerduct.Resources.AGG.png";

	public Result OnShutdown(UIControlledApplication application)
	{
		return Result.Succeeded;
	}

	public Result OnStartup(UIControlledApplication application)
	{
		try
		{
			EnsureTab(application, TabName);
			RibbonPanel panel = GetOrCreatePanel(application, TabName, PanelName);

			// Prevent duplicate buttons if the add-in is loaded more than once
			if (panel.GetItems().Any(i => i.Name == ButtonName))
			{
				return Result.Succeeded;
			}

			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			PushButtonData buttonData = new PushButtonData(
				ButtonName,
				ButtonText,
				executingAssembly.Location,
				ButtonClass);

			RibbonItem item = panel.AddItem(buttonData);
			if (item is PushButton pushButton)
			{
				ImageSource icon = GetImageSource(EmbeddedIcon);
				if (icon != null)
				{
					pushButton.LargeImage = icon;
				}
				pushButton.ToolTip = ButtonToolTip;

				// Keep original contextual help target when present
				try
				{
					ContextualHelp contextualHelp = new ContextualHelp(
						ContextualHelpType.Url,
						"file:///C:/ProgramData/Autodesk/ApplicationPlugins/AG%20Hanger%20Generator.bundle/Contents/Help/help.html");
					pushButton.SetContextualHelp(contextualHelp);
				}
				catch
				{
					// Help file may not exist on all machines; ignore
				}
			}

			return Result.Succeeded;
		}
		catch (Exception)
		{
			return Result.Failed;
		}
	}

	private static void EnsureTab(UIControlledApplication application, string tabName)
	{
		try
		{
			application.CreateRibbonTab(tabName);
		}
		catch (ArgumentException)
		{
			// Tab already exists — reuse it
		}
	}

	private static RibbonPanel GetOrCreatePanel(UIControlledApplication application, string tabName, string panelName)
	{
		IList<RibbonPanel> panels = application.GetRibbonPanels(tabName);
		RibbonPanel existing = panels?.FirstOrDefault(p => p.Name == panelName);
		if (existing != null)
		{
			return existing;
		}
		return application.CreateRibbonPanel(tabName, panelName);
	}

	private static ImageSource GetImageSource(string imageEmbeddedPath)
	{
		Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imageEmbeddedPath);
		if (stream == null)
		{
			return null;
		}
		PngBitmapDecoder decoder = new PngBitmapDecoder(
			stream,
			BitmapCreateOptions.PreservePixelFormat,
			BitmapCacheOption.Default);
		return decoder?.Frames?[0];
	}
}
