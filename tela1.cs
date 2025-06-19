using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression; // Adicionado para ZipFile
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;

// Alias para a classe File do Google Drive e System.IO
using GoogleDriveFile = Google.Apis.Drive.v3.Data.File;
using SystemFile = System.IO.File;

namespace backup
{
    public partial class tela1 : Form
    {
        public tela1()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Fecha todo o programa ao fechar a tela
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string credenciaisPath = Path.Combine(Application.StartupPath, "client_secret_276549656547-553g6v2k2d661e2qfhod7fahtr5j9epf.apps.googleusercontent.com.json"); // Caminho do arquivo de credenciais /////////////////////////////////////////////////////////////////////

            if (!SystemFile.Exists(credenciaisPath)) // Usando SystemFile alias
            {
                MessageBox.Show("Arquivo de credenciais não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pastaRaizId = "1vy9OmI6qJBseL3ZkH_1RBlxE_8V7g-lm"; // ID da pasta principal no Google Drive /////////////////////////////////////////////////////////////////////

            try
            {
                // Autenticação
                UserCredential credential;
                using (var stream = new System.IO.FileStream(credenciaisPath, FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
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

                // Criar pasta com data e hora no Google Drive
                string nomePastaBackup = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                var novaPasta = new GoogleDriveFile()
                {
                    Name = nomePastaBackup,
                    MimeType = "application/vnd.google-apps.folder",
                    Parents = new List<string> { pastaRaizId }
                };

                var requestPasta = service.Files.Create(novaPasta);
                requestPasta.Fields = "id";
                var pastaCriada = await requestPasta.ExecuteAsync();
                string pastaBackupId = pastaCriada.Id;

                // Caminho da pasta local ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string caminhoPastaLocal = @"C:\PRO\aqui";

                // Criar o arquivo ZIP
                string zipPath = Path.Combine(Application.StartupPath, $"{nomePastaBackup}.zip");
                ZipFile.CreateFromDirectory(caminhoPastaLocal, zipPath);

                // Enviar o arquivo ZIP para o Google Drive
                var fileMetadata = new GoogleDriveFile()
                {
                    Name = $"{nomePastaBackup}.zip",
                    Parents = new List<string> { pastaBackupId } // Enviar para a nova pasta criada
                };

                FilesResource.CreateMediaUpload request;
                using (var stream = new FileStream(zipPath, FileMode.Open))
                {
                    request = service.Files.Create(fileMetadata, stream, "application/zip");
                    request.Fields = "id";
                    await request.UploadAsync();
                }

                MessageBox.Show($"Backup concluído! Arquivo ZIP enviado para a pasta '{nomePastaBackup}' no Google Drive.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpar o arquivo ZIP temporário
                SystemFile.Delete(zipPath); // Usando SystemFile alias
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer o backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botão "Não"
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // Criar uma nova instância do Form1
            form1.Show(); // Mostrar Form1
            this.Dispose(); // Fechar tela1 completamente
        }
    }
}