# Sending a Report by Email

This example illustrates how to send exported reports by Email using the viewer

### Installation 
Use npm to install required modules from ClientApp directory:

    npm install

### Step by step
  
#### ViewerController.cs
   
    public IActionResult InitViewer()
    {
      var requestParams = StiAngularViewer.GetRequestParams(this);
      var options = new StiAngularViewerOptions();
      options.Actions.ViewerEvent = "ViewerEvent";
In the options add the action _EmailReport_:

      options.Actions.EmailReport = "EmailReport";
To enable the ability to send Email set the ShowSendEmailButton option in the Toolbar group to true

      options.Toolbar.ShowSendEmailButton = true;
      return StiAngularViewer.ViewerDataResult(requestParams, options);
    }
The EmailReport action will be invoked when you send a report by Email through menu of the viewer. In this action, you can get the email options object of the StiEmailOptions type. In these options will be passed all the data required for sending the Email. You need to fill the necessary options, such as server address, login, password and other. Also you can change the address of the recipient, email subject and body, if it is important (these options are requested in the viewer dialog).
To prepare the answer for the client you should use the EmailReportResult() static method. In the parameters of this method, the email options object should be passed:

    public IActionResult EmailReport()
    {
      StiEmailOptions options = StiAngularViewer.GetEmailOptions(this);
      // Passed from the viewer, can be checked and changed
      // options.AddressTo = "";
      // options.Subject = "";
      // options.Body = "";
      // Should be filled here
      options.AddressFrom = "admin_address@test.com";
      options.Host = "smtp.test.com";
      options.Port = 465;
      options.UserName = "admin_address@test.com";
      options.Password = "admin_password";
      // options.CC.Add("email@test.com");
      // options.BCC.Add("email@test.com");
      // options.EnableSsl = true;
      return StiAngularViewer.EmailReportResult(this, options);
    }
