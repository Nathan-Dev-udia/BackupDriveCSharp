# ☁️ Backup Google Drive
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D7?style=flat&logo=windows&logoColor=white)
![Google Drive API](https://img.shields.io/badge/Google%20Drive%20API-4285F4?style=flat&logo=google-drive&logoColor=white)

**Backup Google Drive** é uma aplicação desktop feita em **C# (Windows Forms)** que realiza o **envio automático de uma pasta local para o Google Drive**, com apenas um clique.
Ideal para quem precisa fazer backups frequentes de forma **prática, rápida e sem complicações** — sem necessidade de configurar compartilhamentos manuais ou sincronizações do Drive.
Com autenticação via API oficial do Google, o sistema cria uma pasta com data e hora no Drive e envia um arquivo ZIP contendo todos os arquivos da pasta local definida.

---

## 🧠 Funcionalidades

- 🔐 Tela de **login com autenticação simples**;
- 📦 Compactação automática da pasta em `.zip`;
- ☁️ **Upload do ZIP para uma pasta no Google Drive**;
- 🕒 Criação de uma subpasta no Drive com data e hora do backup;
- ✅ Interface amigável com **Guna UI2**.

---

## 📂 Estrutura

- `Form1.cs`: Tela inicial com login (`admin` / `1234`);
- `tela1.cs`: Tela principal que realiza o backup;
- `Program.cs`: Ponto de entrada da aplicação.

---

## 🛠️ Tecnologias e Bibliotecas

- **C# / Windows Forms**
- **Google Drive API v3**
- **Google.Apis.Auth.OAuth2**
- **System.IO.Compression**
- **Guna UI2**
- **Inno Setup** (para criar o instalador do programa).

---

## ▶️ Como rodar o projeto

1. Instale as dependências via **NuGet** (Google.Apis.Drive.v3, Google.Apis.Auth, etc);
2. Coloque seu arquivo `client_secret_*.json` na pasta do projeto (não faça push disso!);
3. Defina o ID da pasta no Drive (você pode obter isso pela URL do Drive);
4. Configure o caminho da pasta local no código tela1.cs:
   string caminhoPastaLocal = @"C:\PRO\aqui";
5. Compile e execute. Ao logar, clique em “Sim” para iniciar o backup.

---

## 🚀 Evolução do Projeto

Este projeto em **C#** é uma evolução do meu projeto anterior chamado [**TkBackupDrive**](https://github.com/Nathan-Dev-udia/TkBackupDrive), que foi desenvolvido em **Python** usando Tkinter para interface gráfica.

Embora o TkBackupDrive tenha sido funcional como prova de conceito, ele apresentava limitações como:

- Interface Tkinter pouco prática para empacotamento e distribuição;
- Lentidão no backup (4 a 5 horas para ~250MB);
- Necessidade de instalar o Python, VS Code e todas as dependências em cada máquina onde o programa fosse rodar;

Buscando mais desempenho, facilidade de uso e melhor integração, reescrevi a aplicação em **C# (Windows Forms)**, mantendo toda a lógica de backup e upload para o Google Drive, agora com:

- Autenticação simplificada;
- Compactação automática em ZIP;
- Conclusão do upload em segundos;
- Interface moderna com **Guna UI2**.
- Distribuição facilitada: basta instalar e usar, sem necessidade de configurar dependências ou ambientes manualmente.

---

## 📌 Estado atual
O projeto está funcional, com backup completo e upload seguro para o Google Drive. Futuras melhorias podem incluir:

- Agendamento automático de backups;
- Histórico de backups realizados.

> Projeto criado por Nathan Fernandes Alves para automatizar backups locais, compactação e o envio de pastas diretamente ao Google Drive.
