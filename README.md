# AWS Comprehend

## 📌 Contexto

Com o avanço dos serviços de inteligência artificial, surgiu a oportunidade de analisar rápido e facilmente o sentimento presente em determinadas frases.

Essa análise de sentimento permite gerar insights sobre o seu negócio, como por exemplo:
- Review de produto
- Análise de feedback

### 🔗 Conceitos

🔁 O que é o Amazon Comprehend?

O Amazon Comprehend é um serviço que processa NLP e extrai algumas informações a respeito do contexto que lhe foi passado:

- Análise de sentimentos
- Extração de palavras chaves
- Identificação de palavras chaves
- Detecção de idiomas
- Detecção de dados pessoais

## 🛠 Desenvolvimento

<img width="856" height="677" alt="image" src="https://github.com/user-attachments/assets/efde24b5-e64f-42b9-94cf-244ae4e8b590" />


O exemplo deste repositório implementa o seguinte fluxo:

### 1. **Uma aplicação frontend implementada em Nextjs**.

Essa aplicação é responsável por ser a interface do usuário.

Nela, contém duas abas (somente para estudos)
- Feedback: permite que o usuário adicione um feedback a um produto e envia este comentário para a API
- Admin: análise visual dos insights gerados até o momento, como: total de feedbacks positivos, negativos, produtos mais positivos e negativos.
- 
<img width="1913" height="942" alt="image" src="https://github.com/user-attachments/assets/dbb12277-a5ee-4823-9c36-6a4d5d2b2fd6" />

<img width="1919" height="944" alt="image" src="https://github.com/user-attachments/assets/22b67916-2ede-46c9-942b-1dd6a0a34c31" />


### 2. **API implementada em .NET**.

Essa aplicação tem como responsabilidade:
- Receber os feedbacks e salvá-los em uma base de dados.
- No momento em que um novo feedback é recebido, enviar um evento para o Service Bus.
- Ouvir os eventos enviados e processar a análise de sentimentos.
- Após a análise finalizar, enviar um evento via websocket para sinalizar o frontend.

---

## 💻 Tecnologias Utilizadas

- **.NET**
- **Nextjs**
- **Amazon Comprehend**
- **Websocket**
- **Service bus**

---

## ✅ Conclusão

O Amazon Comprehend é uma boa ferramenta que pode auxiliar na extração de informações chaves sobre uma texto passado.

Essa informações podem ser facilmente convertidas para que o time de negócio promova uma análise e, consequetemente, tome uma decisão mais assertiva.

Além disso, pode extrair dados de maneira simplificada, visando automatizar algum processamento manual.

