# Módulo de Não-Conformidades
##### Teste prático para a vaga de Desenvolvedor na QualyTeam
###### Matheus Duarte Sacramento
###### Contatos: [Email](mdsacra@gmail.com) - [Linkedin](http://linkedin.com/in/mdsacra)
---
### Sumário
1) Sobre o projeto
2) Como executar
3) Entidades
4) End-points
5) Conclusão


### 1. Sobre o projeto
O projeto **Módulo de Não-conformidades** tem como objetivo apresentar o desenvolvimento em Linguagem **C#** do *Backend* de algumas funcionalidades básicas para o cadastro de Não-conformidades e suas Ações de Correção em um Sistema de Gestão de Qualidade. Os requisitos solicitados e desenvolvidos nesta aplicação são os seguintes:
- Cadastrar novas Não-conformidades
- Gerar código da Não-conformidade
- Cadastrar novas Ações de Correção
- Avaliar uma Não-conformidade
- Inserir Ações de Correção em uma Não-conformidade
- Buscar Não-conformidades

### 2. Como Executar
Basta clonar o repositório com o comando abaixo:<br>
```git clone https://github.com/mdsacra/NC_Module.git```<br>
 A seguir, tendo o .NET Core corretamente instalado no computador, executar o arquivo **NC_Module.exe**, que encontra-se em ```NC_Module/bin/release/netcoreapp3.1```. A aplicação subirá o servidor em ```localhost:\\5000```. Sugere-se utilizar o programa *Postman* para realizar os testes de requisição.

### 3. Entidades
As duas entidades que foram desenvolvidas no projeto foram **NonConf**, para não conformidades, e **CorrAction**, para as Ações de Correção.
Vale destacar que:
- **NonConf** possui geração automática da data de criação da Não-conformidade, bem como a geração do código em uma *string*. O atributo **_Status_** é do tipo *int* e inicia em ```0```, o que indica que a Não-conformidade está aberta, ele pode receber os valores ```1```, para Eficaz, e ```2```, para Ineficaz, ambos encerram a Não-conformidade. O atributo **_Version_** inicia em ```1``` e alterado conforme a Não-conformidade é avaliada como Ineficaz.
- **CorrAction** possui um atributo **_Description_**, que é obrigatório.
### 4. Endpoints
Segue a lista dos *Endpoints* do projeto para requisições HTTP:
##### Não-conformidades
- [**GET**]: ```/NonConf/{Id}``` -> Buscar uma Não-conformidade específica através de sua Id.
- [**GET**]: ```/NonConf/{All}``` -> Buscar a lista de todas as Não-conformidades
- [**POST**]: ```/NonConf``` -> Salva uma nova Não-conformidade.
- [**PUT**]:```/NonConf``` ->  Este método é somente para Avaliação da Não-conformidade, portanto é necessário passar os atributos **_Id_** e **_Status_** no corpo da requisição, conforme abaixo:
```
{
    "Id":1,
    "Status":2
}
```

##### Ações de Correção
- [**GET**]: ```/CorrAction/{Id}``` -> Buscar uma Ação específica através de sua Id.
- [**GET**]: ```/CorrAction/{All}``` -> Buscar a lista de todas as Ações
- [**POST**]: ```/CorrAction``` -> Salva uma nova Ação.

##### Inserção das Ações de Correção nas Não-conformidades
- [**POST**]: ```/NonConfCorrActions``` -> Vincula uma Ação a uma Não-conformidade, para isto, basta passar no corpo da requisição o **_Id_** da Não conformidade (atributo **_NonconfId_**) e o **_Id_** da Ação (atributo **_CorractionId_**), conforme abaixo:
```
{
    "NonconfId":1,
    "CorractionId":1
}
```
### 5. Conclusão
O projeto **Módulo de Não-conformidades** foi desenvolvido no período entre 11/09/2020 e 18/09/2020, em linguagem **C#** com **ASP.NET CORE 3.1** na IDE **Visual Studio 2019**.

