# Localizing the Viewer

This example illustrates how to to localize the viewer. To select localization, it is enough to set the path to the localization XML file as the value of the Localization option.

### Step by step
  
#### ViewerController.cs
   
    public IActionResult InitViewer()
    {
       var requestParams = StiAngularViewer.GetRequestParams(this);
       var options = new StiAngularViewerOptions();
       options.Actions.ViewerEvent = "ViewerEvent";
       
Set the path to the localization XML file as the value of the Localization option:
       
       options.Localization = StiAngularHelper.MapPath(this, "Localization/de.xml");
       return StiAngularViewer.ViewerDataResult(requestParams, options);
    }
