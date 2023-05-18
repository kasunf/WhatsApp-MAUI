namespace WhatsApp;
using RestSharp;
using WhatsappBusiness.CloudApi;
using WhatsappBusiness.CloudApi.Configurations;
using WhatsappBusiness.CloudApi.Messages.Requests;
using WhatsappBusiness.CloudApi.Media.Requests;
public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        WhatsAppBusinessCloudApiConfig whatsAppConfig = new WhatsAppBusinessCloudApiConfig();
        whatsAppConfig.WhatsAppBusinessPhoneNumberId = "";
        whatsAppConfig.WhatsAppBusinessAccountId = "";
        whatsAppConfig.WhatsAppBusinessId = "";
        whatsAppConfig.AccessToken = "";

        string path = "";
        string no = "";

        var httpClient = new HttpClient();

        httpClient.BaseAddress = WhatsAppBusinessRequestEndpoint.BaseAddress;

        var whatsAppBusinessClient = new WhatsAppBusinessClient(httpClient, whatsAppConfig);


        string fileName = path;
        FileInfo fi = new FileInfo(fileName);
        UploadMediaRequest uploadrequest = new UploadMediaRequest();
        uploadrequest.File = path;
        uploadrequest.Type = "application/pdf";
        var media =  whatsAppBusinessClient.UploadMediaAsync(uploadrequest);
        //var uploadSessionId = await whatsAppBusinessClient.CreateResumableUploadSessionAsync(fi.Length, "application/pdf", fi.Name);

        //var media = await whatsAppBusinessClient.UploadFileDataAsync(uploadSessionId.Id, path, "application/pdf");

        //var url = await whatsAppBusinessClient.GetMediaUrlAsync(media.Id);

        DocumentMessageByIdRequest documentMessage = new DocumentMessageByIdRequest();
        documentMessage.To = no;
        documentMessage.Document = new MediaDocument();
        documentMessage.Document.Id = media.Id.ToString();
        documentMessage.Document.Caption = "hello";
        documentMessage.Document.Filename = "hello.pdf";

  
         whatsAppBusinessClient.SendDocumentAttachmentMessageByIdAsync(documentMessage); ;
    }
}

