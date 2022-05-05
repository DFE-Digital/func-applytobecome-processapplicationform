# func-applytobecome-processapplicationform

An Azure function used to process submitted application forms from '**Apply to Become an Academy**'.  This will create database records in the database for the application form and also will create the associated project.  This function is designed to run as part of an Azure Data Factory pipeline which will create and populate the source tables when triggered.  Only new application forms will be created and then function will not create any database records if the application form has previously been processed by the function.

## Local Setup

This function runs against Azure Functions runtime v4 and built using .NET 6 Isolated Function architecture.

Please follow the section below relevent to your development environment

<details>
  <summary> VS Code</summary>
  
  * [.NET 6.0 SDK](<https://dotnet.microsoft.com/en-us/download/dotnet/6.0>)
  
  * [Azure Functions Core Tools version 4.x](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local#install-the-azure-functions-core-tools)
  
  * [C# extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)
  
  * [Azure Functions extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)
  
</details>
<details>
  <summary>Visual Studio</summary>
  
  * Visual Studio 2022, which supports .NET 6.0. Make sure to select the **Azure development** workload during installation.
</details>
<details>
  <summary>JetBrains Rider</summary>
  
  * [.NET 6.0 SDK](<https://dotnet.microsoft.com/en-us/download/dotnet/6.0>)
  
  * Go to the Settings (ctrl+alt+s) > Plugins tab and search for "Azure Toolkit for Rider" and install it. Restart Rider.
  
  * Settings > Tools tab: "Azure". Select the Functions subsection, and install the latest version of the Azure Functions Core Tools. Restart Rider.
</details>

You will need to run locally against **Dev** and ensure you have either an environment variable, secret or a local.settings.json file with
the following value set to the the connection string for **Dev Database**:

`__SQLAZURECONNSTR_SqlConnectionString_`

_Note: As we cannot run the ADF pipeline against local Db, we will not have the tables or any data in a local Db._
  
 
Once you have this in place you will be able to run locally and after a few seconds your output window should show the link call the http trigger.
For example: ProcessApplicationForm: [GET] http://localhost:7071/api/ProcessApplicationForm

## Authorisation
  
The function uses Function Level authorisation.  When run locally this is ignored, however when running on Azure it requires the function key to provided as a header in the the API call:
  
`x-functions-key`
  
 This key is found within azure portal by navigating to the Azure Function -> Keys.  You will be able to retrieve the default key from page displayed.
  
  
_Note: The function only processes new application forms based on if the record already exists in the database, so to see the process running through, you will need to use the complete an Apply To Become form in the dev environment and then trigger the function.  At this point it will create the application form and associated project._
  
  

