# ☁️ Backup Google Drive

**Backup Google Drive** é uma aplicação desktop feita em **C# (Windows Forms)** com integração à **API do Google Drive**, permitindo o backup automático de uma pasta local para a nuvem. Ideal para garantir segurança e mobilidade dos arquivos com um clique.

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

Este projeto em **C#** é uma evolução do meu projeto anterior chamado **TkBackupDrive**, que foi desenvolvido em **Python** usando Tkinter para interface gráfica.

Embora o TkBackupDrive tenha sido funcional como prova de conceito, ele apresentava limitações como:

- Interface Tkinter pouco prática para empacotamento e distribuição;
- Lentidão no backup (4 a 5 horas para ~250MB);
- Dificuldades com dependências da Google API em ambientes diferentes.

Buscando mais desempenho, facilidade de uso e melhor integração, reescrevi a aplicação em **C# (Windows Forms)**, mantendo toda a lógica de backup e upload para o Google Drive, agora com:

- Autenticação simplificada;
- Compactação automática em ZIP;
- Upload mais rápido e confiável;
- Interface moderna com **Guna UI2**.

Se quiser conferir a primeira idealização em Python, ele está disponível [aqui](https://github.com/Nathan-Dev-udia/TkBackupDrive)

---

## 📌 Estado atual
O projeto está funcional, com backup completo e upload seguro para o Google Drive. Futuras melhorias podem incluir:

- Agendamento automático de backups;
- Histórico de backups realizados.
