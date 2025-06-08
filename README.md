# 🛡️ SafeLink - Sistema Inteligente de Monitoramento de Riscos Naturais

## 📄 Descrição do Projeto
O SafeLink é uma API RESTful desenvolvida em ASP.NET Core (.NET 7), voltada ao monitoramento, prevenção e resposta a eventos extremos da natureza. Gerencia alertas, previsões de risco, eventos naturais, regiões monitoradas e relatos dos usuários.

Projeto acadêmico desenvolvido para a Global Solution 2025/1 (FIAP).

## 👨‍💻 Integrantes
- Rafael Rodrigues de Almeida — RM: 557837  
- Lucas Kenji Miyahira — RM: 555368

## 🚀 Tecnologias Utilizadas
- ASP.NET Core 7  
- Entity Framework Core  
- PostgreSQL  
- JWT (autenticação)  
- Swagger (OpenAPI)  

## 🧠 Funcionalidades Principais
- Login e autenticação JWT  
- Cadastro e consulta de usuários  
- Criação e listagem de alertas de risco  
- Registro de eventos naturais  
- Previsões de risco por região  
- Relatos de usuários em tempo real  
- Consulta paginada e ordenada  
- Integração com Swagger para testes e documentação  

## ⚙️ Como Executar Localmente

1. Clone o repositório  
   git clone https://github.com/rafael051/SafeLinkApi.git

2. Abra o projeto no Visual Studio ou rode pelo terminal:  
   dotnet run

3. Configure o banco no appsettings.json com sua instância PostgreSQL:  
   "ConnectionStrings": {  
     "DefaultConnection": "Host=localhost;Port=5432;Database=safelinkdb;Username=rm557837;Password=181088"  
   }

4. Acesse a documentação Swagger em:  
   http://localhost:5000/swagger ou http://localhost:8080/swagger

## 🔐 Autenticação JWT
Todos os endpoints (exceto /auth/login) exigem autenticação com token JWT.

Use no cabeçalho da requisição:  
Authorization: Bearer <seu_token>

Exemplo para login:
POST /auth/login  
{  
  "email": "admin@safelink.com",  
  "password": "admin123"  
}

## 📂 Estrutura das Pastas

SafeLinkApi/  
├── Controllers/  
├── DTOs/  
│   ├── Request/  
│   └── Response/  
├── Models/  
├── Services/  
├── appsettings.json  
├── Program.cs  
└── README.md

## 🧪 Exemplos de Endpoints

Criar Região:  
POST /regioes  
{  
  "nome": "Zona Norte",  
  "cidade": "São Paulo",  
  "estado": "SP",  
  "latitude": -23.5365,  
  "longitude": -46.6333  
}

Cadastrar Alerta:  
POST /alertas  
{  
  "tipo": "Enchente",  
  "nivelRisco": "ALTO",  
  "mensagem": "Evacuar imediatamente a área",  
  "emitidoEm": "2025-06-08T14:00:00",  
  "idRegiao": 1  
}

## 📝 Licença
Projeto acadêmico — sem fins lucrativos.

## ✉️ Contato
- rm557837@fiap.com.br  
- rm555368@fiap.com.br
