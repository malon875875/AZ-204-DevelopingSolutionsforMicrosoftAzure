# Notes

MVC
* Model: Index.cshtml.cs 
* View: Index.cshtml 
* Controller: ImagesController.cs

* Api.Controllers ImagesController.cs contains the API for fetching all the images stored Blob Container in the Storage Account
* Api.Controllers ImagesController.cs will be in the Azure Web App imgapimarcos

* Web.Pages Index.cshtml.cs contains the Model of the Azure Web App imgwebmarcos
* Web.Pages Index.cshtml contains the View of the Azure Web App imgwebmarcos

* Storage Account will contain the jpg in Images
* The Access Key from the Storage Account is given as the application setting (aka global parameter) "StorageConnectionString" to the API in Azure (Web App containing ImagesController.cs)
* The API ImagesController.cs will prove that it is allowed using the Storage Account by passing the "StorageConnectionString" to BlobServiceClient
 * BlobServiceClient serviceClient = new BlobServiceClient(_options.StorageConnectionString);
