using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using System.IO;
using System.Threading;

// Alias para a classe File do Google Drive
using GoogleDriveFile = Google.Apis.Drive.v3.Data.File;

namespace backup
{
    public partial class tela1 : Form
    {
        public tela1()
        {
            InitializeComponent();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string credenciaisPath = Path.Combine(Application.StartupPath, "client_secret_276549656547-553g6v2k2d661e2qfhod7fahtr5j9epf.apps.googleusercontent.com.json");

            // Usando System.IO.File para evitar ambiguidade
            if (!System.IO.File.Exists(credenciaisPath))
            {
                MessageBox.Show("Arquivo de credenciais não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pastaId = "1vy9OmI6qJBseL3ZkH_1RBlxE_8V7g-lm"; // ID da pasta de destino no Google Drive

            try
            {
                UserCredential credential;
                using (var stream = new System.IO.FileStream(credenciaisPath, FileMode.Open, FileAccess.Read)) // Usando System.IO.FileStream
                {
                    // Alterado para usar FromStream, método mais recente
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets, // Mudança para FromStream
                        new[] { DriveService.Scope.DriveFile },
                        "user",
                        CancellationToken.None
                    );
                }

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Backup Google Drive",
                });

                string caminhoPastaLocal = @"C:\PRO\aqui";

                DirectoryInfo di = new DirectoryInfo(caminhoPastaLocal);
                foreach (var file in di.GetFiles())
                {
                    var fileMetadata = new GoogleDriveFile()  // Usando o alias GoogleDriveFile
                    {
                        Name = file.Name,
                        Parents = new List<string> { pastaId }
                    };

                    FilesResource.CreateMediaUpload request;
                    using (var stream = new System.IO.FileStream(file.FullName, FileMode.Open)) // Usando System.IO.FileStream
                    {
                        request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                        request.Fields = "id";
                        await request.UploadAsync();
                    }
                }

                MessageBox.Show("Backup concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer o backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}