# 📦 AWS S3 File Upload API (.NET 9 + DDD)

Este projeto é uma API desenvolvida em **.NET 9** com padrão **DDD (Domain-Driven Design)** que permite **fazer upload, visualizar e baixar arquivos e imagens** diretamente de um bucket da **AWS S3**.

---

## 🚀 Funcionalidades

- ✅ Upload de arquivos para um bucket S3
- ✅ Retorno da URL pública do arquivo (caso o bucket ou objeto seja público)
- ✅ Endpoint para **visualização** de imagem via stream
- ✅ Endpoint para **download** de arquivo
- ✅ Uso de **variáveis de ambiente** para as credenciais da AWS (nada de secrets no código!)
- ✅ Projeto estruturado em **camadas com DDD**:
  - `Api`
  - `Domain`
  - `Infrastructure`

---

## 🧱 Estrutura do Projeto

📁 Core/
│
├── Api/ → Camada de apresentação (controllers, Program.cs)
├── Application/ → 
├── Domain/ → Interfaces, configuração de conexão, modelos e regras de negócio
└── Infrastructure/ → Conexão com AWS S3 e repositorios

---

## 🔧 Variáveis de Ambiente

Crie as seguintes variáveis no seu sistema ou no `.env` (se usar `dotnet user-secrets`, configure ali):

```env
AWS_ACCESS_KEY=SEU_ACCESS_KEY
AWS_SECRET_KEY=SEU_SECRET_KEY
AWS_REGION=us-east-1
AWS_BUCKET_NAME=nome-do-seu-bucket

Kauê Correia
Desenvolvedor Back-End | C# • SQL • AWS