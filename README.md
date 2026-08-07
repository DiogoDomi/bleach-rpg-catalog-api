# 🌐 Bleach: Soul Resonance - Catalog API (`bleach-rpg-catalog-api`)

## 📖 Sobre
Este é o repositório de Back-end do projeto **Bleach: Soul Resonance -> Game Guide**.
Trata-se de uma API RESTful de alta performance, projetada para servir como o *hub* principal de fornecimento de dados do game.

**🔗 Ecossistema do Projeto:**
Esta API é o núcleo do ecossistema, conectando a base de dados ao cliente final:
- 📥 **Recebe de:** O banco de dados consumido aqui é gerado e atualizado pelo **[Data Pipeline em Python (bleach-rpg-data-info)](https://github.com/DiogoDomi/bleach-rpg-data-info)**.
- 📤 **Fornece para:** Os dados expostos por esta API são consumidos pela interface/engine no **[Build Calculator (bleach-rpg-build-calculator)](https://github.com/DiogoDomi/bleach-rpg-build-calculator)**.

## ⚙️ Funcionalidades e Workflow
- Atua como a camada intermediária entre o processamento de dados e o motor da aplicação.
- Consome diretamente o banco de dados `.db` gerado pelo repositório `bleach-rpg-data-info`.
- Expõe os dados estruturados (personagens, armas, stamps, custos, etc.) via endpoints HTTP.
- **Nota de Domínio:** Esta API é um serviço estático de consulta. Não há persistência de dados de usuários, transações ou comunicação direta com os servidores oficiais do jogo.

## 🛠️ Tecnologias
- **Linguagem:** C#
- **Micro-ORM:** Dapper
- **Banco de Dados:** SQLite

