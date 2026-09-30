# ArchOr - Organizador de Arquivos Cartorários

<img width="1732" height="504" alt="Logotipo ArchOr" src="https://github.com/user-attachments/assets/3b6dcc51-a867-4de7-9ce7-acd9773bf866" />


## Sobre o Projeto
O **ArchOr** é uma aplicação desktop desenvolvida em C# (Windows Forms) criada para automatizar e otimizar o fluxo de triagem de documentos digitais em Cartórios de Registo de Imóveis. 

Na rotina diária, a digitalização em massa gera dezenas de ficheiros com nomes genéricos (ex: `img_001.jpg`), tornando o arquivamento por protocolo e categoria num processo manual, lento e suscetível a falhas. O ArchOr resolve este problema ao fornecer um ambiente centralizado onde o utilizador visualiza o documento digitalizado em tempo real e o encaminha para a estrutura de pastas correta, já devidamente renomeado e organizado, com apenas alguns cliques.

## Funcionalidades Principais
* **Visualizador Dinâmico (Sem Bloqueio de Ficheiro):** O sistema utiliza `FileStream` para carregar a imagem na memória. Isto permite que o utilizador visualize o documento original sem que o ficheiro fique "trancado" pelo Windows, garantindo que a cópia e o arquivamento ocorram sem erros.
* **Categorização e Renomeação Automática:** Separação imediata por tipos de documento (CIQR, Nota de Exigência, Documento de Arquivo e Título de Registo) com controlo interno de contagem (ex: `CIQR(1).jpg`, `CIQR(2).jpg`).
* **Proteção contra Sobrescrita:** Sistema de validação de diretórios que impede a modificação acidental de pastas de protocolos já existentes.
* **Gestão de Sessão (Cache Local):** Gravação automática dos últimos caminhos de origem e destino utilizados num ficheiro `config.txt` oculto, poupando tempo na reabertura do sistema.
* **Processamento Assíncrono da Interface:** Remoção dinâmica apenas das linhas processadas da grelha de trabalho, mantendo os documentos não categorizados intactos para triagens futuras.

## Tecnologias Utilizadas
* **Linguagem:** C# 10.0+
* **Framework:** .NET (Windows Forms)
* **Manipulação de Ficheiros (I/O):** `System.IO`

## Como Executar
1. Clone este repositório: `git clone https://github.com/SeuUsuario/ArchOr.git`
2. Abra o ficheiro `.sln` no Visual Studio.
3. Prima `F5` para compilar e executar o projeto.

## Autor
**Diego Souza**  
*Desenvolvedor de Software*  
[LinkedIn](https://www.linkedin.com/in/diego-gon%C3%A7alves-souza-6bb132179/?isSelfProfile=true) | [GitHub](https://github.com/iTzMeDieGoO)
